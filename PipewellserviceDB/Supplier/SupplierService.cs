using PipewellserviceDB.Common;
using PipewellserviceModels.Account;
using PipewellserviceModels.Supplier;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceDB.Supplier
{
    public class SupplierService : DataServices
    {



        public async Task<int> SaveRegistration(SupplierAssesment assesment)
        {
            try
            {
                StringBuilder items = new StringBuilder();
                StringBuilder customers = new StringBuilder();
                StringBuilder productions = new StringBuilder();
                StringBuilder qualtycontrol = new StringBuilder();
                items.AppendLine("<NewDataSet>");
                if (assesment.SupplierItems != null && assesment.SupplierItems.Count > 0)
                {
                    foreach (SupplierItem a in assesment.SupplierItems)
                    {
                        items.AppendLine($"<Table1><ItemName>{ StringHelper.ReplaceXmlChar(a.ItemServiceName)}</ItemName></Table1>");
                    }
                }
                items.AppendLine("</NewDataSet>");


                customers.AppendLine("<NewDataSet>");
                if (assesment.SupplierCustomers != null && assesment.SupplierCustomers.Count > 0)
                {
                    foreach (SupplierCustomer a in assesment.SupplierCustomers)
                    {
                        customers.AppendLine($"<Table1><CustomerName>{ StringHelper.ReplaceXmlChar(a.CustomerName)}</CustomerName><ItemServiceName>{ StringHelper.ReplaceXmlChar(a.ItemServiceName)}</ItemServiceName><TurnOver>{ StringHelper.ReplaceXmlChar(a.TurnOver)}</TurnOver></Table1>");
                    }
                }
                customers.AppendLine("</NewDataSet>");
                productions.AppendLine("<NewDataSet>");
                if (assesment.SupplierProductionFacilities != null && assesment.SupplierProductionFacilities.Count > 0)
                {
                    foreach (SupplierProductionFacility a in assesment.SupplierProductionFacilities)
                    {
                        productions.AppendLine($"<Table1><MachineName>{ StringHelper.ReplaceXmlChar(a.MachineName)}</MachineName><Model>{ StringHelper.ReplaceXmlChar(a.Model)}</Model><NoOfMachines>{ StringHelper.ReplaceXmlChar(a.NoOfMachines)}</NoOfMachines></Table1>");
                    }
                }
                productions.AppendLine("</NewDataSet>");

                qualtycontrol.AppendLine("<NewDataSet>");
                if (assesment.SupplierQualityControlFacilities != null && assesment.SupplierQualityControlFacilities.Count > 0)
                {
                    foreach (SupplierQualityControlFacility a in assesment.SupplierQualityControlFacilities)
                    {
                        qualtycontrol.AppendLine($"<Table1><EquipmentDescription>{ StringHelper.ReplaceXmlChar(a.EquipmentDescription)}</EquipmentDescription><Range>{ StringHelper.ReplaceXmlChar(a.Range)}</Range><Quantity>{ StringHelper.ReplaceXmlChar(a.Quantity)}</Quantity></Table1>");
                    }
                }
                qualtycontrol.AppendLine("</NewDataSet>");


                SqlParameter[] parameters = new SqlParameter[60];
                parameters[0] = new SqlParameter { ParameterName = "@ID", Value = assesment.ID };
                parameters[1] = new SqlParameter { ParameterName = "@Assessment", Value = assesment.Assessment };
                parameters[2] = new SqlParameter { ParameterName = "@RecordDate", Value = assesment.RecordDate };
                parameters[3] = new SqlParameter { ParameterName = "@CompanyName", Value = StringHelper.NullToString(assesment.CompanyName) };
                parameters[4] = new SqlParameter { ParameterName = "@PoBox", Value = StringHelper.NullToString(assesment.PoBox) };
                parameters[5] = new SqlParameter { ParameterName = "@PostalCode", Value = StringHelper.NullToString(assesment.PostalCode) };
                parameters[6] = new SqlParameter { ParameterName = "@Street", Value = StringHelper.NullToString(assesment.Street) };
                parameters[7] = new SqlParameter { ParameterName = "@City", Value = StringHelper.NullToString(assesment.City) };
                parameters[8] = new SqlParameter { ParameterName = "@Region", Value = StringHelper.NullToString(assesment.Region) };
                parameters[9] = new SqlParameter { ParameterName = "@Country", Value = StringHelper.NullToString(assesment.Country) };
                parameters[10] = new SqlParameter { ParameterName = "@Website", Value = StringHelper.NullToString(assesment.Website) };
                parameters[11] = new SqlParameter { ParameterName = "@GeneralEmailAddress", Value = StringHelper.NullToString(assesment.GeneralEmailAddress) };
                parameters[12] = new SqlParameter { ParameterName = "@PhoneNumber", Value = StringHelper.NullToString(assesment.PhoneNumber) };
                parameters[13] = new SqlParameter { ParameterName = "@FaxNumber", Value = StringHelper.NullToString(assesment.FaxNumber) };
                parameters[14] = new SqlParameter { ParameterName = "@CRNumber", Value = StringHelper.NullToString(assesment.CRNumber) };
                parameters[15] = new SqlParameter { ParameterName = "@CRExpiryDate", Value = StringHelper.NullToString(assesment.CRExpiryDate) };
                parameters[16] = new SqlParameter { ParameterName = "@CRFile", Value = StringHelper.NullToString(assesment.CRFile) };
                parameters[17] = new SqlParameter { ParameterName = "@ZakatNumber", Value = StringHelper.NullToString(assesment.ZakatNumber) };
                parameters[18] = new SqlParameter { ParameterName = "@ZakatExpiryDate", Value = StringHelper.NullToString(assesment.ZakatExpiryDate) };
                parameters[19] = new SqlParameter { ParameterName = "@ZakatFile", Value = StringHelper.NullToString(assesment.ZakatFile) };
                parameters[20] = new SqlParameter { ParameterName = "@VATRegNumber", Value = StringHelper.NullToString(assesment.VATRegNumber) };
                parameters[21] = new SqlParameter { ParameterName = "@ChamberMemberShip", Value = StringHelper.NullToString(assesment.ChamberMemberShip) };
                parameters[22] = new SqlParameter { ParameterName = "@MemberShipDate", Value = StringHelper.NullToString(assesment.MemberShipDate) };
                parameters[23] = new SqlParameter { ParameterName = "@Local", Value = StringHelper.NullToString(assesment.Local) };
                parameters[24] = new SqlParameter { ParameterName = "@CompanyType", Value = StringHelper.NullToString(assesment.CompanyType) };
                parameters[25] = new SqlParameter { ParameterName = "@ContractServiceProvider", Value = StringHelper.NullToString(assesment.ContractServiceProvider) };
                parameters[26] = new SqlParameter { ParameterName = "@ScopeOfServices", Value = StringHelper.NullToString(assesment.ScopeOfServices) };
                parameters[27] = new SqlParameter { ParameterName = "@ScopeOfProducts", Value = StringHelper.NullToString(assesment.ScopeOfProducts) };
                parameters[28] = new SqlParameter { ParameterName = "@CompanyBusinessEntityType", Value = StringHelper.NullToString(assesment.CompanyBusinessEntityType) };
                parameters[29] = new SqlParameter { ParameterName = "@BankAcctNumber", Value = StringHelper.NullToString(assesment.BankAcctNumber) };
                parameters[30] = new SqlParameter { ParameterName = "@BankName", Value = StringHelper.NullToString(assesment.BankName) };
                parameters[31] = new SqlParameter { ParameterName = "@BeneficiaryBankAddress", Value = StringHelper.NullToString(assesment.BeneficiaryBankAddress) };
                parameters[32] = new SqlParameter { ParameterName = "@SwiftCode", Value = StringHelper.NullToString(assesment.SwiftCode) };
                parameters[33] = new SqlParameter { ParameterName = "@BankSortcode", Value = StringHelper.NullToString(assesment.BankSortcode) };
                parameters[34] = new SqlParameter { ParameterName = "@IBAN", Value = StringHelper.NullToString(assesment.IBAN) };
                parameters[35] = new SqlParameter { ParameterName = "@BankContactMobileNumber", Value = StringHelper.NullToString(assesment.BankContactMobileNumber) };
                parameters[36] = new SqlParameter { ParameterName = "@BankContactEmailAddress", Value = StringHelper.NullToString(assesment.BankContactEmailAddress) };
                parameters[37] = new SqlParameter { ParameterName = "@CompanyManagerName", Value = StringHelper.NullToString(assesment.CompanyManagerName) };
                parameters[38] = new SqlParameter { ParameterName = "@ManagerTitle", Value = StringHelper.NullToString(assesment.ManagerTitle) };
                parameters[39] = new SqlParameter { ParameterName = "@ManagerMobileNumber", Value = StringHelper.NullToString(assesment.ManagerMobileNumber) };
                parameters[40] = new SqlParameter { ParameterName = "@ManagerFaxNumber", Value = StringHelper.NullToString(assesment.ManagerFaxNumber) };
                parameters[41] = new SqlParameter { ParameterName = "@ManagerEmailAddress", Value = StringHelper.NullToString(assesment.ManagerEmailAddress) };
                parameters[42] = new SqlParameter { ParameterName = "@CompanyQRName", Value = StringHelper.NullToString(assesment.CompanyQRName) };
                parameters[43] = new SqlParameter { ParameterName = "@QRTitle", Value = StringHelper.NullToString(assesment.QRTitle) };
                parameters[44] = new SqlParameter { ParameterName = "@QRMobileNumber", Value = StringHelper.NullToString(assesment.QRMobileNumber) };
                parameters[45] = new SqlParameter { ParameterName = "@QRFaxNumber", Value = StringHelper.NullToString(assesment.QRFaxNumber) };
                parameters[46] = new SqlParameter { ParameterName = "@QREmailAddress", Value = StringHelper.NullToString(assesment.QREmailAddress) };
                parameters[47] = new SqlParameter { ParameterName = "@QualityManagementCertificate", Value = StringHelper.NullToString(assesment.QualityManagementCertificateFile) };
                parameters[48] = new SqlParameter { ParameterName = "@ISO9001Certificate", Value = StringHelper.NullToString(assesment.ISO9001Certificate) };
                parameters[49] = new SqlParameter { ParameterName = "@APISpecQ1Certificate", Value = StringHelper.NullToString(assesment.APISpecQ1Certificate) };
                parameters[50] = new SqlParameter { ParameterName = "@APISpecQ2Certificate", Value = StringHelper.NullToString(assesment.APISpecQ2Certificate) };
                parameters[51] = new SqlParameter { ParameterName = "@QMSCertificate", Value = StringHelper.NullToString(assesment.QMSCertificate) };
                parameters[52] = new SqlParameter { ParameterName = "@QMSCertificateNotes", Value = StringHelper.NullToString(assesment.QMSCertificateNotes) };
                parameters[53] = new SqlParameter { ParameterName = "@CurrentTurnOver", Value = StringHelper.NullToString(assesment.CurrentTurnOver) };
                parameters[54] = new SqlParameter { ParameterName = "@PurchaseTypeCritical", Value = StringHelper.NullToString(assesment.PurchaseTypeCritical) };
                parameters[55] = new SqlParameter { ParameterName = "@DirectEmployees", Value = StringHelper.NullToString(assesment.DirectEmployees) };
                parameters[56] = new SqlParameter { ParameterName = "@IndirectEmployees", Value = StringHelper.NullToString(assesment.IndirectEmployees) };
                parameters[57] = new SqlParameter { ParameterName = "@TechnicalEmployees", Value = StringHelper.NullToString(assesment.TechnicalEmployees) };
                parameters[58] = new SqlParameter { ParameterName = "@OtherEmployees", Value = StringHelper.NullToString(assesment.OtherEmployees) };
                parameters[59] = new SqlParameter { ParameterName = "@NationalAddress", Value = StringHelper.NullToString(assesment.NationalAddress) };
                int ID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, "ProcAddOrUpdateSupplierAssessment", CommandType.StoredProcedure, parameters));
                try
                {
                    parameters = new SqlParameter[5];
                    parameters[0] = new SqlParameter { ParameterName = "@ID", Value = ID };
                    parameters[1] = new SqlParameter { ParameterName = "@Customers", Value = customers.ToString() };
                    parameters[2] = new SqlParameter { ParameterName = "@items", Value = items.ToString() };
                    parameters[3] = new SqlParameter { ParameterName = "@production", Value = productions.ToString() };
                    parameters[4] = new SqlParameter { ParameterName = "@qualitycontrol", Value = qualtycontrol.ToString() };

                    SqlHelper.ExecuteNonQuery(ConnectionString, "ProcAddOrUpdateSupplierAssessmentData", CommandType.StoredProcedure, parameters);
                }
                catch (Exception e) { }
                return ID;

            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public async Task<bool> SaveRegistrationFiles(int ID, RegistrationFile assesmentFile)
        {

            try
            {
                SqlParameter[] parameters = new SqlParameter[17];
                parameters[0] = new SqlParameter { ParameterName = "@ID", Value = ID };
                parameters[1] = new SqlParameter { ParameterName = "@CRFile", Value = assesmentFile.CRFile };
                parameters[2] = new SqlParameter { ParameterName = "@CRFileID", Value = assesmentFile.CRFileID };
                parameters[3] = new SqlParameter { ParameterName = "@ZakatFile", Value = StringHelper.NullToString(assesmentFile.ZakatFile) };
                parameters[4] = new SqlParameter { ParameterName = "@ZakatFileID", Value = StringHelper.NullToString(assesmentFile.ZakatFileID) };
                parameters[5] = new SqlParameter { ParameterName = "@ChamberMemberShipFile", Value = StringHelper.NullToString(assesmentFile.ChamberMemberShipFile) };
                parameters[6] = new SqlParameter { ParameterName = "@ChamberMemberShipFileID", Value = StringHelper.NullToString(assesmentFile.ChamberMemberShipFileID) };
                parameters[7] = new SqlParameter { ParameterName = "@QualityManagementCertificateFile", Value = StringHelper.NullToString(assesmentFile.QualityManagementCertificateFile) };
                parameters[8] = new SqlParameter { ParameterName = "@QualityManagementCertificateFileID", Value = StringHelper.NullToString(assesmentFile.QualityManagementCertificateFileID) };
                parameters[9] = new SqlParameter { ParameterName = "@MajorCustomerFile", Value = StringHelper.NullToString(assesmentFile.MajorCustomerFile) };

                parameters[10] = new SqlParameter { ParameterName = "@MajorCustomerFileID", Value = StringHelper.NullToString(assesmentFile.MajorCustomerFileID) };
                parameters[11] = new SqlParameter { ParameterName = "@ProductionFile", Value = StringHelper.NullToString(assesmentFile.ProductionFile) };
                parameters[12] = new SqlParameter { ParameterName = "@ProductionFileID", Value = StringHelper.NullToString(assesmentFile.ProductionFileID) };

                parameters[13] = new SqlParameter { ParameterName = "@QualityControlFile", Value = StringHelper.NullToString(assesmentFile.QualityControlFile) };
                parameters[14] = new SqlParameter { ParameterName = "@QualityControlFileID", Value = StringHelper.NullToString(assesmentFile.QualityControlFileID) };

                parameters[15] = new SqlParameter { ParameterName = "@NationalAddressFile", Value = StringHelper.NullToString(assesmentFile.NationalAddressFile) };
                parameters[16] = new SqlParameter { ParameterName = "@NationalAddressFileID", Value = StringHelper.NullToString(assesmentFile.NationalAddressFileID) };
                SqlHelper.ExecuteScalar(ConnectionString, "ProcAddOrUpdateSupplierFiles", CommandType.StoredProcedure, parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public async Task<DataTable> SupplierAssessment(SupplierAssessmentParam param)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[5];
                collSP[0] = new SqlParameter { ParameterName = "@CompanyName", Value = param.Name };
                collSP[1] = new SqlParameter { ParameterName = "@City", Value = param.City };
                collSP[2] = new SqlParameter { ParameterName = "@Country", Value = param.Country };
                collSP[3] = new SqlParameter { ParameterName = "@PageNumber", Value = param.PageNumber };
                collSP[4] = new SqlParameter { ParameterName = "@PageSize", Value = param.pageSize };

                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcListSupplierAssessmentData", CommandType.StoredProcedure, collSP);
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
        public async Task<SupplierAssementDTOSQL> SupplierAssessment(int ID)
        {
            try
            {


                var result = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetSupplierAssessmentData", CommandType.StoredProcedure, new SqlParameter { ParameterName = "@ID", Value = ID });
                SupplierAssementDTOSQL dt = new SupplierAssementDTOSQL();
                dt.assessment.Load(result);
                dt.supplierItems.Load(result);
                dt.supplierCustomers.Load(result);
                dt.supplierProductions.Load(result);
                dt.supplierQualityControls.Load(result);
                result.Close();
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<QuoteRequestSQL> QuoteRequest(string ID)
        {
            try
            {
                SqlParameter[] collSP = new SqlParameter[3];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = ID };
                collSP[1] = new SqlParameter { ParameterName = "@Status", DbType = DbType.Boolean, Direction = ParameterDirection.Output };
                collSP[2] = new SqlParameter { ParameterName = "@IPO", DbType = DbType.Int32, Direction = ParameterDirection.Output };


                var reader = await SqlHelper.ExecuteReader(this.ConnectionString, "ProcGetQuoteDetailByRequestID", CommandType.StoredProcedure, collSP);

                QuoteRequestSQL model = new QuoteRequestSQL();



                if (reader.HasRows)
                {
                    model.Supplier.Load(reader);
                    model.QuoteItems.Load(reader);
                    model.PastQuotes.Load(reader);
                    model.PastQuoteItems.Load(reader);

                }
                reader.Close();
                model.Status = Convert.ToBoolean(collSP[1].Value);
                model.IPOID = Convert.ToInt32(collSP[2].Value);
                return model;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<int> SubmitQuote(string ID, Quote quote)
        {
            try
            {
                StringBuilder xml = new StringBuilder();
                xml.Append("<Data>");
                if (quote.Items != null)
                {
                    foreach (QuoteItem itm in quote.Items)
                    {
                        xml.Append($"<Item><ItemID>{itm.ItemID}</ItemID><Quantity>{itm.Quantity}</Quantity><Price>{itm.Price}</Price><Notes>{StringHelper.ReplaceXmlChar(itm.Notes)}</Notes></Item>");
                    }
                }
                xml.Append("</Data>");
                SqlParameter[] collSP = new SqlParameter[4];
                collSP[0] = new SqlParameter { ParameterName = "@ID", Value = ID };

                collSP[1] = new SqlParameter { ParameterName = "@Remarks", Value = StringHelper.NullToString(quote.Remarks) };
                collSP[2] = new SqlParameter { ParameterName = "@Items", Value = xml.ToString() };
                collSP[3] = new SqlParameter { ParameterName = "@FileName", Value = StringHelper.NullToString(quote.FileName) };

                int QuoteID = Convert.ToInt32(SqlHelper.ExecuteScalar(ConnectionString, "ProcSubmitSupplierQuoteData", CommandType.StoredProcedure, collSP));
                return QuoteID;
            }
            catch (Exception e)
            {
                return 0;
            }

        }
    }
}
