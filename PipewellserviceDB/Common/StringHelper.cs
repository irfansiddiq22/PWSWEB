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
    }

}
