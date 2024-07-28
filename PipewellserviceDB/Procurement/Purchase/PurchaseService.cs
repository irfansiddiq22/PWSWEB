using PipewellserviceModels.Common;
using PipewellserviceModels.Procurement.Purchase;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB.Procurement.Purchase
{
    public class PurchaseService : DataServices
    {
        public async Task<DataTable> GetPurchaseRequestList(DateParam date, PagingDTO paging, int RequestType)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[5];
                collSP[0] = new SqlParameter { ParameterName = "@PageNo", Value = paging.pageNumber };
                collSP[1] = new SqlParameter { ParameterName = "@PageSize", Value = paging.pageSize };
                collSP[2] = new SqlParameter { ParameterName = "@StartDate", Value = date.StartDate };
                collSP[3] = new SqlParameter { ParameterName = "@EndDate", Value = date.EndDate };
                collSP[4] = new SqlParameter { ParameterName = "@RequestType", Value = RequestType };
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "GetInternalPurchaseList", CommandType.StoredProcedure, collSP);
                DataTable Data = new DataTable();
                Data.Load(result);
                result.Close();
                return Data;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<InternalPurchaseRequestDB> GetPurchaseRequestDetail(int ID)
        {
            try
            {

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetInternalPurchaseRequestDetail", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                InternalPurchaseRequestDB Data = new InternalPurchaseRequestDB();
                Data.InternalPurchase.Load(result);
                Data.InternalPurchaseRequestItem.Load(result);
                result.Close();
                return Data;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<InternalPurchaseRequestDB> GetPurchaseRequestItems(int ID)
        {
            try
            {

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetInternalPurchaseRequestItems", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                InternalPurchaseRequestDB Data = new InternalPurchaseRequestDB();
                Data.InternalPurchaseRequestItem.Load(result);
                result.Close();
                return Data;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<InternalPurchaseRequestResult> AddPurchaseRequest(InternalPurchaseRequest request, List<InternalPurchaseRequestItem> Items)
        {
            InternalPurchaseRequestResult requestResult = new InternalPurchaseRequestResult();
            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<NewDataSet>");
                foreach (InternalPurchaseRequestItem item in Items)
                {
                    xml.Append($"<Table1><ID>{item.ID}</ID><Name>{item.ItemName}</Name><Unit>{item.Unit}</Unit><Quantity>{item.Quantity}</Quantity><Notes>{item.Notes}</Notes><MSDS>{item.MSDS}</MSDS><PartNumber>{item.PartNumber}</PartNumber></Table1>");
                }
                xml.Append("</NewDataSet>");
                SqlParameter[] collSP = new SqlParameter[16];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = request.ID };
                collSP[1] = new SqlParameter { ParameterName = "@Remarks", Value = request.Remarks };
                collSP[2] = new SqlParameter { ParameterName = "@RequestType", Value = request.RequestType };
                collSP[3] = new SqlParameter { ParameterName = "@QuotationNumber", Value = request.QuotationNumber };
                collSP[4] = new SqlParameter { ParameterName = "@DeliveryType", Value = request.DeliveryType };
                collSP[5] = new SqlParameter { ParameterName = "@PaymentType", Value = request.PaymentType };
                collSP[6] = new SqlParameter { ParameterName = "@RequestedBy", Value = request.RequestedBy };
                collSP[7] = new SqlParameter { ParameterName = "@RequestDate", Value = request.RequestDate };
                collSP[8] = new SqlParameter { ParameterName = "@RequestSignDate", Value = request.RequestSignDate };
                collSP[9] = new SqlParameter { ParameterName = "@MaintRequestNumber", Value = request.MaintRequestNumber };

                collSP[10] = new SqlParameter { ParameterName = "@RecordCreatedBy", Value = request.RecordCreatedBy };


                collSP[11] = new SqlParameter { ParameterName = "@FileName", Value = request.FileName };
                collSP[12] = new SqlParameter { ParameterName = "@RequestItems", Value = xml.ToString() };
                collSP[13] = new SqlParameter { ParameterName = "@SupplierID", Value = request.SupplierID };
                collSP[14] = new SqlParameter { ParameterName = "@MaterialRequestID", Value = request.MaterialRequestID };
                collSP[15] = new SqlParameter { ParameterName = "@RecordDate", Value = request.RecordDate };
                

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcAddUpdateInternalPurchaseRequest", CommandType.StoredProcedure, collSP);

                if (result.HasRows)
                {
                    result.Read();
                    requestResult.ID = result.GetInt32(0);
                    requestResult.ApprovalID = result.GetInt32(1);
                }
                return requestResult;
            }
            catch (Exception e)
            {
                return requestResult;
            }

        }
        public  int OutOfStockMaterialRequests()
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(this.ConnectionString, "ProcOutOfStockMaterialRequest", CommandType.StoredProcedure));


        }

    }
}
