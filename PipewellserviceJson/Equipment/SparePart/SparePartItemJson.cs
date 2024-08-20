using PipewellserviceDB.Equipment.SparePart;
using PipewellserviceModels.Equipment.SparePart;
using System;
using System.Collections.Generic;
using System.Data;
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
        public async Task<List<SparePartItemList>> List(SparePartItemParam item)
        {
            var Data= await service.List(item);
            return await JsonHelper.Convert<List<SparePartItemList>, DataTable>(Data);
        }
        public async Task<List<SparePartItem>> FindByName(string Name)
        {
            var Data = await service.FindByName(Name);
            return await JsonHelper.Convert<List<SparePartItem>, DataTable>(Data);
        }
    }
}
