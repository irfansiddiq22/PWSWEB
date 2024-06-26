﻿var Certificate = {
    ID: 0,
    EmployeeID: 0,
    Name: '',
    IssueDate: '',
    ExpiryDate: null,
    Remarks: '',
    FileName: '',
    RecordAddedBy: User.Name
};
var CertificateList = [];

function _Init() {
    
    HideSpinner();
    SetPagePermission(PAGES.Certificate, function () {
        BindUsers();
        $("#ddCertificateEmployeeCode").change(function () {
            FillCertificates($(this).val());
        })
    });
    
}
function ResetNav() {
    window.location = "/home"
}
$('form').on('reset', function (e) {
    $("#ddCertificateName").val("").trigger("change");
    InitializeCertificate();
})
function InitializeCertificate() {
    Certificate.ID = 0;
    Certificate.Name = "";
    Certificate.IssueDate = "";
    Certificate.ExpiryDate = "";
    Certificate.Remarks = "";
    Certificate.FileName = "";
    $("#ddCertificateName").val("").trigger("change");
    $("#imgEmployeeCertficate").hide();
    ResetChangeLog(PAGES.Certificate);
}
function ToggleOffShore(sender) {
    if ($(sender).prop("checked"))
        $("#chkCertificateOffshore").prop("checked", false)
}
function ToggleOnShore(sender) {
    if ($(sender).prop("checked"))
        $("#chkCertificateOnshore").prop("checked", false)
}
function BindUsers() {
    Post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        if (Response.length>1)
        data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
        })
        $("#ddCertificateEmployeeCode").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            width: '100%',
            data: data
        })

        if (Response.length == 1) {
            $("#ddCertificateEmployeeCode").val(Response[0].ID).trigger("change")
            
            //$("#ddCertificateEmployeeCode").val(Response[0].ID).trigger("change")
            //FillCertificates(Response[0].ID);
        }
    })
    Post("/DataList/CertificeTypes", {}).done(function (Response) {


        var data = []
        data.push({ id: 0, text: 'Select Certificate' });
        $.each(Response, function (i, c) {
            data.push({ id: c.Name, text:  c.Name });
        })
        $("#ddCertificateName").select2({
            tags: "false",
            placeholder: "Select a Certificate",
            allowClear: true,
            width: '100%',
            data: data
        }).on('select2:select', function (e) {
            
        });
    });
   
}

