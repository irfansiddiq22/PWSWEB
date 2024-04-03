var IDFile = {
    ID: 0,
    EmployeeID: 0,
    Name: '',
    Relation: '',
    Description: '',
    Number: '',

    IssueDate: '',
    ExpiryDate: '',
    Remarks: '',
    FileName: '',
    RecordAddedBy: User.Name
};
var IDFileList = [];

function _Init() {
    HideSpinner();
    BindUsers();
}
function InitilzeIDFile() {
    ResetChangeLog(PAGES.FamilyID)
    IDFile.ID = 0;

    IDFile.Relation = "";
    IDFile.Description = "";
    IDFile.Number = "";
    IDFile.Name = "";
    IDFile.IssueDate = "";
    IDFile.ExpiryDate = "";
    IDFile.Remarks = "";
    IDFile.FileName = "";
}

function BindUsers() {
    Post("/EmployeeAPI/FamilyCodeName", {}).done(function (Response) {

        var data = []
        data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.Code + " - " + emp.Name });
        })
        $("#ddIDFileEmployeeCode").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data
        }).on('select2:select', function (e) {
            var data = e.params.data;
            FillIDFiles(parseInt(data.id));
        });
    })
    FillIDTypeList("datalistOptions")

}


function FillIDFiles(EmployeeID) {
    $("#tblEmployeeIDList").empty();
    IDFile.EmployeeID = EmployeeID;
    InitilzeIDFile();

    Post("/EmployeeAPI/EmployeeFamilyIDFileList", { EmployeeID: EmployeeID }).done(function (Response) {
        FillIDListTable(Response)
    });
}
function FillIDListTable(Response) {
    IDFileList = Response;
    $("#tblEmployeeIDList").empty();
    $.each(Response, function (i, c) {
        var tr = $('<tr>');
        var Link = $('<a>').attr("href", "javascript:void(0)").attr("onclick", "DownloadIDFile('" + c.EmployeeID + "','" + c.FileName + "','" + c.FileID + "')").text(c.FileName);
        tr.append($('<td>').append(c.FileName == "null" || c.FileName == "" ? "" : $(Link)))
        tr.append($('<td>').text(c.Relation))
        tr.append($('<td>').text(c.Description))
        tr.append($('<td>').text(c.IDNumber))
        tr.append($('<td>').text(moment(c.IssueDate).format("MM/DD/YYYY")))
        tr.append($('<td>').text(moment(c.ExpiryDate).format("MM/DD/YYYY")))

        tr.append($('<td>').append(c.Remarks))

        var Icons = $('<div class="icons">');
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary me-2" onclick="EditIDFile(' + i + ')"><i class="fa fa-edit"></i></a>'));
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="DeleteIDFile(' + i + ')"><i class="fa fa-trash"></i></a>'));
        tr.append($('<td>').append($(Icons)));

        $("#tblEmployeeIDList").append(tr)
    })
}
function DownloadIDFile(EmployeeID, FileName, FileID) {
    ShowSpinner();
    DownloadFile("/EmployeeAPI/DownloadFamilyIDFile?EmployeeID=" + String(EmployeeID) + "&FileName=" + FileName + "&FileID=" + FileID, FileName);
}
function EditIDFile(index) {
    IDFile = IDFileList[index];
    SetvalOf("txtIDFileName", IDFile.Name);
    SetvalOf("txtIDFileRelation", IDFile.Relation);
    SetvalOf("txtIDFileDescription", IDFile.Description);
    SetvalOf("txtIDFileNumber", IDFile.IDNumber);
    SetvalOf("txtIDFileDateOfBirth", (moment(IDFile.DateOfBirth).format("MM/DD/YYYY")));

    SetvalOf("txtIDFileIssueDate", (moment(IDFile.IssueDate).format("MM/DD/YYYY")));
    SetvalOf("txtIDFileExpiryDate", moment(IDFile.ExpiryDate).format("MM/DD/YYYY"));
    SetvalOf("txtIDFileRemarks", IDFile.Remarks);

}
function SaveIDFile() {
    $("#frmIDFile").validate({
        errorClass: "text-danger",

        rules: {
            EmployeeCode: "required",
            IDFileRelation: "required",
            IDFileDescription: "required",
            IDFileNumber: "required",
            IDFileIssueDate: "required",
            IDFileExpiryDate: "required",
            IDFileName: "required"

        },
        messages: {
            EmployeeCode: "Please select employee",
            IDFileRelation: "Please enter ID file relationship with employee",
            IDFileDescription: "Please enter ID file description",
            IDFileNumber: "Please enter ID number",
            IDFileIssueDate: "Please enter ID file issue date",
            IDFileExpiryDate: "Please enter ID file expiry date",
            IDFileName: "Please enter name"


        },
        submitHandler: function (form) {


            var fileData = new FormData();
            var fileUpload = $('#txtIDFile').get(0);
            var files = fileUpload.files;
            if (files.length > 0)
                fileData.append(files[0].name, files[0]);

            if (IDFile.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: valOf("txtIDFileName") } });
            } else {

                if ($.trim(IDFile.Name) != $.trim(valOf("txtIDFileName"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: IDFile.Name, New: valOf("txtIDFileName") } });
                }
                if ($.trim(IDFile.Description) != $.trim(valOf("txtIDFileDescription"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Description", Data: { OLD: IDFile.Description, New: valOf("txtIDFileDescription") } });
                }
                if ($.trim(IDFile.IDNumber) != $.trim(valOf("txtIDFileNumber"))) {
                    DataChangeLog.DataUpdated.push({ Field: "ID", Data: { OLD: IDFile.IDNumber, New: valOf("txtIDFileNumber") } });
                }
                if ($.trim(IDFile.Relation) != $.trim(valOf("txtIDFileRelation"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Relation", Data: { OLD: IDFile.Relation, New: valOf("txtIDFileRelation") } });
                }
                if (moment(IDFile.IssueDate).format("MM/DD/YYYY") != $.trim(valOf("txtIDFileIssueDate"))) {
                    DataChangeLog.DataUpdated.push({ Field: "IssueDate", Data: { OLD: moment(IDFile.IssueDate).format("MM/DD/YYYY"), New: valOf("txtIDFileIssueDate") } });
                }
                if (moment(IDFile.ExpiryDate).format("MM/DD/YYYY") != $.trim(valOf("txtIDFileExpiryDate"))) {
                    DataChangeLog.DataUpdated.push({ Field: "ExpiryDate", Data: { OLD: moment(IDFile.ExpiryDate).format("MM/DD/YYYY"), New: valOf("txtIDFileExpiryDate") } });
                }

                if ($.trim(IDFile.Remarks) != $.trim(valOf("txtIDFileRemarks"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Remarks", Data: { OLD: IDFile.Remarks, New: valOf("txtIDFileRemarks") } });
                }

                if (files.length > 0) {
                    DataChangeLog.DataUpdated.push({ Field: "FileName", Data: { OLD: IDFile.FileName, New: files[0].name } });
                }

            }


            IDFile.Name = valOf("txtIDFileName");
            IDFile.Description = valOf("txtIDFileDescription");
            IDFile.IDNumber = valOf("txtIDFileNumber");
            IDFile.Relation = valOf("txtIDFileRelation");

            IDFile.IssueDate = valOf("txtIDFileIssueDate");
            IDFile.ExpiryDate = valOf("txtIDFileExpiryDate");
            IDFile.Remarks = valOf("txtIDFileRemarks");


            fileData.append('RecordUpdatedBy', User.Name);
            fileData.append('Name', IDFile.Name);
            fileData.append('Relation', IDFile.Relation);

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
                url: '/EmployeeAPI/UpdateEmployeeFamilyIDFile',
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (Response) {
                    HideSpinner();
                    if (IDFile.ID == 0)
                        swal({ text: "New employee family id record added.", icon: "success" });
                    else
                        swal({ text: "Employee family id record updated.", icon: "success" });
                    SaveLog(Response);

                    FillIDFiles(IDFile.EmployeeID)
                    document.getElementById("frmIDFile").reset();
                    InitilzeIDFile();
                    FillIDTypeList("datalistOptions")
                    SetvalOf("ddIDFileEmployeeCode", IDFile.EmployeeID);

                }, error: function (errormessage) {
                    HideSpinner();
                    if (IDFile.ID == 0)
                        swal({ text: "Failed to create new family id record.", icon: "error" });
                    else
                        swal({ text: "Failed to update family id record.", icon: "error" });
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
