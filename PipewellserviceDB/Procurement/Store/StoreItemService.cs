using PipewellserviceModels.Common;
using PipewellserviceModels.Procurement.Store;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB.Procurement.Store
{
    public class StoreItemService:DataServices
    {
        public async Task<DataTable> GetStoreItemUnit()
        {

            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetStoreItemUnit", CommandType.StoredProcedure);
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
        public async Task<DataTable> GetStoreItemList(PagingDTO paging,string Name)
        {

            try
            {
                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@PageNo", Value = paging.pageNumber };
                collSP[1] = new SqlParameter { ParameterName = "@PageSize", Value = paging.pageSize };
                collSP[2] = new SqlParameter { ParameterName = "@Name", Value = Name };
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetStoreItemList", CommandType.StoredProcedure, collSP);
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
        public async Task<bool> AddStoreItem(Item item,int UserID)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[14];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = item.ID };
                collSP[1] = new SqlParameter { ParameterName = "@ItemCode", Value = item.ItemCode };
                collSP[2] = new SqlParameter { ParameterName = "@Name", Value = item.Name };
                collSP[3] = new SqlParameter { ParameterName = "@Unit", Value = item.Unit };
                collSP[4] = new SqlParameter { ParameterName = "@OpeningStock", Value = item.OpeningStock };
                collSP[5] = new SqlParameter { ParameterName = "@ReOrderLimit", Value = item.ReOrderLimit };
                collSP[6] = new SqlParameter { ParameterName = "@Packing", Value = item.Packing };
                collSP[7] = new SqlParameter { ParameterName = "@Location", Value = item.Location };
                collSP[8] = new SqlParameter { ParameterName = "@PartNumber", Value = item.PartNumber };
                collSP[9] = new SqlParameter { ParameterName = "@StockItem", Value = item.StockItem };
                collSP[10] = new SqlParameter { ParameterName = "@CreticalItem", Value = item.CreticalItem };
                collSP[11] = new SqlParameter { ParameterName = "@Active", Value = item.Active };
                collSP[12] = new SqlParameter { ParameterName = "@Tengible", Value = item.Tengible };
                collSP[13] = new SqlParameter { ParameterName = "@RecordUpdatedBy", Value = UserID };
                SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcAddStoreItem", CommandType.StoredProcedure, collSP);

                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}
