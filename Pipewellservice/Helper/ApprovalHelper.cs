using Newtonsoft.Json;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
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
        public async Task<bool> ProcessRequest(ApprovalTypes type, ApprovalRequestResult result)
        {
            if (type == ApprovalTypes.Leaves)
            {
                List<MergeField> field = new List<MergeField>();
                EmployeeLeave record = JsonConvert.DeserializeObject<EmployeeLeave>(result.Request[0].ToString());
                field.Add(new MergeField("LEAVE_TYPE", record.LeaveTypeName));
                field.Add(new MergeField("START_DATE", record.StartDate.ToString("MM/dd/yyyy")));
                field.Add(new MergeField("END_DATE", record.EndDate.ToString("MM/dd/yyyy")));
                field.Add(new MergeField("DAYS", (record.EndDate - record.StartDate).Days.ToString()));
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

                    else if (requestApprover.RowID == 2)
                    {
                        if (RequestStatus == ApprovalStatus.Approved)
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
                if(Supervisor.ID>0) field.Add(new MergeField("APROVE_NAME", Supervisor.Name));

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

                    if ((RequestStatus == ApprovalStatus.Pending || RequestStatus == ApprovalStatus.Ready || RequestStatus == ApprovalStatus.New) && template.Type == 2)
                        SupervisorEmailTemplate = template;
                }

                EmailHelper email = new EmailHelper();
                bool status = false ;

                if (RequestStatus == ApprovalStatus.Approved || RequestStatus == ApprovalStatus.Declined || RequestStatus == ApprovalStatus.NotApproved)
                    status = await email.SendEmail(new EmailDTO() { To = employee.EmailAddress, From = "no-reply@pipewellservices.com", Subject = EmployeeEmailTemplate.Subject, Body = EmployeeEmailTemplate.Body }, field);

                if (RequestStatus == ApprovalStatus.Pending && Supervisor.ID > 0 && Supervisor.EmailAddress != "")
                {
                    Supervisor.EmailAddress = "irfanullahurfi@gmail.com";
                    field.Add(new MergeField("APPROVE_NAME", Supervisor.Name));
                    field.Add(new MergeField("PORTAL_LINK", ""));
                    status = await email.SendEmail(new EmailDTO() { To = Supervisor.EmailAddress, From = "no-reply@pipewellservices.com", Subject = SupervisorEmailTemplate.Subject, Body = SupervisorEmailTemplate.Body }, field);
                }
                return status;

            }
            return true;
        }
    }
}