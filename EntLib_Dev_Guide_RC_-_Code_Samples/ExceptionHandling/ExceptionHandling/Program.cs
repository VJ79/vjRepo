//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Exception Handling Application Block Examples
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;

// references to configuration namespaces (required in all examples)
using DevGuideExample.MenuSystem;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

// references to application block namespace(s) for these examples
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using ExceptionHandlingExample.SalaryService;
using System.ServiceModel;
using System.ComponentModel;

namespace ExceptionHandlingExample
{
    class Program
    {
        static ExceptionManager exManager;

        static void Main(string[] args)
        {
            #region Resolve the required object

            // Resolve the default ExceptionManager object from the container.
            exManager = EnterpriseLibraryContainer.Current.GetInstance<ExceptionManager>();

            #endregion

            #region Main menu routines

            var app = new MenuDrivenApplication("Exception Handling Block Developer's Guide Examples",
                DefaultNoExceptionShielding,
                WithWrapExceptionShielding,
                WithReplaceExceptionShielding,
                LoggingTheException,
                ShieldingExceptionsInWCF,
                ExecutingCodeAroundException,
                ProvidingAdminAssistance);

            app.Run();

            #endregion
        }

        // You can run the examples in one of two ways inside Visual Studio:
        // -----------------------------------------------------------------
        // 1: By starting them with F5 (debugging mode) and then pressing F5 again
        //    when the debugger halts at the exception in the SalaryCalculator class,
        //    or:
        // 2: By starting them Ctrl-F5 (non-debugging mode).
        [Description("Typical Default Behavior without Exception Shielding")]
        static void DefaultNoExceptionShielding()
        {
            Console.WriteLine("Getting salary for 'jsmith'...");
            Console.WriteLine();
            SalaryCalculator calc = new SalaryCalculator();
            Console.WriteLine("Result is: {0}", calc.GetWeeklySalary("jsmith", 0));
        }

        [Description("Behavior After Applying Exception Shielding with a Wrap Handler")]
        static void WithWrapExceptionShielding()
        {
            Console.WriteLine("Getting salary for 'jsmith'...");
            Console.WriteLine();
            // NOTE: Any exception raised when creating the SalaryCalculator
            // class instance will not be handled using this approach.
            SalaryCalculator calc = new SalaryCalculator();
            var result = exManager.Process(() => calc.GetWeeklySalary("jsmith", 0), "ExceptionShielding");
            Console.WriteLine("Result is: {0}", result);
            // NOTE: If you do not need to return the value from the function, you can
            // simply consume it within the lambda expression. This is a simple example:
            // ------------------------------
            //exManager.Process(() =>
            //  {
            //    SalaryCalculator calc = new SalaryCalculator();
            //    Console.WriteLine("Result is: {0}", calc.GetWeeklySalary("jsmith", 0));
            //  },
            //  "ExceptionShielding");
            // ------------------------------
            // This approach also allows you to handle any exception raised by creating the 
            // instance of the SalaryCalculator class.
        }

        [Description("Behavior After Applying Exception Shielding with a Replace Handler")]
        static void WithReplaceExceptionShielding()
        {
            Console.WriteLine("Getting salary for 'jsmith'...");
            Console.WriteLine();
            // NOTE: Any exception raised when creating the SalaryCalculator
            // class instance will not be handled using this approach.
            SalaryCalculator calc = new SalaryCalculator();
            decimal result = exManager.Process(() => calc.GetWeeklySalary("jsmith", 0), "ReplacingException");
            Console.WriteLine("Result is: {0}", result);
        }

        [Description("Logging an Exception to Preserve the Information it Contains")]
        static void LoggingTheException()
        {
            try
            {
                Console.WriteLine("Getting salary for 'jsmith'...");
                Console.WriteLine();
                // NOTE: Any exception raised when creating the SalaryCalculator
                // class instance will not be handled using this approach.
                var calc = new SalaryCalculator();
                decimal result = exManager.Process(() => calc.GetWeeklySalary("jsmith", 0), "LoggingAndReplacingException");
                Console.WriteLine("Result is: {0}", result);
            }
            catch (Exception ex)
            {
                MenuOption.ShowExceptionDetails(ex);
                Console.WriteLine("Open the Windows Application Event Log to see the logged exception details.");
            }
        }

