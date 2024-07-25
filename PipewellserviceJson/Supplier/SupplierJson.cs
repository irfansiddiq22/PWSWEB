using PipewellserviceDB.Supplier;
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


    }
}
