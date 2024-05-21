var ShortLeaves = [];
var ApprovalList = [];
var ShortLeave = { ID: 0, Approvals: [] }
function _Init() {
    HideSpinner();
    $("#txtRecordDate").val(moment().format("DD/MM/YYYY"))

    SetvalOf("txtRecordTime", moment().format("HH:mm"));
    

    SetPagePermission(PAGES.ShortLeave, function () {


        $("#dvEditShortLeave").hide();
        $("#dvShortLeaveList").show();
        BindUsers();
        
        ResetChangeLog(PAGES.ShortLeave)
        $("#ddEmployeeCode").change(function () {
            BindShortLeaves();
        })
    });
    
}
function BindUsers() {
    Post("/EmployeeAPI/CodeName", {}).done(function (Response) {

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
        }).on('select2:select', function (e) {
            
        });

        if (data.length == 1) {
            $("#ddEmployeeName").val(data[0].id);
            
        }

        BindShortLeaves();
    })
    
    


}
function BindShortLeaves() {
    $("#tblEmployeeShortLeaveList").empty();
    ShortLeave = { ID: 0, Approvals: [] };
    $(".breadcrumb-item.active").find("a").contents().unwrap();

    var StartDate, EndDate = ''
    ShortLeave = { ID: 0 };
    ResetChangeLog(PAGES.ShortLeave);
    StartDate = "";
    EndDate = "";

    Post("/EmployeeAPI/EmployeeShortLeaves", {
        EmployeeID: valOf("ddEmployeeName") == null ? 0 : valOf("ddEmployeeName"),
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

            tr.append($('<td>').text(r.Status))


            
            

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
                LeaveTime: valOf("txtRecordTime"),
                Remarks: valOf("txtremarks"),
                Approvals: []
            };


            
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: textOf("ddEmployeeName") } });
            
            $.each(User.Supervisors, function (i, s) {
                NewLeave.Approvals.push({ ID: s.ID, DivisionID: s.DivisionID });
            });

             
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
                                ProcessShortLeaveMail();
                                BindShortLeaves(NewLeave)
                                CancelNewLeave();
                            } else {

                                swal("Failed to upload leave sheet file.", { icon: "error" })
                            }
                        });
                    }
                    else {

                        if (NewLeave.ID == 0)
                            swal("Employee leave record added", { icon: "success" })
                        else
                            swal("Employee leave records updated", { icon: "success" })
                        ProcessShortLeaveMail(NewLeave);
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
function ProcessShortLeaveMail() {
    Post("/EmployeeAPI/ProcessShortLeaveMail", { record: NewLeave}, function (resp) { });
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
    SetvalOf("txtRecordTime", moment().format("HH:MM"))
}

