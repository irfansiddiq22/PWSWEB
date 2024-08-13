using System;
using PipewellserviceModels.Common;
using PipewellserviceModels.Procurement.Store;
using SQLHelper;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipewellserviceModels.Procurement;

namespace PipewellserviceDB.Procurement
{
    public class ProcurementService : DataServices
    {
        public async Task<DataTable> GetMatrialRequestList(DateParam date, PagingDTO paging, int RequestType,int EmployeeID)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[6];
                collSP[0] = new SqlParameter { ParameterName = "@PageNo", Value = paging.pageNumber };
                collSP[1] = new SqlParameter { ParameterName = "@PageSize", Value = paging.pageSize };
                collSP[2] = new SqlParameter { ParameterName = "@StartDate", Value = date.StartDate };
                collSP[3] = new SqlParameter { ParameterName = "@EndDate", Value = date.EndDate };
                collSP[4] = new SqlParameter { ParameterName = "@RequestType", Value = RequestType };
                collSP[5] = new SqlParameter { ParameterName = "@EmployeeID", Value = EmployeeID };
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "GetProcurementMaterialList", CommandType.StoredProcedure, collSP);
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

        public async Task<DataTable> GetOutofStockMatrialRequest(PagingDTO paging)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@PageNo", Value = paging.pageNumber };
                collSP[1] = new SqlParameter { ParameterName = "@PageSize", Value = paging.pageSize };
                
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "GetOutOfStockProcurementMaterialList", CommandType.StoredProcedure, collSP);
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
        public async Task<MaterialRequestDB> GetMatrialRequestDetail(int ID)
        {
            try
            {
                
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetMaterialRequestDetail", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                MaterialRequestDB Data = new MaterialRequestDB();
                Data.MaterialRequest.Load(result);
                Data.MaterialRequestItem.Load(result);
                result.Close();
                return Data;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<MaterialRequestDB> GetIPRMatrialRequestItems(int ID)
        {
            try
            {

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetIPRMaterialRequestItems", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                MaterialRequestDB Data = new MaterialRequestDB();
                Data.MaterialRequest.Load(result);
                Data.MaterialRequestItem.Load(result);
                result.Close();
                return Data;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<MaterialRequestDB> GetMatrialRequestDeliveryItems(int ID)
        {
            try
            {

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "GetMatrialRequestDeliveryItems", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                MaterialRequestDB Data = new MaterialRequestDB();

                Data.MaterialRequestItem.Load(result);
                result.Close();
                return Data;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        

        public async Task<MaterialRequestResult> AddMaterialRequest(MaterialRequest request, List<MaterialRequestItem> Items)
        {
            MaterialRequestResult requestResult = new MaterialRequestResult();
            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<NewDataSet>");
                foreach (MaterialRequestItem item in Items){
                    xml.Append($"<Table1><ID>{item.ID}</ID><Name>{item.ItemName}</Name><Unit>{item.Unit}</Unit><Quantity>{item.Quantity}</Quantity><Notes>{item.Notes}</Notes></Table1>");
                }
                xml.Append("</NewDataSet>");
                SqlParameter[] collSP = new SqlParameter[8];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = request.ID };
                collSP[1] = new SqlParameter { ParameterName = "@RequestDate", Value = request.RequestDate };
                collSP[2] = new SqlParameter { ParameterName = "@RequestedBy", Value = request.RequestedBy };
                collSP[3] = new SqlParameter { ParameterName = "@Remarks", Value = request.Remarks };
                collSP[4] = new SqlParameter { ParameterName = "@RequestType", Value = request.RequestType };
                collSP[5] = new SqlParameter { ParameterName = "@RecordCreatedBy", Value = request.RecordCreatedBy };
                collSP[6] = new SqlParameter { ParameterName = "@FileName", Value = request.FileName };
                collSP[7] = new SqlParameter { ParameterName = "@RequestItems", Value = xml.ToString() };

                var result =  await SqlHelper.ExecuteReader(this.ConnectionString, "ProcAddUpdateMaterialRequest", CommandType.StoredProcedure, collSP);
                
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

        public async Task<DataTable> FindMatrialRequestNumber(string ID)
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "FindMatrialRequestNumber", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
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

        public async Task<DataTable> GetProcurementSuperVisior()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetProcurementSuperVisior", CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
