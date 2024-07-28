using Newtonsoft.Json;
using PipewellserviceJson.HR.Employee;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using PipewellserviceModels.Procurement;
using PipewellserviceModels.Procurement.Purchase;
using PipewellserviceModels.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Pipewellservice.Helper
{
    public class ApprovalHelper
    {

        EmployeeJson json = new EmployeeJson();
        public async Task<bool> ProcessRequest(ApprovalTypes type, ApprovalRequestResult result, bool NewRequest = false)
        {
            List<MergeField> field = new List<MergeField>();

            bool ProcessMail = false;

            string Attachment = "";

            int RecordID = 0;
            if (type == ApprovalTypes.Leaves)
            {
                ProcessMail = true;
                EmployeeLeave record = JsonConvert.DeserializeObject<EmployeeLeave>(result.Request[0].ToString());
                field.Add(new MergeField("LEAVE_TYPE", record.LeaveTypeName));
                field.Add(new MergeField("START_DATE", record.StartDate.ToString("dd/MM/yyyy")));
                field.Add(new MergeField("END_DATE", record.EndDate.ToString("dd/MM/yyyy")));
                field.Add(new MergeField("DAYS", (record.EndDate - record.StartDate).Days.ToString()));

                if (record.LeaveType == 1)
                {
                    LeaveStats LeaveStat = await json.EmployeeLeaveStats(record.EmployeeID);

                    if (LeaveStat == null || LeaveStat.Allowance == 0)
                    {
                        LeaveStat = new LeaveStats() { Allowance = 30, CarriedOver=0, LeavesTaken=0,Balance=30 };
                    }

                    string table = $"<table style='width:900px;border-style:solid;'><tr><td><b> Allowance</b></td><td><b> Carried Over</b></td><td><b> Available</b></td><td><b> Used</b></td><td><b> Balance</b></td><td><b> Unit</b></td></tr><tr><td><b> {LeaveStat.Allowance}</b></td><td><b> {LeaveStat.CarriedOver}</b></td><td><b> {LeaveStat.Available}</b></td><td><b> {LeaveStat.LeavesTaken}</b></td><td><b> {LeaveStat.Balance}</b></td><td><b> Days</b></td></tr></table>";
                    field.Add(new MergeField("LEAVESTATS", table));
                }

                field.Add(new MergeField("PRIORITYLEVEL", record.PriorityLevelName));
                field.Add(new MergeField("PRIORITYLEVELCOLOR", record.ColorCode));
                RecordID = record.ID;
            }
            else if (type == ApprovalTypes.Inquiry)
            {
                ProcessMail = true;
                EmployeeInquiry record = JsonConvert.DeserializeObject<EmployeeInquiry>(result.Request[0].ToString());
                field.Add(new MergeField("DATE", record.InquiryDate == null ? DateTime.Now.ToString("dd/MM/yyyy") : Convert.ToDateTime(record.InquiryDate).ToString("dd/MM/yyyy")));
                field.Add(new MergeField("REMARKS", record.Remarks));
                field.Add(new MergeField("PRIORITYLEVEL", record.PriorityLevelName));
                field.Add(new MergeField("PRIORITYLEVELCOLOR", record.ColorCode));
                Attachment = "";
                if (record.FileID != null)
                {
                    Attachment = await FileHelper.GetFile(record.FileID, record.EmployeeID, DirectoryNames.EmployeeInquiry);
                }
                RecordID = record.ID;

                ProcessMail = true;

            }
            else if (type == ApprovalTypes.ShortLeave)
            {
                ProcessMail = true;
                EmployeeShortLeave record = JsonConvert.DeserializeObject<EmployeeShortLeave>(result.Request[0].ToString());
                field.Add(new MergeField("DATE", record.RecordDate == null ? DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") : Convert.ToDateTime(record.RecordDate).ToString("dd/MM/yyyy hh:mm tt")));
                field.Add(new MergeField("REMARKS", record.Remarks));
                Attachment = "";
                if (record.FileID != null)
                {
                    Attachment = await FileHelper.GetFile(record.FileID, record.EmployeeID, DirectoryNames.EmployeeShortLeave);
                }
                RecordID = record.ID;


                ProcessMail = true;

            }
            else if (type == ApprovalTypes.MaterialRequest)
            {
                ProcessMail = true;
                List<MaterialRequestMailDetail> record = new List<MaterialRequestMailDetail>();
                try
                {
                    foreach (object  js in result.Request)
                    {
                        record.Add(JsonConvert.DeserializeObject<MaterialRequestMailDetail>(js.ToString()));
                    }
                }catch(Exception e)
                {
                    string g = e.Message;
                }
                field.Add(new MergeField("REQUEST_DATE", record[0].RequestDate == null ? DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") :DateTime.Now.ToString("dd/MM/yyyy hh:mm tt")));
                field.Add(new MergeField("REMARKS", record[0].Remarks));
                field.Add(new MergeField("REQUEST_TYPE", record[0].RequestType));
                Attachment = "";
                
                RecordID = record[0].ID;

                string items = "";//$"<table style='width:900px;border-style:solid;'><tr><td><b> Allowance</b></td><td><b> Carried Over</b></td><td><b> Available</b></td><td><b> Used</b></td><td><b> Balance</b></td><td><b> Unit</b></td></tr><tr><td><b> {LeaveStat.Allowance}</b></td><td><b> {LeaveStat.CarriedOver}</b></td><td><b> {LeaveStat.Available}</b></td><td><b> {LeaveStat.LeavesTaken}</b></td><td><b> {LeaveStat.Balance}</b></td><td><b> Days</b></td></tr></table>";
                foreach(MaterialRequestMailDetail detail in record)
                {
                    /*<tr>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Name</td>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Unit</td>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Quantity</td>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Notes</td>
                            </tr>*/
                    string StockAlert = "";

                    if (detail.Quantity > detail.StockQuantity)
                    {
                        StockAlert = $"<div style='background-color:#dc3545;color:#fff;font-size:11px'>Currently {detail.StockQuantity} items are in store for remaining {(detail.Quantity -  detail.StockQuantity) } Internal purchase request will be generated Upon Approval";
                    }
                    items += $"<tr><td>{detail.ItemName}</td><td>{detail.Unit}</td><td>{detail.Quantity}{StockAlert }</td><td>{detail.Notes}</td></tr>";

                }
                field.Add(new MergeField("ITEMS", items));

                ProcessMail = true;

            }
            else if (type == ApprovalTypes.InternalPurchaseRequest)
            {
                ProcessMail = true;
                List<InternalPurchaseMailDetail> record = new List<InternalPurchaseMailDetail>();
                try
                {
                    foreach (object js in result.Request)
                    {
                        record.Add(JsonConvert.DeserializeObject<InternalPurchaseMailDetail>(js.ToString()));
                    }
                }
                catch (Exception e)
                {
                    string g = e.Message;
                }
                field.Add(new MergeField("REQUEST_DATE", record[0].RequestDate == null ? DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") : DateTime.Now.ToString("dd/MM/yyyy hh:mm tt")));
                field.Add(new MergeField("REMARKS", record[0].Remarks));
                field.Add(new MergeField("REQUEST_TYPE", record[0].RequestType));

                field.Add(new MergeField("SUPPLIER_NAME", record[0].SupplierName));
                field.Add(new MergeField("QUOTATION", record[0].QuotationNumber));
                field.Add(new MergeField("REQUEST_NUMBER", record[0].MaintRequestNumber));
                field.Add(new MergeField("DELIVERY_TYPE", record[0].DeliveryTypeName));
                field.Add(new MergeField("PAYMENT_TYPE", record[0].PaymentTypeName));

                Attachment = "";

                RecordID = record[0].ID;

                string items = "";//$"<table style='width:900px;border-style:solid;'><tr><td><b> Allowance</b></td><td><b> Carried Over</b></td><td><b> Available</b></td><td><b> Used</b></td><td><b> Balance</b></td><td><b> Unit</b></td></tr><tr><td><b> {LeaveStat.Allowance}</b></td><td><b> {LeaveStat.CarriedOver}</b></td><td><b> {LeaveStat.Available}</b></td><td><b> {LeaveStat.LeavesTaken}</b></td><td><b> {LeaveStat.Balance}</b></td><td><b> Days</b></td></tr></table>";
                foreach (InternalPurchaseMailDetail detail in record)
                {
                    /*<tr>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Name</td>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Unit</td>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Quantity</td>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Notes</td>
                            </tr>*/
                    items += $"<tr><td>{detail.ItemName}</td><td>{detail.Unit}</td><td>{detail.Quantity}</td><td>{detail.PartNumber}</td><td>{detail.Notes}</td></tr>";

                }
                field.Add(new MergeField("ITEMS", items));

                ProcessMail = true;

            }
            else if (type == ApprovalTypes.PurchaseOrderManagement)
            {
                ProcessMail = true;
                List<PurchaseOrderManagementMailDetail> record = new List<PurchaseOrderManagementMailDetail>();
                try
                {
                    foreach (object js in result.Request)
                    {
                        record.Add(JsonConvert.DeserializeObject<PurchaseOrderManagementMailDetail>(js.ToString()));
                    }
                }
                catch (Exception e)
                {
                    string g = e.Message;
                }
                field.Add(new MergeField("REQUEST_DATE", record[0].RequestDate == null ? DateTime.Now.ToString("dd/MM/yyyy hh:mm tt") : DateTime.Now.ToString("dd/MM/yyyy hh:mm tt")));
                field.Add(new MergeField("REMARKS", record[0].Remarks));
                field.Add(new MergeField("IPO", record[0].InternalPurchaseOrderNumber.ToString()));

                field.Add(new MergeField("SUPPLIER_NAME", record[0].SupplierName));
                field.Add(new MergeField("WARRANTY", record[0].WarrantyPeriod));
                field.Add(new MergeField("Currency", record[0].Currency));
                field.Add(new MergeField("Freight", record[0].Freight.ToString()));
                field.Add(new MergeField("Discount", record[0].Discount.ToString()));
                field.Add(new MergeField("VAT", record[0].VAT.ToString()));
                field.Add(new MergeField("TOTAL", record[0].Total.ToString()));


                field.Add(new MergeField("DELIVERY_TYPE", record[0].DeliveryTypeName));
                field.Add(new MergeField("PAYMENT_TYPE", record[0].PaymentTypeName));

                Attachment = "";

                RecordID = record[0].ID;

                string items = "";//$"<table style='width:900px;border-style:solid;'><tr><td><b> Allowance</b></td><td><b> Carried Over</b></td><td><b> Available</b></td><td><b> Used</b></td><td><b> Balance</b></td><td><b> Unit</b></td></tr><tr><td><b> {LeaveStat.Allowance}</b></td><td><b> {LeaveStat.CarriedOver}</b></td><td><b> {LeaveStat.Available}</b></td><td><b> {LeaveStat.LeavesTaken}</b></td><td><b> {LeaveStat.Balance}</b></td><td><b> Days</b></td></tr></table>";
                foreach (PurchaseOrderManagementMailDetail detail in record)
                {
                    /*<tr>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Name</td>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Unit</td>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Quantity</td>
                                <td style="font-weight: bold; font-size: 12px; background-color: #f2f2f2">Notes</td>
                            </tr>*/
                    items += $"<tr><td>{detail.ItemName}</td><td>{detail.Unit}</td><td>{detail.Quantity}</td><td>{detail.UnitCost}</td><td>{detail.Amount}</td><td>{detail.PartNumber}</td><td>{detail.Notes}</td></tr>";

                }
                field.Add(new MergeField("ITEMS", items));

                ProcessMail = true;

            }
            if (ProcessMail)
            {
                string Row = "";

                string Status = "";
                ApprovalStatus RequestStatus = ApprovalStatus.Ready;
                RequestApprover Supervisor = new RequestApprover();
                RequestApprover employee = new RequestApprover();
                foreach (RequestApprover requestApprover in result.Employees)
                {
                    if (requestApprover.RowID == 0)
                    {
                        Status = "Requested";
                        employee = requestApprover;
                        field.Add(new MergeField("EMP_NAME", employee.Name));
                        field.Add(new MergeField("EMP_ID", employee.ID.ToString()));
                    }
                    else if (requestApprover.RowID == 1)
                    {
                        RequestStatus = requestApprover.Status;
                        if (requestApprover.Status == ApprovalStatus.Approved)
                        {
                            Status = "Approved";
                        }
                        else if (requestApprover.Status == ApprovalStatus.Declined)
                        {
                            Status = "Declined";
                            field.Add(new MergeField("REASON", requestApprover.Remarks));
                        }
                        else if (requestApprover.Status == ApprovalStatus.NoAction)
                        {
                            Status = "NoAction";
                            field.Add(new MergeField("REASON", requestApprover.Remarks));
                        }
                        else if (requestApprover.Status == ApprovalStatus.NotApproved)
                        {
                            Status = "Rejected";
                            field.Add(new MergeField("REASON", requestApprover.Remarks));
                        }
                        else
                        {
                            Status = "Pending Approval";
                            Supervisor = requestApprover;
                            requestApprover.Status = ApprovalStatus.Pending;

                        }

                    }

                    else
                    {
                        if (RequestStatus == ApprovalStatus.Approved || RequestStatus == ApprovalStatus.NoAction)
                        {

                            if (requestApprover.Status == ApprovalStatus.Approved)
                            {
                                Status = "Approved";

                            }
                            else if (requestApprover.Status == ApprovalStatus.Declined)
                            {
                                Status = "Declined";
                                field.Add(new MergeField("REASON", requestApprover.Remarks));
                            }
                            else if (requestApprover.Status == ApprovalStatus.NotApproved)
                            {
                                Status = "Rejected";
                                field.Add(new MergeField("REASON", requestApprover.Remarks));
                            }
                            else
                            {
                                Supervisor = requestApprover;
                                Status = "Pending Approval";
                                requestApprover.Status = ApprovalStatus.Pending;
                            }
                            RequestStatus = requestApprover.Status;
                        }

                        else
                        {
                            requestApprover.Status = ApprovalStatus.Pending;
                            Status = "Pending Approval";
                        }
                    }

                    Row = Row + $"<tr><td>{ requestApprover.Name }</td><td>{ requestApprover.Position }</td><td>{Status}</td></tr>";
                }
                if (Supervisor.ID > 0) field.Add(new MergeField("APPROVE_NAME", Supervisor.Name));

                field.Add(new MergeField("APPROVALS", Row));


                var EmailTemplate = new EmailTemplate();
                var SupervisorEmailTemplate = new EmailTemplate();
                var EmployeeEmailTemplate = new EmailTemplate();
                foreach (EmailTemplate template in result.EmailTemplate)
                {
                    if ((RequestStatus == ApprovalStatus.Declined || RequestStatus == ApprovalStatus.NotApproved) && template.Type == 4)
                        EmployeeEmailTemplate = template;
                    else if ((RequestStatus == ApprovalStatus.Approved) && template.Type == 3)
                        EmployeeEmailTemplate = template;
                    else if (NewRequest && template.Type == 1)
                        EmployeeEmailTemplate = template;
                    if ((RequestStatus == ApprovalStatus.Pending || RequestStatus == ApprovalStatus.Ready || RequestStatus == ApprovalStatus.New) && template.Type == 2)
                        SupervisorEmailTemplate = template;
                }

                EmailHelper email = new EmailHelper();
                bool status = false;

                if (NewRequest || (RequestStatus == ApprovalStatus.Approved || RequestStatus == ApprovalStatus.Declined || RequestStatus == ApprovalStatus.NotApproved))
                {
                    status = await email.SendEmail(new EmailDTO() { To = employee.EmailAddress, From = "no-reply@pipewellservices.com", Subject = EmployeeEmailTemplate.Subject, Body = EmployeeEmailTemplate.Body }, field);
                    await json.UpdateRequestStatus(RecordID, type, RequestStatus);
                }
                if ((NewRequest ||  RequestStatus == ApprovalStatus.Pending )&& Supervisor.ID > 0 && Supervisor.EmailAddress != "")
                {

                    field.Add(new MergeField("APPROVE_NAME", Supervisor.Name));
                    field.Add(new MergeField("PORTAL_LINK", ""));
                    status = await email.SendEmail(new EmailDTO() { To = Supervisor.EmailAddress, From = "no-reply@pipewellservices.com", Subject = SupervisorEmailTemplate.Subject, Body = SupervisorEmailTemplate.Body, Attachment = Attachment }, field);
                }
                return status;
            }

            return true;
        }
    }
}