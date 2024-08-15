using PipewellserviceDB.Common;
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
    public class StoreItemService : DataServices
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
        public async Task<DataTable> GetStoreItemList(PagingDTO paging, string Name)
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
        public async Task<DataTable> FindStoreItem(string Name)
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcFindStoreItem", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@Name", Value = Name });
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
        public async Task<bool> AddStoreItem(Item item, int UserID)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[16];
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
                collSP[14] = new SqlParameter { ParameterName = "@Image", Value = item.Image };
                collSP[15] = new SqlParameter { ParameterName = "@StockQuantity", Value = item.StockQuantity };
                SqlHelper.ExecuteNonQuery(this.ConnectionString, "ProcAddStoreItem", CommandType.StoredProcedure, collSP);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



        public async Task<DataTable> FindReceivingNumber(int OrderID)
        {
            var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcFindReceivingNumber", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@OrderID", Value = OrderID });
            DataTable Data = new DataTable();
            Data.Load(result);
            result.Close();
            return Data;
        }
        

        public async Task<int> AddStoreReceiving(StoreReceiving dto, List<ReceivingItem> items)
        {
            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<DataSet>");
                foreach (ReceivingItem item in items)
                {
                    xml.Append($"<Data><ItemID>{item.ID}</ItemID><Quantity>{item.Quantity}</Quantity><Notes>{ StringHelper.ReplaceXmlChar(item.Notes)}</Notes><UnitCost>{ item.UnitCost }</UnitCost><ItemAvgUnitCost>{ item.ItemAvgUnitCost }</ItemAvgUnitCost><ExpiryDate>{ item.ExpiryDate }</ExpiryDate><PartNumber>{item.PartNumber}</PartNumber><ReceivingQuantity>{item.ReceivingQuantity}</ReceivingQuantity></Data>");
                }
                xml.Append("</DataSet>");
                var parameters = new SqlParameter[]
                {
                    new SqlParameter { ParameterName = "@ID", Value = dto.ID },
                    new SqlParameter { ParameterName = "@PurchaseOrderID", Value = dto.PurchaseOrderID },
                    new SqlParameter { ParameterName = "@ReceivingNumber", Value = dto.ReceivingNumber },
                    new SqlParameter { ParameterName = "@IPRID", Value = dto.IPRID },
                    new SqlParameter { ParameterName = "@RecordDate", Value = dto.RecordDate },
                    new SqlParameter { ParameterName = "@Remarks", Value = StringHelper.NullToString(dto.Remarks) },
                    new SqlParameter { ParameterName = "@VendorInvoice", Value = StringHelper.NullToString(dto.VendorInvoice) },
                    new SqlParameter { ParameterName = "@InvoiceDate", Value = dto.InvoiceDate },
                    new SqlParameter { ParameterName = "@Notes", Value = StringHelper.NullToString(dto.Notes) },
                    new SqlParameter { ParameterName = "@NoteDate", Value = dto.NoteDate },
                    new SqlParameter { ParameterName = "@NonC", Value = dto.NonC },

                    new SqlParameter { ParameterName = "@ReceivedDate", Value = dto.ReceiveDate},
                    new SqlParameter { ParameterName = "@InvoiceFileName"  , Value =StringHelper.NullToString(dto.InvoiceFileName)},
                    new SqlParameter { ParameterName = "@InvoiceFileID"  , Value =StringHelper.NullToString(dto.InvoiceFileID)},

                    new SqlParameter { ParameterName = "@FileName", Value =StringHelper.NullToString(dto.FileName)},
                    new SqlParameter { ParameterName = "@FileID", Value =StringHelper.NullToString(dto.FileID)},
                    new SqlParameter { ParameterName = "@RecordCreatedBy", Value =StringHelper.NullToString(dto.RecordCreatedBy)},
                    new SqlParameter { ParameterName = "@Items", Value = xml.ToString()},


                };


                return Convert.ToInt32(SqlHelper.ExecuteScalar(this.ConnectionString, "ProcAddOrUpdateStoreOrderReceiving", CommandType.StoredProcedure, parameters));


            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public async Task<StoreReceivingViewSQL> StoreReceivingList(StoreReceivingParam param)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[8];
                collSP[0] = new SqlParameter { ParameterName = "@PageNumber", Value = param.pageNumber };
                collSP[1] = new SqlParameter { ParameterName = "@PageSize", Value = param.pageSize };
                collSP[2] = new SqlParameter { ParameterName = "@SupplierID", Value = param.SupplierID };
                collSP[3] = new SqlParameter { ParameterName = "@ReceivingNumber", Value = param.ReceivingNumber };
                collSP[4] = new SqlParameter { ParameterName = "@PurchaseOrderNumber", Value = param.PurchaseOrderNumber };
                collSP[5] = new SqlParameter { ParameterName = "@StartDate", Value = param.StartDate };
                collSP[6] = new SqlParameter { ParameterName = "@EndDate", Value = param.EndDate };
                collSP[7] = new SqlParameter { ParameterName = "@NextID", Value = 0, Direction = ParameterDirection.Output };


                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetStoreReceiving", CommandType.StoredProcedure, collSP);
                StoreReceivingViewSQL Data = new StoreReceivingViewSQL();
                Data.Receivings.Load(result);
                Data.ID = Convert.ToInt32(collSP[7].Value ?? (object)collSP[7].Value);
                result.Close();
                return Data;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<StoreReceiveDetailSQL> FindStoreReceivingDetail(int ReceivingNumber)
        {
            var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetReceivingDetail", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ReceivingNumber", Value = ReceivingNumber });
            StoreReceiveDetailSQL Data = new StoreReceiveDetailSQL();
            Data.Detail.Load(result);
            Data.Items.Load(result);
            result.Close();
            return Data;
        }
        public async Task<StoreReceivingViewSQL> StoreReceivingReturnList(StoreReceivingReturnParam param)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[8];
                collSP[0] = new SqlParameter { ParameterName = "@PageNumber", Value = param.pageNumber };
                collSP[1] = new SqlParameter { ParameterName = "@PageSize", Value = param.pageSize };
                collSP[2] = new SqlParameter { ParameterName = "@SupplierID", Value = param.SupplierID };
                collSP[3] = new SqlParameter { ParameterName = "@ReceivingNumber", Value = param.ReceivingNumber };
                collSP[4] = new SqlParameter { ParameterName = "@PurchaseOrderNumber", Value = param.PurchaseOrderNumber };
                collSP[5] = new SqlParameter { ParameterName = "@StartDate", Value = param.StartDate };
                collSP[6] = new SqlParameter { ParameterName = "@EndDate", Value = param.EndDate };
                collSP[7] = new SqlParameter { ParameterName = "@NextID", Value = 0, Direction = ParameterDirection.Output };


                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetStoreReceivingReturn", CommandType.StoredProcedure, collSP);
                StoreReceivingViewSQL Data = new StoreReceivingViewSQL();
                Data.Receivings.Load(result);
                Data.ID = Convert.ToInt32(collSP[7].Value ?? (object)collSP[7].Value);
                result.Close();
                return Data;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<int> AddStoreReceivingReturn(StoreReceivingReturn dto, List<ReceivingReturnItem> items)
        {
            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<DataSet>");
                foreach (ReceivingReturnItem item in items)
                {
                    xml.Append($"<Data><ItemID>{item.ID}</ItemID><Quantity>{item.Quantity}</Quantity><Notes>{ StringHelper.ReplaceXmlChar(item.Notes)}</Notes><ReturnQuantity>{ item.ReturnQuantity }</ReturnQuantity><ExpiryDate>{ item.ExpiryDate }</ExpiryDate></Data>");
                }
                xml.Append("</DataSet>");
                var parameters = new SqlParameter[]
                {
                    new SqlParameter { ParameterName = "@ID", Value = dto.ID },
                    new SqlParameter { ParameterName = "@ReceivingNumber", Value = dto.ReceivingNumber },
                    new SqlParameter { ParameterName = "@RecordDate", Value = dto.RecordDate },
                    new SqlParameter { ParameterName = "@Remarks", Value = StringHelper.NullToString(dto.Remarks) },
                    new SqlParameter { ParameterName = "@ReturnedBy", Value = dto.ReturnedBy},
                    new SqlParameter { ParameterName = "@ReturnDate", Value = dto.ReturnDate},
                    new SqlParameter { ParameterName = "@RecordCreatedBy", Value =StringHelper.NullToString(dto.RecordCreatedBy)},
                    new SqlParameter { ParameterName = "@Items", Value = xml.ToString()},


                };


                return Convert.ToInt32(SqlHelper.ExecuteScalar(this.ConnectionString, "ProcAddOrUpdateStoreOrderReceivingReturn", CommandType.StoredProcedure, parameters));


            }
            catch (Exception e)
            {
                return 0;
            }
        }
        //-------------------------------------------///
        public async Task<int> AddStoreDelivery(StoreDelivery dto, List<DeliveryItem> items)
        {
            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<DataSet>");
                foreach (DeliveryItem item in items)
                {
                    xml.Append($"<Data><ItemID>{item.ID}</ItemID><Quantity>{item.Quantity}</Quantity><Notes>{ StringHelper.ReplaceXmlChar(item.Notes)}</Notes><UnitCost>{ item.UnitCost }</UnitCost></Data>");
                }
                xml.Append("</DataSet>");
                var parameters = new SqlParameter[]
                {
                    new SqlParameter { ParameterName = "@ID", Value = dto.ID },
                    new SqlParameter { ParameterName = "@MRID", Value = dto.MRID },
                    new SqlParameter { ParameterName = "@DeliveryNumber", Value = dto.DeliveryNumber },
                    new SqlParameter { ParameterName = "@DeliveryDate", Value = dto.DeliveryDate },
                    new SqlParameter { ParameterName = "@WorkOrderID", Value = dto.WorkOrderID ?? (object)DBNull.Value },
                    new SqlParameter { ParameterName = "@Customer", Value = dto.Customer ?? (object)DBNull.Value },
                    new SqlParameter { ParameterName = "@ReceivedBy", Value = dto.ReceivedBy },
                    new SqlParameter { ParameterName = "@Remarks", Value = dto.Remarks ?? (object)DBNull.Value },
                    new SqlParameter { ParameterName = "@RecordCreatedBy", Value =StringHelper.NullToString(dto.RecordCreatedBy)},
                    new SqlParameter { ParameterName = "@Items", Value = xml.ToString()},


                };


                return Convert.ToInt32(SqlHelper.ExecuteScalar(this.ConnectionString, "ProcAddOrUpdateStoreOrderDelivery", CommandType.StoredProcedure, parameters));


            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public async Task<StoreDeliveryViewSQL> StoreDeliveryList(StoreDeliveryParam  param)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[8];
                collSP[0] = new SqlParameter { ParameterName = "@PageNumber", Value = param.pageNumber };
                collSP[1] = new SqlParameter { ParameterName = "@PageSize", Value = param.pageSize };
                collSP[2] = new SqlParameter { ParameterName = "@ReceivedBy", Value = param.ReceivedBy };
                collSP[3] = new SqlParameter { ParameterName = "@WorkOrderID", Value = param.WorkOrderNumber ?? (object)DBNull.Value };
                collSP[4] = new SqlParameter { ParameterName = "@DeliveryNumber", Value = param.DeliveryNumber };
                collSP[5] = new SqlParameter { ParameterName = "@StartDate", Value = param.StartDate };
                collSP[6] = new SqlParameter { ParameterName = "@EndDate", Value = param.EndDate };
                collSP[7] = new SqlParameter { ParameterName = "@NextID", Value = 0, Direction = ParameterDirection.Output };


                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetStoreDelivery", CommandType.StoredProcedure, collSP);
                StoreDeliveryViewSQL Data = new StoreDeliveryViewSQL();
                Data.Delivery.Load(result);
                Data.ID = Convert.ToInt32(collSP[7].Value ?? (object)collSP[7].Value);
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
