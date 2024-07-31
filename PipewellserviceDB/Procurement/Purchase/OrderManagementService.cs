using PipewellserviceModels.Common;
using PipewellserviceModels.HR.Employee;
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
    public class PurchaseOrderManagementService : DataServices
    {
        public async Task<DataTable> GetPurchaseOrderRequestList(DateParam date, PagingDTO paging, PurchaseOrderParam param)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[7];
                collSP[0] = new SqlParameter { ParameterName = "@PageNo", Value = paging.pageNumber };
                collSP[1] = new SqlParameter { ParameterName = "@PageSize", Value = paging.pageSize };
                collSP[2] = new SqlParameter { ParameterName = "@StartDate", Value = date.StartDate };
                collSP[3] = new SqlParameter { ParameterName = "@EndDate", Value = date.EndDate };

                collSP[4] = new SqlParameter { ParameterName = "@SupplierID", Value = param.SupplierID };
                collSP[5] = new SqlParameter { ParameterName = "@ID", Value = param.ID };
                collSP[6] = new SqlParameter { ParameterName = "@RequestedBy", Value = param.RequestedBy };

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetPurchaseOrderManagementList", CommandType.StoredProcedure, collSP);
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
        public async Task<PurchaseOrderManagementDB> GetPurchaseOrderDetail(int ID)
        {
            try
            {

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetPurchaseOrderManagementDetail", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                PurchaseOrderManagementDB Data = new PurchaseOrderManagementDB();
                Data.PurchaseOrder.Load(result);
                Data.OrderItem.Load(result);
                Data.Approvals.Load(result);
                result.Close();
                return Data;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public async Task<DataTable> GetPurchaseOrderApprovals(int ID)
        {
            try
            {

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetPurchasOrderApprovals", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
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
        public async Task<PurchaseOrderManagementResult> AddPurchaseOrderManagmentData(PurchaseOrderManagement request, List<EmployeeApproval> approvals, List<PurchaseOrderManagementItem> Items)
        {
            PurchaseOrderManagementResult requestResult = new PurchaseOrderManagementResult();
            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<NewDataSet>");
                foreach (PurchaseOrderManagementItem item in Items)
                {
                    xml.Append($"<Table1><ID>{item.ID}</ID><Name>{item.ItemName}</Name><UnitCost>{item.UnitCost}</UnitCost><Unit>{item.Unit}</Unit><Quantity>{item.Quantity}</Quantity><Notes>{item.Notes}</Notes><MSDS>{item.MSDS}</MSDS><PartNumber>{item.PartNumber}</PartNumber></Table1>");
                }
                xml.Append("</NewDataSet>");

                StringBuilder xmlApprovals = new StringBuilder();
                xmlApprovals.Append("<NewDataSet>");
                foreach (EmployeeApproval item in approvals)
                {
                    xmlApprovals.Append($"<Table1><ID>{item.ID}</ID><DivisionID>{item.DivisionID}</DivisionID><SupervisorID>{item.SupervisorID}</SupervisorID></Table1>");
                }
                xmlApprovals.Append("</NewDataSet>");

                SqlParameter[] collSP = new SqlParameter[28];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = request.ID };
                collSP[1] = new SqlParameter { ParameterName = "@SupplierID", Value = request.SupplierID };
                collSP[2] = new SqlParameter { ParameterName = "@Attn", Value = request.Attn };
                collSP[3] = new SqlParameter { ParameterName = "@InternalPurchaseOrderNumber", Value = request.InternalPurchaseOrderNumber };
                collSP[4] = new SqlParameter { ParameterName = "@RequiredDate", Value = request.RequiredDate };
                collSP[5] = new SqlParameter { ParameterName = "@ContractPeriodFrom", Value = request.ContractPeriodFrom };
                collSP[6] = new SqlParameter { ParameterName = "@ContractPeriodTo", Value = request.ContractPeriodTo };
                collSP[7] = new SqlParameter { ParameterName = "@WarrantyPeriod", Value = request.WarrantyPeriod };
                collSP[8] = new SqlParameter { ParameterName = "@LongTermContract", Value = request.LongTermContract };
                collSP[9] = new SqlParameter { ParameterName = "@Calibration", Value = request.Calibration };
                collSP[10] = new SqlParameter { ParameterName = "@Certification", Value = request.Certification };
                collSP[11] = new SqlParameter { ParameterName = "@Remarks", Value = request.Remarks };
                collSP[12] = new SqlParameter { ParameterName = "@Currency", Value = request.Currency };
                collSP[13] = new SqlParameter { ParameterName = "@Freight", Value = request.Freight };
                collSP[14] = new SqlParameter { ParameterName = "@VAT", Value = request.VAT };
                collSP[15] = new SqlParameter { ParameterName = "@Discount", Value = request.Discount };
                collSP[16] = new SqlParameter { ParameterName = "@ShowVatOnInvoice", Value = request.ShowVatOnInvoice };
                collSP[17] = new SqlParameter { ParameterName = "@DeliveryType", Value = request.DeliveryType };
                collSP[18] = new SqlParameter { ParameterName = "@PaymentType", Value = request.PaymentType };
                collSP[19] = new SqlParameter { ParameterName = "@RequestedBy", Value = request.RequestedBy };
                collSP[20] = new SqlParameter { ParameterName = "@RequestDate", Value = request.RequestDate };
                collSP[21] = new SqlParameter { ParameterName = "@RequestPerpDate", Value = request.RequestPerpDate };
                collSP[22] = new SqlParameter { ParameterName = "@DepartmentID", Value = request.DepartmentID };
                collSP[23] = new SqlParameter { ParameterName = "@RecordCreatedBy", Value = request.RecordCreatedBy };
                collSP[24] = new SqlParameter { ParameterName = "@OrderItems", Value = xml.ToString() };
                collSP[25] = new SqlParameter { ParameterName = "@RecordDate", Value = request.RecordDate };
                collSP[26] = new SqlParameter { ParameterName = "@Total", Value = request.Total };

                collSP[27] = new SqlParameter { ParameterName = "@Approvals", Value = xmlApprovals.ToString() };

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcAddUpdatePurchaseOrderManagementDetail", CommandType.StoredProcedure, collSP);

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

        public async Task<DataTable> GetInterPurchaseOrderNumber(string IPO) {
            try
            {
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetInterPurchaseOrderNumber", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@IPO", Value = IPO });
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
        public async Task<DataTable> GetSupplierItemRate(int SupplierID, int ItemID)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[2];
                collSP[0] = new SqlParameter { ParameterName = "@ItemID", Value = ItemID };
                collSP[1] = new SqlParameter { ParameterName = "@SupplierID", Value = SupplierID };
                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetSupplierItemRate", CommandType.StoredProcedure, collSP);
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
        public async Task<DataTable> FindPurchaseOrder(int OrderID)
        {
            var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcFindPurchaseOrderNumber", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@OrderID", Value = OrderID });
            DataTable Data = new DataTable();
            Data.Load(result);
            result.Close();
            return Data;
        }
        public async Task<PurchaseOrderManagementDB> GetPurchaseOrderItems(int ID)
        {
            try
            {

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetPurchaseOrderItems", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                PurchaseOrderManagementDB Data = new PurchaseOrderManagementDB();
                Data.PurchaseOrder.Load(result);
                Data.OrderItem.Load(result);
                
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
