using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.HR.Employee
{
    public class EmployeeInquiryReport: EmployeeInquiry
    {
        public string ApprovedBy1Name { get; set; }
        public DateTime? ApprovalDate1 { get; set; }
        public string ApprovalRemarks1 { get; set; }
        public string ApprovalPosition1 { get; set; }
        public Byte[] ApprovalSign1 { get; set; }
        public Image Signature1 {
            get
            {
                byte[] imageBytes = ApprovalSign1;
                if (imageBytes != null)
                {
                    
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        return System.Drawing.Image.FromStream (ms);
                        
                        //Bitmap m = new Bitmap(ms);
                        //m.Save(@"K:\IrfanUllah\Pipewellservice\Pipewellservice\Content\images\test.jpg");
                     //   return m;// new Bitmap(ms);
                    }
                }
                else
                {
                    return null;
                }

            }
        }

        public string ApprovedBy2Name { get; set; }
        public DateTime? ApprovalDate2 { get; set; }
        public string ApprovalRemarks2 { get; set; }
        public string ApprovalPosition2 { get; set; }
        public Byte[] ApprovalSign2 { get; set; }
        public Bitmap Signature2
        {
            get
            {
                byte[] imageBytes = ApprovalSign2;
                if (imageBytes != null)
                {
                    
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        return new Bitmap(ms);
                    }
                }
                else
                {
                    return null;
                }

            }
        }


        public string ApprovedBy3Name { get; set; }
        public DateTime? ApprovalDate3 { get; set; }
        public string ApprovalRemarks3 { get; set; }
        public string ApprovalPosition3 { get; set; }
        public Byte[] ApprovalSign3 { get; set; }
        public Bitmap Signature3
        {
            get
            {
                byte[] imageBytes = ApprovalSign3;
                if (imageBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        return new Bitmap(ms);
                    }
                }
                else
                {
                    return null;
                }

            }
        }


        public string ApprovedBy4Name { get; set; }
        public DateTime? ApprovalDate4 { get; set; }
        public string ApprovalRemarks4 { get; set; }
        public string ApprovalPosition4 { get; set; }
        public string EmployeePicture { get; set; }
        public Byte[] ApprovalSign4 { get; set; }

        public Bitmap Signature4
        {
            get
            {
                byte[] imageBytes = ApprovalSign4;

                if (imageBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        return new Bitmap(ms);
                    }
                }
                else
                {
                    return null;
                }

            }
        }

    }
    public class EmployeeInquiry
    {

        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Division { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; }
        public int TotalRecords { get; set; }
        public List<EmployeeApproval> Approvals { get; set; }
        public DateTime? InquiryDate { get; set; }
        public string Remarks { get; set; }
        public string Preparedby { get; set; }
        public string UserName { get; set; }
        public int RecordCreatedBy { get; set; }
        public bool PersonalInquiry { get; set; }
        public bool GeneralInquiry { get; set; }
        public bool LoanInquiry { get; set; }

        public bool Resignation { get; set; }
        public bool SalaryCertificate { get; set; }
        public bool MissPunch { get; set; }
        public DateTime LastWorkingDate { get; set; }
        public string FileID { get; set; }
        public string FileName { get; set; }
        public ApprovalStatus Status { get; set; }

        public int PriorityLevelID { get; set; }
        public string PriorityLevelName { get; set; }
        public string ColorCode { get; set; }
        public string InquiryStatus
        {
            get
            {
                if (Status==ApprovalStatus.Approved) return "Approved";
                else if (Status == ApprovalStatus.Declined || Status==ApprovalStatus.NotApproved) return "Not Approved";
                else if (Status == ApprovalStatus.NoAction) return "";
                else return "InProcess";

            }
        }
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
        public bool PersonalInquiry { get; set; }
        public bool GeneralInquiry { get; set; }
        public bool LoanInquiry { get; set; }
        public int PageNumber { get; set; }
        public int pageSize { get; set; }

    }
}

