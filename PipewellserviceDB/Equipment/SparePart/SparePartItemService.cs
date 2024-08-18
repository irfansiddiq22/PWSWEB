using PipewellserviceModels.Equipment.SparePart;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB.Equipment.SparePart
{
    public class SparePartItemService:DataServices
    {

        public async Task<int>SaveItem(SparePartItem item)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[13];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = item.ID };
                collSP[1] = new SqlParameter { ParameterName = "@PartNumber", Value = item.PartNumber };
                collSP[2] = new SqlParameter { ParameterName = "@PartName", Value = item.PartName };
                collSP[3] = new SqlParameter { ParameterName = "@Application", Value = item.Application };
                collSP[4] = new SqlParameter { ParameterName = "@Alternatives", Value = item.Alternatives };
                collSP[5] = new SqlParameter { ParameterName = "@PurchasePrice", Value = item.PurchasePrice };
                collSP[6] = new SqlParameter { ParameterName = "@SalesPrice", Value = item.SalesPrice };
                collSP[7] = new SqlParameter { ParameterName = "@ReOrderLimit", Value = item.ReOrderLimit };
                collSP[8] = new SqlParameter { ParameterName = "@Notes", Value = item.Notes };
                collSP[9] = new SqlParameter { ParameterName = "@InventoryPart", Value = item.InventoryPart };
                collSP[10] = new SqlParameter { ParameterName = "@PartGroup", Value = item.PartGroup };
                collSP[11] = new SqlParameter { ParameterName = "@Location", Value = item.Location     };
                collSP[12] = new SqlParameter { ParameterName = "@RecordCreatdBy", Value = item.RecordCreatdBy };



                var result =  SqlHelper.ExecuteScalar(this.ConnectionString, "ProcAddUpdateSparePartItem", CommandType.StoredProcedure, collSP);
                return  Convert.ToInt32( result);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public async Task<DataTable> List(SparePartItemParam item)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[5];
                collSP[0] = new SqlParameter { ParameterName = "@PartNumber", Value = item.PartName };
                
                collSP[1] = new SqlParameter { ParameterName = "@PartName", Value = item.PartName };
                collSP[2] = new SqlParameter { ParameterName = "@Application", Value = item.Application };
                collSP[3] = new SqlParameter { ParameterName = "@PageNo", Value = item.pageNumber };
                collSP[4] = new SqlParameter { ParameterName = "@PageSize", Value = item.pageSize };
                


                var result =await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetSparePartItems", CommandType.StoredProcedure, collSP);
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
    }
}
