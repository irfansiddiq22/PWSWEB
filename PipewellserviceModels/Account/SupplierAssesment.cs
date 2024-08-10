using PipewellserviceModels.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipewellserviceModels.Supplier
{
    public class SupplierAssesment
    {

        public int ID { get; set; }
        public bool Assessment { get; set; }
        public DateTime RecordDate { get; set; }
        public string CompanyName { get; set; }
        public string PoBox { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
        public string NationalAddress { get; set; }
        public string GeneralEmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string CRNumber { get; set; }
        public DateTime CRExpiryDate { get; set; }
        public string CRFile { get; set; }
        public string CRFileID { get; set; }
        public string ZakatNumber { get; set; }
        public DateTime ZakatExpiryDate { get; set; }
        public string ZakatFile { get; set; }
        public string ZakatFileID { get; set; }

        public string VATRegNumber { get; set; }
        public string ChamberMemberShip { get; set; }
        public string ChamberMemberShipFile { get; set; }
        public string ChamberMemberShipFileID { get; set; }
        public DateTime MemberShipDate { get; set; }
        public bool Local { get; set; }
        public int CompanyType { get; set; }
        public string CompanyTypeName {
            get {
                if (CompanyType == 1) return "Supplier";
                if (CompanyType == 2) return "Dealer";
                if (CompanyType == 3) return "Trade";
                return "";
            }
        }
        public bool ContractServiceProvider { get; set; }
        public string ScopeOfServices { get; set; }
        public string ScopeOfProducts { get; set; }
        public int CompanyBusinessEntityType { get; set; }
        public bool CompanyBusinessEntityTypeInd {
            get {
                return (CompanyBusinessEntityType == (int)CompanyBusinessEntityTypes.Individual);
            }
            set
            {
                if (value)
                    CompanyBusinessEntityType = (int)CompanyBusinessEntityTypes.Individual;

            }
        }
        public bool CompanyBusinessEntityTypeShare
        {
            get
            {
                return (CompanyBusinessEntityType == (int)CompanyBusinessEntityTypes.ShareHolder);
            }
            set
            {
                if (value)
                    CompanyBusinessEntityType = (int)CompanyBusinessEntityTypes.ShareHolder;

            }
        }
        public bool CompanyBusinessEntityTypeLLC
        {
            get
            {
                return (CompanyBusinessEntityType == (int)CompanyBusinessEntityTypes.LLC);
            }
            set
            {
                if (value)
                    CompanyBusinessEntityType = (int)CompanyBusinessEntityTypes.LLC;

            }
        }
        public bool CompanyBusinessEntityTypePartner
        {
            get
            {
                return (CompanyBusinessEntityType == (int)CompanyBusinessEntityTypes.Partnership);
            }
            set
            {
                if (value)
                    CompanyBusinessEntityType = (int)CompanyBusinessEntityTypes.Partnership;

            }
        }
        public string BankAcctNumber { get; set; }
        public string BankName { get; set; }
        public string BeneficiaryBankAddress { get; set; }
        public string SwiftCode { get; set; }
        public string BankSortcode { get; set; }
        public string IBAN { get; set; }
        public string BankContactMobileNumber { get; set; }
        public string BankContactEmailAddress { get; set; }
        public string CompanyManagerName { get; set; }
        public string ManagerTitle { get; set; }
        public string ManagerMobileNumber { get; set; }
        public string ManagerFaxNumber { get; set; }
        public string ManagerEmailAddress { get; set; }
        public string CompanyQRName { get; set; }
        public string QRTitle { get; set; }
        public string QRMobileNumber { get; set; }
        public string QRFaxNumber { get; set; }
        public string QREmailAddress { get; set; }
        public string QualityManagementCertificateFile { get; set; }
        public string QualityManagementCertificateFileID { get; set; }
        public bool ISO9001Certificate { get; set; }
        public bool APISpecQ1Certificate { get; set; }
        public bool APISpecQ2Certificate { get; set; }
        public string QMSCertificate { get; set; }
        public string QMSCertificateNotes { get; set; }
        public string CurrentTurnOver { get; set; }
        public bool PurchaseTypeCritical { get; set; }
        public int DirectEmployees { get; set; }
        public int IndirectEmployees { get; set; }
        public int TechnicalEmployees { get; set; }
        public int OtherEmployees { get; set; }

        public string MajorCustomerFile { get; set; }
        public string MajorCustomerFileID { get; set; }
        public string ProductionFile { get; set; }
        public string ProductionFileID { get; set; }
        public string QualityControlFile { get; set; }
        public string QualityControlFileID { get; set; }
        public string NationalAddressFile { get; set; }
        public string NationalAddressFileID { get; set; }
        public List<SupplierItem> SupplierItems { get; set; }
        public List<SupplierCustomer> SupplierCustomers { get; set; }
        public List<SupplierProductionFacility> SupplierProductionFacilities { get; set; }
        public List<SupplierQualityControlFacility> SupplierQualityControlFacilities { get; set; }
    }
    public class AssessmentListView
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        
        public int TotalRecords { get; set; }
    }
    public class RegistrationFile
    {

        public string CRFile { get; set; }
        public string CRFileID { get; set; }
        public string ZakatFile { get; set; }
        public string ZakatFileID { get; set; }
        public string ChamberMemberShipFile { get; set; }
        public string ChamberMemberShipFileID { get; set; }

        public string QualityManagementCertificateFile { get; set; }
        public string QualityManagementCertificateFileID { get; set; }

        public string MajorCustomerFile { get; set; }
        public string MajorCustomerFileID { get; set; }
        public string ProductionFile { get; set; }
        public string ProductionFileID { get; set; }
        public string QualityControlFile { get; set; }
        public string QualityControlFileID { get; set; }
        public string NationalAddressFile { get; set; }
        public string NationalAddressFileID { get; set; }

    }
    public class SupplierItem
    {
        public int RowNumber { get; set; }
        public string ItemServiceName { get; set; }
    }
    public class SupplierCustomer
    {
        public int RowNumber { get; set; }
        public string CustomerName { get; set; }
        public string ItemServiceName { get; set; }
        public string TurnOver { get; set; }
    }
    public class SupplierProductionFacility
    {
        public int RowNumber { get; set; }
        public string MachineName { get; set; }
        public string Model { get; set; }
        public string NoOfMachines { get; set; }
    }
    public class SupplierQualityControlFacility
    {
        public int RowNumber { get; set; }
        public string EquipmentDescription { get; set; }
        public string Range { get; set; }
        public string Quantity { get; set; }
    }

    public class SupplierAssessmentParam
    {
        
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public int PageNumber { get; set; }
        public int pageSize { get; set; }
    }
    public class SupplierAssementDTOSQL{
        public DataTable assessment { get; set; }
        public DataTable supplierItems { get; set; }
        public DataTable supplierProductions { get; set; }
        public DataTable supplierCustomers { get; set; }
        public DataTable supplierQualityControls { get; set; }
        public SupplierAssementDTOSQL()
        {
            assessment = new DataTable();
            supplierItems = new DataTable();
            supplierProductions = new DataTable();
            supplierCustomers = new DataTable();
            supplierQualityControls = new DataTable();
        }
    }
    public class SupplierAssementDTO
    {
        public List<SupplierAssesment> assessment { get; set; }
        public List<SupplierItem> supplierItems { get; set; }

        public List<SupplierProductionFacility> supplierProductions { get; set; }
        public List<SupplierCustomer> supplierCustomers { get; set; }
        public List<SupplierQualityControlFacility> supplierQualityControls { get; set; }

    }
}
