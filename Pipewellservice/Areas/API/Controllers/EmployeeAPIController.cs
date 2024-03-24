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
    public class EmployeeAPIController : Controller
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

        ///////////////////////////////////////////

        public async Task<JsonResult> CertificateList(int EmployeeID)
        {
            return new JsonResult
            {
                Data = await json.CertificateList(EmployeeID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> UpdateCertificate(EmployeeCertificate certificate)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                string FileID = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);
                DirectoryInfo Directory = new DirectoryInfo($"{Config.ResourcesDirectory}\\Employee\\{certificate.EmployeeID}\\Certificates");
                if (!Directory.Exists)
                {
                    Directory.Create();
                }
                try
                {
                    file.SaveAs($"{Config.ResourcesDirectory}\\Employee\\{certificate.EmployeeID}\\Certificates\\{FileID}{extension}");
                    certificate.FileID = $"{FileID}{extension}";
                    certificate.FileName = file.FileName;
                }
                catch (Exception e)
                {

                }
            }

            return new JsonResult
            {
                Data = await json.UpdateCertificate(certificate),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> RemoveCertificate(DeleteDTO delete)
        {
            return new JsonResult
            {
                Data = await json.RemoveCertificate(delete),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        ///////////////////////////////////////////

        public async Task<JsonResult> AssetList(int EmployeeID)
        {
            return new JsonResult
            {
                Data = await json.AssetList(EmployeeID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> UpdateAsset(EmployeeAsset asset)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                string FileID = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);
                DirectoryInfo Directory = new DirectoryInfo($"{Config.ResourcesDirectory}\\Employee\\{asset.EmployeeID}\\Assets");
                if (!Directory.Exists)
                {
                    Directory.Create();
                }
                try
                {
                    file.SaveAs($"{Config.ResourcesDirectory}\\Employee\\{asset.EmployeeID}\\Assets\\{FileID}{extension}");
                    asset.FileID = $"{FileID}{extension}";
                    asset.FileName = file.FileName;
                }
                catch (Exception e)
                {

                }
            }

            return new JsonResult
            {
                Data = await json.UpdateAsset(asset),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
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

            string BasePath = $"{Config.ResourcesDirectory}\\Employee\\{EmployeeID}\\Contracts\\{FileID}";
            return File(BasePath, System.Net.Mime.MediaTypeNames.Application.Octet, FileName);

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
                string FileID = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);
                DirectoryInfo Directory = new DirectoryInfo($"{Config.ResourcesDirectory}\\Employee\\{contract.EmployeeID}\\Contracts");
                if (!Directory.Exists)
                {
                    Directory.Create();
                }
                try
                {
                    file.SaveAs($"{Config.ResourcesDirectory}\\Employee\\{contract.EmployeeID}\\Contracts\\{FileID}{extension}");
                    contract.FileID = $"{FileID}{extension}";
                    contract.FileName = file.FileName;
                }
                catch (Exception e)
                {

                }


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
        public async Task<FileResult> DownloadIDFile(int EmployeeID, string FileName, string FileID)
        {

            string BasePath = $"{Config.ResourcesDirectory}\\Employee\\{EmployeeID}\\ID\\{FileID}";
            return File(BasePath, System.Net.Mime.MediaTypeNames.Application.Octet, FileName);

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
        public async Task<JsonResult> UpdateEmployeeIDFile(EmployeeIDFile Idfile)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                string FileID = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);
                DirectoryInfo Directory = new DirectoryInfo($"{Config.ResourcesDirectory}\\Employee\\{Idfile.EmployeeID}\\ID");
                if (!Directory.Exists)
                {
                    Directory.Create();
                }
                try
                {
                    file.SaveAs($"{Config.ResourcesDirectory}\\Employee\\{Idfile.EmployeeID}\\ID\\{FileID}{extension}");
                    Idfile.FileID = $"{FileID}{extension}";
                    Idfile.FileName = file.FileName;
                }
                catch (Exception e)
                {

                }
            }

            return new JsonResult
            {
                Data = await json.UpdateEmployeeIDFile(Idfile),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
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

            string BasePath = $"{Config.ResourcesDirectory}\\Employee\\{EmployeeID}\\FamilyID\\{FileID}";
            return File(BasePath, System.Net.Mime.MediaTypeNames.Application.Octet, FileName);

        }
        public async Task<JsonResult> EmployeeFamilyIDFileList(int EmployeeID)
        {
            return new JsonResult
            {
                Data = await json.EmployeeFamilyIDFileList(EmployeeID),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> UpdateEmployeeFamilyIDFile(EmployeeFamilyIDFile Idfile)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                string FileID = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);
                DirectoryInfo Directory = new DirectoryInfo($"{Config.ResourcesDirectory}\\Employee\\{Idfile.EmployeeID}\\FamilyID");
                if (!Directory.Exists)
                {
                    Directory.Create();
                }
                try
                {
                    file.SaveAs($"{Config.ResourcesDirectory}\\Employee\\{Idfile.EmployeeID}\\FamilyID\\{FileID}{extension}");
                    Idfile.FileID = $"{FileID}{extension}";
                    Idfile.FileName = file.FileName;
                }
                catch (Exception e)
                {

                }
            }

            return new JsonResult
            {
                Data = await json.UpdateEmployeeFamilyIDFile(Idfile),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
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

            string BasePath = $"{Config.ResourcesDirectory}\\Employee\\{EmployeeID}\\Family\\{FileID}";
            return File(BasePath, System.Net.Mime.MediaTypeNames.Application.Octet, FileName);

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
        public async Task<JsonResult> UpdateEmployeeFamily(EmployeeFamily family)
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                string FileID = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(file.FileName);
                DirectoryInfo Directory = new DirectoryInfo($"{Config.ResourcesDirectory}\\Employee\\{family.EmployeeID}\\Family");
                if (!Directory.Exists)
                {
                    Directory.Create();
                }
                try
                {
                    file.SaveAs($"{Config.ResourcesDirectory}\\Employee\\{family.EmployeeID}\\Family\\{FileID}{extension}");
                    family.FileID = $"{FileID}{extension}";
                    family.FileName = file.FileName;
                }
                catch (Exception e)
                {

                }
            }

            return new JsonResult
            {
                Data = await json.UpdateEmployeeFamily(family),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
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
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
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
        public async Task<JsonResult> EmployeeDataList()
        {
            return new JsonResult
            {
                Data = await json.EmployeeDataList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> UpdateEmployee(EmployeeData employee)
        {
            return new JsonResult
            {
                Data = await json.UpdateEmployee(employee),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

    }

}