function FillCertificates(EmployeeID) {
    $("#tblCertificateList").empty();
    Certificate.EmployeeID = EmployeeID;
    InitializeCertificate();

    Post("/EmployeeAPI/CertificateList", { EmployeeID: EmployeeID, Name: valOf("txtFindCertificate") }).done(function (Response) {
        //if (valOf("txtFindCertificate") != "")
        //    Response = Response.filter(x => x.Name.toLowerCase().indexOf(valOf("txtFindCertificate").toLowerCase()) > -1 || x.ID == valOf("txtFindCertificate"))

        CertificateList = Response;
        
        $.each(Response, function (i, c) {
            var tr = $('<tr>');
            tr.append($('<td>').text((c.ID)))
            tr.append($('<td>').text((c.EmployeeID)))
            tr.append($('<td>').text(c.Name))
            tr.append($('<td>').text(moment(c.IssueDate).format("DD/MM/YYYY")))
            tr.append($('<td>').text(c.ExpiryDate ? moment(c.ExpiryDate).format("DD/MM/YYYY") : ""))
            tr.append($('<td>').append(c.Remarks))
            tr.append($('<td>').append(CheckboxSwitch("", c.OnShore ? "checked" : "", "", "")))
            var Icons = $('<div class="icons">');
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary writeble me-2" onclick="EditCertificate(' + i + ')"><i class="fa fa-edit"></i></a>'));
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger deleteble" onclick="DeleteCertificate(' + i + ')"><i class="fa fa-trash"></i></a>'));
            tr.append($('<td>').append($(Icons)));

            $("#tblCertificateList").append(tr)
        })
        SetPagePermission(PAGES.Certificate, function () { });
    });
}
function EditCertificate(index) {
    Certificate = CertificateList[index];
    

    SetvalOf("ddCertificateName", $.trim(Certificate.Name)).trigger("change");
    SetvalOf("txtCertificateIssueDate", (moment(Certificate.IssueDate).format("DD/MM/YYYY")));
    SetvalOf("txtCertificateExpiryDate", (Certificate.ExpiryDate ? moment(Certificate.ExpiryDate).format("DD/MM/YYYY") : ""));
    SetvalOf("txtCertificateRemarks", Certificate.Remarks);
    SetChecked("chkCertificateOnshore", Certificate.OnShore)
    if (valOf("ddCertificateEmployeeCode") != Certificate.EmployeeID)
        SetvalOf("ddCertificateEmployeeCode", $.trim(Certificate.EmployeeID));//.trigger("change");
    $("#imgEmployeeCertficate").show();
    $("#imgEmployeeCertficate").attr("src", "/EmployeeAPI/DownloadCertificateFile?EmployeeID=" + Certificate.EmployeeID + "&FileName=" + Certificate.FileName + "&FileID=" + Certificate.FileID)
    Certificate.OnShore == null ? "" : SetChecked("chkCertificateOffshore", !Certificate.OnShore)
    ResetDatePicker();
}
function SaveCertificate() {
    $("#frmCertificate").validate({
        errorClass: "text-danger",

        rules: {
            EmployeeCode: {
                required: true,
                min: 1},
            CertificateName: "required",
            CertificateIssueDate: "required"
        },
        messages: {
            EmployeeCode: { required: "Please select employee", min: "Please select employee"},
            CertificateName: "Please enter certificate name",
            CertificateIssueDate: "Please enter certificate issue date",

        },
        submitHandler: function (form) {
            

            var fileData = new FormData();
            var fileUpload = $('#txtCertificateImage').get(0);
            var files = fileUpload.files;
            if (files.length > 0)
                fileData.append(files[0].name, files[0]);


            if (Certificate.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: valOf("ddCertificateName") } });
            } else {
                if ($.trim(Certificate.Name) != $.trim(valOf("ddCertificateName"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: Certificate.Name, New: valOf("ddCertificateName") } });
                }
                if (moment(Certificate.IssueDate).format("DD/MM/YYYY") != $.trim(valOf("txtCertificateIssueDate"))) {
                    DataChangeLog.DataUpdated.push({ Field: "IssueDate", Data: { OLD: moment(Certificate.IssueDate).format("DD/MM/YYYY"), New: valOf("txtCertificateIssueDate") } });
                }
                if (moment(Certificate.ExpiryDate).format("DD/MM/YYYY") != $.trim(valOf("txtCertificateExpiryDate"))) {
                    DataChangeLog.DataUpdated.push({ Field: "ExpiryDate", Data: { OLD: moment(Certificate.ExpiryDate).format("DD/MM/YYYY"), New: valOf("txtCertificateExpiryDate") } });
                }
                if ($.trim(Certificate.OnShore) != $.trim(GetChecked("chkCertificateOnshore"))) {
                    DataChangeLog.DataUpdated.push({ Field: "OnShore", Data: { OLD: Certificate.OnShore, New: GetChecked("chkCertificateOnshore") } });
                }
                if (files.length > 0) {
                    DataChangeLog.DataUpdated.push({ Field: "FileName", Data: { OLD: Certificate.FileName, New: files[0].name } });
                }
            }




            Certificate.Name = valOf("ddCertificateName");
            Certificate.IssueDate = valOf("txtCertificateIssueDate");
            Certificate.ExpiryDate = valOf("txtCertificateExpiryDate");
            Certificate.Remarks = valOf("txtCertificateRemarks");
            if (GetChecked("chkCertificateOnshore") && GetChecked("chkCertificateOffshore"))
                Certificate.OnShore = null;
            else
                Certificate.OnShore = GetChecked("chkCertificateOnshore")
            
            fileData.append('RecordUpdatedBy', User.Name);
            fileData.append('Name', Certificate.Name);
            fileData.append('IssueDate', Certificate.IssueDate);
            fileData.append('ExpiryDate', Certificate.ExpiryDate);
            fileData.append('Remarks', Certificate.Remarks);
            fileData.append('OnShore', Certificate.OnShore);
            fileData.append('EmployeeID', Certificate.EmployeeID);
            fileData.append('FileID', Certificate.FileID);
            fileData.append('FileName', Certificate.FileName);
            fileData.append('ID', Certificate.ID);

            ShowSpinner();
            $.ajax({
                url: '/EmployeeAPI/UpdateCertificate',
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (result) {
                    HideSpinner();
                    if (Certificate.ID == 0)
                        swal({ text: "New employee certificate record added.", icon: "success" });
                    else
                        swal({ text: "Employee certificate record updated.", icon: "success" });
                    
                    SaveLog(result);

                    FillCertificates(Certificate.EmployeeID)
                    document.getElementById("frmCertificate").reset();
                    InitializeCertificate();
                    SetvalOf("ddCertificateEmployeeCode", Certificate.EmployeeID);

                }, error: function (errormessage) {
                    HideSpinner();
                    if (Certificate.ID == 0)
                        swal({ text: "Failed to create new certificate record.", icon: "error" });
                    else
                        swal({ text: "Failed to update certificate record.", icon: "error" });
                }
            });
            //Post("/", { certificate: Certificate }).done(function (Response) {
            //    swal({ text: "New employee certificate record added.", icon: "success" });
            //    Clear("txtUserName")
            //    Clear("txtUserPassword")

            //    FillUserList(Response);
            //}).fail(function () {
            //    swal({ text: "Failed to create new certificate record.", icon: "error" });
            //});
            return false;
        }

    });
}

function FindCertificate() {
    FillCertificates($("#ddCertificateEmployeeCode").val())
}