var LeaveRequest = {
    ID: 0,
    EmployeeID: 0,
    StartDate: '',
    EndDate: '',
    LeaveType: 0,
    Remarks: '',
    RecordCreatedBy: User.ID
};
var PriorityLevels = [];
var LeaveStat = {};
var Message = " Sir,\n\rIt is requested that i want to avail #leave# for #day# day(s), kindly allow me leave for #startdate# to #enddate#.Kindly do the needful and oblige.\n\rThanks,\n#Name#"
function _Init() {

    HideSpinner();
    SetPagePermission(PAGES.LeaveRequest, function () {
        BindUsers();
        $.post("/DataList/LeaveTypes", {}, function (Response) {
            var data = []
            data.push({ id: 0, text: 'Leave Type' });
            $.each(Response, function (i, Lv) {
                if (Lv.Value<13)
                data.push({ id: Lv.Value, text: Lv.Name });
            })
            $("#ddlLeaveTypes").select2({
                tags: "true",
                placeholder: "Leave Type",
                allowClear: true,
                width: '100%',
                data: data
            }).on('select2:select', function (e) {
                BindLeaveStats();
            });
        })
        Post("/DataList/PriorityLevels", {}).done(function (Response) {
            FillList("ddlPriorityLevel", Response, "Name", "ID", "Choose Request Priority");
            PriorityLevels = Response;
        });

        $(".datepicker").val(moment().format("DD/MM/YYYY"));
        
        SetvalOf("txtRecordEndDate", moment().add(2, 'day').format("DD/MM/YYYY"));

        $("#txtRecordStartDate").on('changeDate', function (selected) {
            $('#txtRecordEndDate').datepicker('setStartDate', selected.date)
            if (moment(valOf("txtRecordEndDate"), "DD/MM/YYYY", true).diff(moment(valOf("txtRecordStartDate"), "DD/MM/YYYY", true), 'days') < 0)
                SetvalOf("txtRecordEndDate", moment(selected.date).add(1, 'day').format("DD/MM/YYYY"));
        });
        

        
       /* $(".datepicker").on('changeDate', function (selected) {
            ResetMessageText();
        });
        */

    });

}

function ResetMessageText() {
    return;
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
            $("#ddEmployeeName").val(Response[0].ID).trigger("change")
        }
    })
}
$("#ddEmployeeName").change(function () {
    FillLeaves();
})
function BindLeaveStats() {
    $("#tblLeaveStats").empty()
    if (parseInt($("#ddlLeaveTypes").val()) == 1) {
        var tr = $('<tr>')
        $(tr).append($('<td>').append('<b> Allowance'));
        $(tr).append($('<td>').append('<b> Carried Over'));
        $(tr).append($('<td>').append('<b> Available'));
        $(tr).append($('<td>').append('<b> Used'));
        $(tr).append($('<td>').append('<b> Balance'));
        $(tr).append($('<td>').append('<b> Unit'));
        $("#tblLeaveStats").append(tr);
        if (LeaveStat == null || LeaveStat.Allowance == 0) {
            LeaveStat = {
                Allowance: 30,
                CarriedOver: 0,
                LeavesTaken: 0,
                Available: 30,
                Balance: 30

            }
        }
        tr = $('<tr>')
        $(tr).append($('<td>').append(LeaveStat.Allowance));
        $(tr).append($('<td>').append(LeaveStat.CarriedOver));
        $(tr).append($('<td>').append(LeaveStat.Available));
        $(tr).append($('<td>').append(LeaveStat.LeavesTaken));
        $(tr).append($('<td>').append(LeaveStat.Balance));
        $(tr).append($('<td>').append('Days'));
        $("#tblLeaveStats").append(tr);
    }
}
function FillLeaves() {
    $.post("/EmployeeAPI/EmployeeLeaveStats", { EmployeeID: $("#ddEmployeeName").val() }, function (resp) {
        LeaveStat = resp;
        BindLeaveStats();
    });

    $.post("/EmployeeAPI/EmployeeLeaveRequest", { EmployeeID: $("#ddEmployeeName").val(), StartDate: '', EndDate:'' }, function (resp) {
        $("#tblEmployeeLeaves").empty();
        $.each(resp, function (i, l) {
            var tr = $('<tr>');
            tr.append($('<td>').append(l.LeaveTypeName).append(l.PriorityLevelID > 0 ? '<br><span class="badge badge-primary" style="background-color:' + l.ColorCode + '">' + l.PriorityLevelName:''));
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
            Remarks: "required",
            PriorityLevel: {
                required: true,
                min: 1
            },
        },
        messages: {
            EmployeeName: "Please select employee",
            RecordStartDate: "Please enter leave start date",
            RecordEndDate: "Please enter work resume date",
            LeaveTypes: {
                required: "Please choose leave type",
                min: "Please choose leave type",
            },
            PriorityLevel: {
                required: "Please choose request priority level",
                min: "Please choose  request priority level",
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
                Remarks: valOf("txtRemarks"),
                PriorityLevelID: valOf("ddlPriorityLevel")
            };

            var PriorityLevel = PriorityLevels.find(x => x.ID = NewLeave.PriorityLevelID)

            var fileUpload = $('#LeaveFileID').get(0);
            var files = fileUpload.files;
           /* if (files.length == 0) {
                swal("Please attach leave sheet", { icon: "error" });
                return false;
            }*/
            Post("/EmployeeAPI/NewLeaveRequest", { record: NewLeave, PriorityLevel: PriorityLevel, LeaveStat: LeaveStat }).done(function (Resp) {
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
