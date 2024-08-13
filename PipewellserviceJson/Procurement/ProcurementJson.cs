using PipewellserviceDB.Procurement;
using PipewellserviceModels.Common;
using PipewellserviceModels.Procurement;
using PipewellserviceModels.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceJson.Procurement
{
   public class ProcurementJson
    {
        private ProcurementService service = new ProcurementService();
        public async Task<List<MaterialRequest>> GetMatrialRequestList(DateParam date, PagingDTO paging, int RequestType,int EmployeeID)
        {
            return await JsonHelper.Convert<List<MaterialRequest>, DataTable>(await service.GetMatrialRequestList(date, paging, RequestType, EmployeeID));
        }
        public async Task<List<MaterialRequest>> GetOutofStockMatrialRequest(PagingDTO paging)
        {
            return await JsonHelper.Convert<List<MaterialRequest>, DataTable>(await service.GetOutofStockMatrialRequest( paging));
        }
        public async Task<List<MaterialRequest>> PendingDeliveyMatrialRequest(PagingDTO paging)
        {
            return await JsonHelper.Convert<List<MaterialRequest>, DataTable>(await service.PendingDeliveyMatrialRequest(paging));
        }

        
        public async Task<MaterialRequestDetail> GetMatrialRequestDetail(int ID)
        {
            MaterialRequestDB dB= await service.GetMatrialRequestDetail(ID);
            MaterialRequestDetail model = new MaterialRequestDetail();
            model.Request = (await JsonHelper.Convert<List<MaterialRequest>, DataTable>(dB.MaterialRequest)).FirstOrDefault();
            model.Items = await JsonHelper.Convert<List<MaterialRequestItem>, DataTable>(dB.MaterialRequestItem);

            return model;
        }
        public async Task<MaterialRequestDetail> GetIPRMatrialRequestItems(int ID)
        {
            MaterialRequestDB dB = await service.GetIPRMatrialRequestItems(ID);
            MaterialRequestDetail model = new MaterialRequestDetail();
            model.Request=( await JsonHelper.Convert<List<MaterialRequest>, DataTable>(dB.MaterialRequest)).FirstOrDefault();
            model.Items = await JsonHelper.Convert<List<MaterialRequestItem>, DataTable>(dB.MaterialRequestItem);

            return model;
        }
        public async Task<List<MaterialRequestItem>> GetMatrialRequestDeliveryItems(int ID)
        {
            MaterialRequestDB dB = await service.GetMatrialRequestDeliveryItems(ID);

            return await JsonHelper.Convert<List<MaterialRequestItem>, DataTable>(dB.MaterialRequestItem);


        }

        
        public async Task<MaterialRequestResult> AddMaterialRequest(MaterialRequest request, List<MaterialRequestItem> Items) {
            return await service.AddMaterialRequest(request,Items);
        }
        
           public async Task<List<MaterialRequestNumber>> FindMatrialRequestNumber(string ID)
        {
            return await JsonHelper.Convert<List<MaterialRequestNumber>, DataTable>(await service.FindMatrialRequestNumber(ID));
        }
        public async Task<User> GetProcurementSuperVisior()
        {
            return (await JsonHelper.Convert<List<User>, DataTable>(await service.GetProcurementSuperVisior())).FirstOrDefault();
        }
        
    }
}
