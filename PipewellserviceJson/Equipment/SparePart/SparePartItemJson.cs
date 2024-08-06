using PipewellserviceDB.Equipment.SparePart;
using PipewellserviceModels.Equipment.SparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.Equipment.SparePart
{
   public class SparePartItemJson
    {
        private SparePartItemService service = new SparePartItemService();
        public async Task<int> SaveItem(SparePartItem item)
        {
            return await service.SaveItem(item);
        }
    }
}
