var ShortLeaves = [];
var ApprovalList = [];
var ShortLeave = { ID: 0, Approvals: [] }
function _Init() {
    HideSpinner();
    $("#ddlDataRange").val(moment().startOf('month').format('DD/MM/YYYY') + ' - ' + moment().endOf('week').format('DD/MM/YYYY'));
    SetPagePermission(PAGES.ShortLeave, function () {


        $("#dvEditShortLeave").hide();
        $("#dvShortLeaveList").show();
        BindEmployeeLists(0);
        BindShortLeaves();
        ResetChangeLog(PAGES.ShortLeave)
    });

}
function BindShortLeaves() {
    $("#tblEmployeeShortLeaveList").empty();
    ShortLeave = { ID: 0, Approvals: [] };
    $(".breadcrumb-item.active").find("a").contents().unwrap();

    var StartDate, EndDate = ''
    ShortLeave = { ID: 0 };
    ResetChangeLog(PAGES.ShortLeave);
    StartDate = $.trim($("#ddlDataRange").val().split("-")[0])
    EndDate = $.trim($("#ddlDataRange").val().split("-")[1]);

    Post("/EmployeeAPI/EmployeeShortLeaves", {
        EmployeeID: valOf("ddEmployeeCode") == null ? 0 : valOf("ddEmployeeCode"),
        StartDate: StartDate, EndDate: EndDate

    }).done(function (Response) {
        ShortLeaves = Response.Leaves;
        ApprovalList = Response.Approvals;


        $.each(ShortLeaves, function (i, r) {
            var tr = $('<tr>')
            tr.append($('<td>').text(r.ID))
            tr.append($('<td>').append(r.EmployeeID).append("<br>").append("Name:" + r.EmployeeName).append("<br>Division: " + r.Division).append("<br>Position: " + r.Position))
            tr.append($('<td>').text(moment(r.RecordDate).format("DD/MM/YYYY hh:mm A")))

            tr.append($('<td>').text(r.Remarks))
            


            var Icons = $('<div class="icons">');
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary writeble me-2" onclick="EditEmployeeLeave(' + i + ')"><i class="fa fa-edit"></i></a>'));
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger deleteble" onclick="DeleteEmployeeLeave(' + r.ID + ')"><i class="fa fa-trash"></i></a>'));
            tr.append($('<td>').append($(Icons)));

            $("#tblEmployeeShortLeaveList").append(tr);
        });
    })
}

