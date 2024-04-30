using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Common
{
    public class RecordLog
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateTime RecordDate { get; set; }

        public int RecordCreatedBy { get; set; }
        public DateTime RecordDateCreated { get; set; }
        public bool RecordDeleted { get; set; }
        public DateTime RecordDateUpdated { get; set; }
        public string RecordDeletedBy { get; set; }
        public string FileName { get; set; }
        public string FileID { get; set; }


        public string Division { get; set; }
        public int DivisionID { get; set; }

        public int PositionID { get; set; }
        public string Position { get; set; }


        public int NationalityID { get; set; }
        public string Nationality { get; set; }
    }
}
