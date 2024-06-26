﻿var IquiryList = [];
var ApprovalList = [];
var Inquiry = { ID: 0, Approvals: [] };
var PriorityLevels = [];
function _Init() {
    HideSpinner();
    pageNumber = 1
    SetvalOf("txtInquiryPreparedBy", User.Name);
    $("#dvEditClearance").hide();
    $("#dvClearanceList").show();
    SetPagePermission(PAGES.EmployeeInquiry, function () {
        BindUsers();
        
    });
    $("#ddlInquiryDataRange").val(moment().subtract(3, 'month').startOf('month').format("DD/MM/YYYY") + ' - ' + moment().endOf('month').format("DD/MM/YYYY"))

    SetvalOf("txtInquiryDate", moment().format("DD/MM/YYYY"));
}
function BindUsers() {
    $.post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        if (Response.length > 1) data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
        })
        $("#ddEmployeeCode").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data,
            width: "100%"
        }).on('select2:select', function (e) {
            BindInquiryList();
        });
        

        $("#ddEmployeeName").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data,
            width: "100%"
        });
        if (data.length == 1) {
            $("#ddEmployeeName,#ddEmployeeCode").val(data[0].id).trigger("change")
        }

        Post("/DataList/PriorityLevels", {}).done(function (Response) {
            FillList("ddlPriorityLevel", Response, "Name", "ID", "Choose Request Priority");
            PriorityLevels = Response;
        });

        BindInquiryList();
    })
    //Post("/SettingAPI/DivisionList", {}).done(function (Response) {
    //    FillList("ddEmployeeDivision", Response, "Name", "ID", "Select Division")

    //});
    //Post("/SettingAPI/PositionList", {}).done(function (Response) {
    //    FillList("ddEmployeePosition", Response, "Name", "ID", "Select Position")
    //});
    //Post("/SettingAPI/NationalityList", {}).done(function (Response) {
    //    FillList("ddEmployeeNationality", Response, "Name", "ID", "Select Nationality")
    //});
    $.post("/EmployeeAPI/Supervisors", {}).done(function (Response) {
        var data = []
        data.push({ id: 0, text: 'Select Supervisor' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.DivisionID, text: emp.Name });
        })
        //FillList("ddSupervisorApproval1", Response, "Name", "DivisionID", "Select Supervisor")
        //FillList("ddSupervisorApproval3", Response, "Name", "DivisionID", "Select Supervisor")
        //FillList("ddSupervisorApproval3", Response, "Name", "DivisionID", "Select Supervisor")
        //FillList("ddSupervisorApproval4", Response, "Name", "DivisionID", "Select Supervisor")


        $(".supervisor").select2({
            placeholder: "Select Supervisor",
            data: data,
            width: "100%"
        })
    });


}

function BindInquiryList(PageNumber = 1) {
    pageNumber = PageNumber;
    $("#tblEmployeeInQuiryList").empty();

    var StartDate = "", EndDate = "";
    if (valOf("ddlInquiryDataRange") != "") {
        StartDate = $.trim(valOf("ddlInquiryDataRange").split("-")[0]);
        EndDate = $.trim(valOf("ddlInquiryDataRange").split("-")[1]);
    }

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
                EmployeeID: valOf("ddEmployeeCode"),
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
                tr.append($('<td>').append(r.EmployeeID).append("<br>").append("Name:" + r.EmployeeName))

                tr.append($('<td>').append(r.Division))
                tr.append($('<td>').append(r.Position))
                tr.append($('<td>').append(r.Nationality))
                tr.append($('<td>').text(moment(r.InquiryDate).format("DD/MM/YYYY")))
                tr.append($('<td>').append(r.Remarks))

                tr.append($('<td>').append(r.Preparedby).append(r.PriorityLevelID > 0 ? '<br><span class="badge badge-primary" style="background-color:' + r.ColorCode + '">' + r.PriorityLevelName : ''));

                tr.append($('<td>').append(CheckboxSwitch("", (r.PersonalInquiry ? "checked" : ""), "", "")))
                tr.append($('<td>').append(CheckboxSwitch("", (r.GeneralInquiry ? "checked" : ""), "", "")))
                tr.append($('<td>').append(CheckboxSwitch("", (r.LoanInquiry ? "checked" : ""), "", "")))


                var Icons = $('<div class="icons">');
                $(Icons).append($('<a href="javascript:void(0)" class="me-2 writeble" onclick="EditInquiry(' + r.ID + ')"><i class="fa fa-edit"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="deleteble" onclick="DeleteInquiry(' + r.ID + ')"><i class="fa fa-trash"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="" onclick="PrintInquiry(' + r.ID + ')"><i class="fa fa-print"></i></a>'));
                tr.append($('<td>').append($(Icons)));

                $("#tblEmployeeInQuiryList").append(tr);

            });


        }
    })

}

