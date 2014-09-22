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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.WCF;

namespace ExampleService
{
  [ServiceContract]
  public interface ISalaryService
  {
    [OperationContract]
    [FaultContract(typeof(SalaryCalculationFault))]
    decimal GetWeeklySalary(string employeeId, int weeks);
  }

  [DataContract]
  public class SalaryCalculationFault
  {
    [DataMember]
    public Guid FaultID { get; set; }

    [DataMember]
    public string FaultMessage { get; set; }
  }

  [ExceptionShielding("SalaryServicePolicy")]
  public class SalaryService : ISalaryService
  {
    public decimal GetWeeklySalary(string employeeId, int weeks)
    {
      SalaryCalculator calc = new SalaryCalculator();
      return calc.GetWeeklySalary(employeeId, weeks);
    }
  }
}
