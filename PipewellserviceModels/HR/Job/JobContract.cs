using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Job
{
    using System;

    public class JobContract
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public int CountryID { get; set; }
        public string JobTitle { get; set; }
        public string Nationality { get; set; }
        public string IDNumber { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public int Period { get; set; }
        public int Basic { get; set; }
        public int Transportation { get; set; }
        public string UserName { get; set; }
    }

}
