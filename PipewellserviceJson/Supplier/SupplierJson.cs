using PipewellserviceDB.Supplier;
using PipewellserviceModels.Account;
using PipewellserviceModels.Supplier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.SupplierJson
{
 public   class SupplierJson
    {
        private SupplierService service = new SupplierService();
        public async Task<int> SaveRegistration(SupplierAssesment assesment)
        {
            return await service.SaveRegistration(assesment);

        }
        public async Task<bool> SaveRegistrationFiles(int ID, RegistrationFile assesmentFile)
        {
            return await service.SaveRegistrationFiles(ID, assesmentFile);

        }


        public async Task<List<AssessmentListView>> SupplierAssessment(SupplierAssessmentParam param)
        {
            var data = await service.SupplierAssessment(param);

            return await JsonHelper.Convert<List<AssessmentListView>, DataTable>(data);
        }
        public async Task<SupplierAssementDTO> SupplierAssessment(int ID)
        {
            SupplierAssementDTOSQL data = await service.SupplierAssessment(ID);

            SupplierAssementDTO model = new SupplierAssementDTO();
            model.assessment = await JsonHelper.Convert<List<SupplierAssesment>, DataTable>(data.assessment);

            model.supplierItems = await JsonHelper.Convert<List<SupplierItem>, DataTable>(data.supplierItems);
            model.supplierCustomers = await JsonHelper.Convert<List<SupplierCustomer>, DataTable>(data.supplierCustomers);
            model.supplierProductions = await JsonHelper.Convert<List<SupplierProductionFacility>, DataTable>(data.supplierProductions);
            model.supplierQualityControls = await JsonHelper.Convert<List<SupplierQualityControlFacility>, DataTable>(data.supplierQualityControls);

            return model;
        }

        public async Task<QuoteRequest> QuoteRequest (string ID)
        {
            QuoteRequestSQL data = await service.QuoteRequest(ID);
            QuoteRequest model = new QuoteRequest();
            model.Status = data.Status;
            model.IPO = data.IPOID;
            if (data.Status)
            {
                model.Supplier =( await JsonHelper.Convert<List<Supplier>, DataTable>(data.Supplier)).FirstOrDefault();
                model.QuoteItems = await JsonHelper.Convert<List<QuoteItem>, DataTable>(data.QuoteItems);

                model.PastQuotes = await JsonHelper.Convert<List<Quote>, DataTable>(data.PastQuotes);
                model.PastQuoteItems = await JsonHelper.Convert<List<QuoteItem>, DataTable>(data.PastQuoteItems);
            }
            return model;
        }
        public async Task<int> SubmitQuote(string ID,Quote quote)
        {
            return await service.SubmitQuote(ID, quote);
        }
    }
}
