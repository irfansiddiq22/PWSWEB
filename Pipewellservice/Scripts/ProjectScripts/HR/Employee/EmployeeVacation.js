var VacationList = [];
var ApprovalList = [];
var AssetList = [];
var Vacation = { ID: 0, Approvals: [], Assets: [] };
function _Init() {
    HideSpinner();
    $("#ddlDataRange").val(moment().startOf('month').format('DD/MM/YYYY') + ' - ' + moment().endOf('week').format('DD/MM/YYYY'));
    SetPagePermission(PAGES.EmployeeVacation, function () {

        SetvalOf("txtPreparedBy", User.Name);
        $("#dvEditVacation").hide();
        $("#dvVacationList").show();
        BindUsers();
        BindVacation();
        ResetChangeLog(PAGES.EmployeeVacation)
    });

}
function BindUsers() {
    Post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        if (Response.length>1) data.push({ id: 0, text: 'Select an employee' });
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
            BindVacation();
        });
        $("#ddEmployeeName").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data,
            width: "100%"
        }).on('select2:select', function (e) {
            BindEmployeePositionDivision();
            BindEmployeeAssets();
            });

        if (data.length == 1) {
            $("#ddEmployeeName,#ddEmployeeCode").val(data[0].ID)
            BindEmployeePositionDivision();
            BindEmployeeAssets();
            BindVacation()
        }

    })
    Post("/SettingAPI/DivisionList", {}).done(function (Response) {
        FillList("ddEmployeeDivision", Response, "Name", "ID", "Select Division")

    });
    Post("/SettingAPI/PositionList", {}).done(function (Response) {
        FillList("ddEmployeePosition", Response, "Name", "ID", "Select Position")
    });
    Post("/SettingAPI/NationalityList", {}).done(function (Response) {
        FillList("ddEmployeeNationality", Response, "Name", "ID", "Select Nationality")
    });
    Post("/EmployeeAPI/WarningSupervisors", {}).done(function (Response) {
        var data = []
        data.push({ id: 0, text: 'Select Supervisor' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.Name });
        })
        FillList("ddApproval1", Response, "Name", "ID", "Select Supervisor")
        FillList("ddApproval2", Response, "Name", "ID", "Select Supervisor")
        FillList("ddApproval3", Response, "Name", "ID", "Select Supervisor")
        FillList("ddApproval4", Response, "Name", "ID", "Select Supervisor")
        FillList("ddApproval5", Response, "Name", "ID", "Select Supervisor")
        FillList("ddApproval6", Response, "Name", "ID", "Select Supervisor")
        FillList("ddApproval7", Response, "Name", "ID", "Select Supervisor")
        FillList("ddApproval8", Response, "Name", "ID", "Select Supervisor")
        FillList("ddApproval9", Response, "Name", "ID", "Select Supervisor")
        FillList("ddApproval10", Response, "Name", "ID", "Select Supervisor")
        FillList("ddApproval11", Response, "Name", "ID", "Select Supervisor")

        $(".supervisor").select2({
            placeholder: "Select Supervisor",
            data: data,
            width: "100%"
        })
    });


}

function BindEmployeePositionDivision() {
    var EmployeeID = $("#ddEmployeeName").val();
    Post("/EmployeeAPI/EmployeeData", { EmployeeID: EmployeeID }).done(function (Response) {
        var DivisionID = Response[0].DivisionID;
        var PositionID = Response[0].PositionID;
        var IqmaExpiryDate = Response[0].IqmaExpiryDate;
        var VacationRotation = Response[0].VacationRotation;

        $("#ddEmployeeNationality").val(Response[0].NationalityID).trigger("change")
        $("#ddEmployeeDivision").val(DivisionID).trigger("change")
        $("#ddEmployeePosition").val(PositionID).trigger("change")

        SetvalOf("txtIqama", moment(IqmaExpiryDate).format("DD/MM/YYYY"));
        SetvalOf("txtLeaveSchedule", VacationRotation);

    });
}

function BindEmployeeAssets() {
    var EmployeeID = $("#ddEmployeeName").val();
    Post("/EmployeeAPI/AssetList", { EmployeeID: EmployeeID }).done(function (Response) {

        $("#tblVacationAssets").empty();
        $.each(Response, function (i, a) {
            var tr = $('<tr>')
            tr.append($('<td width="10px">').append($('<input type="checkbox" data-id="' + a.ID + '">').prop("checked", (a.ID > 0))))
            tr.append($('<td>').append(a.Name))
            $("#tblVacationAssets").append(tr);
        });
    });
}

