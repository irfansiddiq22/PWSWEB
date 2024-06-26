﻿var IDFile = {
    ID: 0,
    Name: '',
    EmployeeID: 0,
    Description: '',
    Number:'',
    IssueDate: '',
    ExpiryDate: '',
    Remarks: '',
    FileName: '',
    RecordAddedBy: User.Name
};
var IDFileList = [];

function _Init() {
    HideSpinner();
    SetPagePermission(PAGES.EmployeeID, function () {

        FillIDTypeList("ddFileTypeList")
        BindUsers();
    });
    
}
$('form').on('reset', function (e) {
    InitializeIDFile();
})
function InitializeIDFile() {
    IDFile.ID = 0;
    
    IDFile.Description = "";
    IDFile.Number = "";
    IDFile.IssueDate = "";
    IDFile.ExpiryDate = "";
    IDFile.Remarks = "";
    IDFile.FileName = "";
    ResetChangeLog(PAGES.EmployeeID)
    $("#imgEmployeeID").hide();
    $("#imgEmployeeID").attr("src","");
}

function BindUsers() {
    Post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        if (Response.length>1)  data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
        })
        $("#ddIDFileEmployeeCode").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data,
            width:'100%'
        }).on('select2:select', function (e) {
            FillIDFiles();
            });
        if (data.length == 1) {
            $("#ddIDFileEmployeeCode").val(parseInt(data[0].id));
            FillIDFiles();
        }
    })
    
   
}

