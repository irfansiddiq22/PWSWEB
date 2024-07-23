using PipewellserviceDB.Home;
using PipewellserviceModels.Home;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.Home
{
  public  class HomeJson
    {
        private HomeService service = new HomeService();
        public async Task<bool> SavePersonalDetails(PersonalDetail PersonalDetail, List<PersonalWorkExperience> WorkExperience)
        {
            return await service.SavePersonalDetails(PersonalDetail, WorkExperience);

        }
        public async Task<int> SaveSupplierAssesment(SupplierAssesment assesment)
        {
            return await service.SaveSupplierAssesment(assesment);

        }
        public async Task<bool> SaveSupplierAssesmentFiles(int ID,AssessmentFile assesmentFile)
        {
            return await service.SaveSupplierAssesmentFiles(ID,assesmentFile);

        }

        public async Task<List<SupplierAssesment>> SupplierAssessment(SupplierAssessmentParam param)
        {
            var data = await service.SupplierAssessment(param);

            return await JsonHelper.Convert<List<SupplierAssesment>, DataTable>(data);
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