function BindVacation() {
    $("#tblEmployeeVacationList").empty();
    Vacation = { ID: 0, Approvals: [], Assets: [] };
    $(".breadcrumb-item.active").find("a").contents().unwrap();

    var StartDate, EndDate = ''
    Warning = { ID: 0 };
    ResetChangeLog(PAGES.EmployeeVacation);
    StartDate = $.trim($("#ddlDataRange").val().split("-")[0])
    EndDate = $.trim($("#ddlDataRange").val().split("-")[1]);

    Post("/EmployeeAPI/EmployeeVacationList", {
        EmployeeID: valOf("ddEmployeeCode") == null ? 0 : valOf("ddEmployeeCode"),
        StartDate: StartDate, EndDate: EndDate,
        EmergencyOnly: GetChecked("chkEmergencyOnly")

    }).done(function (Response) {
        VacationList = Response.Vacation;
        ApprovalList = Response.Approvals;
        AssetList = Response.Assets;


        $.each(VacationList, function (i, r) {
            var tr = $('<tr>')
            tr.append($('<td>').text(r.ID))
            tr.append($('<td>').append(r.EmployeeID).append("<br>").append("Name:" + r.EmployeeName).append("<br>Division: " + r.Division).append("<br>Position: " + r.Position))
            tr.append($('<td>').text(r.Pay))
            tr.append($('<td>').text(r.WithOutPay))
            tr.append($('<td>').text(r.Approved))
            tr.append($('<td>').text(r.Destination))
            tr.append($('<td>').text(moment(r.DepartDate).format("DD/MM/YYYY")))
            tr.append($('<td>').text(moment(r.ReturnDate).format("DD/MM/YYYY")))
            tr.append($('<td>').text(r.Reason))
            tr.append($('<td>').text(r.VacationRotation))



            tr.append($('<td>').text(r.Dues))
            tr.append($('<td>').text(r.Duration))
            var tbl = $('<table>')
            $(tbl).append($("<tr>").append($('<td>').text("Emergencey")).append($('<td>').append('<input type="checkbox" ' + (r.Emergency ? "checked" : "") + '>')));
            $(tbl).append($("<tr>").append($('<td>').text("Vacation Due")).append($('<td>').append('<input type="checkbox" ' + (r.VacationDue ? "checked" : "") + '>')));
            $(tbl).append($("<tr>").append($('<td>').text("Travel Order")).append($('<td>').append('<input type="checkbox" ' + (r.VacationDue ? "checked" : "") + '>')));
            $(tbl).append($("<tr>").append($('<td>').text("Iqama renewal")).append($('<td>').append('<input type="checkbox" ' + (r.IqamaRenewal ? "checked" : "") + '>')));
            $(tbl).append($("<tr>").append($('<td>').text("Ticket")).append($('<td>').append('<input type="checkbox" ' + (r.Ticket ? "checked" : "") + '>')));
            $(tbl).append($("<tr>").append($('<td>').text("Entry Exit Visa")).append($('<td>').append('<input type="checkbox" ' + (r.EntryExitVisa ? "checked" : "") + '>')));
            tr.append($('<td>').append($(tbl)))
            tr.append($('<td>').append(moment(r.RecordDate).format("DD/MM/YYYY")))
            tr.append($('<td>').append(r.PreparedBy))

            tr.append($('<td>').append(moment(r.FinalDepartDate).format("DD/MM/YYYY")))
            tr.append($('<td>').append(moment(r.LastWorkingDate).format("DD/MM/YYYY")))
            tr.append($('<td>').append(r.HandOver))
            tr.append($('<td>').append(r.Contact))
            tr.append($('<td>').append(r.Remarks))



            var Icons = $('<div class="icons">');
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary writeble me-2" onclick="EditVacation(' + i + ')"><i class="fa fa-edit"></i></a>'));
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger deleteble" onclick="DeleteVacation(' + r.ID + ')"><i class="fa fa-trash"></i></a>'));
            tr.append($('<td>').append($(Icons)));

            $("#tblEmployeeVacationList").append(tr);
        });
    })
}
function DeleteVacation(ID) {
    SwalConfirm("Are you sure to delete this record?", function () {
        Post("/EmployeeAPI/DeleteEmployeeVacation", { ID: ID }).done(function (ID) {
            BindVacation();

        });
    })
}
function EditVacation(index) {
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:CancelNewVacation()"));
    $("#dvEditVacation").show();
    $("#dvVacationList").hide();

    Vacation = VacationList[index];
    var Approvals = ApprovalList.filter(x => x.RecordID === Vacation.ID)
    var Assets = AssetList.filter(x => x.EmployeeID === Vacation.EmployeeID)
    Vacation.Approvals = Approvals;
    Vacation.Assets = Assets;

    SetvalOf("ddEmployeeName", Vacation.EmployeeID).trigger("change");
    SetvalOf("txtRecordDate", moment(Vacation.RecordDate).format("DD/MM/YYYY"));
    SetvalOf("txtwithPay", Vacation.WithPay);
    SetvalOf("txtwithoutPay", Vacation.WithOutPay);
    SetvalOf("txtreason", Vacation.Reason);
    SetChecked("Chkemergency", Vacation.Emergency);
    SetChecked("ChkvacationDue", Vacation.VacationDue);
    SetChecked("chktravelOrder", Vacation.TravelOrder);
    SetChecked("chkticket", Vacation.Ticket);
    SetChecked("chkiqamaRenewal", Vacation.IqamaRenewal);
    SetChecked("chkentryExitVisa", Vacation.EntryExitVisa);
    SetvalOf("txtremarks", Vacation.Remarks);
    SetvalOf("txtApproved", Vacation.Approved);
    SetvalOf("txtDestination", Vacation.Destination);
    SetvalOf("txtDepartDate", moment(Vacation.DepartDate).format("DD/MM/YYYY"));
    SetvalOf("txtReturnDate", moment(Vacation.ReturnDate).format("DD/MM/YYYY"));
    SetvalOf("txtLastJoinDate", moment(Vacation.lastJoinDate).format("DD/MM/YYYY"));
    SetvalOf("txtDues", Vacation.Dues);
    SetvalOf("txtExitEntryDuration", Vacation.Duration);
    SetvalOf("txtMonthsEarly", Vacation.MonthsEarly);
    SetvalOf("txtPreparedBy", Vacation.PreparedBy);
    SetvalOf("txtContact", Vacation.Contact);
    SetvalOf("txtHandover", Vacation.HandOver);
    SetvalOf("txtLastWorkingDate", moment(Vacation.LastWorkingDate).format("DD/MM/YYYY"));
    SetvalOf("txtFinalDepartDate", moment(Vacation.FinalDepartDate).format("DD/MM/YYYY"));


    BindEmployeePositionDivision();
    
    
    
    $.each(Approvals, function (i, a) {
        SetvalOf("ddApproval" + (i + 1), a.ApprovalBy).trigger("change");
    });
    $("#tblVacationAssets").empty();
    $.each(Assets, function (i, a) {
        var tr = $('<tr>')
        tr.append($('<td width="10px">').append($('<input type="checkbox" data-id="' + a.AssetID + '">').prop("checked", (a.ID > 0))))
        tr.append($('<td>').append(a.Name))
        $("#tblVacationAssets").append(tr);
    });
    ResetDatePicker();
}

