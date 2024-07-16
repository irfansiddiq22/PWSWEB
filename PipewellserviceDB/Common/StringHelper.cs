using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB.Common
{
   public  class StringHelper
    {
        public static string NullToString(object value)
        {
            if (value == null)
            {
                return "";
            }
            else
            {
                return value.ToString();
            }
        }
        public static string ReplaceXmlChar(object input)
        {
            string input2 = NullToString(input);
            input = input2.Replace("&", "&amp");
            input2 = input2.Replace("<", "&lt;");
            input2 = input2.Replace(">", "&gt;");
            input2 = input2.Replace("\"", "&quot;");
            input2 = input2.Replace("'", "&apos;");
            return input2;
        }
    }

}
