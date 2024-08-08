using PipewellserviceDB.Procurement.Purchase;
using PipewellserviceModels.Account;
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
    public class PurchaseJson
    {
        private PurchaseService service = new PurchaseService();
        public async Task<List<InternalPurchaseRequest>> GetPurchaseRequestList(DateParam date, PagingDTO paging, int RequestType)
        {
            return await JsonHelper.Convert<List<InternalPurchaseRequest>, DataTable>(await service.GetPurchaseRequestList(date, paging, RequestType));
        }
        public async Task<List<InternalPurchaseRequest>> GetPedingRequestList(PagingDTO paging)
        {
            return await JsonHelper.Convert<List<InternalPurchaseRequest>, DataTable>(await service.GetPedingRequestList(paging));
        }

        public async Task<InternalPurchaseRequestDetail> GetPurchaseRequestDetail(int ID)
        {
            InternalPurchaseRequestDB dB = await service.GetPurchaseRequestDetail(ID);
            InternalPurchaseRequestDetail model = new InternalPurchaseRequestDetail();
            model.Request = (await JsonHelper.Convert<List<InternalPurchaseRequest>, DataTable>(dB.InternalPurchase)).FirstOrDefault();
            model.Items = await JsonHelper.Convert<List<InternalPurchaseRequestItem>, DataTable>(dB.InternalPurchaseRequestItem);

            return model;
        }
        public async Task<List<InternalPurchaseRequestItem>> GetPurchaseRequestItems(int ID)
        {
            InternalPurchaseRequestDB dB = await service.GetPurchaseRequestDetail(ID);
            return await JsonHelper.Convert<List<InternalPurchaseRequestItem>, DataTable>(dB.InternalPurchaseRequestItem);
        }



        public async Task<InternalPurchaseRequestResult> AddPurchaseRequest(InternalPurchaseRequest request, List<InternalPurchaseRequestItem> Items)
        {
            return await service.AddPurchaseRequest(request, Items);
        }

        public async Task<List<SuplierContact>> SaveRequestForQuote(int IPO,int RecordCreatedBy, string Suppliers)
        {
            try
            {
                DataTable data = await service.SaveRequestForQuote(IPO, RecordCreatedBy, Suppliers);
                return await JsonHelper.Convert<List<SuplierContact>, DataTable>(data);
            }
            catch (Exception)
            {
                return null; 
            }
        }
    }
}


