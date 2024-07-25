using System;
using System.Collections.Generic;
using SQLHelper;
using System.Data;

using System.Data.SqlClient;
using System.Threading.Tasks;
using PipewellserviceModels.Customer;
using PipewellserviceDB.Common;

namespace PipewellserviceDB.Customer
{
    public class CustomerService : DataServices
    {
        public async Task<int> SaveRegistration(CustomerRegistrationDTO dto)
        {
            try
            {

                var parameters = new SqlParameter[]
                {
    new SqlParameter { ParameterName = "@ID", Value = dto.ID },
    new SqlParameter { ParameterName = "@CompanyName", Value = StringHelper.NullToString(dto.CompanyName) },
    new SqlParameter { ParameterName = "@BusinessDate", Value = dto.BusinessDate },
    new SqlParameter { ParameterName = "@RepresentativeName1", Value = StringHelper.NullToString(dto.RepresentativeName1) },
    new SqlParameter { ParameterName = "@RepresentativeTitle1", Value = StringHelper.NullToString(dto.RepresentativeTitle1) },
    new SqlParameter { ParameterName = "@RepresentativeName2", Value = StringHelper.NullToString(dto.RepresentativeName2) },
    new SqlParameter { ParameterName = "@RepresentativeTitle2", Value = StringHelper.NullToString(dto.RepresentativeTitle2) },
    new SqlParameter { ParameterName = "@PhoneNumber", Value = StringHelper.NullToString(dto.PhoneNumber) },
    new SqlParameter { ParameterName = "@FaxNumber", Value = StringHelper.NullToString(dto.FaxNumber) },
    new SqlParameter { ParameterName = "@EmailAddress", Value = StringHelper.NullToString(dto.EmailAddress) },
    new SqlParameter { ParameterName = "@CRNumber", Value = StringHelper.NullToString(dto.CRNumber) },
    new SqlParameter { ParameterName = "@CRExpiryDate", Value = dto.CRExpiryDate },
    new SqlParameter { ParameterName = "@VATNumber", Value = StringHelper.NullToString(dto.VATNumber) },
    new SqlParameter { ParameterName = "@VATExpiryDate", Value = dto.VATExpiryDate },
    new SqlParameter { ParameterName = "@ZakatNumber", Value = StringHelper.NullToString(dto.ZakatNumber) },
    new SqlParameter { ParameterName = "@ZakatExpiryDate", Value = dto.ZakatExpiryDate },
    new SqlParameter { ParameterName = "@CompanyAddress", Value = StringHelper.NullToString(dto.CompanyAddress) },
    new SqlParameter { ParameterName = "@City", Value = StringHelper.NullToString(dto.City) },
    new SqlParameter { ParameterName = "@PoBox", Value = StringHelper.NullToString(dto.PoBox) },
    new SqlParameter { ParameterName = "@ResidencyDuration", Value = StringHelper.NullToString(dto.ResidencyDuration) },
    new SqlParameter { ParameterName = "@MonthlyBusiness", Value = StringHelper.NullToString(dto.MonthlyBusiness) },
    new SqlParameter { ParameterName = "@PaidUpCapital", Value = StringHelper.NullToString(dto.PaidUpCapital) },
    new SqlParameter { ParameterName = "@BankName", Value = StringHelper.NullToString(dto.BankName) },
    new SqlParameter { ParameterName = "@BankAcctNumber", Value = StringHelper.NullToString(dto.BankAcctNumber) },
    new SqlParameter { ParameterName = "@BankAddress", Value = StringHelper.NullToString(dto.BankAddress) },
    new SqlParameter { ParameterName = "@BankCity", Value = StringHelper.NullToString(dto.BankCity) },
    new SqlParameter { ParameterName = "@BankPoBox", Value = StringHelper.NullToString(dto.BankPoBox) },
    new SqlParameter { ParameterName = "@BankPhoneNumber", Value = StringHelper.NullToString(dto.BankPhoneNumber) },
    new SqlParameter { ParameterName = "@BankFaxNumber", Value = StringHelper.NullToString(dto.BankFaxNumber) },
    new SqlParameter { ParameterName = "@BankEmailAddress", Value = StringHelper.NullToString(dto.BankEmailAddress) },
    new SqlParameter { ParameterName = "@TradeCompanyName1", Value = StringHelper.NullToString(dto.TradeCompanyName1) },
    new SqlParameter { ParameterName = "@TradeAddress1", Value = StringHelper.NullToString(dto.TradeAddress1) },
    new SqlParameter { ParameterName = "@TradeContactPerson1", Value = StringHelper.NullToString(dto.TradeContactPerson1) },
    new SqlParameter { ParameterName = "@TradePhoneNumber1", Value = StringHelper.NullToString(dto.TradePhoneNumber1) },
    new SqlParameter { ParameterName = "@TradeFaxNumber1", Value = StringHelper.NullToString(dto.TradeFaxNumber1) },
    new SqlParameter { ParameterName = "@TradeEmailAddress1", Value = StringHelper.NullToString(dto.TradeEmailAddress1) },
    new SqlParameter { ParameterName = "@TradeCompanyName2", Value = StringHelper.NullToString(dto.TradeCompanyName2) },
    new SqlParameter { ParameterName = "@TradeAddress2", Value = StringHelper.NullToString(dto.TradeAddress2) },
    new SqlParameter { ParameterName = "@TradeContactPerson2", Value = StringHelper.NullToString(dto.TradeContactPerson2) },
    new SqlParameter { ParameterName = "@TradePhoneNumber2", Value = StringHelper.NullToString(dto.TradePhoneNumber2) },
    new SqlParameter { ParameterName = "@TradeFaxNumber2", Value = StringHelper.NullToString(dto.TradeFaxNumber2) },
    new SqlParameter { ParameterName = "@TradeEmailAddress2", Value = StringHelper.NullToString(dto.TradeEmailAddress2) },
    new SqlParameter { ParameterName = "@TradeCompanyName3", Value = StringHelper.NullToString(dto.TradeCompanyName3) },
    new SqlParameter { ParameterName = "@TradeAddress3", Value = StringHelper.NullToString(dto.TradeAddress3) },
    new SqlParameter { ParameterName = "@TradeContactPerson3", Value = StringHelper.NullToString(dto.TradeContactPerson3) },
    new SqlParameter { ParameterName = "@TradePhoneNumber3", Value = StringHelper.NullToString(dto.TradePhoneNumber3) },
    new SqlParameter { ParameterName = "@TradeFaxNumber3", Value = StringHelper.NullToString(dto.TradeFaxNumber3) },
    new SqlParameter { ParameterName = "@TradeEmailAddress3", Value = StringHelper.NullToString(dto.TradeEmailAddress3) }
    
                };


                return Convert.ToInt32(SqlHelper.ExecuteScalar(this.ConnectionString, "ProcAddOrUpdateCustomerRegistrationInfo", CommandType.StoredProcedure, parameters));

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
                SqlParameter[] parameters = new SqlParameter[7];
                parameters[0] = new SqlParameter { ParameterName = "@ID", Value = ID };
                parameters[1] = new SqlParameter { ParameterName = "@CRFile", Value = assesmentFile.CRFile };
                parameters[2] = new SqlParameter { ParameterName = "@CRFileID", Value = assesmentFile.CRFileID };
                parameters[3] = new SqlParameter { ParameterName = "@ZakatFile", Value = StringHelper.NullToString(assesmentFile.ZakatFile) };
                parameters[4] = new SqlParameter { ParameterName = "@ZakatFileID", Value = StringHelper.NullToString(assesmentFile.ZakatFileID) };
                parameters[5] = new SqlParameter { ParameterName = "@VATFile", Value = StringHelper.NullToString(assesmentFile.VATFile) };
                parameters[6] = new SqlParameter { ParameterName = "@VATFileID", Value = StringHelper.NullToString(assesmentFile.VATFileID) };
                
                SqlHelper.ExecuteScalar(ConnectionString, "ProcAddOrUpdateCustomerFiles", CommandType.StoredProcedure, parameters);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
