using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Configuration;

namespace Pipewellservice.Helper
{
    public class Config
    {
        public static readonly string ResourcesDirectory = ConfigurationManager.AppSettings["Resources"];
        public static readonly string SMTPPassword = ConfigurationManager.AppSettings["SMTPPassword"];
    }
}