using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    [AttributeUsage(AttributeTargets.All,AllowMultiple=true,Inherited=false)]
    public class HelpAttribute:Attribute
    {
        public HelpAttribute(string s)
        {
            description = s;
        }

        protected String description;

        public String Description
        {

            get
            {

                return this.description;

            }
            set
            {
                this.description = value;
            }

        }

        protected String version;

        public String Version
        {

            get
            {

                return this.version;

            }

            //if we ever want our attribute user to set this property, 

            //we must specify set method for it 

            set
            {

                this.version = value;

            }

        }
    }

    

    
}