function SaveEmployeeVacation() {
    $("#frmVacation").validate({
        errorClass: "text-danger",
        rules: {
            ddEmployeeName: {
                required: true,
                min: 1
            },
            remarks: "required",
            destination: "required",
            departDate: "required",
            returnDate: "required",
            lastJoinDate: "required",
            exitEntryDuration: "required",
            contact: "required",
            handover: "required",
            lastWorkingDate: "required",
            FinalDepartDate: "required"
        },
        messages: {
            ddEmployeeName: { required: "Please select employee", min: "Please select employee" },
            remarks: "Please enter remarks",
            destination: "Please enter destination",
            departDate: "Please enter depart date",
            returnDate: "Please enter return data",
            lastJoinDate: "Please enter last join date",
            exitEntryDuration: "Please enter exit and entry duration",
            contact: "Please enter contact number",
            FinalDepartDate: "Please enter Final Depart Date",
            handover: "Please enter handover",
            lastWorkingDate: "Please enter last working date"
        },

        submitHandler: function (form) {

            var NewVacation = {
                ID: Vacation.ID,
                EmployeeID: valOf("ddEmployeeName"),
                RecordDate: valOf("txtRecordDate"),
                WithPay: valOf("txtwithPay"),
                WithOutPay: valOf("txtwithoutPay"),
                Reason: valOf("txtreason"),
                Emergency: GetChecked("Chkemergency"),
                VacationDue: GetChecked("ChkvacationDue"),
                TravelOrder: GetChecked("chktravelOrder"),
                Ticket: GetChecked("chkticket"),
                IqamaRenewal: GetChecked("chkiqamaRenewal"),
                EntryExitVisa: GetChecked("chkentryExitVisa"),
                Remarks: valOf("txtremarks"),
                Approved: valOf("txtApproved"),
                Destination: valOf("txtDestination"),
                DepartDate: valOf("txtDepartDate"),
                ReturnDate: valOf("txtReturnDate"),
                lastJoinDate: valOf("txtLastJoinDate"),
                Dues: valOf("txtDues"),
                Duration: valOf("txtExitEntryDuration"),
                MonthsEarly: valOf("txtMonthsEarly"),
                PreparedBy: valOf("txtPreparedBy"),
                Contact: valOf("txtContact"),
                HandOver: valOf("txtHandover"),
                LastWorkingDate: valOf("txtLastWorkingDate"),
                FinalDepartDate: valOf("txtFinalDepartDate"),
                Approvals: [],
                Assets: []
            };


            if (Vacation.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: textOf("ddEmployeeName") } });
            } else {
                DataChangeLog.DataUpdated = [];


                jQuery.each(NewVacation, function (name, value) {
                    if (name != 'Approvals' && name != 'Assets') {
                        if ($.trim(value) != $.trim(Vacation[name])) {
                            DataChangeLog.DataUpdated.push({ Field: name, Data: { OLD: Vacation[name], New: $.trim(value) } });
                        }
                    }
                });

                NewVacation.Approvals = [];
                NewVacation.Assets = [];

                for (i = 1; i <= 11; i++) {
                    if (i <= Vacation.Approvals.length) {
                        if (Vacation.Approvals[i - 1].ApprovalBy != valOf("ddApproval" + (i))) {
                            if (valOf("ddApproval" + (i)) == 0)
                                DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: Vacation.Approvals[i - 1].Name, New: "-" } });
                            else
                                DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: Vacation.Approvals[i - 1].Name, New: textOf("ddApproval" + (i)) } });
                        }
                    } else if (valOf("ddApproval" + (i)) > 0) {
                        DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: "-", New: textOf("ddApproval" + (i)) } });
                    }

                }
                $("#tblVacationAssets tr").each(function (i, r) {
                    var assest = $(this).find("td:eq(0)").find(":checkbox")

                    if ($(assest).prop("checked") != (Vacation.Assets[i].ID > 0)) {
                        DataChangeLog.DataUpdated.push({
                            Field: "Asset" + (i + 1), Data: {
                                OLD: Vacation.Assets[i].Name + ":" + (Vacation.Assets[i].ID > 0 ? "True" : "False"),
                                New: Vacation.Assets[i].Name + ":" + ($(assest).prop("checked") ? "True" : "False")
                            }
                        });
                    }
                })
            }


            for (i = 1; i <= 11; i++) {
                if (valOf("ddApproval" + (i)) > 0) {
                    NewVacation.Approvals.push({ ID: i, ApprovalBy: parseInt(valOf("ddApproval" + (i))) });
                }
            }
            $("#tblVacationAssets tr").each(function (i, r) {
                var assest = $(this).find("td:eq(0)").find(":checkbox")

                if ($(assest).prop("checked")) {
                    NewVacation.Assets.push({ ID: i + 1, AssetID: parseInt($(assest).attr("data-id")) })
                }

            });
            console.log(DataChangeLog);
            console.log(NewVacation);

            Post("/EmployeeAPI/UpdateEmployeeVacation", { Vacation: NewVacation }).done(function (ID) {
                if (ID > 0) {
                    if (NewVacation.ID > 0)
                        swal("Employee Vacation record added", { icon: "success" })
                    else
                        swal("Employee Vacation updated" { icon: "success" })
                    SaveLog(ID);
                    BindVacation()
                    CancelNewVacation();
                }

            })
            return false;
        }
    });




}

