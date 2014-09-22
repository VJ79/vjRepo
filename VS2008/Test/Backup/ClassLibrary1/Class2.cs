/**************************************************************
 * this file is part of ClassLibrary1 Project
 * Copyright (C)1997-2009 CnSync Tech Corp.
 * 
 * Author      : wangj
 * Mail        : blueler@gmail.com
 * Create Date : 3/11/2009 3:04:42 PM 
 * Summary     : 
 * 
 * 
 * Modified By : 
 * Date        : 
 * Mail        : 
 * Comment     :   
 * *************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1
{
    public class Class2
    {
        public string tt()
        {
           // try
            {
                Class1 c1 = new Class1();
                c1.tt();
            }
            //catch (Exception ex)
            //{
            //    throw new Exception(this.ToString(), ex);
            //}
            return "";
        }
    }
}
