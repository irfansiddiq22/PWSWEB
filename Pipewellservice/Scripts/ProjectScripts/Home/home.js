﻿var PendingApprovalList = [];
function _Init() {
    $("#spinner").hide();
    SetUserGroupPermissions();
    SetGroupPermissions([1,2,3,4]);
    if (!User.ApprovalRequests) {
        $("#dvApprovals").remove();
        $("#dlgPendingApprovals").remove();
    }
    SetPagePermissions([0, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 20, 21, 22,29]);
    SetGroupPermissions([1, 2,3,4,7,8]);
    if (User.ApprovalRequests) GetPendingRequests();

}
function GetPendingRequests() {
    $("#dvApprovals").removeClass("d-none");
    Post("/EmployeeAPI/PendingApprovals", {
        Declined: GetChecked("chkDeclinedApprovals")
    }).done(function (resp) {
        PendingApprovalList = resp;
    })
}
function ShowApprovalList() {
    $("#tblPendingApprovals").empty()
    $.each(PendingApprovalList, function (i, d) {
        var tr = $('<tr data-id="' + d.ID + '" data-type="' + d.RecordType + '">')
        $(tr).append($('<td>').text(d.ApprovalForm))
        $(tr).append($('<td>').append($('<a>').attr("href", "javascript:void(0)").attr("onclick", "Print(" + d.ID + "," + d.PageID + "," + d.RecordID +")").text(d.RecordID)))
        $(tr).append($('<td>').text(moment(d.RecordDate).format("DD/MM/YYYY hh:mm A")));
        $(tr).append($('<td>').text(d.PreparedBy))
        var Remarks = $('<textarea id="txtApprovalRemarks' + d.ID + '" class="form-control form-control-sm" rows="4">')
        $(Remarks).val(d.Remarks);

        var btng = '<div class="m-2"><div class="btn-group mt-2" role="group"><input name="approvals' + d.ID + '" type="radio" class="btn-check" id="btnApprove' + d.ID + '" autocomplete="off"><label class="btn btn-sm btn-outline-success" for="btnApprove' + d.ID + '">Approve</label>';
        btng += '  <input name="approvals' + d.ID + '" type="radio" class="btn-check" id="btnReject' + d.ID + '" autocomplete="off">'
        btng += '  <label class="btn btn-sm btn-outline-danger " for="btnReject' + d.ID + '">Reject</label>'
        btng += '  <input name="approvals' + d.ID + '" type="radio" class="btn-check"  id="btnDeclined' + d.ID + '" autocomplete="off">'
        //btng += '  <label class="btn btn-sm btn-outline-warning" for="btnDeclined' + d.ID + '">Decline</label>'
        // btng += '  <input name="approvals' + d.ID + '" type="radio" class="btn-check"  id="btnNoAction' + d.ID + '" autocomplete="off">'
        btng += '  <label class="btn btn-sm btn-outline-primary" for="btnNoAction' + d.ID + '">Forward to higher Level</label>'
        btng += '  </div></div>'
        $(tr).append($('<td>').append($(Remarks)).append(btng))
        var link = '';
        if (d.FileName != "")
            link = $('<a>').attr("href", "javascript:void(0)").attr("onclick", "DownloadFile(" + d.EmployeeID + ",'" + d.FileName + "','" + d.FileID + "','" + d.RecordType + "')").text(d.FileName);




        $(tr).append($('<td>').html("Employee ID =" + d.EmployeeID + "<br>" + d.RequestRemarks).append(link));


        $("#tblPendingApprovals").append(tr);
    })
    $("#dlgPendingApprovals").modal('show');
}
$("#dlgPendingApprovals").on("hidden.bs.modal", function () {

    var List = [];
    $.each($("#tblPendingApprovals tr"), function (i, tr) {
        var ID = $(this).attr("data-id");
        var RecordType = $(this).attr("data-type");
        var Remarks = valOf("txtApprovalRemarks" + ID);
        var Approved = GetChecked("btnApprove" + ID);
        var Rejected = GetChecked("btnReject" + ID);
        var Declined = GetChecked("Declined" + ID);
        var NoAction = GetChecked("btnNoAction" + ID);
        var Status = 3;
        if (Approved)
            Status = 1;
        else if (Rejected)
            Status = 0;
        else if (Declined)
            Status = 2;
        else if (NoAction)
            Status = 7;
        else
            Status = 4;
        List.push({
            RecordType: RecordType,
            ID: ID,
            Remarks: Remarks,
            Status: Status
        })
    })
    if (List.length > 0) {
        Post("/EmployeeAPI/ApproveRequests", { approvals: List }).done(function (resp) {
            if (resp) {
                GetPendingRequests();
            }
        });
    }
});


function DownloadFile(EmployeeID, FileName, FileID, Type) {
    ShowSpinner();
    if (Type == 1)
        DownloadFile("/EmployeeAPI/DownloadClearanceFile?EmployeeID=" + String(EmployeeID) + "&FileName=" + FileName + "&FileID=" + FileID);
    else if (Type == 2)
        DownloadFile("/EmployeeAPI/DownloadInQuiryFile?EmployeeID=" + String(EmployeeID) + "&FileName=" + FileName + "&FileID=" + FileID);
    else if (Type == 3)
        DownloadFile("/EmployeeAPI/DownloadWarningFile?EmployeeID=" + String(EmployeeID) + "&FileName=" + FileName + "&FileID=" + FileID);
    else if (Type == 4)
        return false;
    else if (Type == 5)
        DownloadFile("/EmployeeAPI/DownloadJoiningFile?EmployeeID=" + String(EmployeeID) + "&FileName=" + FileName + "&FileID=" + FileID);
    else if (Type == 6)
        DownloadFile("/EmployeeAPI/DownloadShortLeaveFile?EmployeeID=" + String(EmployeeID) + "&FileName=" + FileName + "&FileID=" + FileID);
    else if (Type == 7)
        DownloadFile("/EmployeeAPI/DownloadLeaveFile?EmployeeID=" + String(EmployeeID) + "&FileName=" + FileName + "&FileID=" + FileID);
}
function Print(ID, Page, RecordID) {
    if (Page == 30)
        window.open("/Procurement/PrintInternalPurchaseRequest?ID=" + RecordID, "ReportPreview", "toolbar=no,status=yes,scrollbars=yes;width:850;height:950")
    else if (Page == 31)
        window.open("/Procurement/PrintPurchaseOrderRequest?ID=" + RecordID, "ReportPreview", "toolbar=no,status=yes,scrollbars=yes;width:850;height:950")
    else
        window.open("/Employee/PrintReport?ID=" + RecordID + "&ReportID=" + Page, "ReportPreview", "toolbar=no,status=yes,scrollbars=yes;width:850;height:950")
}