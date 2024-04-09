using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Job
{
    public class JobOffer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public int CountryID { get; set; }
        public string Nationality { get; set; }
        public string JobTitle { get; set; }
        public int Basic { get; set; }
        public int Transportation { get; set; }
        public int Housing { get; set; }

        public string FileID { get; set; }
        public string Period { get; set; }
        public string UserName { get; set; }
    }
}
