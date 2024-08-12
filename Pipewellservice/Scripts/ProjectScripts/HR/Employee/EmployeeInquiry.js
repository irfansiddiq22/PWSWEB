﻿var IquiryList = [];
var ApprovalList = [];
var Inquiry = { ID: 0, Approvals: [] };
var PriorityLevels = [];
function _Init() {
    HideSpinner();
    pageNumber = 1
    SetvalOf("txtInquiryPreparedBy", User.Name);
    SetPagePermission(PAGES.EmployeeInquiry, function () {
        BindUsers();
    });
    SetvalOf("txtInquiryDate", moment().format("DD/MM/YYYY"));
    SetvalOf("txtLastWorkingDate", moment().format("DD/MM/YYYY"));
    
}
function BindUsers() {
    $.post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        if (Response.length > 1) data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
        })

        $("#ddEmployeeName").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data,
            width: "100%"
        });
        if (data.length == 1) {
            $("#ddEmployeeName").val(data[0].id).trigger("change")
        }
        Post("/DataList/PriorityLevels", {}).done(function (Response) {
            FillList("ddlPriorityLevel", Response, "Name", "ID", "Choose Request Priority");
            PriorityLevels = Response;
        });

        BindInquiryList();
    })




}

function BindInquiryList(PageNumber = 1) {
    pageNumber = PageNumber;
    $("#tblEmployeeInQuiryList").empty();

    var StartDate = "", EndDate = "";


    Inquiry = { ID: 0, Approvals: [] };
    ResetChangeLog(PAGES.EmployeeInquiry);

    $('#dvEmployeeInquiryPaging').pagination({
        dataSource: "/EmployeeAPI/EmployeeInquiryList",
        pageSize: pageSize,
        pageNumber: pageNumber,
        showGoInput: true,
        showGoButton: true,
        locator: function (response) {
            return 'Inquiry';
        },
        totalNumberLocator: function (response) {
            return response.TotalRecords;
        },

        ajax: {
            type: "POST",
            dataType: "json",
            data: {
                EmployeeID: valOf("ddEmployeeName"),
                StartDate: StartDate,
                EndDate: EndDate,
                PersonalInquiry: GetChecked("ChkInquiryPersonalFilter"),
                GeneralInquiry: GetChecked("ChkInquiryGeneralFilter"),
                LoanInquiry: GetChecked("ChkInquiryLoanFilter")
            },
            beforeSend: function () {
                ShowSpinner();
            }
        },
        callback: function (data, pagination) {
            HideSpinner();

            $("#tblEmployeeInQuiryList").empty();
            $.each(data, function (i, r) {
                var tr = $('<tr>')
                tr.append($('<td>').text(r.ID))
                tr.append($('<td>').append(r.Division))
                tr.append($('<td>').text(moment(r.InquiryDate).format("DD/MM/YYYY")))
                tr.append($('<td>').append(r.Remarks))

                tr.append($('<td>').append(r.Preparedby).append(r.PriorityLevelID > 0 ? '<br><span class="badge badge-primary" style="background-color:' + r.ColorCode + '">' + r.PriorityLevelName : ''));
                var p = $('<div>').append("Personal").append(CheckboxSwitch("", (r.PersonalInquiry ? "checked" : ""), "", ""))
                if (!r.PersonalInquiry) p = ''

                var g = $('<div>').append("General :").append(CheckboxSwitch("", (r.GeneralInquiry ? "checked" : ""), "", ""))
                if (!r.GeneralInquiry) g =''

                var l = $('<div>').append("Loan :").append(CheckboxSwitch("", (r.LoanInquiry ? "checked" : ""), "", ""))
                if (!r.LoanInquiry) l = ''

                var s = $('<div>').append("Salary Certificate :").append(CheckboxSwitch("", (r.SalaryCertificate ? "checked" : ""), "", ""))
                if (!r.SalaryCertificate) s = ''
                var m = $('<div>').append("Miss Punch :").append(CheckboxSwitch("", (r.MissPunch ? "checked" : ""), "", ""))
                if (!r.MissPunch) m = ''

                var reg = $('<div>')
                if (reg.Resignation) {
                    $(r).append("Resignation:").append(CheckboxSwitch("", (r.Resignation ? "checked" : ""), "", ""))
                    $(r).append("<br>Last Working Day:" + moment(r.LastWorkingDate).format("DD/MM/YYYY") )
                } else
                    reg=''
                tr.append($('<td>').append($(p)).append($(g)).append($(l)).append($(s)).append($(m)).append($(reg)))
                
                tr.append($('<td>').append(r.InquiryStatus))


                $("#tblEmployeeInQuiryList").append(tr);

            });


        }
    })

}


