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
        public async Task<int> AddStoreReceiving(StoreReceiving dto, List<ReceivingItem> items)
        {
            return await itemService.AddStoreReceiving(dto, items);
        }


        public async Task<StoreReceivingView> StoreReceivingList(StoreReceivingParam param)
        {
            StoreReceivingViewSQL data = await itemService.StoreReceivingList(param);
            StoreReceivingView model = new StoreReceivingView();
            model.Receivings= await JsonHelper.Convert<List<StoreReceiving>, DataTable>(data.Receivings);
            model.ID = data.ID;
            model.TotalRecords = model.Receivings.Count==0 ? 0 : model.Receivings[0].TotalRecords;
            
            return model;
        }

        public async Task<int> AddStoreDelivery(StoreDelivery dto, List<DeliveryItem> items)
        {
            return await itemService.AddStoreDelivery(dto, items);
        }


        public async Task<StoreDeliveryView> StoreDeliveryList(StoreDeliveryParam param)
        {
            StoreDeliveryViewSQL data = await itemService.StoreDeliveryList(param);
            StoreDeliveryView model = new StoreDeliveryView();
            model.Delivery = await JsonHelper.Convert<List<StoreDelivery>, DataTable>(data.Delivery);
            model.ID = data.ID;
            model.TotalRecords = model.Delivery.Count == 0 ? 0 : model.Delivery[0].TotalRecords;

            return model;
        }



    }
}
