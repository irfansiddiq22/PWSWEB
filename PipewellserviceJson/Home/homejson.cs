﻿using PipewellserviceDB.Home;
using PipewellserviceModels.Home;
using System;
using System.Collections.Generic;
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
        
    }
}
