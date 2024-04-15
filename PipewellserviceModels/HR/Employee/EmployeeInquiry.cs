using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
    public class EmployeeInquiry
    {

        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Division { get; set; }
        public string Position { get; set; }
        public string Nationality { get; set; }
        public int TotalRecords { get; set; }
        public List<EmployeeApproval> Approvals { get; set; }
        public DateTime? InquiryDate { get; set; }
        public string Remarks { get; set; }
        public string Preparedby { get; set; }
        public string UserName { get; set; }
        public bool PersonalInquiry { get; set; }
        public bool GeneralInquiry { get; set; }
        public bool LoanInquiry { get; set; }

    }
    public class EmployeeInquiryDB
    {
        public DataTable Inquiry { get; set; }
        public DataTable Approvals { get; set; }
        public EmployeeInquiryDB()
        {
            Inquiry = new DataTable();
            Approvals = new DataTable();
        }
    }
    public class EmployeeInquiryListView
    {
        public List<EmployeeInquiry> Inquiry { get; set; }

        public int TotalRecords { get; set; }
        public List<EmployeeApproval> Approvals { get; set; }
    }
    public class EmployeeInquiryParam
    {
        public int EmployeeID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int PersonalInquiry { get; set; }
        public int GeneralInquiry { get; set; }
        public int LoanInquiry { get; set; }
        public int PageNumber { get; set; }
        public int pageSize { get; set; }

    }
}

