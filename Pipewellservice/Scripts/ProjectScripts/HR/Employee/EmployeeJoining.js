var JoiningList = [];
var ApprovalList = [];

var Joining = { ID: 0, Approvals: [] };
function _Init() {
    HideSpinner();
    $("#ddlDataRange").val(moment().startOf('month').format('DD/MM/YYYY') + ' - ' + moment().endOf('week').format('DD/MM/YYYY'));
    SetPagePermission(PAGES.EmployeeJoining, function () {

        $("#dvEditJoining").hide();
        $("#dvJoiningList").show();
        BindUsers();
        BindJoining();
    });

}
function BindUsers() {
    Post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        data.push({ id: 0, text: 'Select an employee' });
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
            BindWarnings();
        });
        $("#ddEmployeeName").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data,
            width: "100%"
        }).on('select2:select', function (e) {
            BindEmployeePositionDivision();
        });
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
        
        $("#ddEmployeeNationality").val(Response[0].NationalityID).trigger("change")
        $("#ddEmployeeDivision").val(DivisionID).trigger("change")
        $("#ddEmployeePosition").val(PositionID).trigger("change")

    });
}



function BindJoining() {
    $("#tblEmployeeJoiningList").empty();
    Joining = { ID: 0, Approvals: [] };
    $(".breadcrumb-item.active").find("a").contents().unwrap();

    var StartDate, EndDate = ''
    Warning = { ID: 0 };
    ResetChangeLog(PAGES.EmployeeVacation);
    StartDate = $.trim($("#ddlDataRange").val().split("-")[0])
    EndDate = $.trim($("#ddlDataRange").val().split("-")[1]);

    Post("/EmployeeAPI/EmployeeJoining", {
        EmployeeID: valOf("ddEmployeeCode") == null ? 0 : valOf("ddEmployeeCode"),
        StartDate: StartDate, EndDate: EndDate

    }).done(function (Response) {
        JoiningList = Response.Joining;
        ApprovalList = Response.Approvals;


        $.each(JoiningList, function (i, r) {
            var tr = $('<tr>')
            tr.append($('<td>').text(r.ID))
            tr.append($('<td>').append(r.EmployeeID).append("<br>").append("Name:" + r.EmployeeName).append("<br>Division: " + r.Division).append("<br>Position: " + r.Position))
            tr.append($('<td>').text(r.Remarks))
            tr.append($('<td>').text(moment(r.LastDepartDate).format("DD/MM/YYYY")))
            tr.append($('<td>').text(moment(r.JoiningDate).format("DD/MM/YYYY")))
            tr.append($('<td>').text(moment(r.JoiningDate).diff(moment(r.LastDepartDate), 'days')))

            tr.append($('<td>').text(moment(r.NextDepartDate).format("DD/MM/YYYY")))
            tr.append($('<td>').text(moment(r.RecordDate).format("DD/MM/YYYY")))
            tr.append($('<td>').text(r.Division))
            tr.append($('<td>').text(r.Position))
            tr.append($('<td>').text(r.Nationality))



            var Icons = $('<div class="icons">');
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary writeble me-2" onclick="EditJoining(' + i + ')"><i class="fa fa-edit"></i></a>'));
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger deleteble" onclick="DeleteJoining(' + r.ID + ')"><i class="fa fa-trash"></i></a>'));
            tr.append($('<td>').append($(Icons)));

            $("#tblEmployeeJoiningList").append(tr);
        });
    })
}
function DeleteJoining(ID) {
    SwalConfirm("Are you sure to delete this record?", function () {
        Post("/EmployeeAPI/DeleteEmployeeJoining", { ID: ID }).done(function (ID) {
            BindJoining();

        });
    })
}
function EditJoining(index) {
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:CancelNewJoining()"));
    $("#dvEditJoining").show();
    $("#dvJoiningList").hide();

    Joining = JoiningList[index];
    var Approvals = ApprovalList.filter(x => x.RecordID === Joining.ID)
    Joining.Approvals = Approvals;

    SetvalOf("ddEmployeeName", Joining.EmployeeID).trigger("change")
    SetvalOf("recorddate", moment(Joining.RecordDate).format("DD/MM/YYYY"));
    SetvalOf("LastDepartDate", moment(Joining.LastDepartDate).format("DD/MM/YYYY"));
    SetvalOf("JoiningDate", moment(Joining.JoiningDate).format("DD/MM/YYYY"));
    SetvalOf("NextDepartDate", moment(Joining.NextDepartDate).format("DD/MM/YYYY"));
    SetvalOf("Remarks", Joining.Remarks);


    BindEmployeePositionDivision();
    ResetDatePicker();


    $.each(Approvals, function (i, a) {
        SetvalOf("ddlapproval" + (i + 1), a.ApprovalBy).trigger("change");
    });

}

