using PipewellserviceDB.Procurement.Purchase;
using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
using PipewellserviceModels.Procurement.Purchase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.Procurement.Purchase
{
    public class PurchaseOrderManagmentJson
    {

        private PurchaseOrderManagementService service = new PurchaseOrderManagementService();
        public async Task<List<PurchaseOrderManagement>> GetPurchaseOrderRequestList(DateParam date, PagingDTO paging, PurchaseOrderParam param)
        {
            return await JsonHelper.Convert<List<PurchaseOrderManagement>, DataTable>(await service.GetPurchaseOrderRequestList(date, paging, param));
        }
        public async Task<PurchaseOrderManagementDetail> GetPurchaseOrderRequestDetail(int ID)
        {
            PurchaseOrderManagementDB dB = await service.GetPurchaseOrderDetail(ID);
            PurchaseOrderManagementDetail model = new PurchaseOrderManagementDetail();
            model.Order = (await JsonHelper.Convert<List<PurchaseOrderManagement>, DataTable>(dB.PurchaseOrder)).FirstOrDefault();
            model.Items = await JsonHelper.Convert<List<PurchaseOrderManagementItem>, DataTable>(dB.OrderItem);
            model.Approvals = await JsonHelper.Convert<List<EmployeeApproval>, DataTable>(dB.Approvals);

            return model;
        }

        public async Task<PurchaseOrderManagementResult> AddPurchaseOrderManagmentData(PurchaseOrderManagement request, List<EmployeeApproval> approvals, List<PurchaseOrderManagementItem> Items)
        {
            return await service.AddPurchaseOrderManagmentData(request,approvals, Items);
        }
        public async Task<List<InterPurchaseOrderNumber>> GetInterPurchaseOrderNumber(string IPO)
        {
            return await JsonHelper.Convert<List<InterPurchaseOrderNumber>, DataTable>(await service.GetInterPurchaseOrderNumber(IPO));
        }
        public async Task<List<SupplierItemRate>> GetSupplierItemRate(int SupplierID,int ItemID)
        {
            return await JsonHelper.Convert<List<SupplierItemRate>, DataTable>(await service.GetSupplierItemRate(SupplierID,ItemID));
        }
        public async Task<List<PurchaseOrderNumber>> FindPurchaseOrder(int OrderID)
        {
            return await JsonHelper.Convert<List<PurchaseOrderNumber>, DataTable>(await service.FindPurchaseOrder(OrderID));
        }
        public async Task<PurchaseOrderManagementDetail> GetPurchaseOrderRequestItems(int ID)
        {
            PurchaseOrderManagementDB dB = await service.GetPurchaseOrderItems(ID);
            PurchaseOrderManagementDetail model = new PurchaseOrderManagementDetail();
            model.Order = (await JsonHelper.Convert<List<PurchaseOrderManagement>, DataTable>(dB.PurchaseOrder)).FirstOrDefault();
            model.Items = await JsonHelper.Convert<List<PurchaseOrderManagementItem>, DataTable>(dB.OrderItem);
            

            return model;
        }


    }
}
