using PipewellserviceDB.Procurement.Store;
using PipewellserviceModels.Common;
using PipewellserviceModels.Procurement;
using PipewellserviceModels.Procurement.Purchase;
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
        public async Task<List<PurchaseOrderNumber>> FindReceivingNumber(int OrderID)
        {
            return await JsonHelper.Convert<List<PurchaseOrderNumber>, DataTable>(await itemService.FindReceivingNumber(OrderID));
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

        public async Task<StoreReceiveDetail> FindStoreReceivingDetail(int ReceivingNumber)
        {
            StoreReceiveDetailSQL data = await itemService.FindStoreReceivingDetail(ReceivingNumber);
            StoreReceiveDetail model = new StoreReceiveDetail();
            model.Detail =( await JsonHelper.Convert<List<StoreReceiving>, DataTable>(data.Detail)).FirstOrDefault();

            model.Items = await JsonHelper.Convert<List<ReceivingItem>, DataTable>(data.Items);

            return model;
        }


        public async Task<int> AddStoreReceivingReturn(StoreReceivingReturn dto, List<ReceivingReturnItem> items)
        {
            return await itemService.AddStoreReceivingReturn(dto, items);
        }


        public async Task<StoreReceivingReturnView> StoreReceivingReturnList(StoreReceivingReturnParam param)
        {
            StoreReceivingViewSQL data = await itemService.StoreReceivingReturnList(param);
            StoreReceivingReturnView model = new StoreReceivingReturnView();
            model.Receivings = await JsonHelper.Convert<List<StoreReceivingReturn>, DataTable>(data.Receivings);
            model.ID = data.ID;
            model.TotalRecords = model.Receivings.Count == 0 ? 0 : model.Receivings[0].TotalRecords;

            return model;
        }
        //--------------------------//

        
        public async Task<List<PurchaseOrderNumber>> FindDeliveryNumber(int OrderID)
        {
            return await JsonHelper.Convert<List<PurchaseOrderNumber>, DataTable>(await itemService.FindDeliveryNumber(OrderID));
        }
        public async Task<StoreDeliveryDetail> FindStoreDeliveryDetail(int DeliveryNumber)
        {
            StoreDeliveryDetailSQL data = await itemService.FindStoreDeliveryDetail(DeliveryNumber);
            StoreDeliveryDetail model = new StoreDeliveryDetail();
            model.Detail = (await JsonHelper.Convert<List<StoreDelivery>, DataTable>(data.Detail)).FirstOrDefault();

            model.Items = await JsonHelper.Convert<List<DeliveryItem>, DataTable>(data.Items);

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
        public async Task<int> AddStoreDeliveryReturn(StoreDeliveryReturn dto, List<DeliveryReturnItem> items)
        {
            return await itemService.AddStoreDeliveryReturn(dto, items);
        }


        public async Task<StoreDeliveryReturnView> StoreDeliveryReturnList(StoreDeliveryReturnParam param)
        {
            StoreDeliveryViewSQL data = await itemService.StoreDeliveryReturnList(param);
            StoreDeliveryReturnView model = new StoreDeliveryReturnView();
            model.Delivery = await JsonHelper.Convert<List<StoreDeliveryReturn>, DataTable>(data.Delivery);
            
            model.TotalRecords = model.Delivery.Count == 0 ? 0 : model.Delivery[0].TotalRecords;

            return model;
        }


        



    }
}