function SaveEmployeeJoining() {
    $("#frmJoining").validate({
        errorClass: "text-danger",
        rules: {
            employeeName: {
                required: true,
                min: 1
            },
            remarks: "required",
            recorddate: "required",
            LastDepartDate: "required",
            JoiningDate: "required",
            NextDepartDate: "required",
            contact: "required",
            handover: "required",
            lastWorkingDate: "required",
            FinalDepartDate: "required"
        },
        messages: {
            employeeName: { required: "Please select employee", min: "Please select employee" },
            remarks: "Please enter remarks",
            recorddate: "Please enter destination",
            LastDepartDate: "Please enter depart date",
            JoiningDate: "Please enter joining data",
            NextDepartDate: "Please enter next depart date"
        },

        submitHandler: function (form) {

            var NewJoining = {
                ID: Joining.ID,
                EmployeeID: valOf("ddEmployeeName"),
                RecordDate: valOf("recorddate"),
                LastDepartDate: valOf("LastDepartDate"),
                JoiningDate: valOf("JoiningDate"),
                NextDepartDate: valOf("NextDepartDate"),
                Remarks: valOf("Remarks"),
                Approvals: [],
                PreparedBy: User.Name,
            };


            if (Joining.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: textOf("ddEmployeeName") } });
            } else {
                DataChangeLog.DataUpdated = [];


                jQuery.each(NewJoining, function (name, value) {
                    if (name != 'Approvals') {
                        if ($.trim(value) != $.trim(Joining[name])) {
                            DataChangeLog.DataUpdated.push({ Field: name, Data: { OLD: Joining[name], New: $.trim(value) } });
                        }
                    }
                });

                NewJoining.Approvals = [];

                for (i = 1; i <= 3; i++) {
                    if (i <= Joining.Approvals.length) {
                        if (Joining.Approvals[i - 1].ApprovalBy != valOf("ddlapproval" + (i))) {
                            if (valOf("ddlapproval" + (i)) == 0)
                                DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: Joining.Approvals[i - 1].Name, New: "-" } });
                            else
                                DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: Joining.Approvals[i - 1].Name, New: textOf("ddlapproval" + (i)) } });
                        }
                    } else if (valOf("ddlapproval" + (i)) > 0) {
                        DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: "-", New: textOf("ddlapproval" + (i)) } });
                    }

                }

            }


            for (i = 1; i <= 3; i++) {
                if (valOf("ddlapproval" + (i)) > 0) {
                    NewJoining.Approvals.push({ ID: i, ApprovalBy: parseInt(valOf("ddlapproval" + (i))) });
                }
            }

            console.log(DataChangeLog);
            console.log(NewJoining);

            Post("/EmployeeAPI/UpdateEmployeeJoining", { record: NewJoining }).done(function (ID) {

                if (ID > 0) {

                    Joining.ID = ID;

                    SaveLog(ID);

                    var fileUpload = $('#JoiningSheet').get(0);
                    var files = fileUpload.files;
                    if (files.length > 0) {

                        UploadFile("/EmployeeAPI/UpdateJoiningSheet", files[0], { EmployeeID: Joining.EmployeeID, ID: ID }, function (Status, Response) {

                            if (Response.Status) {

                                if (NewJoining.ID == 0)
                                    swal("Employee Joining record added", { icon: "success" })
                                else
                                    swal("Employee Joining updated", { icon: "success" })
                                BindJoining()
                                CancelNewJoining();
                            } else {

                                swal("Failed to upload inquire file.", { icon: "error" })
                            }
                        });
                    } else {

                        if (NewJoining.ID > 0)
                            swal("Employee Joining record added", { icon: "success" })
                        else
                            swal("Employee Joining updated", { icon: "success" })

                        BindJoining()
                        CancelNewJoining();
                    }
                } else {
                    swal("Failed to upload Joining sheet.", { icon: "error" })
                }


            })
            return false;
        }
    });




}

function CancelNewJoining() {
    document.getElementById("frmJoining").reset();

    Joining = { ID: 0, Approvals: [], Assets: [] };
    SetvalOf("ddEmployeeName", 0).trigger("change")
    SetvalOf("ddEmployeeDivision", 0);
    SetvalOf("ddEmployeePosition", 0);
    SetvalOf("ddEmployeeNationality", 0);

    SetvalOf("recorddate", moment().format("DD/MM/YYYY"))
    SetvalOf("LastDepartDate", moment().format("DD/MM/YYYY"))
    SetvalOf("JoiningDate", moment().format("DD/MM/YYYY"))
    SetvalOf("NextDepartDate", moment().format("DD/MM/YYYY"))
    SetvalOf("txtFinalDepartDate", moment().format("DD/MM/YYYY"))
    SetvalOf("Remarks", "");

    ResetDatePicker();
    for (i = 1; i <= 3; i++) {
        SetvalOf("ddlapproval" + (i), 0).trigger("change");
    }

    $("#dvEditJoining").hide();
    $("#dvJoiningList").show();
    $(".breadcrumb-item.active").find("a").contents().unwrap();
}

function NewJoining() {
    CancelNewJoining();
    $("#dvEditJoining").show();
    $("#dvJoiningList").hide();

    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:CancelNewJoining()"));


}
