var WarningList = [];
var Warning = {ID:0};
function _Init() {
    HideSpinner();
    $("#aWarningSheet").hide()
    $("#ddlWarningDataRange").val(moment().startOf('year').format('DD/MM/YYYY') + ' - ' + moment().endOf('week').format('DD/MM/YYYY'));

    BindUsers();
    BindWarnings();
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
            width:"100%"
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
    Post("/EmployeeAPI/WarningSupervisors", {}).done(function (Response) {
        var data = []
        data.push({ id: 0, text: 'Select Supervisor' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.Name });
        })
        FillList("ddWarningApproval1", Response, "Name", "ID", "Select Supervisor")
        FillList("ddWarningApproval2", Response, "Name", "ID", "Select Supervisor")
        FillList("ddWarningApproval3", Response, "Name", "ID", "Select Supervisor")

        $("#ddWarningApproval1,#ddWarningApproval2,#ddWarningApproval3").select2({
            placeholder: "Select Supervisor",
            data: data,
            width: "100%"
        })
    });


}
function BindWarnings() {
    $("#tblWarningList").empty();
    $("#dvWarningList").show();
    $("#dvEditWarning").hide();
    var StartDate, EndDate = ''
    Warning = { ID: 0 };
    ResetChangeLog(PAGES.EmployeeWarning);
    StartDate = $("#ddlWarningDataRange").val().split("-")[0]
    EndDate = $("#ddlWarningDataRange").val().split("-")[1]
    Post("/EmployeeAPI/EmployeeWarningList", { EmployeeID: $("#ddEmployeeCode").val(), StartDate: StartDate, EndDate: EndDate }).done(function (Response) {
        WarningList = Response;
        $.each(Response, function (i, r) {
            var tr = $('<tr>')
            tr.append($('<td>').text(r.ID))
            tr.append($('<td>').append(r.EmployeeID).append("<br>").append("Name:" + r.EmployeeName).append("<br>Division: " + r.Division).append("<br>Position: " + r.Position))
            tr.append($('<td>').text(moment(r.WarningDate).format("DD/MM/YYYY")))
            tr.append($('<td>').text(r.WarningTypeName))
            tr.append($('<td>').append("Written:<label class='switch float-end'><input type='checkbox' " + (r.Written ?"checked" :"" )+ "><div class='slider round'></div></label><br>")
                .append("Tardiness: <label class='switch float-end'><input type='checkbox'  " + (r.Tardiness ? "checked" : "") + "><div class='slider round'></div></label><br>")
                .append("Absenteeism: <label class='switch float-end'><input type='checkbox'  " + (r.Absenteeism ? "checked" : "") + "><div class='slider round'></div></label><br> ")
                .append("Violation: <label class='switch float-end'><input type='checkbox'  " + (r.Violation ? "checked" : "") + "><div class='slider round'></div></label><br> ")
                .append("Substandard: <label class='switch float-end'><input type='checkbox'  " + (r.Substandard ? "checked" : "") + "><div class='slider round'></div></label><br>")
                .append("Policies: <label class='switch float-end'><input type='checkbox'  " + (r.Policies ? "checked" : "") + "><div class='slider round'></div></label><br> ")
                .append("Rudeness: <label class='switch float-end'><input type='checkbox' " + (r.Rudeness ? "checked" : "") + "><div class='slider round'></div></label><br> ")
                .append("Other: <label class='switch float-end'><input type='checkbox' " + (r.Other ? "checked" : "") + "><div class='slider round'></div></labels><br> ")

            )
            tr.append($('<td>').text(r.OtherDetail))
            tr.append($('<td>').text(r.Infraction))
            tr.append($('<td>').text(r.Improvement))
            tr.append($('<td>').text(r.Consequences))

            tr.append($('<td>').append(r.ApprovedBy1 > 0 ? r.ApprovedBy1Name + (r.Approved1 != 3 ? "<br> Date: " + moment(r.ApprovedDate1).format("MM/DD/YYYYY") + "<br> Approval :" + r.Approved1Name : "") : ""))
            tr.append($('<td>').append(r.ApprovedBy2 > 0 ? r.ApprovedBy2Name + (r.Approved2 != 3 ? "<br> Date: " + moment(r.ApprovedDate2).format("MM/DD/YYYYY") + "<br> Approval :" + r.Approved2Name : "") : ""))
            tr.append($('<td>').append(r.ApprovedBy3 > 0 ? r.ApprovedBy3Name + (r.Approved3 != 3 ? "<br> Date: " + moment(r.ApprovedDate3).format("MM/DD/YYYYY") + "<br> Approval :" + r.Approved3Name : "") : ""))
            tr.append($('<td>').append(r.PreparedBy))

            var Icons = $('<div class="icons">');
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary me-2" onclick="EditWarning(' + i + ')"><i class="fa fa-edit"></i></a>'));
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="DeleteWarning(' + i + ')"><i class="fa fa-trash"></i></a>'));
            tr.append($('<td>').append($(Icons)));


            var Link = $('<a>').attr("href", "javascript:void(0)").attr("onclick", "DownloadContract('" + r.EmployeeID + "','" + r.FileName + "','" + r.FileID + "')").text(r.FileName);
            //tr.append($('<td>').append($(Link)))
            $("#tblWarningList").append(tr);
        });
    })
}
function EditWarning(index) {
    
    Warning = WarningList[index];

    SetvalOf("ddEmployeeName", Warning.EmployeeID).trigger("change")
    SetvalOf("txtWarningDate", moment(Warning.WarningDate).format("DD/MM/YYYY"))
    SetvalOf("ddEmployeeDivision", Warning.DivisionID)
    SetvalOf("ddEmployeePosition", Warning.PositionID)

    SetvalOf("ddWarningApproval1", Warning.ApprovedBy1).trigger("change")
    SetvalOf("ddWarningApproval2", Warning.ApprovedBy2).trigger("change")
    SetvalOf("ddWarningApproval3", Warning.ApprovedBy3).trigger("change")

    if (Warning.WarningType == 1)
        SetChecked("rdWarningType1", "checked").trigger("click");
    else if (Warning.WarningType == 2)
        SetChecked("rdWarningType2", "checked").trigger("click");
    else if (Warning.WarningType == 3)
        SetChecked("rdWarningType3", "checked").trigger("click");

    if (Warning.Written)
        SetChecked("rdWarningWritten", "checked").trigger("click");
    else
        SetChecked("rdWarningVerbal", "checked").trigger("click");


    SetChecked("ChkWarningTardiness", Warning.Tardiness ? "checked" : "");
    SetChecked("ChkWarningAbsenteeism", Warning.Absenteeism ? "checked" : "");
    SetChecked("ChkWarningViolation", Warning.Violation ? "checked" : "");
    SetChecked("ChkWarningSubstandard", Warning.Substandard ? "checked" : "");
    SetChecked("ChkWarningPolicies", Warning.Policies ? "checked" : "");
    SetChecked("ChkWarningRudeness", Warning.Rudeness ? "checked" : "");
    SetChecked("ChkWarningOther", Warning.Other ? "checked" : "");
    SetvalOf("txtWarningOtherDetail", Warning.OtherDetail)

    SetvalOf("txtWarningInfraction", Warning.Infraction)
    SetvalOf("txtWarningImprovement", Warning.Improvement)
    SetvalOf("txtWarningConsequences", Warning.Consequences)
    $("#aWarningSheet").hide()
    if (Warning.FileID != null) {
        $("#aWarningSheet").hide()
        $("#aWarningSheet").attr("onclick", "DownloadWarningSheet('" + Warning.FileID + "','" + Warning.FileName + "')")
    }
    $("#dvEditWarning").show();
    $("#dvWarningList").hide();
}

