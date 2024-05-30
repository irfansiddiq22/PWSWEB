var LeaveRequest = {
    ID: 0,
    EmployeeID: 0,
    StartDate: '',
    EndDate: '',
    LeaveType: 0,
    Remarks: '',
    RecordCreatedBy: User.ID
};

var Message = " Sir,\n\rIt is requested that i want to avail #leave# for #day# day(s), kindly allow me leave for #startdate# to #enddate#.Kindly do the needful and oblige.\n\rThanks,\n#Name#"
function _Init() {

    HideSpinner();
    SetPagePermission(PAGES.LeaveRequest, function () {
        BindUsers();
        $.post("/DataList/LeaveTypes", {}, function (Response) {
            var data = []
            data.push({ id: 0, text: 'Leave Type' });
            $.each(Response, function (i, Lv) {
                if (Lv.Value < 13)
                data.push({ id: Lv.Value, text: Lv.Name });
            })
            $("#ddlLeaveTypes").select2({
                tags: "true",
                placeholder: "Leave Type",
                allowClear: true,
                width: '100%',
                data: data
            }).on('select2:select', function (e) {
                ResetMessageText();
            });
        })
        $(".datepicker").val(moment().format("DD/MM/YYYY"));
        
        SetvalOf("txtRecordEndDate", moment().add(2, 'day').format("DD/MM/YYYY"));

        $("#txtRecordStartDate").on('changeDate', function (selected) {
            $('#txtRecordEndDate').datepicker('setStartDate', selected.date)
            if (moment(valOf("txtRecordEndDate"), "DD/MM/YYYY", true).diff(moment(valOf("txtRecordStartDate"), "DD/MM/YYYY", true), 'days') < 0)
                SetvalOf("txtRecordEndDate", moment(selected.date).add(1, 'day').format("DD/MM/YYYY"));
        });

        $(".datepicker").on('changeDate', function (selected) {
            ResetMessageText();
        });
        
        $("#ddlLeaveDataRange").val(moment().subtract(3, 'month').startOf('month').format("DD/MM/YYYY") + ' - ' + moment().endOf('month').format("DD/MM/YYYY"))
        FillLeaves();
    });

}
function BindLeaveList() {

}
function ResetMessageText() {
    if (valOf("ddlLeaveTypes") > 0 && (moment(valOf("txtRecordStartDate"), "DD/MM/YYYY", true).isValid() && moment(valOf("txtRecordEndDate"), "DD/MM/YYYY", true).isValid())) {
        var LeaveMessage = Message;
        LeaveMessage = LeaveMessage.replace("#leave#", $("#ddlLeaveTypes option:selected").text())
        LeaveMessage = LeaveMessage.replace("#startdate#", $("#txtRecordStartDate").val())
        LeaveMessage = LeaveMessage.replace("#enddate#", $("#txtRecordEndDate").val())
        var end = moment(valOf("txtRecordEndDate"), "DD/MM/YYYY", true);
        var start = moment(valOf("txtRecordStartDate"), "DD/MM/YYYY", true);
        LeaveMessage = LeaveMessage.replace("#day#", end.diff(start, 'days'));
        var name = $("#ddEmployeeName option:selected").text().split("-")
        name.splice(0, 1)
        LeaveMessage = LeaveMessage.replace("#Name#", name.join(" "));

        $("#txtRemarks").val(LeaveMessage);
    }
}
function ResetNav() {
    window.location = "/home"
}

$('form').on('reset', function (e) {
    InitializeLeave();
})
function InitializeLeave() {
    LeaveRequest = {
        ID: 0,
        StartDate: '',
        EndDate: '',
        LeaveType: 0,
        Remarks: '',
        RecordCreatedBy: User.ID
    }

    ResetChangeLog(PAGES.LeaveRequest);
}

