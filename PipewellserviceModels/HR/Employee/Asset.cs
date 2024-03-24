using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
   public class EmployeeAsset
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int EmployeeID { get; set; }
        public DateTime? IssueDate { get; set; }
        public string Remarks { get; set; }
        public string FileName { get; set; }
        public string FileID { get; set; }
        public bool RecordDeleted { get; set; }
        public string RecordedDeletedBy { get; set; }
        public DateTime RecordDateAdded { get; set; }
        public string RecordAddedBy { get; set; }
        public DateTime RecordDateUpdated { get; set; }
        public string RecordUpdatedBy { get; set; }
    }
}