function SaveEmployeeWarning() {
    $("#frmWarning").validate({
        errorClass: "text-danger",

        rules: {
            EmployeeCode: "required"
        },
        messages: {
            EmployeeCode: "Please select employee"
        },
        submitHandler: function (form) {


            var fileData = new FormData();
            var fileUpload = $('#txtWarningFileFileID').get(0);
            var files = fileUpload.files;
            if (files.length > 0)
                fileData.append(files[0].name, files[0]);

            var WarningType = 1;
            if (GetChecked("rdWarningType2"))
                WarningType = 2;
            if (GetChecked("rdWarningType3"))
                WarningType = 3;



            if (Warning.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: textOf("ddEmployeeName") } });
            } else {

                if ($.trim(Warning.ApprovedBy1) != $.trim(valOf("ddWarningApproval1"))) {
                    DataChangeLog.DataUpdated.push({ Field: "ApprovedBy1", Data: { OLD: Warning.ApprovedBy1Name, New: textOf("ddWarningApproval1") } });
                }
                if ($.trim(Warning.ApprovedBy2) != $.trim(valOf("ddWarningApproval2"))) {
                    DataChangeLog.DataUpdated.push({ Field: "ApprovedBy2", Data: { OLD: Warning.ApprovedBy2Name, New: textOf("ddWarningApproval2") } });
                }
                if ($.trim(Warning.ApprovedBy3) != $.trim(valOf("ddWarningApproval3"))) {
                    DataChangeLog.DataUpdated.push({ Field: "ApprovedBy3", Data: { OLD: Warning.ApprovedBy3Name, New: textOf("ddWarningApproval3") } });
                }
                

                if ($.trim(Warning.WarningType) != WarningType) {
                    DataChangeLog.DataUpdated.push({ Field: "WarningType", Data: { OLD: Warning.WarningType, New: WarningType } });
                }

                if (Warning.Written != GetChecked("rdWarningWritten")) {
                    DataChangeLog.DataUpdated.push({ Field: "Written", Data: { OLD: Warning.Written, New: GetChecked("rdWarningWritten") } });
                }

                if (Warning.Tardiness != GetChecked("ChkWarningTardiness")) {
                    DataChangeLog.DataUpdated.push({ Field: "Tardiness", Data: { OLD: Warning.Tardiness, New: GetChecked("ChkWarningTardiness") } });
                }
                if (Warning.Absenteeism != GetChecked("ChkWarningAbsenteeism")) {
                    DataChangeLog.DataUpdated.push({ Field: "Absenteeism", Data: { OLD: Warning.Absenteeism, New: GetChecked("ChkWarningAbsenteeism") } });
                }
                if (Warning.Violation != GetChecked("ChkWarningViolation")) {
                    DataChangeLog.DataUpdated.push({ Field: "Violation", Data: { OLD: Warning.Violation, New: GetChecked("ChkWarningViolation") } });
                }
                if (Warning.Substandard != GetChecked("ChkWarningSubstandard")) {
                    DataChangeLog.DataUpdated.push({ Field: "Substandard", Data: { OLD: Warning.Substandard, New: GetChecked("ChkWarningSubstandard") } });
                }
                if (Warning.Policies != GetChecked("ChkWarningPolicies")) {
                    DataChangeLog.DataUpdated.push({ Field: "Policies", Data: { OLD: Warning.Policies, New: GetChecked("ChkWarningPolicies") } });
                }
                if (Warning.Rudeness != GetChecked("ChkWarningRudeness")) {
                    DataChangeLog.DataUpdated.push({ Field: "Rudeness", Data: { OLD: Warning.Rudeness, New: GetChecked("ChkWarningRudeness") } });
                }
                if (Warning.Other != GetChecked("ChkWarningOther")) {
                    DataChangeLog.DataUpdated.push({ Field: "Other", Data: { OLD: Warning.Other, New: GetChecked("ChkWarningOther") } });
                }

                if ($.trim(Warning.OtherDetail) != $.trim(valOf("txtWarningOtherDetail"))) {
                    DataChangeLog.DataUpdated.push({ Field: "OtherDetail", Data: { OLD: Warning.OtherDetail, New: valOf("txtWarningOtherDetail") } });
                }

                if ($.trim(Warning.Infraction) != $.trim(valOf("txtWarningInfraction"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Infraction", Data: { OLD: Warning.Infraction, New: valOf("txtWarningInfraction") } });
                }
                if ($.trim(Warning.Improvement) != $.trim(valOf("txtWarningImprovement"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Improvement", Data: { OLD: Warning.Improvement, New: valOf("txtWarningImprovement") } });
                }
                if ($.trim(Warning.Consequences) != $.trim(valOf("txtWarningConsequences"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Consequences", Data: { OLD: Warning.Consequences, New: valOf("txtWarningConsequences") } });
                }
                
                
                if (files.length > 0) {
                    DataChangeLog.DataUpdated.push({ Field: "FileName", Data: { OLD: Warning.FileName, New: files[0].name } });
                }

            }

            
            

            fileData.append('ID', Warning.ID);
            fileData.append('EmployeeID', valOf("ddEmployeeName"));
            fileData.append('WarningDate', valOf("txtWarningDate"));
            fileData.append('WarningType', WarningType);
            fileData.append('Written', GetChecked("rdWarningWritten"));
            fileData.append('Tardiness', GetChecked("ChkWarningTardiness"));
            fileData.append('Absenteeism', GetChecked("ChkWarningTardiness"));
            fileData.append('Violation', GetChecked("ChkWarningViolation"));
            fileData.append('Substandard', GetChecked("ChkWarningSubstandard"));
            fileData.append('Policies', GetChecked("ChkWarningPolicies"));
            fileData.append('Rudeness', GetChecked("ChkWarningRudeness"));
            fileData.append('Other', GetChecked("ChkWarningOther"));
            fileData.append('OtherDetail', valOf("txtWarningOtherDetail"));

            fileData.append('Infraction', valOf("txtWarningInfraction"));
            fileData.append('Improvement', valOf("txtWarningImprovement"));
            fileData.append('Consequences', valOf("txtWarningConsequences"));

            fileData.append('ApprovedBy1', valOf("ddWarningApproval1"));
            fileData.append('ApprovedBy2', valOf("ddWarningApproval2"));
            fileData.append('ApprovedBy3', valOf("ddWarningApproval3"));
            
            fileData.append('FileID', Warning.FileID);
            fileData.append('FileName', Warning.FileName);
            fileData.append('RecordAddedBy', User.Name);
            

            ShowSpinner();
            $.ajax({
                url: '/EmployeeAPI/UpdateEmployeeWarning',
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (Response) {
                    HideSpinner();
                    if (Warning.ID == 0)
                        swal({ text: "New employee warning record added.", icon: "success" });
                    else
                        swal({ text: "Employee warning record updated.", icon: "success" });
                    SaveLog(Response);

                    
                    document.getElementById("frmWarning").reset();
                    BindWarnings()
                    SetvalOf("ddEmployeeName",0).trigger("change")
                    SetvalOf("txtWarningDate", moment().format("DD/MM/YYYY"))
                    SetvalOf("ddEmployeeDivision", 0)
                    SetvalOf("ddEmployeePosition", 0)

                    SetvalOf("ddWarningApproval1", 0).trigger("change")
                    SetvalOf("ddWarningApproval2", 0).trigger("change")
                    SetvalOf("ddWarningApproval3", 0).trigger("change")


                }, error: function (errormessage) {
                    HideSpinner();
                    if (Warning.ID == 0)
                        swal({ text: "Failed to create new warning record.", icon: "error" });
                    else
                        swal({ text: "Failed to update warning record.", icon: "error" });
                }
            });
            return false;
        }

    });
}

function NewWarning() {
    CancelNewWarning();
    $("#dvEditWarning").show();
    $("#dvWarningList").hide();

}


function CancelNewWarning() {
    $("#dvEditWarning").hide();
    $("#dvWarningList").show();

    document.getElementById("frmWarning").reset();
    Warning = { ID: 0 };
    SetvalOf("ddEmployeeName", 0).trigger("change")
    SetvalOf("txtWarningDate", moment().format("DD/MM/YYYY"))
    SetvalOf("ddEmployeeDivision", 0)
    SetvalOf("ddEmployeePosition", 0)

    SetvalOf("ddWarningApproval1", 0).trigger("change")
    SetvalOf("ddWarningApproval2", 0).trigger("change")
    SetvalOf("ddWarningApproval3", 0).trigger("change")
}







/////
function BindEmployeePositionDivision() {
    var EmployeeID = $("#ddEmployeeName").val();
    Post("/EmployeeAPI/EmployeeData", { EmployeeID: EmployeeID }).done(function (Response) {
        var DivisionID = Response[0].DivisionID;
        var PositionID = Response[0].PositionID;

        $("#ddEmployeeDivision").val(DivisionID)

        $("#ddEmployeePosition").val(PositionID)
    });
}