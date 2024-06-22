using PipewellserviceDB.Procurement.Store;
using PipewellserviceModels.Common;
using PipewellserviceModels.Procurement;
using PipewellserviceModels.Procurement.Store;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.Procurement.Store
{
   public class StoreItemJson
    {
        private StoreItemService itemService = new StoreItemService();
        public async Task<List<ItemUnit>> GetStoreItemUnit()
        {
          return  await JsonHelper.Convert<List<ItemUnit>, DataTable>(await itemService.GetStoreItemUnit());
        }
        public async Task<List<Item>> GetStoreItemList(PagingDTO paging, string Name)
        {
            return await JsonHelper.Convert<List<Item>, DataTable>(await itemService.GetStoreItemList(paging, Name));
        }
        public async Task<List<Item>> FindStoreItem(string Name)
        {
            return await JsonHelper.Convert<List<Item>, DataTable>(await itemService.FindStoreItem( Name));
        }
        

        public async Task<bool> AddStoreItem(Item item,int UserID)
        {
            return await itemService.AddStoreItem(item,UserID);
        }
        


    }
}