function PrintInquiry(ID) {
    window.open("/Employee/PrintReport?ID=" + ID + "&ReportID=" + PAGES.EmployeeInquiry, "ReportPreview", "toolbar=no,status=yes,scrollbars=yes;width:850;height:950")
}
function EditInquiry(ID) {

    $("#dvEditInquiry").removeClass("d-none");
    $("#dvInquiryList").addClass("d-none");

    Post("/EmployeeAPI/EmployeeInquiryDetail", { ID: ID }).done(function (resp) {

        Inquiry = resp;
        SetvalOf("ddEmployeeName", Inquiry.EmployeeID).trigger("change");
        SetvalOf("txtInquiryDate", moment(Inquiry.InquiryDate).format("DD/MM/YYYY"))
        SetvalOf("txtInquiryPreparedBy", Inquiry.Preparedby);
        SetvalOf("txtInquiryRemarks", Inquiry.Remarks);
        SetChecked("chkInquiryPersonal", Inquiry.PersonalInquiry);
        SetChecked("chkInquiryGeneral", Inquiry.GeneralInquiry);
        SetChecked("chkInquiryLoan", Inquiry.LoanInquiry);

        $.each(Inquiry.Approvals, function (i, a) {
            SetvalOf("ddSupervisorApproval" + (i + 1), a.DivisionID).trigger("change");
        });

        $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
    });
    ResetDatePicker();

}

function ResetNav() {
    document.getElementById("frmInquiry").reset();
    Inquiry = { ID: 0, Approvals: [] };
    for (i = 1; i <= 4; i++) {
        SetvalOf("ddSupervisorApproval" + (i), 0).trigger("change");
    }
    SetvalOf("ddEmployeeName", 0).trigger("change");

    $("#dvEditInquiry").addClass("d-none")
    $("#dvInquiryList").removeClass("d-none")
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
                required: true,
                min: 1,
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
            } else {
                DataChangeLog.DataUpdated = [];

                if (moment(Inquiry.InquiryDate).format("DD/MM/YYYY") != valOf("txtInquiryDate")) {
                    DataChangeLog.DataUpdated.push({ Field: "InquiryDate", Data: { OLD: Inquiry.InquiryDate, New: valOf("txtInquiryDate") } });
                }

                if (Inquiry.EmployeeID != valOf("ddEmployeeName")) {
                    DataChangeLog.DataUpdated.push({ Field: "Employee", Data: { OLD: Inquiry.EmployeeID, New: valOf("ddEmployeeName") } });
                }

                if (Inquiry.EmployeeID != GetChecked("chkInquiryPersonal")) {
                    DataChangeLog.DataUpdated.push({ Field: "PersonalInquiry", Data: { OLD: Inquiry.PersonalInquiry, New: GetChecked("chkInquiryPersonal") } });
                }
                if (Inquiry.GeneralInquiry != GetChecked("chkInquiryGeneral")) {
                    DataChangeLog.DataUpdated.push({ Field: "GeneralInquiry", Data: { OLD: Inquiry.GeneralInquiry, New: GetChecked("chkInquiryGeneral") } });
                }
                if (Inquiry.LoanInquiry != GetChecked("chkInquiryLoan")) {
                    DataChangeLog.DataUpdated.push({ Field: "LoanInquiry", Data: { OLD: Inquiry.LoanInquiry, New: GetChecked("chkInquiryLoan") } });
                }


                for (i = 1; i <= 4; i++) {
                    if (i <= Inquiry.Approvals.length) {
                        if (Inquiry.Approvals[i - 1].DivisionID != valOf("ddSupervisorApproval" + (i))) {
                            if (valOf("ddSupervisorApproval" + (i)) == 0)
                                DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: Inquiry.Approvals[i - 1].Name, New: "-" } });
                            else
                                DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: Inquiry.Approvals[i - 1].Name, New: textOf("ddSupervisorApproval" + (i)) } });
                        }
                    } else if (valOf("ddSupervisorApproval" + (i)) > 0) {
                        DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: "-", New: textOf("ddSupervisorApproval" + (i)) } });
                    }

                }

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
                UserName: User.Name,
                RecordCreatedBy: User.ID,
                PriorityLevelID: valOf("ddlPriorityLevel"),
                Approvals: []
            };

            for (i = 1; i <= 4; i++) {
                if (valOf("ddSupervisorApproval" + (i)) > 0) {
                    NewInquiry.Approvals.push({ ID: i, DivisionID: parseInt(valOf("ddSupervisorApproval" + (i))) });
                }
            }
            var PriorityLevel = PriorityLevels.find(x => x.ID = NewInquiry.PriorityLevel)
            Post("/EmployeeAPI/UpdateEmployeeInquiry", { Inquiry: NewInquiry }).done(function (ID) {
                if (ID > 0) {

                    Inquiry.ID = ID;

                    SaveLog(ID);

                    var fileUpload = $('#InquiryFile').get(0);
                    var files = fileUpload.files;
                    if (files.length > 0) {

                        UploadFile("/EmployeeAPI/UpdateEmployeeInquiryFile", files[0], { EmployeeID: NewInquiry.EmployeeID, ID: ID }, function (Status, Response) {

                            
                            if (Status == 1) {

                                if (NewInquiry.ID > 0)
                                    swal("Employee request record added", { icon: "success" })
                                else
                                    swal("Employee request updated", { icon: "success" })

                                ProcessInquiryMail(NewInquiry, PriorityLevel);
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
    $("#dvEditInquiry").removeClass("d-none")
    $("#dvInquiryList").addClass("d-none")
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
}
