var Family = {
    ID: 0,
    EmployeeID: 0,
    Name: '',
    Relation: '',
    DateOfBirth: '',
    PassportNumber: '',
    PassportIssueDate: '',
    PassportExpiryDate: '',
    IqamaNumber: '',
    LocalPhoneNumber: '',
    HomePhoneNumber: '',
    RecordAddedBy: User.Name
};
var FamilyList = [];

function _Int() {
    HideSpinner();
    BindUsers();
}
function InitilzeFamily() {
    ResetChangeLog(PAGES.Family)
    Family.Name = '';
    Family.Relation = ''
    Family.DateOfBirth = ''
    Family.PassportNumber = ''
    Family.PassportIssueDate = ''
    Family.PassportExpiryDate = ''
    Family.IqamaNumber = ''
    Family.LocalPhoneNumber = ''
    Family.HomePhoneNumber = ''

    SetvalOf("txtFamilyName", Family.Name);
    SetvalOf("txtFamilyDateOfBirth", (moment(Family.DateOfBirth).format("MM/DD/YYYY")));
    SetvalOf("txtFamilyRelationship", Family.Relation);
    SetvalOf("txtFamilyPassportNumber", Family.PassportNumber);
    SetvalOf("txtFamilyPassportIssueDate", (moment(Family.PassportIssueDate).format("MM/DD/YYYY")));
    SetvalOf("txtFamilyPassportExpiryDate", moment(Family.PassportExpiryDate).format("MM/DD/YYYY"));
    SetvalOf("txtFamilyIqamaNumber", Family.IqamaNumber);
    SetvalOf("txtFamilyLocalPhoneNumber", Family.LocalPhoneNumber);
    SetvalOf("txtFamilyHomePhoneNumber", Family.HomePhoneNumber);

}

function BindUsers() {
    Post("/EmployeeAPI/FamilyCodeName", {}).done(function (Response) {

        var data = []
        data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.Code + " - " + emp.Name });
        })
        $("#ddEmployeeFamilyCode").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data
        }).on('select2:select', function (e) {
            var data = e.params.data;
            FillEmployeeFamily(parseInt(data.id));
        });
    })
    FillRelationList("datalistOptions")

}


