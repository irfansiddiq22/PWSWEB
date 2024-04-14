﻿using PipewellserviceDB.HR.Employee;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using PipewellserviceModels.HR.Settings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.HR.Employee
{
    public class EmployeeJson
    {
        public EmployeeService service = new EmployeeService();
        public async Task<List<EmployeeNameCode>> CodeName()
        {
            var Data = await service.CodeName();
            List<EmployeeNameCode> result = await JsonHelper.Convert<List<EmployeeNameCode>, DataTable>(Data);
            return result;
        }
        public async Task<List<EmployeeNameCode>> FamilyCodeName()
        {
            var Data = await service.FamilyCodeName();
            List<EmployeeNameCode> result = await JsonHelper.Convert<List<EmployeeNameCode>, DataTable>(Data);
            return result;
        }
        ////////..................

        public async Task<bool> SaveLog(DataChangeLog log)
        {
            return await service.SaveLog(log);
        }

        public async Task<List<EmployeeCertificate>> CertificateList(int EmployeeID)
        {
            return await JsonHelper.Convert<List<EmployeeCertificate>, DataTable>(await service.CertificateList(EmployeeID));
        }
        public async Task<int> UpdateCertificate(EmployeeCertificate certificate)
        {
            return await service.UpdateCertificate(certificate);
        }
        public async Task<bool> RemoveCertificate(DeleteDTO delete)
        {
            return await service.RemoveCertificate(delete);
        }
        ////////..................
        public async Task<List<EmployeeAsset>> AssetList(int EmployeeID)
        {
            return await JsonHelper.Convert<List<EmployeeAsset>, DataTable>(await service.AssetList(EmployeeID));
        }
        public async Task<int> UpdateAsset(EmployeeAsset asset)
        {
            return await service.UpdateAsset(asset);
        }
        public async Task<bool> RemoveAsset(DeleteDTO delete)
        {
            return await service.RemoveAsset(delete);
        }


        /////////////////        ......
        public async Task<List<EmployeeContract>> ContractList()
        {
            return await JsonHelper.Convert<List<EmployeeContract>, DataTable>(await service.ContractList());
        }
        public async Task<List<EmployeeContract>> UpdateContract(EmployeeContract contract)
        {
            return await JsonHelper.Convert<List<EmployeeContract>, DataTable>(await service.UpdateContract(contract));
        }

        ////////..................


        public async Task<List<EmployeeIDFileType>> EmployeeIDTypeList()
        {
            return await JsonHelper.Convert<List<EmployeeIDFileType>, DataTable>(await service.EmployeeIDTypeList());
        }
        public async Task<List<EmployeeIDFile>> EmployeeIDFileList(int EmployeeID)
        {
            return await JsonHelper.Convert<List<EmployeeIDFile>, DataTable>(await service.EmployeeIDFileList(EmployeeID));
        }
        public async Task<int> UpdateEmployeeIDFile(EmployeeIDFile file)
        {
            return await service.UpdateEmployeeIDFile(file);
        }
        public async Task<bool> RemoveEmployeeIDFile(DeleteDTO delete)
        {
            return await service.RemoveEmployeeIDFile(delete);
        }

        ////////..................
        public async Task<List<EmployeeFamilyIDFile>> EmployeeFamilyIDFileList(int EmployeeID)
        {
            return await JsonHelper.Convert<List<EmployeeFamilyIDFile>, DataTable>(await service.EmployeeFamilyIDFileList(EmployeeID));
        }
        public async Task<int> UpdateEmployeeFamilyIDFile(EmployeeFamilyIDFile file)
        {
            return await service.UpdateEmployeeFamilyIDFile(file);
        }
        public async Task<bool> RemoveEmployeeFamilyIDFile(DeleteDTO delete)
        {
            return await service.RemoveEmployeeFamilyIDFile(delete);
        }

        ////////..................

        public async Task<List<EmployeeRelation>> EmployeeRelationList()
        {
            return await JsonHelper.Convert<List<EmployeeRelation>, DataTable>(await service.EmployeeRelationList());
        }
        public async Task<List<EmployeeFamily>> EmployeeFamilyList(int EmployeeID)
        {
            return await JsonHelper.Convert<List<EmployeeFamily>, DataTable>(await service.EmployeeFamilyList(EmployeeID));
        }
        public async Task<int> UpdateEmployeeFamily(EmployeeFamily family)
        {
            return await service.UpdateEmployeeFamily(family);
        }
        public async Task<bool> RemoveEmployeeFamily(DeleteDTO delete)
        {
            return await service.RemoveEmployeeFamily(delete);
        }
        ///.........................
        public async Task<List<EmployeeListView>> EmployeeList()
        {
            return await JsonHelper.Convert<List<EmployeeListView>, DataTable>(await service.EmployeeList());
        }

        public async Task<List<EmployeeReferenceData>> EmployeeData(int EmployeeID)
        {
            return await JsonHelper.Convert<List<EmployeeReferenceData>, DataTable>(await service.EmployeeDetail(EmployeeID));
        }
        public async Task<List<EmployeeData>> EmployeeDetail(int EmployeeID)
        {
            return await JsonHelper.Convert<List<EmployeeData>, DataTable>(await service.EmployeeDetail(EmployeeID));
        }

        public async Task<EmployeeListData> EmployeeDataList()
        {
            EmployeeDataSql result = await service.EmployeeDataList();
            EmployeeListData model = new EmployeeListData();
            model.departments = await JsonHelper.Convert<List<Department>, DataTable>(result.Department);
            model.divisions = await JsonHelper.Convert<List<Division>, DataTable>(result.Division);
            model.positions = await JsonHelper.Convert<List<Position>, DataTable>(result.Position);
            //model.supervisior = await JsonHelper.Convert<List<EmployeeIDView>, DataTable>(result.Supervisior);
            model.sponsors = await JsonHelper.Convert<List<SponsorCompany>, DataTable>(result.Sponsor);
            model.worktime = await JsonHelper.Convert<List<WorkInOutTime>, DataTable>(result.WorkTime);
            model.nationalities = await JsonHelper.Convert<List<Nationality>, DataTable>(result.Nationality);
            return model;
        }
        public async Task<ResultDTO> UpdateEmployee(EmployeeData employee)
        {
            return await service.UpdateEmployee(employee);
        }
        public async Task<ResultDTO> UpdateEmployeePicture(int EmployeeID,string FileName,string FileID)
        {
            return await service.UpdateEmployeePicture(EmployeeID, FileName, FileID);
        }
        //////////...............................

        public async Task<List<EmployeeWarning>> EmployeeWarningList(EmployeeWarningDTO dTO)
        {
            return await JsonHelper.Convert<List<EmployeeWarning>, DataTable>(await service.EmployeeWarningList(dTO));
        }
        public async Task<int> UpdateEmployeeWarning(EmployeeWarning dTO)
        {
            return  await service.UpdateEmployeeWarning(dTO);
        }
        public async Task<EmployeeClearanceListView> EmployeeClearanceList(int EmployeeID)
        {
            var db= await service.EmployeeClearanceList(EmployeeID);
            EmployeeClearanceListView model = new EmployeeClearanceListView();
            model.Clearance = await JsonHelper.Convert<List<EmployeeClearance>, DataTable>(db.Clearance);
            model.Assets = await JsonHelper.Convert<List<ClearanceAsset>, DataTable>(db.Assets );
            model.Approvals= await JsonHelper.Convert<List<EmployeeApproval>, DataTable>(db.Approvals);
            return model;
        }
        public async Task<int> UpdateEmployeeClearance(EmployeeClearance dTO)
        {
            return await service.UpdateEmployeeClearance(dTO);
        }
        public async Task<EmployeeInquiryListView> EmployeeInquiryList(EmployeeInquiryParam param)
        {
            var db = await service.EmployeeInquiryList(param);
            EmployeeInquiryListView model = new EmployeeInquiryListView();
            model.Inquiry = await JsonHelper.Convert<List<EmployeeInquiry>, DataTable>(db.Inquiry);
            model.TotalRecords = 0;
            if (model.Inquiry.Count > 0)
                model.TotalRecords = model.Inquiry[0].TotalRecords;
            return model;
        }
        public async Task<EmployeeInquiry> EmployeeInquiryDetail(int ID)
        {
            var db = await service.EmployeeInquiryDetail(ID);

            EmployeeInquiry inquiry = (await JsonHelper.Convert<List<EmployeeInquiry>, DataTable>(db.Inquiry)).FirstOrDefault();
            inquiry.Approvals= await JsonHelper.Convert<List<EmployeeApproval>, DataTable>(db.Approvals);
            return inquiry;
        }
        public async Task<int> UpdateEmployeeInquiry(EmployeeInquiry inquiry)
        {
            return await service.UpdateEmployeeInquiry(inquiry);
        }
        public async Task<bool> UpdateEmployeeInquiryFile(int ID,string FileName,string FileID)
        {
            return await service.UpdateEmployeeInquiryFile(ID,FileName,FileID);
        }

        
        public async Task<List<EmployeeIDView>> WarningSupervisors()
        {
            return await JsonHelper.Convert<List<EmployeeIDView>, DataTable>(await service.WarningSupervisors());
        }

        ////////////////////



    }
}