function CancelNewVacation() {
    document.getElementById("frmVacation").reset();

    Vacation = { ID: 0, Approvals: [], Assets: [] };
    SetvalOf("ddEmployeeName", 0).trigger("change")
    SetvalOf("ddEmployeeDivision", 0);
    SetvalOf("ddEmployeePosition", 0);
    SetvalOf("ddEmployeeNationality", 0);

    SetvalOf("txtRecordDate", moment().format("DD/MM/YYYY"))
    SetvalOf("txtPreparedBy", User.Name);
    SetvalOf("txtReturnDate", moment().format("DD/MM/YYYY"))
    SetvalOf("txtDepartDate", moment().format("DD/MM/YYYY"))
    SetvalOf("txtLastWorkingDate", moment().format("DD/MM/YYYY"))
    SetvalOf("txtFinalDepartDate", moment().format("DD/MM/YYYY"))



    $("#tblVacationAssets").empty();
    for (i = 1; i <= 11; i++) {
        SetvalOf("ddApproval" + (i), 0).trigger("change");
    }

    $("#dvEditVacation").hide();
    $("#dvVacationList").show();
    $(".breadcrumb-item.active").find("a").contents().unwrap();
    ResetDatePicker();
}

function NewVacation() {
    CancelNewVacation();
    $("#dvEditVacation").show();
    $("#dvVacationList").hide();

    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:CancelNewVacation()"));


}
