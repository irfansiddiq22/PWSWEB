using PipewellserviceDB.Equipment;
using PipewellserviceModels.Equipment.SparePart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.Equipment
{
   public  class EquipmentPurchaseOrderJson
    {
        private EquipmentPurchaseOrderService service = new EquipmentPurchaseOrderService();
        public async Task<int> SaveOrder(EquipmentPurchaseOrder order)
        {
            return await service.SaveOrder(order);
        }
        public async Task<EquipmentPurchaseOrderListView> List(EquipmentPurchaseOrderParam param)
        {
            var Data = await service.List(param);
            EquipmentPurchaseOrderListView model = new EquipmentPurchaseOrderListView();
             model.List= await JsonHelper.Convert<List<EquipmentPurchaseOrderList>, DataTable>(Data.List);
            model.ID = Data.ID;
            return model;
        }
        public async Task<EquipmentPurchaseOrderList> OrderDetail(int ID)
        {
            var Data = await service.OrderDetail(ID);
            EquipmentPurchaseOrderList equipmentOrder = new EquipmentPurchaseOrderList();
            equipmentOrder = (await JsonHelper.Convert<List<EquipmentPurchaseOrderList>, DataTable>(Data.Detail)).FirstOrDefault();
            equipmentOrder.Items = await JsonHelper.Convert<List<EquipmentPurchaseOrderItem>, DataTable>(Data.Items);
            return equipmentOrder;
        }
        public async Task<EquipmentPurchaseOrderDataLists> OrderListData()
        {
            EquipmentPurchaseOrderDataListSql Data = await service.OrderListData();
            EquipmentPurchaseOrderDataLists model = new EquipmentPurchaseOrderDataLists();
            model.ShipmentMethods = await JsonHelper.Convert<List<EquipmentPurchaseOrderDataList>, DataTable>(Data.ShipmentMethods);
            model.NotifyInstructions = await JsonHelper.Convert<List<EquipmentPurchaseOrderDataList>, DataTable>(Data.NotifyInstructions);
            model.ShippingInstructions = await JsonHelper.Convert<List<EquipmentPurchaseOrderDataList>, DataTable>(Data.ShippingInstructions);
            model.Currency = await JsonHelper.Convert<List<EquipmentPurchaseOrderDataList>, DataTable>(Data.Currency);
            model.ItemShipmentMethods = await JsonHelper.Convert<List<EquipmentPurchaseOrderDataList>, DataTable>(Data.ItemShipmentMethods);

            return model;
        }
    }
}
