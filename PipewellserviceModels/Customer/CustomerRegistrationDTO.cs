using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Customer
{
    public class CustomerRegistrationDTO
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public DateTime BusinessDate { get; set; }
        public string RepresentativeName1 { get; set; }
        public string RepresentativeTitle1 { get; set; }
        public string RepresentativeName2 { get; set; }
        public string RepresentativeTitle2 { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public string CRNumber { get; set; }
        public DateTime CRExpiryDate { get; set; }
        public string CRFile { get; set; }
        public string CRFileID { get; set; }
        public string ZakatNumber { get; set; }
        public DateTime ZakatExpiryDate { get; set; }
        public string ZakatFile { get; set; }
        public string ZakatFileID { get; set; }


        public string VATNumber { get; set; }
        public DateTime VATExpiryDate { get; set; }
        public string VATFile { get; set; }
        public string VATFileID { get; set; }

        public string CompanyAddress { get; set; }
        public string City { get; set; }
        public string PoBox { get; set; }
        public string ResidencyDuration { get; set; }
        public string MonthlyBusiness { get; set; }
        public string PaidUpCapital { get; set; }
        public string BankName { get; set; }
        public string BankAcctNumber { get; set; }
        public string BankAddress { get; set; }
        public string BankCity { get; set; }
        public string BankPoBox { get; set; }
        public string BankPhoneNumber { get; set; }
        public string BankFaxNumber { get; set; }
        public string BankEmailAddress { get; set; }
        public string TradeCompanyName1 { get; set; }
        public string TradeAddress1 { get; set; }
        public string TradeContactPerson1 { get; set; }
        public string TradePhoneNumber1 { get; set; }
        public string TradeFaxNumber1 { get; set; }
        public string TradeEmailAddress1 { get; set; }
        public string TradeCompanyName2 { get; set; }
        public string TradeAddress2 { get; set; }
        public string TradeContactPerson2 { get; set; }
        public string TradePhoneNumber2 { get; set; }
        public string TradeFaxNumber2 { get; set; }
        public string TradeEmailAddress2 { get; set; }
        public string TradeCompanyName3 { get; set; }
        public string TradeAddress3 { get; set; }
        public string TradeContactPerson3 { get; set; }
        public string TradePhoneNumber3 { get; set; }
        public string TradeFaxNumber3 { get; set; }
        public string TradeEmailAddress3 { get; set; }
        public DateTime RecordDateAdded { get; set; }

    }

    public class RegistrationFile
    {

        public string CRFile { get; set; }
        public string CRFileID { get; set; }
        public string ZakatFile { get; set; }
        public string ZakatFileID { get; set; }
        public string VATFile { get; set; }
        public string VATFileID { get; set; }
    }
}