function FillEmployeeFamily(EmployeeID) {
    $("#tblEmployeeFamily").empty();
    Family.EmployeeID = EmployeeID;
    InitilzeFamily();

    Post("/EmployeeAPI/EmployeeFamilyList", { EmployeeID: EmployeeID }).done(function (Response) {
        FillEmployeeFamilyTable(Response)
    });
}
function FillEmployeeFamilyTable(Response) {
    FamilyList = Response;
    $("#tblEmployeeFamily").empty();
    $.each(Response, function (i, c) {
        var tr = $('<tr>');
        tr.append($('<td>').text(c.ID))
        tr.append($('<td>').text(c.Name))
        tr.append($('<td>').text(moment(c.DateOfBirth).format("MM/DD/YYYY")))
        tr.append($('<td>').text(c.Relation))


        tr.append($('<td>').text(c.PassportNumber))
        tr.append($('<td>').text(c.IqamaNumber))

        tr.append($('<td>').text(moment(c.PassportIssueDate).format("MM/DD/YYYY")))
        tr.append($('<td>').text(moment(c.PassportExpiryDate).format("MM/DD/YYYY")))

        tr.append($('<td>').text(c.HomePhoneNumber))
        tr.append($('<td>').text(c.LocalPhoneNumber))

        var Link = $('<a>').attr("href", "javascript:void(0)").attr("onclick", "DownloadPassportFile('" + c.EmployeeID + "','" + c.FileName + "','" + c.FileID + "')").text(c.FileName);
        tr.append($('<td>').append(c.FileName == "null" || c.FileName == "" ? "" : $(Link)))

        var Icons = $('<div class="icons">');
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary me-2" onclick="EditFamilyMember(' + i + ')"><i class="fa fa-edit"></i></a>'));
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="DeleteIDFile(' + i + ')"><i class="fa fa-trash"></i></a>'));
        tr.append($('<td>').append($(Icons)));

        $("#tblEmployeeFamily").append(tr)
    })
    
}
function DownloadPassportFile(EmployeeID, FileName, FileID) {
    ShowSpinner();
    DownloadFile("/EmployeeAPI/DownloadFamilyFile?EmployeeID=" + String(EmployeeID) + "&FileName=" + FileName + "&FileID=" + FileID, FileName);
}
function EditFamilyMember(index) {
    Family = FamilyList[index];
    SetvalOf("txtFamilyName", Family.Name);
    SetvalOf("txtFamilyDateOfBirth", (moment(Family.DateOfBirth).format("MM/DD/YYYY")));
    SetvalOf("txtFamilyRelationship", Family.Relation);
    SetvalOf("txtFamilyPassportNumber", Family.PassportNumber);
    SetvalOf("txtFamilyPassportIssueDate", (moment(Family.PassportIssueDate).format("MM/DD/YYYY")));
    SetvalOf("txtFamilyPassportExpiryDate", moment(Family.PassportExpiryDate).format("MM/DD/YYYY"));
    SetvalOf("txtFamilyIqamaNumber", Family.IqamaNumber);
    SetvalOf("txtFamilyLocalPhoneNumber", Family.LocalPhoneNumber);
    SetvalOf("txtFamilyHomePhoneNumber", Family.HomePhoneNumber);

}
function SaveFamily() {
    if ($("#frmEmployeeFamily").valid()) {

        var fileData = new FormData();
        var fileUpload = $('#txtFamilyPassport').get(0);
        var files = fileUpload.files;
        if (files.length > 0)
            fileData.append(files[0].name, files[0]);

        if (Family.ID == 0) {
            DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: valOf("txtFamilyName") } });
        } else {
            if ($.trim(Family.Name) != $.trim(valOf("txtFamilyName"))) 
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: Family.Name, New: valOf("txtFamilyName") } });

            if (moment(Family.DateOfBirth).format("MM/DD/YYYY") != $.trim(valOf("txtFamilyDateOfBirth")))
                DataChangeLog.DataUpdated.push({ Field: "DateOfBirth", Data: { OLD: moment(Family.DateOfBirth).format("MM/DD/YYYY"), New: valOf("txtFamilyDateOfBirth") } });
            if ($.trim(Family.Relation) != $.trim(valOf("txtFamilyRelationship")))
                DataChangeLog.DataUpdated.push({ Field: "Relation", Data: { OLD: Family.Relation, New: valOf("txtFamilyRelationship") } });

            
            if ($.trim(Family.PassportNumber) != $.trim(valOf("txtFamilyPassportNumber")))
                DataChangeLog.DataUpdated.push({ Field: "PassportNumber", Data: { OLD: Family.PassportNumber, New: valOf("txtFamilyPassportNumber") } });

            if (moment(Family.PassportIssueDate).format("MM/DD/YYYY") != $.trim(valOf("txtFamilyPassportIssueDate")))
                DataChangeLog.DataUpdated.push({ Field: "PassportIssueDate", Data: { OLD: moment(Family.PassportIssueDate).format("MM/DD/YYYY"), New: valOf("txtFamilyPassportIssueDate") } });

            if (moment(Family.PassportExpiryDate).format("MM/DD/YYYY") != $.trim(valOf("txtFamilyPassportExpiryDate")))
                DataChangeLog.DataUpdated.push({ Field: "PassportExpiryDate", Data: { OLD: moment(Family.PassportExpiryDate).format("MM/DD/YYYY"), New: valOf("txtFamilyPassportExpiryDate") } });

            if ($.trim(Family.IqamaNumber) != $.trim(valOf("txtFamilyIqamaNumber")))
                DataChangeLog.DataUpdated.push({ Field: "IqamaNumber", Data: { OLD: Family.IqamaNumber, New: valOf("txtFamilyIqamaNumber") } });

            if ($.trim(Family.LocalPhoneNumber) != $.trim(valOf("txtFamilyLocalPhoneNumber")))
                DataChangeLog.DataUpdated.push({ Field: "LocalPhoneNumber", Data: { OLD: Family.LocalPhoneNumber, New: valOf("txtFamilyLocalPhoneNumber") } });

            if ($.trim(Family.HomePhoneNumber) != $.trim(valOf("txtFamilyHomePhoneNumber")))
                DataChangeLog.DataUpdated.push({ Field: "HomePhoneNumber", Data: { OLD: Family.HomePhoneNumber, New: valOf("txtFamilyHomePhoneNumber") } });

            if (files.length > 0) 
                DataChangeLog.DataUpdated.push({ Field: "FileName", Data: { OLD: Family.FileName, New: files[0].name } });
            

        }


        Family.Name = valOf("txtFamilyName");
        Family.DateOfBirth = valOf("txtFamilyDateOfBirth");
        Family.Relation = valOf("txtFamilyRelationship");
        Family.PassportNumber = valOf("txtFamilyPassportNumber");
        Family.PassportIssueDate = valOf("txtFamilyPassportIssueDate");
        Family.PassportExpiryDate = valOf("txtFamilyPassportExpiryDate");
        Family.IqamaNumber = valOf("txtFamilyIqamaNumber");
        Family.LocalPhoneNumber = valOf("txtFamilyLocalPhoneNumber");
        Family.HomePhoneNumber = valOf("txtFamilyHomePhoneNumber");

        
        fileData.append('RecordUpdatedBy', User.Name);
        fileData.append('Name', Family.Name);
        fileData.append('DateOfBirth', Family.DateOfBirth);
        fileData.append('Relation', Family.Relation);
        fileData.append('PassportNumber', Family.PassportNumber);
        fileData.append('PassportIssueDate', Family.PassportIssueDate);
        fileData.append('PassportExpiryDate', Family.PassportExpiryDate);
        fileData.append('IqamaNumber', Family.IqamaNumber);
        fileData.append('LocalPhoneNumber', Family.LocalPhoneNumber);
        fileData.append('HomePhoneNumber', Family.HomePhoneNumber);
        
        fileData.append('EmployeeID', Family.EmployeeID);
        fileData.append('ID', Family.ID);

        ShowSpinner();
        $.ajax({
            url: '/EmployeeAPI/UpdateEmployeeFamily',
            type: "POST",
            contentType: false,
            processData: false,
            data: fileData,
            success: function (Response) {
                HideSpinner();
                if (Family.ID == 0)
                    swal({ text: "New employee family record added.", icon: "success" });
                else
                    swal({ text: "Employee family record updated.", icon: "success" });

                SaveLog(Response);

                FillEmployeeFamily(Family.EmployeeID);

                document.getElementById("frmEmployeeFamily").reset();
                InitilzeFamily();
                FillRelationList("datalistOptions")
                SetvalOf("ddEmployeeFamilyCode", Family.EmployeeID);

            }, error: function (errormessage) {
                HideSpinner();
                if (Family.ID == 0)
                    swal({ text: "Failed to create new family id record.", icon: "error" });
                else
                    swal({ text: "Failed to update family id record.", icon: "error" });
            }
        });

    }

}
