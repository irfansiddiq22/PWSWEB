
function _Int() {
    HideSpinner();
    BindUsers();
    BindContracts();
}
function BindUsers() {
    Post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.Code + " - " + emp.Name });
        })
        $("#ddContractEmployeeCode").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data
        }).on('select2:select', function (e) {
            UploadContract();
        });
    })
}
function BindContracts() {
    $("#tblEmployeeContracts").empty();
    Post("/EmployeeAPI/ContractList").done(function (Response) {
        $.each(Response, function (i, r) {
            var tr = $('<tr>')
            tr.append($('<td>').text(r.EmployeeID))
            tr.append($('<td>').text(r.Name))
            tr.append($('<td>').text(r.ArabicName))
            tr.append($('<td>').text(moment(r.RecordDateUpdated).format("MM/DD/YYYY")))
            tr.append($('<td>').text(r.Nationality))
            var Link = $('<a>').attr("href", "javascript:void(0)").attr("onclick", "DownloadContract('" + r.EmployeeID + "','" + r.FileName + "','" + r.FileID + "')").text(r.FileName);
            tr.append($('<td>').append($(Link)))
            $("#tblEmployeeContracts").append(tr);
        });
    })
}
function DownloadContract(EmployeeID, FileName, FileID) {
    ShowSpinner();
    DownloadFile("/EmployeeAPI/DownloadContract?EmployeeID=" + String(EmployeeID) + "&FileName=" + FileName + "&FileID=" + FileID, FileName);
}
$("#txtContractImage").change(function () {
    if ($('#ddContractEmployeeCode').val() == 0) {
        swal({ text: "Select Employee to upload contract.", icon: "error" });
        return false;
    }
    UploadContract();
});
function UploadContract() {
    var fileData = new FormData();
    var fileUpload = $('#txtContractImage').get(0);
    var files = fileUpload.files;
    if (files.length > 0)
        fileData.append(files[0].name, files[0]);
    else {
        return false;
    }

    fileData.append('RecordUpdatedBy', User.Name);
    fileData.append('EmployeeID', valOf("ddContractEmployeeCode"));
    ShowSpinner();
    $.ajax({
        url: '/EmployeeAPI/UpdateContract',
        type: "POST",
        contentType: false,
        processData: false,
        data: fileData,
        success: function (result) {
            HideSpinner();
            SetvalOf("txtContractImage", "")
            swal({ text: "Contract record updated successfully.", icon: "success" });
            BindContracts();
        },
        error: function (errormessage) {
            HideSpinner();
            SetvalOf("txtContractImage", "")
            swal({ text: "Failed to update contract record.", icon: "error" });
        }
    });
}