using PipewellserviceDB.Procurement.Purchase;
using PipewellserviceModels.Common;
using PipewellserviceModels.Procurement.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.Procurement.Purchase
{
    public class OrderPurchaseManagmentJson
    {

        private OrderPurchaseManagementService service = new OrderPurchaseManagementService();
        public async Task<List<OrderPurchaseManagement>> GetOrderPurchaseRequestList(DateParam date, PagingDTO paging, PurchaseOrderParam param)
        {
            return await JsonHelper.Convert<List<OrderPurchaseManagement>, DataTable>(await service.GetOrderPurchaseRequestList(date, paging, param));
        }
        public async Task<OrderPurchaseManagementDetail> GetOrderPurchaseRequestDetail(int ID)
        {
            OrderPurchaseManagementDB dB = await service.GetOrderPurchaseDetail(ID);
            OrderPurchaseManagementDetail model = new OrderPurchaseManagementDetail();
            model.Order = (await JsonHelper.Convert<List<OrderPurchaseManagement>, DataTable>(dB.OrderPurchase)).FirstOrDefault();
            model.Items = await JsonHelper.Convert<List<OrderPurchaseManagementItem>, DataTable>(dB.OrderPurchaseItem);

            return model;
        }

        public async Task<OrderPurchaseManagementResult> AddOrderPurchaseManagmentData(OrderPurchaseManagement request, List<OrderPurchaseManagementItem> Items)
        {
            return await service.AddOrderPurchaseManagmentData(request, Items);
        }
        public async Task<List<InterPurchaseOrderNumber>> GetInterPurchaseOrderNumber(string IPO)
        {
            return await JsonHelper.Convert<List<InterPurchaseOrderNumber>, DataTable>(await service.GetInterPurchaseOrderNumber(IPO));
        }
        public async Task<List<SupplierItemRate>> GetSupplierItemRate(int SupplierID,int ItemID)
        {
            return await JsonHelper.Convert<List<SupplierItemRate>, DataTable>(await service.GetSupplierItemRate(SupplierID,ItemID));
        }
        
    }
}
