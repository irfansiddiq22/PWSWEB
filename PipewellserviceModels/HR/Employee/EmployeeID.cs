﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
    public class EmployeeIDFileType
    {
        public string FileType { get; set; }
    }
   public class EmployeeIDFile
    {
        public int ID { get; set; }
        
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string IDNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
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
    public class ExpiringID
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string ArabicName { get; set; }
        public string Nationality { get; set; }
        public string IDNumber { get; set; }
        public string Division { get; set; }
        public string Position { get; set; }
        public string IDType { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
    public class ExpistingIDParam
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string  FileType { get; set; }
    }
}
