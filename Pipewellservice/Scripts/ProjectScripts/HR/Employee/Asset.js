var Asset = {
    ID: 0,
    EmployeeID: 0,
    Name: '',
    IssueDate: '',
    Remarks: '',
    FileName: '',
    RecordAddedBy: User.Name
};
var AssetList = [];

function _Init() {
    HideSpinner();
    BindUsers();
}
$('form').on('reset', function (e) {
    
    InitilzeAsset();
})

function InitilzeAsset() {
    Asset.ID = 0;
    Asset.Name = "";
    Asset.IssueDate = "";
    Asset.Remarks = "";
    Asset.FileName = "";
    ResetChangeLog(PAGES.Asset)
    $("#imgEmployeeAsset").attr("src", "");
    $("#imgEmployeeAsset").hide();   
}

function BindUsers() {
    Post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
        })
        $("#ddAssetEmployeeCode").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data
        }).on('select2:select', function (e) {
            var data = e.params.data;
            FillAssets(parseInt(data.id));
        });
    })
}

function FillAssets(EmployeeID) {
    $("#tblAssetList").empty();
    Asset.EmployeeID = EmployeeID;
    InitilzeAsset();

    Post("/EmployeeAPI/AssetList", { EmployeeID: EmployeeID }).done(function (Response) {
        AssetList = Response;
        
        $.each(Response, function (i, c) {
            var tr = $('<tr>');
            tr.append($('<td>').text((i + 1)))
            tr.append($('<td>').text(c.Name))
            tr.append($('<td>').text(moment(c.IssueDate).format("DD/MM/YYYY")))
            
            tr.append($('<td>').append(c.Remarks))
            
            var Icons = $('<div class="icons">');
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary me-2" onclick="EditAsset(' + i + ')"><i class="fa fa-edit"></i></a>'));
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="DeleteAsset(' + i + ')"><i class="fa fa-trash"></i></a>'));
            tr.append($('<td>').append($(Icons)));

            $("#tblAssetList").append(tr)
        })
    });
}
function EditAsset(index) {
    Asset = AssetList[index];
    SetvalOf("txtAssetName", Asset.Name);
    SetvalOf("txtAssetIssueDate", (moment(Asset.IssueDate).format("DD/MM/YYYY")));
    SetvalOf("txtAssetRemarks", Asset.Remarks);
    $("#imgEmployeeAsset").attr("src", "/EmployeeAPI/DownloadAssetFile?EmployeeID=" + Asset.EmployeeID + "&FileName=" + Asset.FileName + "&FileID=" + Asset.FileID);
    $("#imgEmployeeAsset").show();

}
function SaveAsset() {
    $("#frmAsset").validate({
        errorClass: "text-danger",

        rules: {
            EmployeeCode: "required",
            AssetName: "required",
            AssetIssueDate: "required"
        },
        messages: {
            EmployeeCode: "Please select employee",
            AssetName: "Please enter Asset name",
            AssetIssueDate: "Please enter Asset issue date",

        },
        submitHandler: function (form) {

            var fileData = new FormData();
            var fileUpload = $('#txtAssetImage').get(0);

            var files = fileUpload.files;
            if (files.length > 0)
                fileData.append(files[0].name, files[0]);



            if (Asset.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: valOf("txtAssetName") } });
            } else {
                if ($.trim(Asset.Name) != $.trim(valOf("txtAssetName"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: Asset.Name, New: valOf("txtAssetName") } });
                }
                if (moment(Asset.IssueDate).format("DD/MM/YYYY") != $.trim(valOf("txtAssetIssueDate"))) {
                    DataChangeLog.DataUpdated.push({ Field: "IssueDate", Data: { OLD: moment(Asset.IssueDate).format("DD/MM/YYYY"), New: valOf("txtAssetIssueDate") } });
                }
                
                if ($.trim(Asset.Remarks) != $.trim(valOf("txtAssetRemarks"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: Asset.Remarks, New: valOf("txtAssetRemarks") } });
                }

                if (files.length > 0) {
                    DataChangeLog.DataUpdated.push({ Field: "FileName", Data: { OLD: Asset.FileName, New: files[0].name } });
                }

            }

            Asset.Name = valOf("txtAssetName");
            Asset.IssueDate = valOf("txtAssetIssueDate");
            Asset.Remarks = valOf("txtAssetRemarks");
            
            
            
            fileData.append('RecordUpdatedBy', User.Name);
            fileData.append('Name', Asset.Name);
            fileData.append('IssueDate', Asset.IssueDate);
            
            fileData.append('Remarks', Asset.Remarks);

            fileData.append('FileID', Asset.FileID);
            fileData.append('FileName', Asset.FileName);

            fileData.append('EmployeeID', Asset.EmployeeID);
            fileData.append('ID', Asset.ID);
            

            $.ajax({
                url: '/EmployeeAPI/UpdateAsset',
                type: "POST",
                contentType: false,
                processData: false,
                data: fileData,
                success: function (result) {
                    if (Asset.ID==0)
                        swal({ text: "New employee Asset record added.", icon: "success" });
                    else
                        swal({ text: "Employee Asset record updated.", icon: "success" });

                    
                    SaveLog(result);

                    FillAssets(Asset.EmployeeID)
                    document.getElementById("frmAsset").reset();
                    InitilzeAsset();
                    SetvalOf("ddAssetEmployeeCode", Asset.EmployeeID);

                }, error: function (errormessage) {
                    if (Asset.ID == 0)
                        swal({ text: "Failed to create new Asset record.", icon: "error" });
                    else
                        swal({ text: "Failed to update Asset record.", icon: "error" });

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