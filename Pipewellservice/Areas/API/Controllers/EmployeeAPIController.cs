using PipewellserviceJson.HR.Employee;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using Pipewellservice.Helper;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.IO;
namespace Pipewellservice.Areas.API.Controllers
{
    [Authorization]
    public class EmployeeAPIController : BaseController
    {
        EmployeeJson json = new EmployeeJson();

        public async Task<JsonResult> CodeName()
        {
            var result = await json.CodeName();
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> FamilyCodeName()
        {
            var result = await json.FamilyCodeName();
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
        public async Task<JsonResult> CertificateList(int EmployeeID)
        {
            return new JsonResult
            {
                Data = await json.CertificateList(EmployeeID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.Certificates,1,2)]
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
        [Authorization(Pages.Assets, 1,2)]
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
        [Authorization(Pages.Assets, 2,1)]
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
        public async Task<JsonResult> EmployeeIDFileList(int EmployeeID)
        {
            return new JsonResult
            {
                Data = await json.EmployeeIDFileList(EmployeeID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.EmployeeID, 1,2)]
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
        [Authorization(Pages.EmployeeID, 2,1)]
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
        [Authorization(Pages.FamilyID, 1,2)]
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
        [Authorization(Pages.FamilyID, 2,1)]
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
        [Authorization(Pages.Family, 1,2)]

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
        [Authorization(Pages.Family, 2,1)]
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
            return new JsonResult
            {
                Data = await json.EmployeeData(EmployeeID),
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
        [Authorization(Pages.EmployeeDetail, 1,2)]
        public async Task<JsonResult> UpdateEmployee(EmployeeData employee)
        {
            return new JsonResult
            {
                Data = await json.UpdateEmployee(employee),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.EmployeeDetail, 1,2)]
        public async Task<FileResult> EmployeePicture(int EmployeeID, string FileID, string FileName)
        {
            string FilePath = await FileHelper.GetFile(FileID, EmployeeID, DirectoryNames.EmployeePictures); ;
            if (FilePath != "")
                return File(FilePath, System.Net.Mime.MediaTypeNames.Application.Octet, FileName);
            else
                return null;
        }
        [Authorization(Pages.EmployeeDetail, 1,2)]
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
        [Authorization(Pages.EmployeeWarning, 1,2)]
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


        ////////////////////////////////////////////////////

        public async Task<JsonResult> EmployeeClearanceList(int EmployeeID)
        {
            return new JsonResult
            {
                Data = await json.EmployeeClearanceList(EmployeeID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        [Authorization(Pages.EmployeeClearance , 1,2)]
        public async Task<JsonResult> UpdateEmployeeClearance(EmployeeClearance clearance)
        {
            int ID = await json.UpdateEmployeeClearance(clearance);
            return new JsonResult
            {
                Data = ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

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
        [Authorization(Pages.EmployeeInquiry , 1,2)]
        public async Task<JsonResult> UpdateEmployeeInquiry(EmployeeInquiry inquiry)
        {
            int ID = await json.UpdateEmployeeInquiry(inquiry);
            return new JsonResult
            {
                Data = ID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [Authorization(Pages.EmployeeInquiry, 1,2)]
        public async Task<JsonResult> UpdateEmployeeInquiryFile(int EmployeeID,int ID)
        {


            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                bool result = await FileHelper.SaveFile(Request.Files[0], ID, EmployeeID, DirectoryNames.EmployeeInquiry );
                string FileID = $"{ID}{Path.GetExtension(file.FileName)}";

                if (result)
                {
                    var Update = await json.UpdateEmployeeInquiryFile(EmployeeID, file.FileName, FileID);

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


        //////////////////////////////////////////////////////////

        public async Task<JsonResult> WarningSupervisors()
        {
            return new JsonResult
            {
                Data = await json.WarningSupervisors(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}