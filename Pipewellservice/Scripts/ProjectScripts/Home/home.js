var PendingApprovalList = [];
function _Init() {
    $("#spinner").hide();
    SetGroupPermissions([1, 3]);
    if (!User.ApprovalRequests) {
        $("#dvApprovals").remove();
        $("#dlgPendingApprovals").remove();
    }
    
    GetPendingRequests();
    
}
function GetPendingRequests() {
    $("#dvApprovals").removeClass("d-none");
    Post("/EmployeeAPI/PendingApprovals", {
        Declined: GetChecked("chkDeclinedApprovals") }).done(function (resp) {
        PendingApprovalList = resp;
    })
}
function ShowApprovalList() {
    $("#tblPendingApprovals").empty()
    $.each(PendingApprovalList, function (i, d) {
        var tr = $('<tr data-id="' + d.ID + '">')
        $(tr).append($('<td>').text(d.ApprovalForm))
        $(tr).append($('<td>').text(d.ID))
        $(tr).append($('<td>').text(moment(d.RecordDate).format("DD/MM/YYYY hh:mm A")));
        $(tr).append($('<td>').text(d.PreparedBy))
        var Remarks = $('<textarea id="txtApprovalRemarks' + d.ID + '" class="form-control form-control-sm" rows="4">')
        $(Remarks).val(d.Remarks);

        var btng = '<div class="m-2"><div class="btn-group mt-2" role="group"><input name="approvals' + d.ID + '" type="radio" class="btn-check" id="btnApprove' + d.ID + '" autocomplete="off"><label class="btn btn-sm btn-outline-success" for="btnApprove' + d.ID + '">Approve</label>';
        btng += '  <input name="approvals' + d.ID + '" type="radio" class="btn-check" id="btnReject' + d.ID + '" autocomplete="off">'
        btng += '  <label class="btn btn-sm btn-outline-danger " for="btnReject' + d.ID + '">Reject</label>'
        btng += '  <input name="approvals' + d.ID + '" type="radio" class="btn-check"  id="btnDeclined' + d.ID + '" autocomplete="off">'
        btng += '  <label class="btn btn-sm btn-outline-warning" for="btnDeclined' + d.ID + '">Declined</label>'
        btng += '  </div></div>'
        $(tr).append($('<td>').append($(Remarks)).append(btng))
        $(tr).append($('<td>').text(d.FileID))
        $(tr).append($('<td>').text("Employee ID =" + d.EmployeeID));


        $("#tblPendingApprovals").append(tr);
    })
    $("#dlgPendingApprovals").modal('show');
}
$("#dlgPendingApprovals").on("hidden.bs.modal", function () {
    
    var List = [];
    $.each($("#tblPendingApprovals tr"), function (i, tr) {
        var ID = $(this).attr("data-id");
        var Remarks = valOf("txtApprovalRemarks" + ID);
        var Approved = GetChecked("btnApprove" + ID);
        var Rejected = GetChecked("btnReject" + ID);
        var Declined = GetChecked("Declined" + ID);
        var Status = 3;
        if (Approved)
            Status = 1;
        else if (Rejected)
            Status = 0;
        else if (Declined)
            Status = 2;
        else
            Status = 3;

        
            List.push({
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