function ResetNav() {
    document.getElementById("frmInquiry").reset();
    Inquiry = { ID: 0, Approvals: [] };
    
    
    $(".breadcrumb-item.active").find("a").contents().unwrap();
    SetvalOf("txtInquiryPreparedBy", User.Name);
    ResetDatePicker();
    SetvalOf("txtInquiryDate", moment().format("DD/MM/YYYY"));
}
function SaveEmployeeInquiry() {
    $("#frmInquiry").validate({
        errorClass: "text-danger",

        rules: {
            EmployeeName: "required",
            InquiryDate: "required",
            InquiryRemarks: "required",
            PriorityLevel: {
                required:true,
                min:1,
            },

        },
        messages: {
            EmployeeName: "Please select employee",
            InquiryDate: "Please enter date",
            InquiryRemarks: "Please enter remarks",
            PriorityLevel: {
                required: "Please choose request priority level",
                min: "Please choose  request priority level",
            },
        },
        submitHandler: function (form) {
            if (Inquiry.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: textOf("ddEmployeeName") } });
            }
            SetvalOf("txtLastWorkingDate", moment().format("DD/MM/YYYY"));


            var LastWorkingDate = moment().format("DD/MM/YYYY")
            if (GetChecked("chkResignation")) {
                LastWorkingDate = valOf("txtLastWorkingDate");
                if (LastWorkingDate == "") LastWorkingDate = moment().format("DD/MM/YYYY")
            }
            NewInquiry = {
                ID: Inquiry.ID,
                EmployeeID: valOf("ddEmployeeName"),
                InquiryDate: valOf("txtInquiryDate"),
                Remarks: valOf("txtInquiryRemarks"),
                Preparedby: valOf("txtInquiryPreparedBy"),
                PersonalInquiry: GetChecked("chkInquiryPersonal"),
                GeneralInquiry: GetChecked("chkInquiryGeneral"),
                LoanInquiry: GetChecked("chkInquiryLoan"),
                Resignation: GetChecked("chkResignation"),
                MissPunch: GetChecked("chkMissPunch"),
                SalaryCertificate: GetChecked("chkSalaryCertificate"),
                LastWorkingDate: LastWorkingDate,
                UserName: User.Name,
                RecordCreatedBy: User.ID,
                
                PriorityLevelID: valOf("ddlPriorityLevel"),
                Approvals: []
            };
            var PriorityLevel = PriorityLevels.find(x => x.ID = NewInquiry.PriorityLevel)
            $.each(User.Supervisors, function (i, s) {
                if (NewInquiry.MissPunch) {
                    if (s.SupervisorType==1)
                      NewInquiry.Approvals.push({ ID: s.ID, DivisionID: s.DivisionID });
                } else {
                    NewInquiry.Approvals.push({ ID: s.ID, DivisionID: s.DivisionID });
                }
            });

            
            var fileUpload = $('#InquiryFile').get(0);
            var files = fileUpload.files;
            
            Post("/EmployeeAPI/AddEmployeeInquiry", { Inquiry: NewInquiry  }).done(function (ID) {
                if (ID > 0) {

                    Inquiry.ID = ID;
                    
                    if (files.length > 0) {

                        UploadFile("/EmployeeAPI/UpdateEmployeeInquiryFile", files[0], { EmployeeID: NewInquiry.EmployeeID, ID: ID }, function (Status, Response) {


                            if (Status == 1) {

                                if (NewInquiry.ID > 0)
                                    swal("Employee request record added", { icon: "success" })
                                else
                                    swal("Employee request updated", { icon: "success" })
                                NewInquiry.ID = ID;
                                NewInquiry.FileID = Response.FileID;
                                NewInquiry.FileName = files[0].name;

                                ProcessInquiryMail(NewInquiry,  PriorityLevel);
                                BindInquiryList()
                                ResetNav();
                            } else {

                                swal("Failed to upload request file.", { icon: "error" })
                            }
                        });
                    } else {

                        if (NewInquiry.ID > 0)
                            swal("Employee request record added", { icon: "success" })
                        else
                            swal("Employee request updated", { icon: "success" })
                        NewInquiry.ID = ID;
                        ProcessInquiryMail(NewInquiry, PriorityLevel);
                        BindInquiryList()
                        ResetNav();
                    }
                } else {
                    swal("Failed to upload request.", { icon: "error" })
                }

            })
            return false;
        }
    });




}
function ProcessInquiryMail(Inquiry, PriorityLevel) {
    Post("/EmployeeAPI/ProcessInquiryMail", { record: Inquiry, PriorityLevel: PriorityLevel }).done(function (ID) { });
}


function NewInquiry() {
    ResetNav();
    
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
}

function ResetOtherOptions(option, sender) {
    $("#dvLastWorkingDate").addClass("d-none")
    if ($(sender).prop("checked")) {
        if (option == 4)
            $("#chkResignation,#chkMissPunch,#chkInquiryLoan").prop("checked", false)
        else if (option == 5) {
            $("#chkSalaryCertificate,#chkMissPunch,#chkInquiryLoan").prop("checked", false)
            $("#dvLastWorkingDate").removeClass("d-none")
        }
        else if (option == 6)
            $("#chkSalaryCertificate,#chkResignation,#chkInquiryLoan").prop("checked", false)
        else if (option == 3)
            $("#chkSalaryCertificate,#chkResignation,#chkMissPunch").prop("checked", false)

    }
}