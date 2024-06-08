function _Init() {
    //$("#ddlDataRange").val(moment().startOf('month').format('DD/MM/YYYY') + ' - ' + moment().endOf('month').format('DD/MM/YYYY'));//
    FillIDTypeList("ddlIDFileType")
    setTimeout(function () {
        $("#ddlIDFileType").prepend($('<option>', {
            text: "Select ID",
            value: ""
        }))
        $("#ddlIDFileType").val("");
        BindExpiringID();
    }, 2000)
    
}
function BindExpiringID() {
    var Date = $("#ddlDataRange").val()
    if (Date == "") {
        swal("Enter date range", { icon: "error" });
        return false;
    }

    Post("/EmployeeAPI/ExpiringIDData", {
        StartDate: Date.split("-")[0], EndDate: Date.split("-")[1], FileType: valOf("ddlIDFileType")
    }).done(function (resp) {

        var tr = $('<tr>')
        $("#tblEmployeeExpiringID").empty()
        $.each(resp, function (i, d) {
            tr = $('<tr>');
            tr.append($('<td>').text(d.EmployeeID));
            tr.append($('<td>').text(d.Name));
            tr.append($('<td>').text(d.ArabicName));
            tr.append($('<td>').text(d.Nationality));

            tr.append($('<td>').text(d.Division));
            tr.append($('<td>').text(d.Position));
            tr.append($('<td>').text(d.IDType));
            tr.append($('<td>').text(d.IDNumber));
            tr.append($('<td>').text(moment(d.ExpiryDate).format("DD/MM/YYYY")));
            $("#tblEmployeeExpiringID").append(tr);
            
        })
     })
}
function ExportExpiringID() {


    var data = $("<div>");
    $(data).append($("#dvExpiringIdData").html());
    ExportToExcel($(data).html(), "EmployeeExpiringID.xls")
}