        [Description("Applying Exception Shielding at WCF Application Boundaries")]
        static void ShieldingExceptionsInWCF()
        {
            // You can run this example in one of three ways:
            // - Inside VS by starting it with F5 (debugging mode) and then pressing F5 again
            //   when the debugger halts at the exception in the SalaryCalculator class.
            // - Inside VS by right-clicking SalaryService.svc in Solution Explorer and selecting
            //   View in Browser to start the service, then pressing Ctrl-F5 (non-debugging mode) 
            //   to run the application.
            // - By starting the SalaryService in VS (as in previous option) and then running the
            //   executable file ExceptionHandlingExample.exe in the bin\debug folder directly. 

            try
            {
                Console.WriteLine("Getting salary for 'jsmith' from WCF Salary Service...");
                // Create an instance of the client for the WCF Salary Service.
                ISalaryService svc = new SalaryServiceClient();
                // Call the method of the service to get the result.
                Console.WriteLine("Result is: {0}", svc.GetWeeklySalary("jsmith", 0));
            }
            catch (Exception ex)
            {
                // Show details of the exception returned to the calling code.  
                MenuOption. ShowExceptionDetails(ex);
                // Show details of the fault contract returned from the WCF service.  
                ShowFaultContract(ex);
            }
        }

        [Description("Executing Custom Code Before and After Handling an Exception")]
        static void ExecutingCodeAroundException()
        {
            //------------------------------------------------------
            // Note that this is a somewhat contrived exeample designed to
            // show how you can use the HandleException method, detect different
            // exception types, and ignore specific types of exceptions.
            try
            {
                // Execute code that raises a DivideByZeroException.
                Console.WriteLine("Getting salary for 'jsmith' ... this will raise a DivideByZero exception.");
                SalaryCalculator calc = new SalaryCalculator();
                Console.WriteLine("Result is: {0}", calc.RaiseDivideByZeroException("jsmith", 0));
            }
            catch (Exception ex)
            {
                Exception newException;
                bool rethrow = exManager.HandleException(ex, "NotifyingRethrow", out newException);
                if (rethrow)
                {
                    // Exception policy setting is "ThrowNewException".
                    // Code here to perform any clean up tasks required.
                    // Then throw the exception returned by the exception handling policy.
                    throw newException;
                }
                else
                {
                    // Exception policy setting is "None" so exception is not thrown.
                    // Code here to perform any other processing required.
                    // In this example, just ignore the exception and do nothing.
                    Console.WriteLine("Detected and ignored Divide By Zero Error - no value returned.");
                }
            }
            try
            {
                // Now execute code that raises an ArgumentOutOfRangeException.
                // Use the same exception handling policy and catch section code.
                Console.WriteLine();
                Console.WriteLine("Getting salary for 'jsmith' ... this will raise an ArgumentOutOfRange exception.");
                SalaryCalculator calc = new SalaryCalculator();
                Console.WriteLine("Result is: {0}", calc.RaiseArgumentOutOfRangeException("jsmith", 0));
            }
            catch (Exception ex)
            {
                Exception newException;
                bool rethrow = exManager.HandleException(ex, "NotifyingRethrow", out newException);
                if (rethrow)
                {
                    // Exception policy setting is "ThrowNewException".
                    // Code here to perform any clean up tasks required.
                    // Then throw the exception returned by the exception handling policy.
                    throw newException;
                }
                else
                {
                    // Exception policy setting is "None".
                    // Code here to perform any other processing required.
                    // In this example, just ignore the exception and do nothing.
                    Console.WriteLine("Detected and ignored Divide By Zero Error - no value returned.");
                }
            }
        }

        [Description("Providing Assistance to Administrators for Locating Exception Details")]
        static void ProvidingAdminAssistance()
        {
            Console.WriteLine("Getting salary for 'jsmith'...");
            Console.WriteLine();
            // NOTE: Any exception raised when creating the SalaryCalculator
            // class instance will not be handled using this approach.
            SalaryCalculator calc = new SalaryCalculator();
            decimal result = exManager.Process(() => calc.GetWeeklySalary("jsmith", 0), "AssistingAdministrators");
            Console.WriteLine("Result is: {0}", result);
        }

        #region Auxiliary routines

        private static void ShowFaultContract(Exception ex)
        {
            var faultContract = ex as FaultException<SalaryCalculationFault>;
            if (faultContract != null)
            {
                SalaryCalculationFault salaryCalculationFault = faultContract.Detail;
                Console.WriteLine("Fault contract detail: ");
                Console.WriteLine("Fault ID: {0}", salaryCalculationFault.FaultID);
                Console.WriteLine("Message: {0}", salaryCalculationFault.FaultMessage);
            }
        }

        #endregion
    }
}