using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB
{
    public class DataServices
    {
        protected string ConnectionString { get; set; }
        public DataServices()
        {
            this.ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }
    }
}

