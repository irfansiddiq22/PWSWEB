var VendorData = [];
var Vendor = {};
function LoadVendor() {
	Post("/EmployeeAPI/VendorList", {}).done(function (resp) {
		VendorData = resp;
		FillList("ddVendorList", VendorData, "Name", "ID", "Select Vendor");
		FillList("ddEmployeeHiringVendor", VendorData, "Name", "ID", "Select Vendor");

	})
	$("#frmVendor").validate({
		errorClass: "text-danger",

		rules: {
			txtVendorName: "required",
			txtVendorCSR: "required",
			txtVendorContact: "required",
			txtVendorEmergencyContact: "required",
			txtVendorAddress: "required",
			txtVendorEmailAddress: "required",
			txtVendorSOW: "required",
			txtVendorHourlyPrice: "required",
			txtVendorWorkHours: "required",
			txtVendorOverTimeHourPrice: "required",
			txtVendorWorkMinHours: "required",
			ddVendorAccommodation: "required",
			ddVendorFood: "required",
			ddVendorTransport: "required",
			ddVendorAjeerProvided: "required",

			ddVendorAjeerType: "required",
			ddAjeerSaudization: "required",
			ddVendorPWSCR: "required",


		},
		messages: {
			txtVendorName: "Please enter vendor Name",
			txtVendorCSR: "Please enter vendor CSR",
			txtVendorContact: "Please enter vendor Contact Details.",
			txtVendorEmergencyContact: "Please enter Emergency Contact Detail",
			txtVendorAddress: "Please enter vendor Address",
			txtVendorEmailAddress: "Please enter vendor Email Address",
			txtVendorSOW: "Please enter vendor Scope of work",
			txtVendorHourlyPrice: "Please enter vendor Hourly Price",
			txtVendorWorkHours: "Please enter vendor Agreed Working Hour",
			txtVendorOverTimeHourPrice: "Please enter vendor Overtime Hourly Price",
			txtVendorWorkMinHours: "Please enter vendor Minimum Workinging Hour",
			ddVendorAccommodation: "Please select vendor Accommodation",
			ddVendorFood: "Please enter select food",
			ddVendorTransport: "Please select transpost",
			ddVendorAjeerProvided: "Please select ajeer provided",

			ddVendorAjeerType: "Please select ajeer Type",
			ddAjeerSaudization: "Please select ajeer saudization",
			ddVendorPWSCR: "Please enter PWS CSR",


		}
	});
}
function ShowVendorList() {
	$("#frmVendor").validate()
	$("#dlgVendorList").modal("show")
}
function EditVendorData() {
	ShowVendorList();
	SetvalOf("ddVendorList", valOf("ddEmployeeHiringVendor"))
	EditVendor(valOf("ddEmployeeHiringVendor"));
}
function EditVendor(ID) {
	ID = parseInt(ID);
	if (ID == 0) return;
	Vendor =VendorData.find(x=>x.ID == ID);
	SetvalOf("txtVendorName", Vendor.Name);
	SetvalOf("txtVendorCSR", Vendor.CSR);
    SetvalOf("txtVendorContact", Vendor.Contact);
    SetvalOf("ddVendorContractNumber", Vendor.ContractNumber)
	SetvalOf("txtVendorEmergencyContact", Vendor.EmergencyContact);
	SetvalOf("txtVendorAddress", Vendor.Address);
	SetvalOf("txtVendorEmailAddress", Vendor.EmailAddress);
	SetvalOf("txtVendorSOW", Vendor.WorkScope);
	SetvalOf("txtVendorHourlyPrice", Vendor.HourlyPrice);
	SetvalOf("txtVendorWorkHours", Vendor.WorkHours);
	SetvalOf("txtVendorOverTimeHourPrice", Vendor.OverTimeHourlyPrice);
	SetvalOf("txtVendorWorkMinHours", Vendor.MinWorkHours);
	SetvalOf("ddVendorAccommodation", Vendor.Accommodation);
	SetvalOf("ddVendorFood", Vendor.Food);
	SetvalOf("ddVendorTransport", Vendor.Transport);
    SetvalOf("ddVendorAjeerProvided", Vendor.AjeerProvided);
    SetvalOf("ddVendorAjeerType", Vendor.AjeerType).trigger("change");
	SetvalOf("ddAjeerSaudization", Vendor.AjeerSaudization);
	SetvalOf("ddVendorPWSCR", Vendor.PWSCR);
    SetvalOf("txtVendorRemarks", Vendor.Remarks);

    SetvalOf("ddVendorAjeerType", Vendor.AjeerType).trigger("change");
}
function ShowAjeerSaudization() {
    if (parseInt(valOf("ddVendorAjeerType")) == 1) {
        SetvalOf("ddAjeerSaudization", 0)
        $(".pwscr").hide();
    } else {
        SetvalOf("ddAjeerSaudization", 1)
        $(".pwscr").show();
    }
    
}
function ResetAjeerType() {
    if (valOf("ddAjeerSaudization") == 0) {
        SetvalOf("ddVendorAjeerType", 1)
        $(".pwscr").hide();

    } else {
        SetvalOf("ddVendorAjeerType", 2)
        $(".pwscr").show();
    }
}
function SaveVendor() {

	
    if ($("#frmVendor").valid()) {


		ResetChangeLog(PAGES.Vendor);
		var NewData = {
			ID: Vendor.ID,
			Name: valOf("txtVendorName"),
            CSR: valOf("txtVendorCSR"),
            ContractNumber: valOf("ddVendorContractNumber"),
			Contact: valOf("txtVendorContact"),
			EmergencyContact: valOf("txtVendorEmergencyContact"),
			Address: valOf("txtVendorAddress"),
			EmailAddress: valOf("txtVendorEmailAddress"),
			WorkScope: valOf("txtVendorSOW"),
			HourlyPrice: valOf("txtVendorHourlyPrice"),
			WorkHours: valOf("txtVendorWorkHours"),
			OverTimeHourlyPrice: valOf("txtVendorOverTimeHourPrice"),
			MinWorkHours: valOf("txtVendorWorkMinHours"),
			Accommodation: valOf("ddVendorAccommodation"),
			Food: valOf("ddVendorFood"),
			Transport: valOf("ddVendorTransport"),
			AjeerProvided: valOf("ddVendorAjeerProvided"),
			AjeerType: valOf("ddVendorAjeerType"),
			AjeerSaudization: valOf("ddAjeerSaudization"),
			PWSCR: valOf("ddVendorPWSCR"),
			Remarks: valOf("txtVendorRemarks")
		};

		if (Vendor.ID == 0) {
			DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: valOf("txtVendorName") } });
		} else {
			jQuery.each(NewData, function (name, value) {
				if ($.trim(value) != $.trim(Vendor[name])) {
					DataChangeLog.DataUpdated.push({ Field: name, Data: { OLD: Vendor[name], New: $.trim(value) } });
				}
			});
			
		}

		Post("/EmployeeAPI/UpdateVendor", { Vendor: NewData }).done(function (resp) {
			SaveLog(Vendor.ID);
			LoadVendor();

		})
	}
}