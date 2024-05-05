var LeaveRequest = {
    ID: 0,
    EmployeeID: 0,
    StartDate: '',
    EndDate: '',
    LeaveType: 0,
    Remarks: '',
    RecordCreatedBy: User.ID
};

var Message = " Sir,\n\rIt is requested that i want to avail #leave# for #day# day(s), kindly allow me leave for #startdate# to #enddate#.Kindly do the needful and oblige.\n\rThanks ,"
function _Init() {

    HideSpinner();
    SetPagePermission(PAGES.LeaveRequest, function () {
        BindUsers();
        $.post("/DataList/LeaveTypes", {}, function (Response) {
            var data = []
            data.push({ id: 0, text: 'Leave Type' });
            $.each(Response, function (i, Lv) {
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
        $(".datepicker").val(moment().format("MM/DD/YYYY"));

        $("#txtRecordStartDate").on('changeDate', function (selected) {
            $('#txtRecordEndDate').datepicker('setStartDate', selected.date)
            if (moment(valOf("txtRecordEndDate"), "DD/MM/YYYY", true).diff(moment(valOf("txtRecordStartDate"), "DD/MM/YYYY", true), 'days') < 0)
                SetvalOf("txtRecordEndDate", moment(selected.date).add(1, 'day').format("DD/MM/YYYY"));
        });

        $(".datepicker").on('changeDate', function (selected) {
            ResetMessageText();
        });


    });

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
        $("#ddEmployeeName").select2({
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

                                document.getElementById("frmLeave").reset();
                            } else {
                                swal("Failed to upload leave sheet file.", { icon: "error" })
                            }
                        });
                    } else {
                        swal("Employee Leave record added", { icon: "success" })
                    }
                }
                else {
                    swal("Sorry your request is not saved, please contact admin", { icon: "error" });

                }
            })
            return false;
        }
    });
}
