using PipewellserviceDB.Common;
using PipewellserviceModels.Common;
using PipewellserviceModels.Equipment.SparePart;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB.Equipment
{
   public class EquipmentPurchaseOrderService:DataServices
    {
        public async Task<int> SaveOrder(EquipmentPurchaseOrder Order)
        {
            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<NewDataSet>");
                foreach (EquipmentPurchaseOrderItem item in Order.Items)
                {
                    xml.Append($"<Table1><SparePartItemID>{item.SparePartItemID}</SparePartItemID><Description>{ StringHelper.ReplaceXmlChar(item.Description)}</Description><Quantity>{item.Quantity}</Quantity><UnitPrice>{item.UnitPrice}</UnitPrice><ShippingMethod>{StringHelper.ReplaceXmlChar(item.ShippingMethod)}</ShippingMethod><Currency>{item.Currency}</Currency><Received>{item.Received}</Received></Table1>");
                }
                xml.Append("</NewDataSet>");


                var collSP = new SqlParameter[]
                {
                    new SqlParameter("@ID", Order.ID ),
                    new SqlParameter("@SupplierID", Order.SupplierID ),
                    new SqlParameter("@PaymentTerms",  Order.PaymentTerms ),
                    new SqlParameter("@OrderDate",  Order.OrderDate ),
                    new SqlParameter("@OrderID", Order.OrderID ),
                    new SqlParameter("@Status", Order.Status ),
                    new SqlParameter("@PONO", Order.PONO ),
                    new SqlParameter("@BackOrderTo",  Order.BackOrderTo ),
                    new SqlParameter("@ShipmentMethod",  Order.ShipmentMethod ?? (object)DBNull.Value ),
                    new SqlParameter("@ShippingInstructions",  Order.ShippingInstructions ??(object)DBNull.Value ),
                    new SqlParameter("@DocumentRequired", Order.DocumentRequired ),
                    new SqlParameter("@NotifyInstructions", Order.NotifyInstructions ),
                    new SqlParameter("@RecordCreatedBy",   Order.RecordCreatedBy ),
                    new SqlParameter("@Items",   xml.ToString() ),

                };


                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcAddOrUpdateEquipmentPurchaseOrder", CommandType.StoredProcedure, collSP);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public async Task<DataListWithID> List(EquipmentPurchaseOrderParam param)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[8];
                collSP[0] = new SqlParameter { ParameterName = "@OrderID", Value = param.OrderID ?? "" };

                collSP[1] = new SqlParameter { ParameterName = "@PONO", Value = param.PONO ?? "" };
                collSP[2] = new SqlParameter { ParameterName = "@SupplierID", Value = param.SupplierID };
                collSP[3] = new SqlParameter { ParameterName = "@PageNo", Value = param.pageNumber };
                collSP[4] = new SqlParameter { ParameterName = "@PageSize", Value = param.pageSize };

                collSP[5] = new SqlParameter { ParameterName = "@StartDate", Value = param.StartDate };
                collSP[6] = new SqlParameter { ParameterName = "@EndDate", Value = param.EndDate };
                collSP[7] = new SqlParameter { ParameterName = "@NextID", Direction=ParameterDirection.Output, Value = 0 };
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetEquipmentPurchaseOrderList", CommandType.StoredProcedure, collSP);
                DataListWithID Data = new DataListWithID();
                Data.List.Load(result);
                Data.ID = Convert.ToInt32(collSP[7].Value);
                result.Close();
                return Data;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<EquipmentPurchaseOrderSQL> OrderDetail(int ID)
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetEquipmentPurchaseOrderDetail", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                EquipmentPurchaseOrderSQL Data = new EquipmentPurchaseOrderSQL();
                Data.Detail.Load(result);
                Data.Items.Load(result);
                result.Close();
                return Data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<EquipmentPurchaseOrderDataListSql> OrderListData()
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetEquipmentOrderFormListData", CommandType.StoredProcedure);
                EquipmentPurchaseOrderDataListSql Data = new EquipmentPurchaseOrderDataListSql();
                Data.ShipmentMethods.Load(result);
                Data.ShippingInstructions.Load(result);
                Data.NotifyInstructions.Load(result);
                Data.Currency.Load(result);
                Data.ItemShipmentMethods.Load(result);
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