function SaveEmployeeLeave() {

    $("#frmShortLeave").validate({
        errorClass: "text-danger",
        rules: {
            ddEmployeeName: {
                required: true,
                min: 1
            },
            remarks: "required"
        },
        messages: {
            ddEmployeeName: { required: "Please select employee", min: "Please select employee" },
            remarks: "Please enter remarks"
        },

        submitHandler: function (form) {

            var NewLeave = {
                ID: ShortLeave.ID,
                EmployeeID: valOf("ddEmployeeName"),
                RecordDate: valOf("txtRecordDate"),
                LeaveTime: valOf("txtRecrordTime"),
                Remarks: valOf("txtremarks"),
                Approvals: []
            };


            if (ShortLeave.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: textOf("ddEmployeeName") } });
            } else {
                DataChangeLog.DataUpdated = [];


                jQuery.each(NewLeave, function (name, value) {
                    if (name != 'Approvals') {
                        if ($.trim(value) != $.trim(ShortLeave[name])) {
                            DataChangeLog.DataUpdated.push({ Field: name, Data: { OLD: ShortLeave[name], New: $.trim(value) } });
                        }
                    }
                });

                ShortLeave.Approvals = [];

                for (i = 1; i <= 2; i++) {
                    if (i <= ShortLeave.Approvals.length) {
                        if (ShortLeave.Approvals[i - 1].ApprovalBy != valOf("ddlapproval" + (i))) {
                            if (valOf("ddlapproval" + (i)) == 0)
                                DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: ShortLeave.Approvals[i - 1].Name, New: "-" } });
                            else
                                DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: ShortLeave.Approvals[i - 1].Name, New: textOf("ddlapproval" + (i)) } });
                        }
                    } else if (valOf("ddlapproval" + (i)) > 0) {
                        DataChangeLog.DataUpdated.push({ Field: "ddlapproval" + i, Data: { OLD: "-", New: textOf("ddlapproval" + (i)) } });
                    }

                }

            }


            for (i = 1; i <= 2; i++) {
                if (valOf("ddlapproval" + (i)) > 0) {
                    NewLeave.Approvals.push({ ID: i, ApprovalBy: parseInt(valOf("ddlapproval" + (i))) });
                }
            }
            console.log(DataChangeLog);
            console.log(NewLeave);

            Post("/EmployeeAPI/UpdateEmployeeShortLeave", { record: NewLeave }).done(function (ID) {

                if (ID > 0) {


                    ShortLeave.ID = ID;

                    SaveLog(ID);

                    var fileUpload = $('#LeaveFileID').get(0);
                    var files = fileUpload.files;
                    if (files.length > 0) {

                        UploadFile("/EmployeeAPI/UpdateShortLeaveSheet", files[0], { EmployeeID: NewLeave.EmployeeID, ID: ID }, function (Status, Response) {

                            if (Response.Status) {

                                if (NewLeave.ID == 0)
                                    swal("Employee Leave record added", { icon: "success" })
                                else
                                    swal("Employee Leave record updated ", { icon: "success" })
                                BindShortLeaves()
                                CancelNewLeave();
                            } else {

                                swal("Failed to upload leave sheet file.", { icon: "error" })
                            }
                        });
                    } else {

                        if (NewLeave.ID == 0)
                            swal("Employee leave record added", { icon: "success" })
                        else
                            swal("Employee leave records updated", { icon: "success" })
                        BindShortLeaves()
                        CancelNewLeave();

                    }
                } else {
                    swal("Failed to add short leave.", { icon: "error" })
                }

                 

            })
            return false;
        }
    });
}
function DeleteEmployeeLeave(ID) {
    SwalConfirm("Are you sure to delete this record ?", function () {
        Post("/EmployeeAPI/DeleteEmployeeShortLeave", { ID: ID }).done(function (Resp) {
            if (Resp) {
                swal("Record Deleted", { icon: "success" });
                BindShortLeaves();
            } else {
                swal("Failed to delete record", { icon: "error" });
            }
        });
    });
}
function EditEmployeeLeave(index) {
    NewLeave();
    ShortLeave = ShortLeaves[index];
    var Approvals = ApprovalList.filter(x => x.RecordID === ShortLeave.ID)
    ShortLeave.Approvals = Approvals;
    SetvalOf("ddEmployeeName", ShortLeave.EmployeeID).trigger("change");
    SetvalOf("txtRecordDate", moment(ShortLeave.RecordDate).format("DD/MM/YYYY"));
    SetvalOf("txtRecrordTime", moment(ShortLeave.RecordDate).format("HH:mm"));
    SetvalOf("txtremarks", ShortLeave.Remarks);

    $.each(Approvals, function (i, a) {
        SetvalOf("ddlapproval" + (i + 1), a.ApprovalBy).trigger("change");
    });
}

function CancelNewLeave() {
    document.getElementById("frmShortLeave").reset();
    ShortLeave.ID = 0;
    $(".breadcrumb-item.active").find("a").contents().unwrap();
    $("#dvEditShortLeave").hide();
    $("#dvShortLeaveList").show();
    ResetChangeLog(PAGES.ShortLeave)
}
function NewLeave() {
    document.getElementById("frmShortLeave").reset();
    ShortLeave.ID = 0;
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:CancelNewLeave()"));
    $("#dvEditShortLeave").show();
    $("#dvShortLeaveList").hide();
    SetvalOf("txtRecordDate", moment().format("DD/MM/YYYY"))
    SetvalOf("txtRecrordTime", moment().format("HH:MM"))
}

