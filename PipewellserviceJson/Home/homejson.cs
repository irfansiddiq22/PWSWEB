using PipewellserviceDB.Home;
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
    }
}
