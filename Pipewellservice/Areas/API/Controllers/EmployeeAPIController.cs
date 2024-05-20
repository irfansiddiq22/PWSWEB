using PipewellserviceJson.HR.Employee;
using PipewellserviceModels.Common;
using PipewellserviceModels.Setting;
using PipewellserviceModels.HR.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using Pipewellservice.Helper;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PipewellserviceJson.Common;

namespace Pipewellservice.Areas.API.Controllers
{
    [Authorization]
    public class EmployeeAPIController : BaseController
    {
        EmployeeJson json = new EmployeeJson();

        public async Task<JsonResult> CodeName()
        {
            var result = await json.CodeName(SessionHelper.UserGroup() == (int)UserGroups.Employee ? SessionHelper.EmployeeID() : 0);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> FamilyCodeName()
        {
            var result = await json.FamilyCodeName(SessionHelper.UserGroup() == (int)UserGroups.Employee ? SessionHelper.EmployeeID() : 0);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> SaveLog(DataChangeLog log)
        {
            var result = await json.SaveLog(log);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        ///////////////////////////////////////////

        public async Task<FileResult> DownloadCertificateFile(int EmployeeID, string FileName, string FileID)
        {
            return File(await FileHelper.GetFile(FileID, EmployeeID, DirectoryNames.EmployeeCertifications), System.Net.Mime.MediaTypeNames.Application.Octet, FileName);

        }
        public async Task<JsonResult> CertificateList(int EmployeeID, string Name)
        {
            return new JsonResult
            {
                Data = await json.CertificateList(EmployeeID, Name),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.Certificates, 1, 2)]
        public async Task<JsonResult> UpdateCertificate(EmployeeCertificate certificate)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                certificate.FileName = file.FileName;
                certificate.FileID = Path.GetExtension(file.FileName);
                if (certificate.ID > 0)
                    certificate.FileID = $"{certificate.ID}{certificate.FileID}";

            }
            int ID = await json.UpdateCertificate(certificate);

            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                await FileHelper.SaveFile(Request.Files[0], ID, certificate.EmployeeID, DirectoryNames.EmployeeCertifications);
            }

            return new JsonResult
            {
                Data = ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.Certificates, 2, 1)]
        public async Task<JsonResult> RemoveCertificate(DeleteDTO delete)
        {
            return new JsonResult
            {
                Data = await json.RemoveCertificate(delete),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        ///////////////////////////////////////////
        public async Task<FileResult> DownloadAssetFile(int EmployeeID, string FileName, string FileID)
        {
            return File(await FileHelper.GetFile(FileID, EmployeeID, DirectoryNames.EmployeeAssets), System.Net.Mime.MediaTypeNames.Application.Octet, FileName);

        }
        public async Task<JsonResult> AssetList(int EmployeeID)
        {
            return new JsonResult
            {
                Data = await json.AssetList(EmployeeID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.Assets, 1, 2)]
        public async Task<JsonResult> UpdateAsset(EmployeeAsset asset)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                asset.FileName = file.FileName;
                asset.FileID = Path.GetExtension(file.FileName);
                if (asset.ID > 0)
                    asset.FileID = $"{asset.ID}{asset.FileID}";

            }

            int ID = await json.UpdateAsset(asset);

            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                await FileHelper.SaveFile(Request.Files[0], ID, asset.EmployeeID, DirectoryNames.EmployeeAssets);
            }


            return new JsonResult
            {
                Data = ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.Assets, 2, 1)]
        public async Task<JsonResult> RemoveAsset(DeleteDTO delete)
        {
            return new JsonResult
            {
                Data = await json.RemoveAsset(delete),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        /////////////////        ......

        public async Task<FileResult> DownloadContract(int EmployeeID, string FileName, string FileID)
        {
            return File(await FileHelper.GetFile(FileID, EmployeeID, DirectoryNames.EmployeeContract), System.Net.Mime.MediaTypeNames.Application.Octet, FileName);

        }
        public async Task<JsonResult> ContractList()
        {

            return new JsonResult
            {
                Data = await json.ContractList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> UpdateContract(EmployeeContract contract)
        {

            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                contract.FileName = file.FileName;
                contract.FileID = Path.GetExtension(file.FileName);
                await FileHelper.SaveFile(file, contract.EmployeeID, contract.EmployeeID, DirectoryNames.EmployeeContract);
                return new JsonResult
                {
                    Data = await json.UpdateContract(contract),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return await ContractList();
            }
        }

        ///////////////////////////////////////////
        public async Task<FileResult> DownloadIDFile(int EmployeeID, string FileName, string FileID, string Type)
        {
            return File(await FileHelper.GetFile(FileID, EmployeeID, DirectoryNames.EmployeeIDs, Type), System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
        }

        public async Task<JsonResult> EmployeeIDTypeList()
        {
            return new JsonResult
            {
                Data = await json.EmployeeIDTypeList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> EmployeeIDFileList(int EmployeeID, string Name)
        {
            return new JsonResult
            {
                Data = await json.EmployeeIDFileList(EmployeeID, Name),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.EmployeeID, 1, 2)]
        public async Task<JsonResult> UpdateEmployeeIDFile(EmployeeIDFile Idfile)
        {

            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                Idfile.FileName = file.FileName;
                Idfile.FileID = Path.GetExtension(file.FileName);
                if (Idfile.ID > 0)
                    Idfile.FileID = $"{Idfile.ID}{Idfile.FileID}";

            }
            int ID = await json.UpdateEmployeeIDFile(Idfile);

            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                await FileHelper.SaveFile(Request.Files[0], ID, Idfile.EmployeeID, DirectoryNames.EmployeeIDs, Idfile.Description);
            }

            return new JsonResult
            {
                Data = ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.EmployeeID, 2, 1)]
        public async Task<JsonResult> RemoveEmployeeIDFile(DeleteDTO delete)
        {
            return new JsonResult
            {
                Data = await json.RemoveEmployeeIDFile(delete),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        ///////////////////////////////////////////
        public async Task<FileResult> DownloadFamilyIDFile(int EmployeeID, string FileName, string FileID)
        {
            return File(await FileHelper.GetFile(FileID, EmployeeID, DirectoryNames.EmployeeFamilyIDs), System.Net.Mime.MediaTypeNames.Application.Octet, FileName);

        }

        public async Task<JsonResult> EmployeeFamilyIDFileList(int EmployeeID)
        {
            return new JsonResult
            {
                Data = await json.EmployeeFamilyIDFileList(EmployeeID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.FamilyID, 1, 2)]
        public async Task<JsonResult> UpdateEmployeeFamilyIDFile(EmployeeFamilyIDFile Idfile)
        {


            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                Idfile.FileName = file.FileName;
                Idfile.FileID = Path.GetExtension(file.FileName);
                if (Idfile.ID > 0)
                    Idfile.FileID = $"{Idfile.ID}{Idfile.FileID}";

            }
            int ID = await json.UpdateEmployeeFamilyIDFile(Idfile);

            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                await FileHelper.SaveFile(Request.Files[0], ID, Idfile.EmployeeID, DirectoryNames.EmployeeFamilyIDs);
            }

            return new JsonResult
            {
                Data = ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };


        }
        [Authorization(Pages.FamilyID, 2, 1)]
        public async Task<JsonResult> RemoveEmployeeFamilyIDFile(DeleteDTO delete)
        {
            return new JsonResult
            {
                Data = await json.RemoveEmployeeFamilyIDFile(delete),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        ///////////////////////////////////////////
        public async Task<FileResult> DownloadFamilyFile(int EmployeeID, string FileName, string FileID)
        {
            return File(await FileHelper.GetFile(FileID, EmployeeID, DirectoryNames.EmployeeFamily), System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
        }
        public async Task<JsonResult> EmployeeRelationList()
        {
            return new JsonResult
            {
                Data = await json.EmployeeRelationList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> EmployeeFamilyList(int EmployeeID)
        {
            return new JsonResult
            {
                Data = await json.EmployeeFamilyList(EmployeeID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.Family, 1, 2)]

        public async Task<JsonResult> UpdateEmployeeFamily(EmployeeFamily family)
        {

            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                family.FileName = file.FileName;
                family.FileID = Path.GetExtension(family.FileName);
                if (family.ID > 0)
                    family.FileID = $"{family.ID}{family.FileID}";

            }
            int ID = await json.UpdateEmployeeFamily(family);

            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                await FileHelper.SaveFile(Request.Files[0], ID, family.EmployeeID, DirectoryNames.EmployeeFamily);
            }

            return new JsonResult
            {
                Data = ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };


        }
        [Authorization(Pages.Family, 2, 1)]
        public async Task<JsonResult> RemoveEmployeeFamily(DeleteDTO delete)
        {
            return new JsonResult
            {
                Data = await json.RemoveEmployeeFamily(delete),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        ////////////////////////////////////////////////////

        public async Task<JsonResult> EmployeeList()
        {
            return new JsonResult
            {
                Data = await json.EmployeeList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = int.MaxValue

            };
        }
        public async Task<JsonResult> EmployeeDetail(int EmployeeID)
        {
            return new JsonResult
            {
                Data = await json.EmployeeDetail(EmployeeID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> EmployeeData(int EmployeeID)
        {
            var result = await json.EmployeeData(EmployeeID);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> EmployeeDataList()
        {
            return new JsonResult
            {
                Data = await json.EmployeeDataList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [Authorization(Pages.EmployeeDetail, 1, 2)]
        public async Task<JsonResult> UpdateEmployee(EmployeeData employee)
        {
            return new JsonResult
            {
                Data = await json.UpdateEmployee(employee),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.EmployeeDetail, 1, 2)]
        public async Task<FileResult> EmployeePicture(int EmployeeID, string FileID, string FileName)
        {
            string FilePath = await FileHelper.GetFile(FileID, EmployeeID, DirectoryNames.EmployeePictures); ;
            if (FilePath != "")
                return File(FilePath, System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
            else
                return null;
        }
        [Authorization(Pages.EmployeeDetail, 1, 2)]
        public async Task<JsonResult> UpdateEmployeePicture(int EmployeeID)
        {


            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                bool result = await FileHelper.SaveFile(Request.Files[0], EmployeeID, EmployeeID, DirectoryNames.EmployeePictures);
                string FileID = $"{EmployeeID}{Path.GetExtension(file.FileName)}";

                if (result)
                {
                    var Update = await json.UpdateEmployeePicture(EmployeeID, file.FileName, FileID);

                    return new JsonResult
                    {
                        Data = Update,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
            }


            return new JsonResult
            {
                Data = new ResultDTO() { ID = EmployeeID, Status = false, Message = "No file to upload" },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };


        }


        ////////////////////////////////////////////////////

        public async Task<JsonResult> EmployeeWarningList(EmployeeWarningDTO dTO)
        {
            return new JsonResult
            {
                Data = await json.EmployeeWarningList(dTO),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.EmployeeWarning, 1, 2)]
        public async Task<JsonResult> UpdateEmployeeWarning(EmployeeWarning warning)
        {

            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                warning.FileName = warning.FileName;
                warning.FileID = Path.GetExtension(warning.FileName);
                if (warning.ID > 0)
                    warning.FileID = $"{warning.ID}{warning.FileID}";

            }
            else
            {
                warning.FileName = "";
                warning.FileID = "";
            }
            int ID = await json.UpdateEmployeeWarning(warning);

            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                await FileHelper.SaveFile(Request.Files[0], ID, warning.EmployeeID, DirectoryNames.EmployeeWarnings);
            }

            return new JsonResult
            {
                Data = ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };


        }
        public async Task<FileResult> DownloadWarningFile(int EmployeeID, string FileName, string FileID)
        {
            return File(await FileHelper.GetFile(FileID, EmployeeID, DirectoryNames.EmployeeWarnings), System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
        }


        ////////////////////////////////////////////////////

        public async Task<JsonResult> EmployeeClearanceList(int EmployeeID)
        {
            return new JsonResult
            {
                Data = await json.EmployeeClearanceList(EmployeeID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.EmployeeClearance, 1, 2)]
        public async Task<JsonResult> UpdateEmployeeClearance(EmployeeClearance clearance)
        {

            int ID = await json.UpdateEmployeeClearance(clearance);
            return new JsonResult
            {
                Data = ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }////////////////////////////////////////////////////

        public async Task<JsonResult> EmployeeVacationList(EmployeeVacationParam param)
        {
            return new JsonResult
            {
                Data = await json.EmployeeVacationList(param),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.EmployeeVacation, 1, 2)]
        public async Task<JsonResult> UpdateEmployeeVacation(EmployeeVacation vacation)
        {
            vacation.RecordCreatedBy = SessionHelper.UserID();
            int ID = await json.UpdateEmployeeVacation(vacation);
            return new JsonResult
            {
                Data = ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }
        [Authorization(Pages.EmployeeVacation, 1, 1)]
        public async Task<JsonResult> DeleteEmployeeVacation(int ID)
        {
            int UserID = SessionHelper.UserID();
            bool result = await json.DeleteEmployeeVacation(ID, UserID);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }

        public async Task<FileResult> DownloadClearanceFile(int EmployeeID, string FileName, string FileID)
        {
            return File(await FileHelper.GetFile(FileID, EmployeeID, DirectoryNames.EmployeeAssets), System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
        }

        /// 
        public async Task<JsonResult> EmployeeInquiryList(EmployeeInquiryParam param)
        {
            return new JsonResult
            {
                Data = await json.EmployeeInquiryList(param),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> EmployeeInquiryDetail(int ID)
        {
            return new JsonResult
            {
                Data = await json.EmployeeInquiryDetail(ID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.EmployeeInquiry, 1, 2)]
        public async Task<JsonResult> UpdateEmployeeInquiry(EmployeeInquiry inquiry)
        {
            int ID = await json.UpdateEmployeeInquiry(inquiry);
            return new JsonResult
            {
                Data = ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.EmployeeInquiry, 1, 2)]
        public async Task<JsonResult> AddEmployeeInquiry(EmployeeInquiry inquiry)
        {

            int ID = await json.UpdateEmployeeInquiry(inquiry);
            return new JsonResult
            {
                Data = ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        [Authorization(Pages.EmployeeInquiry, 1, 2)]
        public async Task<JsonResult> UpdateEmployeeInquiryFile(int EmployeeID, int ID)
        {


            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                bool result = await FileHelper.SaveFile(Request.Files[0], ID, EmployeeID, DirectoryNames.EmployeeInquiry);
                string FileID = $"{ID}{Path.GetExtension(file.FileName)}";

                if (result)
                {
                    var Update = await json.UpdateEmployeeInquiryFile(EmployeeID, file.FileName, FileID);

                    return new JsonResult
                    {
                        Data = new ResultDTO() { ID = EmployeeID, Status = true, Message = " file uploaded", FileID=FileID },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
            }


            return new JsonResult
            {
                Data = new ResultDTO() { ID = EmployeeID, Status = true, Message = "No file to upload" , FileID = "2901.docx" },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };


        }


        public async Task<JsonResult> ProcessInquiryMail(EmployeeInquiry record)
        {
            bool result = false;
            try
            {
                var User = SessionHelper.UserSession();

                record.RecordCreatedBy = User.ID;


                List<MergeField> field = new List<MergeField>();

                field.Add(new MergeField("DATE", record.InquiryDate == null ? DateTime.Now.ToString("MM/dd/yyyy") : Convert.ToDateTime(record.InquiryDate).ToString("MM/dd/yyyy")));
                field.Add(new MergeField("REMARKS", record.Remarks));
                field.Add(new MergeField("EMP_NAME", User.Name));
                field.Add(new MergeField("EMP_ID", User.EmployeeID.ToString()));


                string Row = "";
                string Status = "";
                EmployeeSupervisor Supervisor = new EmployeeSupervisor();
                List<EmailTemplate> EmplyeeRequestTemplates = await (new DataListJson()).EmplyeeRequestTemplates();
                Row = Row + $"<tr><td>{ User.Name }</td><td>{ User.Position }</td><td>Requested</td></tr>";


                foreach (EmployeeSupervisor requestApprover in SessionHelper.UserSession().Supervisors)
                {
                    if (requestApprover.SupervisorType == SupervisorTypes.Supervisor)
                    {
                        Status = "Pending Approval";
                        Supervisor = requestApprover;
                    }

                    else if (requestApprover.SupervisorType == SupervisorTypes.HRManager)
                        Status = "Pending Approval";

                    Row = Row + $"<tr><td>{ requestApprover.Name }</td><td>{ requestApprover.Position }</td><td>{Status}</td></tr>";
                }

                field.Add(new MergeField("APPROVALS", Row));
                var EmailTemplate = new EmailTemplate();
                var SupervisorEmailTemplate = new EmailTemplate();
                foreach (EmailTemplate template in EmplyeeRequestTemplates)
                {
                    if (template.Type == 1)
                        EmailTemplate = template;
                    else if (template.Type == 2)
                        SupervisorEmailTemplate = template;
                }

                EmailHelper email = new EmailHelper();
                var status = await email.SendEmail(new EmailDTO() { To = User.EmailAddress, From = "no-reply@pipewellservices.com", Subject = EmailTemplate.Subject, Body = EmailTemplate.Body }, field);
                if (status && Supervisor.ID > 0 && Supervisor.EmailAddress != "")
                {

                    field.Add(new MergeField("APPROVE_NAME", Supervisor.Name));
                    field.Add(new MergeField("PORTAL_LINK", ""));
                    string Attachment = "";
                    if (record.FileID != null)
                    {
                          Attachment = await FileHelper.GetFile(record.FileID, record.EmployeeID, DirectoryNames.EmployeeInquiry);
                    }
                    

                    status = await email.SendEmail(new EmailDTO() { To = Supervisor.EmailAddress, From = "no-reply@pipewellservices.com", Subject = SupervisorEmailTemplate.Subject, Body = SupervisorEmailTemplate.Body, Attachment= Attachment }, field);
                }
                result = true;
            }
            catch (Exception e)
            {

            }


            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }

        public async Task<FileResult> DownloadInQuiryFile(int EmployeeID, string FileName, string FileID)
        {
            return File(await FileHelper.GetFile(FileID, EmployeeID, DirectoryNames.EmployeeInquiry), System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
        }
        //////////////////////////////////////////////////////////

        public async Task<JsonResult> Supervisors()
        {
            return new JsonResult
            {
                Data = await json.Supervisors(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }



        public async Task<JsonResult> PendingApprovals(bool Declined)
        {
            return new JsonResult
            {
                Data = await json.ApprovalList(SessionHelper.EmployeeID(), Declined),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.Approvals, 1, 2)]
        public async Task<JsonResult> ApproveRequests(List<PendingApproval> approvals)
        {
            ApprovalRequestResult model = new ApprovalRequestResult();
            ApprovalHelper helper = new ApprovalHelper();
            foreach (PendingApproval approval in approvals)
            {
                model = await json.ApproveRequest(SessionHelper.EmployeeID(), approval);
                if (model.Result && (approval.Status == ApprovalStatus.Approved || approval.Status == ApprovalStatus.Declined || approval.Status == ApprovalStatus.NotApproved))
                {
                    await helper.ProcessRequest(approval.RecordType, model);
                }
            }
            return new JsonResult
            {
                Data = true,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [Authorization(Pages.Vendor)]
        public async Task<JsonResult> VendorList()
        {
            return new JsonResult
            {
                Data = await json.VendorList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.Vendor, 1, 1)]
        public async Task<JsonResult> UpdateVendor(Vendor Vendor)
        {
            Vendor.RecordAddedBy = SessionHelper.UserSession().ID;

            return new JsonResult
            {
                Data = await json.UpdateVendor(Vendor),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        /// <summary>
        /// //////////////////////////////////

        [Authorization(Pages.Joining)]
        public async Task<JsonResult> EmployeeJoining(DateParam param)
        {
            return new JsonResult
            {
                Data = await json.EmployeeJoining(param),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.Joining, 1, 1)]
        public async Task<JsonResult> UpdateEmployeeJoining(EmployeeJoining record)
        {
            record.RecordCreatedBy = SessionHelper.UserSession().ID;

            return new JsonResult
            {
                Data = await json.UpdateEmployeeJoining(record),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }
        [Authorization(Pages.Joining, 1, 2)]
        public async Task<JsonResult> UpdateJoiningSheet(int EmployeeID, int ID)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                bool result = await FileHelper.SaveFile(Request.Files[0], ID, EmployeeID, DirectoryNames.EmployeeJoining);
                string FileID = $"{EmployeeID}{Path.GetExtension(file.FileName)}";

                if (result)
                {
                    var Update = await json.UpdateEmployeeJoiningSheet(EmployeeID, file.FileName, FileID);

                    return new JsonResult
                    {
                        Data = Update,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
            }


            return new JsonResult
            {
                Data = new ResultDTO() { ID = EmployeeID, Status = false, Message = "No file to upload" },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.Joining, 1, 1)]
        public async Task<JsonResult> DeleteEmployeeJoining(int ID)
        {

            return new JsonResult
            {
                Data = await json.DeleteEmployeeJoining(ID, SessionHelper.UserSession().ID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }

        public async Task<FileResult> DownloadJoiningFile(int EmployeeID, string FileName, string FileID)
        {
            return File(await FileHelper.GetFile(FileID, EmployeeID, DirectoryNames.EmployeeJoining), System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
        }


        /// <summary>
        /// //////////////////////////////////

        [Authorization(Pages.ShortLeave)]
        public async Task<JsonResult> EmployeeShortLeaves(DateParam param)
        {
            return new JsonResult
            {
                Data = await json.EmployeeShortLeaves(param),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.ShortLeave, 1, 1)]
        public async Task<JsonResult> UpdateEmployeeShortLeave(EmployeeShortLeave record)
        {
            record.RecordCreatedBy = SessionHelper.UserSession().ID;

            return new JsonResult
            {
                Data = await json.UpdateEmployeeShortLeave(record),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }
        [Authorization(Pages.ShortLeave, 1, 2)]
        public async Task<JsonResult> UpdateShortLeaveSheet(int EmployeeID, int ID)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                bool result = await FileHelper.SaveFile(Request.Files[0], ID, EmployeeID, DirectoryNames.EmployeeShortLeave);
                string FileID = $"{EmployeeID}{Path.GetExtension(file.FileName)}";

                if (result)
                {
                    var Update = await json.UpdateEmployeeShortLeaveSheet(EmployeeID, file.FileName, FileID);

                    return new JsonResult
                    {
                        Data = Update,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
            }


            return new JsonResult
            {
                Data = new ResultDTO() { ID = EmployeeID, Status = false, Message = "No file to upload" },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.ShortLeave, 1, 1)]
        public async Task<JsonResult> DeleteEmployeeShortLeave(int ID)
        {

            return new JsonResult
            {
                Data = await json.DeleteEmployeeShortLeave(ID, SessionHelper.UserSession().ID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }
        public async Task<FileResult> DownloadShortLeaveFile(int EmployeeID, string FileName, string FileID)
        {
            return File(await FileHelper.GetFile(FileID, EmployeeID, DirectoryNames.EmployeeShortLeave), System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
        }


        ////
        [Authorization(Pages.LeaveRequest, 2, 2)]
        public async Task<JsonResult> EmployeeLeaveRequest(DateParam param)
        {
            var result = await json.EmployeeLeaveRequest(param);
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }
        [Authorization(Pages.LeaveRequest, 1, 2)]
        public async Task<JsonResult> NewLeaveRequest(EmployeeLeave record)
        {
            record.RecordCreatedBy = SessionHelper.UserSession().ID;
            ApprovalRequestResult Requestresult = await json.NewLeaveRequest(record);
            if (Requestresult.Result)
            {
                List<MergeField> field = new List<MergeField>();

                field.Add(new MergeField("LEAVE_TYPE", record.LeaveTypeName));
                field.Add(new MergeField("START_DATE", record.StartDate.ToString("MM/dd/yyyy")));
                field.Add(new MergeField("END_DATE", record.EndDate.ToString("MM/dd/yyyy")));
                field.Add(new MergeField("DAYS", (record.EndDate - record.StartDate).Days.ToString()));
                string Row = "";
                string Status = "";
                RequestApprover Supervisor = new RequestApprover();
                RequestApprover employee = new RequestApprover();
                foreach (RequestApprover requestApprover in Requestresult.Employees)
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
                        Status = "Pending Approval";

                        field.Add(new MergeField("APPROVE_NAME", employee.Name));
                        Supervisor = requestApprover;
                    }
                    else if (requestApprover.RowID == 2)
                        Status = "Pending Approval";

                    Row = Row + $"<tr><td>{ requestApprover.Name }</td><td>{ requestApprover.Position }</td><td>{Status}</td></tr>";
                }
                field.Add(new MergeField("APPROVALS", Row));
                var EmailTemplate = new EmailTemplate();
                var SupervisorEmailTemplate = new EmailTemplate();
                foreach (EmailTemplate template in Requestresult.EmailTemplate)
                {
                    if (template.Type == 1)
                        EmailTemplate = template;
                    else if (template.Type == 2)
                        SupervisorEmailTemplate = template;
                }

                EmailHelper email = new EmailHelper();
                var status = await email.SendEmail(new EmailDTO() { To = employee.EmailAddress, From = "no-reply@pipewellservices.com", Subject = EmailTemplate.Subject, Body = EmailTemplate.Body }, field);
                if (status && Supervisor.ID > 0 && Supervisor.EmailAddress != "")
                {

                    field.Add(new MergeField("APPROVE_NAME", Supervisor.Name));
                    field.Add(new MergeField("PORTAL_LINK", ""));

                    status = await email.SendEmail(new EmailDTO() { To = Supervisor.EmailAddress, From = "no-reply@pipewellservices.com", Subject = SupervisorEmailTemplate.Subject, Body = SupervisorEmailTemplate.Body }, field);
                }

            }
            return new JsonResult
            {
                Data = new { result = Requestresult.Result, ID = Requestresult.ID },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

        }
        public async Task<JsonResult> UploadLeaveSheet(int EmployeeID, int ID)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                bool result = await FileHelper.SaveFile(Request.Files[0], ID, EmployeeID, DirectoryNames.Leaves);
                string FileID = $"{EmployeeID}{Path.GetExtension(file.FileName)}";

                if (result)
                {
                    var Update = await json.UpdateEmployeeLeaveSheet(EmployeeID, file.FileName, FileID);

                    return new JsonResult
                    {
                        Data = Update,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
            }


            return new JsonResult
            {
                Data = new ResultDTO() { ID = EmployeeID, Status = false, Message = "No file to upload" },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<FileResult> DownloadLeaveFile(int EmployeeID, string FileName, string FileID)
        {
            return File(await FileHelper.GetFile(FileID, EmployeeID, DirectoryNames.Leaves), System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
        }

    }
}