function FillIDFiles() {
    var EmployeeID = $("#ddIDFileEmployeeCode").val();
    $("#tblEmployeeIDList").empty();
    IDFile.EmployeeID = EmployeeID;
    InitializeIDFile();

    Post("/EmployeeAPI/EmployeeIDFileList", { EmployeeID: EmployeeID, Name: valOf("txtFindEmplyeeID") }).done(function (Response) {
        FillIDListTable(Response)
    });
}
function FillIDListTable(Response) {
    IDFileList = Response;
    $("#tblEmployeeIDList").empty();
    $.each(Response, function (i, c) {
        var tr = $('<tr>');
        tr.append($('<td>').append(c.ID))
        tr.append($('<td>').text(c.EmployeeID))
        tr.append($('<td>').text(c.Description))
        tr.append($('<td>').text(c.IDNumber))
        tr.append($('<td>').text(moment(c.IssueDate).format("DD/MM/YYYY")))
        tr.append($('<td>').text(moment(c.ExpiryDate).format("DD/MM/YYYY")))

        tr.append($('<td>').append(c.Remarks))

        var Icons = $('<div class="icons">');
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary me-2 writeble" onclick="EditIDFile(' + i + ')"><i class="fa fa-edit"></i></a>'));
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger deleteble" onclick="DeleteIDFile(' + i + ')"><i class="fa fa-trash"></i></a>'));
        tr.append($('<td>').append($(Icons)));

        $("#tblEmployeeIDList").append(tr)
    })
}
function DownloadIDFile(EmployeeID,Type, FileName, FileID) {
    ShowSpinner();
    DownloadFile("/EmployeeAPI/DownloadIDFile?EmployeeID=" +  String(EmployeeID) + "&Type="+ Type +"&FileName=" + FileName + "&FileID=" + FileID, FileName);
}
function EditIDFile(index) {
    IDFile = IDFileList[index];
    
    SetvalOf("txtIDFileDescription", IDFile.Description);
    SetvalOf("txtIDFileNumber", IDFile.IDNumber);

    SetvalOf("txtIDFileIssueDate", (moment(IDFile.IssueDate).format("DD/MM/YYYY")));
    SetvalOf("txtIDFileExpiryDate", moment(IDFile.ExpiryDate).format("DD/MM/YYYY") );
    SetvalOf("txtIDFileRemarks", IDFile.Remarks);
    if ($("#ddIDFileEmployeeCode").val() != IDFile.EmployeeID)
        $("#ddIDFileEmployeeCode").val(IDFile.EmployeeID).trigger("change");

    $("#imgEmployeeID").attr("src", "/EmployeeAPI/DownloadIDFile?EmployeeID=" + IDFile.EmployeeID + "&Type=" + IDFile.Description +"&FileName=" + IDFile.FileName + "&FileID=" + IDFile.FileID);
    $("#imgEmployeeID").show();
    ResetDatePicker();
}
function SaveIDFile() {
    $("#frmIDFile").validate({
        errorClass: "text-danger",

        rules: {
            EmployeeCode: "required",
            IDFileDescription: "required",
            IDFileNumber: "required",
            IDFileIssueDate: "required",
            IDFileExpiryDate:"required"
        },
        messages: {
            EmployeeCode: "Please select employee",
            IDFileDescription: "Please enter ID file description",
            IDFileNumber:"Please enter ID number",
            IDFileIssueDate: "Please enter ID file issue date",
            IDFileExpiryDate: "Please enter ID file expiry date",

        },
        submitHandler: function (form) {
            var fileData = new FormData();
            var fileUpload = $('#txtIDFile').get(0);
            var files = fileUpload.files;
            if (files.length > 0)
                fileData.append(files[0].name, files[0]);



            if (IDFile.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Description", Data: { OLD: "", New: valOf("txtIDFileDescription") } });
            } else {
                
                if ($.trim(IDFile.Description) != $.trim(valOf("txtIDFileDescription"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Description", Data: { OLD: IDFile.Description, New: valOf("txtIDFileDescription") } });
                }
                if ($.trim(IDFile.IDNumber) != $.trim(valOf("txtIDFileNumber"))) {
                    DataChangeLog.DataUpdated.push({ Field: "ID", Data: { OLD: IDFile.IDNumber, New: valOf("txtIDFileNumber") } });
                }
                if (moment(IDFile.IssueDate).format("DD/MM/YYYY") != $.trim(valOf("txtIDFileIssueDate"))) {
                    DataChangeLog.DataUpdated.push({ Field: "IssueDate", Data: { OLD: moment(IDFile.IssueDate).format("DD/MM/YYYY"), New: valOf("txtIDFileIssueDate") } });
                }
                if (moment(IDFile.ExpiryDate).format("DD/MM/YYYY") != $.trim(valOf("txtIDFileExpiryDate"))) {
                    DataChangeLog.DataUpdated.push({ Field: "ExpiryDate", Data: { OLD: moment(IDFile.ExpiryDate).format("DD/MM/YYYY"), New: valOf("txtIDFileExpiryDate") } });
                }

                if ($.trim(IDFile.Remarks) != $.trim(valOf("txtIDFileRemarks"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Remarks", Data: { OLD: IDFile.Remarks, New: valOf("txtIDFileRemarks") } });
                }

                if (files.length > 0) {
                    DataChangeLog.DataUpdated.push({ Field: "FileName", Data: { OLD: IDFile.FileName, New: files[0].name } });
                }

            }
            
            IDFile.Description = valOf("txtIDFileDescription");
            IDFile.IDNumber = valOf("txtIDFileNumber");
            IDFile.IssueDate = valOf("txtIDFileIssueDate");
            IDFile.ExpiryDate = valOf("txtIDFileExpiryDate");
            IDFile.Remarks = valOf("txtIDFileRemarks");
            
            
            fileData.append('RecordUpdatedBy', User.Name);
            fileData.append('Description', IDFile.Description);
            fileData.append('IDNumber', IDFile.IDNumber);
            fileData.append('IssueDate', IDFile.IssueDate);
            fileData.append('ExpiryDate', IDFile.ExpiryDate);
            fileData.append('Remarks', IDFile.Remarks);
            
            fileData.append('EmployeeID', IDFile.EmployeeID);
            fileData.append('FileID', IDFile.FileID);
            fileData.append('FileName', IDFile.FileName);
            fileData.append('ID', IDFile.ID);
            
            ShowSpinner();
            $.ajax({
                url: '/EmployeeAPI/UpdateEmployeeIDFile',
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (result) {
                    HideSpinner();
                    if (IDFile.ID==0)
                        swal({ text: "New employee id record added.", icon: "success" });
                    else
                        swal({ text: "Employee id record updated.", icon: "success" });

                    SaveLog(result);

                    FillIDFiles()
                    document.getElementById("frmIDFile").reset();
                    InitializeIDFile();
                    FillIDTypeList("datalistOptions")
                    SetvalOf("ddIDFileEmployeeCode", IDFile.EmployeeID);

                }, error: function (errormessage) {
                    HideSpinner();
                    if (IDFile.ID == 0)
                        swal({ text: "Failed to create new id record.", icon: "error" });
                    else
                        swal({ text: "Failed to update id record.", icon: "error" });
                }
            });
            return false;
        }

    });
}

function FindEmployeeID() {
    FillIDFiles();
}