function BindUsers() {
    Post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        if (Response.length > 1)
            data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
        })
        $("#ddEmployeeName,#ddEmployeeCode").select2({
            tags: "true",
            placeholder: "Select Employee",
            allowClear: true,
            width: '100%',
            data: data
        })

        if (Response.length == 1) {
            $("#ddEmployeeCode").val(Response[0].ID).trigger("change")
        }
    })
}
$("#ddEmployeeCode").change(function () {
    ResetMessageText();
    FillLeaves();
})
function FillLeaves() {
    

    var StartDate = "", EndDate = "";
    if (valOf("ddlLeaveDataRange") != "") {
        StartDate = $.trim(valOf("ddlLeaveDataRange").split("-")[0]);
        EndDate = $.trim(valOf("ddlLeaveDataRange").split("-")[1]);
    }
    ShowSpinner();

    $.post("/EmployeeAPI/EmployeeLeaveRequest", { EmployeeID: $("#ddEmployeeCode").val(), StartDate: StartDate, EndDate: EndDate }, function (resp) {
        HideSpinner();
        $("#tblEmployeeLeaves").empty();
        $.each(resp, function (i, l) {
            var tr = $('<tr>');
            tr.append($('<td>').text(l.LeaveTypeName));
            tr.append($('<td>').text(moment(l.StartDate).format("DD/MM/YYYY")));
            tr.append($('<td>').text(moment(l.EndDate).format("DD/MM/YYYY")));
            tr.append($('<td>').text(l.Remarks));
            tr.append($('<td>').text(l.LeaveStatus));
            $("#tblEmployeeLeaves").append(tr);
        })
    });
}
function SaveEmployeeLeave() {
    $("#frmLeave").validate({
        errorClass: "text-danger",

        rules: {
            EmployeeName: "required",
            RecordStartDate: "required",
            RecordEndDate: "required",
            LeaveTypes: {
                required: true,
                min: 1
            },
            Remarks: "required"
        },
        messages: {
            EmployeeName: "Please select employee",
            RecordStartDate: "Please enter leave start date",
            RecordEndDate: "Please enter work resume date",
            LeaveTypes: {
                required: "Please choose leave type",
                min: "Please choose leave type",
            },
            Remarks: "Please enter leave request"
        },
        submitHandler: function (form) {
            
            var NewLeave = {
                ID: 0,
                EmployeeID: valOf("ddEmployeeName"),
                StartDate: valOf("txtRecordStartDate"),
                EndDate: valOf("txtRecordEndDate"),
                LeaveType: valOf("ddlLeaveTypes"),
                LeaveTypeName: textOf("ddlLeaveTypes"),
                Remarks: valOf("txtRemarks")
            };


            var fileUpload = $('#LeaveFileID').get(0);
            var files = fileUpload.files;
           /* if (files.length == 0) {
                swal("Please attach leave sheet", { icon: "error" });
                return false;
            }*/
            Post("/EmployeeAPI/NewLeaveRequest", { record: NewLeave }).done(function (Resp) {
                if (Resp.result) {
                    if (files.length > 0) {

                        UploadFile("/EmployeeAPI/UploadLeaveSheet", files[0], { EmployeeID: NewLeave.EmployeeID, ID: Resp.ID }, function (Status, Response) {

                            if (Response.Status) {

                                if (NewLeave.ID == 0) 
                                    swal("Employee Leave record added", { icon: "success" })
                                else
                                    swal("Employee Leave record updated ", { icon: "success" })
                                FillLeaves();
                                document.getElementById("frmLeave").reset();
                            } else {
                                swal("Failed to upload leave sheet file.", { icon: "error" })
                            }
                        });
                    } else {
                        FillLeaves();
                        swal("Employee Leave record added", { icon: "success" })
                        document.getElementById("frmLeave").reset();
                    }
                }
                else {
                    swal("Sorry your request is not saved, please contact admin.", { icon: "error" });

                }
            })
            return false;
        }
    });
}

function NewLeave() {
    $("#ddEmployeeName").val($("#ddEmployeeCode").val());
    $("#ddEmployeeName").trigger("change");
    $("#frmLeave").removeClass("d-none");
    $("#dvEmployeeLeaveList").addClass("d-none");
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:CancelNewLeave()"));

}
function CancelNewLeave() {
    $("#frmLeave").addClass("d-none");
    $("#dvEmployeeLeaveList").removeClass("d-none");
    $(".breadcrumb-item.active").find("a").contents().unwrap();
    InitializeLeave();
}