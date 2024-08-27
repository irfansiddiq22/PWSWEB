using PipewellserviceDB.Common;
using PipewellserviceModels.Common;
using PipewellserviceModels.Equipment;
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
    public class EquipmentQuoteService : DataServices
    {
        public async Task<int> SaveQuote(EquipmentQuote quote)
        {
            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<NewDataSet>");
                foreach (EquipmentQuoteItem item in quote.Items)
                {
                    xml.Append($"<Table1><SparePartItemID>{item.SparePartItemID}</SparePartItemID><Description>{ StringHelper.ReplaceXmlChar( item.Description)}</Description><Quantity>{item.Quantity}</Quantity><UnitPrice>{item.UnitPrice}</UnitPrice><Availability>{StringHelper.ReplaceXmlChar(item.Availability)}</Availability><Notes>{StringHelper.ReplaceXmlChar(item.Notes)}</Notes></Table1>");
                }
                xml.Append("</NewDataSet>");


                var collSP = new SqlParameter[]
                {
                    new SqlParameter("@ID", SqlDbType.Int) { Value = quote.ID },
                    new SqlParameter("@SupplierID", SqlDbType.Int) { Value = quote.SupplierID },
                    new SqlParameter("@PaymentTerm", SqlDbType.VarChar) { Value = quote.PaymentTerm },
                    new SqlParameter("@Discount", SqlDbType.Float) { Value = quote.Discount },
                    new SqlParameter("@QuoteDate", SqlDbType.DateTime) { Value = quote.QuoteDate },
                    new SqlParameter("@QuoteID", SqlDbType.VarChar, 50) { Value = quote.QuoteID ?? (object)DBNull.Value },
                    new SqlParameter("@RFQNumber", SqlDbType.VarChar, 50) { Value = quote.RFQNumber ?? (object)DBNull.Value },
                    new SqlParameter("@Accepted", SqlDbType.Bit) { Value = quote.Accepted },
                    new SqlParameter("@Delivered", SqlDbType.Bit) { Value = quote.Delivered },
                    new SqlParameter("@CustomerNotes", SqlDbType.VarChar, 150) { Value = quote.CustomerNotes ?? (object)DBNull.Value },
                    new SqlParameter("@CreditAllowed", SqlDbType.Bit) { Value = quote.CreditAllowed },
                    new SqlParameter("@Remarks", SqlDbType.VarChar) { Value = quote.Remarks ?? (object)DBNull.Value },
                    new SqlParameter("@RecordCreatedBy", SqlDbType.Int) { Value = quote.RecordCreatedBy },
                    new SqlParameter("@Items", SqlDbType.VarChar) { Value = xml.ToString() },

                };


                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcAddOrUpdateEquipmentQuote", CommandType.StoredProcedure, collSP);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public async Task<DataListWithID> List(EquipmentQuoteParam item)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[8];
                collSP[0] = new SqlParameter { ParameterName = "@QuoteID", Value = item.QuoteID };

                collSP[1] = new SqlParameter { ParameterName = "@RFQNumber", Value = item.RFQNumber };
                collSP[2] = new SqlParameter { ParameterName = "@SupplierID", Value = item.SupplierID };
                collSP[3] = new SqlParameter { ParameterName = "@PageNo", Value = item.pageNumber };
                collSP[4] = new SqlParameter { ParameterName = "@PageSize", Value = item.pageSize };

                collSP[5] = new SqlParameter { ParameterName = "@StartDate", Value = item.StartDate };
                collSP[6] = new SqlParameter { ParameterName = "@EndDate", Value = item.EndDate };
                collSP[7] = new SqlParameter { ParameterName = "@NextID", Value = 0,Direction=ParameterDirection.Output };
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetEquipmentQuoteList", CommandType.StoredProcedure, collSP);
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
        public async Task<EquipmentQuoteSQL> QuoteDetail(int ID )
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetEquipmentQuoteDetail", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                EquipmentQuoteSQL Data = new EquipmentQuoteSQL();
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
        public async Task<EquipmentQuoteSQL> QuotePrintDetail(int ID)
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetEquipmentQuotePrintDetail", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                EquipmentQuoteSQL Data = new EquipmentQuoteSQL();
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
        public async Task<EquipmentQuoteSQL> QuoteDetailByID(int ID)
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetEquipmentQuoteDetailByID", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                EquipmentQuoteSQL Data = new EquipmentQuoteSQL();
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
        public async Task<DataTable> QuoteIDList(string ID)
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetEquipmentQuoteIDList", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@QuoteID", Value = ID });
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

        public async Task<int> SaveCollectQuote(EquipmentQuoteCollection dto)
        {
            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<NewDataSet>");
                foreach (EquipQuoteCollectionItems item in dto.Items)
                {
                    xml.Append($"<Table1><SparePartItemID>{item.SparePartItemID}</SparePartItemID><Description>{ StringHelper.ReplaceXmlChar(item.Description)}</Description><Quantity>{item.Quantity}</Quantity><UnitPrice>{item.UnitPrice}</UnitPrice><Notes>{StringHelper.ReplaceXmlChar(item.Notes)}</Notes></Table1>");
                }
                xml.Append("</NewDataSet>");

                var parameters = new SqlParameter[]
                {
                    new SqlParameter { ParameterName = "@ID", SqlDbType = SqlDbType.Int, Value = dto.ID },
                    new SqlParameter { ParameterName = "@QuoteID", SqlDbType = SqlDbType.Int, Value = dto.QuoteID },
                    new SqlParameter { ParameterName = "@DocumentCode", SqlDbType = SqlDbType.VarChar, Size = 100, Value = dto.DocumentCode ?? (object)DBNull.Value },
                    new SqlParameter { ParameterName = "@RecordDate", SqlDbType = SqlDbType.SmallDateTime, Value = dto.RecordDate },
                    new SqlParameter { ParameterName = "@ReceivedBy", SqlDbType = SqlDbType.Int, Value = dto.ReceivedBy },
                    new SqlParameter { ParameterName = "@Freight", SqlDbType = SqlDbType.Float, Value = dto.Freight },
                    new SqlParameter { ParameterName = "@VAT", SqlDbType = SqlDbType.Float, Value = dto.VAT },
                    new SqlParameter { ParameterName = "@Discount", SqlDbType = SqlDbType.Float, Value = dto.Discount },
                    new SqlParameter { ParameterName = "@Total", SqlDbType = SqlDbType.Float, Value = dto.Total },
                    new SqlParameter { ParameterName = "@Remarks", SqlDbType = SqlDbType.VarChar, Size = 500, Value = dto.Remarks ?? (object)DBNull.Value },
                    new SqlParameter { ParameterName = "@RecordCreatedBy", SqlDbType = SqlDbType.Int, Value = dto.RecordCreatedBy },
                    new SqlParameter("@Items", SqlDbType.VarChar) { Value = xml.ToString() },
                };

                var result = SqlHelper.ExecuteScalar(this.ConnectionString, "ProcAddOrUpdateEquipmentQuoteCollect", CommandType.StoredProcedure, parameters);
                return Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<DataTable> QuoteCollectionList(EquipmentQuoteParam item)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[7];
                collSP[0] = new SqlParameter { ParameterName = "@QuoteID", Value = item.QuoteID };

                collSP[1] = new SqlParameter { ParameterName = "@RFQNumber", Value = item.RFQNumber };
                collSP[2] = new SqlParameter { ParameterName = "@SupplierID", Value = item.SupplierID };
                collSP[3] = new SqlParameter { ParameterName = "@PageNo", Value = item.pageNumber };
                collSP[4] = new SqlParameter { ParameterName = "@PageSize", Value = item.pageSize };

                collSP[5] = new SqlParameter { ParameterName = "@StartDate", Value = item.StartDate };
                collSP[6] = new SqlParameter { ParameterName = "@EndDate", Value = item.EndDate };
                
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetEquipmentQuoteCollectionList", CommandType.StoredProcedure, collSP);
                DataListWithID Data = new DataListWithID();
                Data.List.Load(result);
                
                result.Close();
                return Data.List;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<EquipmentQuoteSQL> QuoteCollectionDetail(int ID)
        {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetEquipmentQuoteCollectionDetail", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                EquipmentQuoteSQL Data = new EquipmentQuoteSQL();
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


    }
}
