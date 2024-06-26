﻿using Pipewellservice.Helper;
using PipewellserviceJson.HR.Employee;
using PipewellserviceJson.HR.Job;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using PipewellserviceModels.HR.Job;
using PipewellserviceModels.HR.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Pipewellservice.Areas.API.Controllers
{
    public class JobController : BaseController
    {
        JobJson json = new JobJson();

        public async Task<JsonResult> JobOffers()
        {
            var result = await json.JobOfferList();
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> DeleteJobOffer(DeleteDTO delete)
        {
            return new JsonResult
            {
                Data = await json.DeleteJobOffer(delete),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> UpdateJobOffer(JobOffer job)
        {
            
             string JobOfferTemplatePath=await FileHelper.GetTemplateFile( DirectoryNames.Templates,DocTemplates.JobOffer);
            
            string JobOffer = await FileHelper.GetPath(DirectoryNames.EmployeeJobOffer);
            string Extenstion = Path.GetExtension(JobOfferTemplatePath);
            job.FileID = Extenstion;
            int OfferID = await json.UpdateJobOffer(job);
            HRManager hr = await (new EmployeeJson()).HRManager();

            List<MergeField> mergeFields = new List<MergeField>();
            /*    mergeFields.Add(new MergeField("<NAME>", job.Name));
                mergeFields.Add(new MergeField("<NAME-AR>", job.NameAr));
                mergeFields.Add(new MergeField("<NATIONALITY>", job.Nationality));
                mergeFields.Add(new MergeField("<JOB TITLE>", job.JobTitle));
                mergeFields.Add(new MergeField("<BASIC>", job.Basic.ToString()));
                mergeFields.Add(new MergeField("<PERIOD>", job.Period.ToString()));
                mergeFields.Add(new MergeField("<TRANSPORT>", job.Transportation >0 ?$"{job.Transportation}% from Basic" :"Will be provided by the Company"));
                mergeFields.Add(new MergeField("<HOUSING>", job.Housing > 0 ? $"{job.Housing}% from Basic" : "Will be provided by the Company"));
                mergeFields.Add(new MergeField("<APPROVAL>", hr.Name));
                mergeFields.Add(new MergeField("<APPROVAL-AR>", hr.ArabicName));*/

            /*mergeFields.Add(new MergeField("&lt;NAME&gt;", job.Name));
            mergeFields.Add(new MergeField("&lt;NAME-AR&gt;", job.NameAr));
            mergeFields.Add(new MergeField("&lt;NATIONALITY&gt;", job.Nationality));
            mergeFields.Add(new MergeField("&lt;JOB TITLE&gt;", job.JobTitle));
            mergeFields.Add(new MergeField("&lt;BASIC&gt;", job.Basic.ToString()));
            mergeFields.Add(new MergeField("&lt;PERIOD&gt;", job.Period.ToString()));
            mergeFields.Add(new MergeField("&lt;TRANSPORT&gt;", job.Transportation > 0 ? $"{job.Transportation}% from Basic" : "Will be provided by the Company"));
            mergeFields.Add(new MergeField("&lt;HOUSING&gt;", job.Housing > 0 ? $"{job.Housing}% from Basic" : "Will be provided by the Company"));
            mergeFields.Add(new MergeField("&lt;APPROVAL&gt;", hr.Name));
            mergeFields.Add(new MergeField("&lt;APPROVAL-AR&gt;", hr.ArabicName));*/

            mergeFields.Add(new MergeField("NAME-AR", job.NameAr));
            mergeFields.Add(new MergeField("NAME", job.Name));
            
            mergeFields.Add(new MergeField("NATIONALITY", job.Nationality));
            mergeFields.Add(new MergeField("JOBTITLE", job.JobTitle));
            mergeFields.Add(new MergeField("BASIC", job.Basic.ToString()));
            mergeFields.Add(new MergeField("PERIOD", job.Period.ToString()));
            mergeFields.Add(new MergeField("TRANSPORT", job.Transportation > 0 ? $"{job.Transportation}% from Basic" : "Will be provided by the Company"));
            mergeFields.Add(new MergeField("HOUSING", job.Housing > 0 ? $"{job.Housing}% from Basic" : "Will be provided by the Company"));
            mergeFields.Add(new MergeField("APPROVAL", hr.Name));
            mergeFields.Add(new MergeField("APPROVAL-AR", hr.ArabicName));

            //&lt;
            DocHelper DocHelper = new DocHelper();


          //  JobOffer = @"K:\IrfanUllah\Pipewellservice\Pipewellservice\Resources\Employee\JobContract\";
          // JobOfferTemplatePath = @"K:\IrfanUllah\Pipewellservice\Pipewellservice\Resources\Employee\Template\Job Offer - TEMPLATE.docx";
            try
            {
                await DocHelper.ConvertDocument(JobOfferTemplatePath, $"{JobOffer}\\{OfferID}{Extenstion}", mergeFields);
            }catch(Exception e)
            {
                EmailHelper email = new EmailHelper();
                await email.SendEmail(new EmailDTO() { To = "irfanullah.it@pipewellservices.com", From = "notifications.pws@gmail.com", Subject = "ERROR PWS WEB", Body = e.Message });
            }
            return new JsonResult
            {
                Data = OfferID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<FileResult> DownloadOfferLetter(string FileID)
        {
            return File(await FileHelper.GetFile(FileID, 0, DirectoryNames.EmployeeJobOffer), System.Net.Mime.MediaTypeNames.Application.Octet, FileID);

        }

        public async Task<JsonResult> JobContracts()
        {
            var result = await json.JobContractList();
            return new JsonResult
            {
                Data = result,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> DeleteJobContract(DeleteDTO delete)
        {
            return new JsonResult
            {
                Data = await json.DeleteJobContract(delete),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<JsonResult> UpdateJobContract(JobContract job,Country country, SponsorCompany sponsor)
        {

            string JobContractTemplatePath = await FileHelper.GetTemplateFile(DirectoryNames.Templates, DocTemplates.Contract);

            string JobContract = await FileHelper.GetPath(DirectoryNames.EmployeeJobContract);
            string Extenstion = Path.GetExtension(JobContractTemplatePath);
            job.FileID = Extenstion;
            int ContractID = await json.UpdateJobContract(job);

            HRManager hr = await (new EmployeeJson()).HRManager();
            List<MergeField> mergeFields = new List<MergeField>();
            /*mergeFields.Add(new MergeField("<CR>", job.CompanyRegNumber));
            mergeFields.Add(new MergeField("<EMP-NAME>", job.Name));
            mergeFields.Add(new MergeField("<EMP-NAME-AR>", job.NameAr));

            mergeFields.Add(new MergeField("<NATIONALITY>", country.Nationality));
            mergeFields.Add(new MergeField("<NATIONALITY-AR>", country.ArabicNationality));

            mergeFields.Add(new MergeField("<COUNTRY>", job.Name));
            mergeFields.Add(new MergeField("<COUNTRY-AR>", country.ArabicName ));


            mergeFields.Add(new MergeField("<ID>", job.IDNumber));
            mergeFields.Add(new MergeField("<EMAIL>", job.EmailAddress));

            mergeFields.Add(new MergeField("<MOBILE>", job.MobileNumber));

            mergeFields.Add(new MergeField("<JOB TITLE>", job.JobTitle));
            mergeFields.Add(new MergeField("<JOB TITLE-AR>", job.JobTitleAr));
            mergeFields.Add(new MergeField("<PERIOD-AR>", job.PeriodAr.ToString()));
            mergeFields.Add(new MergeField("<PERIOD>", job.Period.ToString()));

            mergeFields.Add(new MergeField("<BASIC>", job.Basic.ToString()));
            mergeFields.Add(new MergeField("<TRANSPORT-AR>", job.Transportation > 0 ? $"من الراتب الأساسي {job.Transportation}%" : "سيتم توفيرها من قبل الشركة"));
            mergeFields.Add(new MergeField("<TRANSPORT>", job.Transportation > 0 ? $"{job.Transportation}% from Basic" : "Will be provided by the Company"));
            
            mergeFields.Add(new MergeField("<HOUSING>", job.Housing > 0 ? $"{job.Housing}% from Basic" : "Will be provided by the Company"));
            mergeFields.Add(new MergeField("<HOUSING-AR>", job.Housing > 0 ? $"من الراتب الأساسي {job.Transportation}%" : "سيتم توفيرها من قبل الشركة"));

            mergeFields.Add(new MergeField("<date>", job.StartDate==null ? "": Convert.ToDateTime (job.StartDate).ToString("dd/MM/yyyy")));
            mergeFields.Add(new MergeField("<date-ar>", job.StartDate == null ? "" : Convert.ToDateTime(job.StartDate).ToString("yyyy/MM/dd")));

            mergeFields.Add(new MergeField("<TRANSPORT>", job.Transportation > 0 ? $"{Config.ResourcesDirectory}\\{job.Transportation}% from Basic" : "Will be provided by the Company"));
            mergeFields.Add(new MergeField("<APPROVAL>", hr.Name));
            mergeFields.Add(new MergeField("<APPROVAL-AR>", hr.ArabicName));

            mergeFields.Add(new MergeField("<CR>", job.CompanyRegNumber));
            mergeFields.Add(new MergeField("<EMP-NAME>", job.Name));
            mergeFields.Add(new MergeField("<EMP-NAME-AR>", job.NameAr));

            mergeFields.Add(new MergeField("<NATIONALITY>", country.Nationality));
            mergeFields.Add(new MergeField("<NATIONALITY-AR>", country.ArabicNationality));

            mergeFields.Add(new MergeField("<COUNTRY>", job.Name));
            mergeFields.Add(new MergeField("<COUNTRY-AR>", country.ArabicName));*/


            /*mergeFields.Add(new MergeField("&lt;ID&gt;", job.IDNumber));
            mergeFields.Add(new MergeField("&lt;EMAIL&gt;", job.EmailAddress));

            mergeFields.Add(new MergeField("&lt;MOBILE&gt;", job.MobileNumber));

            mergeFields.Add(new MergeField("&lt;JOB TITLE&gt;", job.JobTitle));
            mergeFields.Add(new MergeField("&lt;JOB TITLE-AR&gt;", job.JobTitleAr));
            mergeFields.Add(new MergeField("&lt;PERIOD-AR&gt;", job.PeriodAr.ToString()));
            mergeFields.Add(new MergeField("&lt;PERIOD&gt;", job.Period.ToString()));

            mergeFields.Add(new MergeField("&lt;BASIC&gt;", job.Basic.ToString()));
            mergeFields.Add(new MergeField("&lt;TRANSPORT-AR&gt;", job.Transportation > 0 ? $"من الراتب الأساسي {job.Transportation}%" : "سيتم توفيرها من قبل الشركة"));
            mergeFields.Add(new MergeField("&lt;TRANSPORT&gt;", job.Transportation > 0 ? $"{job.Transportation}% from Basic" : "Will be provided by the Company"));

            mergeFields.Add(new MergeField("&lt;HOUSING&gt;", job.Housing >0 ? $"{job.Housing}% from Basic" : "Will be provided by the Company"));
            mergeFields.Add(new MergeField("&lt;HOUSING-AR&gt;", job.Housing> 0 ? $"من الراتب الأساسي {job.Transportation}%" : "سيتم توفيرها من قبل الشركة"));

            mergeFields.Add(new MergeField("&lt;date&gt;", job.StartDate == null ? "" : Convert.ToDateTime(job.StartDate).ToString("dd/MM/yyyy")));
            mergeFields.Add(new MergeField("&lt;date-ar&gt;", job.StartDate == null ? "" : Convert.ToDateTime(job.StartDate).ToString("yyyy/MM/dd")));

            mergeFields.Add(new MergeField("&lt;TRANSPORT&gt;", job.Transportation > 0 ? $"{Config.ResourcesDirectory}\\{job.Transportation}% from Basic" : "Will be provided by the Company"));
            mergeFields.Add(new MergeField("&lt;APPROVAL&gt;", hr.Name));
            mergeFields.Add(new MergeField("&lt;APPROVAL-AR&gt;", hr.ArabicName));*/


            mergeFields.Add(new MergeField("ID", job.IDNumber));
            mergeFields.Add(new MergeField("EMAIL", job.EmailAddress));

            mergeFields.Add(new MergeField("MOBILE", job.MobileNumber));
            mergeFields.Add(new MergeField("JOBTITLE-AR", job.JobTitleAr));
            mergeFields.Add(new MergeField("JOBTITLE", job.JobTitle));
            
            mergeFields.Add(new MergeField("PERIOD-AR", job.PeriodAr.ToString()));
            mergeFields.Add(new MergeField("PERIOD", job.Period.ToString()));
            mergeFields.Add(new MergeField("BASIC-AR", job.Basic.ToString()));
            mergeFields.Add(new MergeField("BASIC", job.Basic.ToString()));
            mergeFields.Add(new MergeField("TRANSPORT-AR", job.Transportation > 0 ? $"من الراتب الأساسي {job.Transportation}%" : "سيتم توفيرها من قبل الشركة"));
            mergeFields.Add(new MergeField("TRANSPORT", job.Transportation > 0 ? $"{job.Transportation}% from Basic" : "Will be provided by the Company"));


            mergeFields.Add(new MergeField("HOUSING-AR", job.Housing > 0 ? $"من الراتب الأساسي {job.Housing}%" : "سيتم توفيرها من قبل الشركة"));
            mergeFields.Add(new MergeField("HOUSING", job.Housing > 0 ? $"{job.Housing}% from Basic" : "Will be provided by the Company"));

            mergeFields.Add(new MergeField("date-ar", job.StartDate == null ? "" : Convert.ToDateTime(job.StartDate).ToString("yyyy/MM/dd")));
            mergeFields.Add(new MergeField("date", job.StartDate == null ? "" : Convert.ToDateTime(job.StartDate).ToString("dd/MM/yyyy")));
            

            //mergeFields.Add(new MergeField("TRANSPORT", job.Transportation > 0 ? $"{job.Transportation}% from Basic" : "Will be provided by the Company"));
            mergeFields.Add(new MergeField("APPROVAL-AR", hr.ArabicName));
            mergeFields.Add(new MergeField("APPROVAL", hr.Name));
            

            mergeFields.Add(new MergeField("CR", sponsor.CRNumber.ToString()));
            mergeFields.Add(new MergeField("EMP-NAME-AR", job.NameAr));
            mergeFields.Add(new MergeField("EMP-NAME", job.Name));

            mergeFields.Add(new MergeField("NATIONALITY-AR", country.ArabicNationality));
            mergeFields.Add(new MergeField("NATIONALITY", country.Nationality));

            mergeFields.Add(new MergeField("COUNTRY-AR", country.ArabicName));

            mergeFields.Add(new MergeField("COUNTRY", country.Name));
            
            DocHelper DocHelper = new DocHelper();

          // JobContract = @"K:\IrfanUllah\Pipewellservice\Pipewellservice\Resources\Employee\JobContract\";
          // JobContractTemplatePath= @"K:\IrfanUllah\Pipewellservice\Pipewellservice\Resources\Employee\Template\CONTRACT TEMPLATE.docx";
            try
            {
                await DocHelper.ConvertDocument(JobContractTemplatePath, $"{JobContract}\\{ContractID}{Extenstion}", mergeFields);
            }
            catch (Exception e)
            {
                EmailHelper email = new EmailHelper();
                await email.SendEmail(new EmailDTO() { To = "irfanullah.it@pipewellservices.com", From = "notifications.pws@gmail.com", Subject = "ERROR PWS WEB", Body = e.Message });
            }

            return new JsonResult
            {
                Data = ContractID,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
        public async Task<FileResult> DownloadContractLetter( string FileID)
        {
            return File(await FileHelper.GetFile(FileID, 0, DirectoryNames.EmployeeJobContract ), System.Net.Mime.MediaTypeNames.Application.Octet, FileID);

        }
    }
}