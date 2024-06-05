﻿function _Init() {
    HideSpinner();
    SetPagePermission(PAGES.EmployeeAttendence, function () {
        BindUsers();
        $("#ddlReportDataRange").val(moment().subtract(30, 'days').format("DD/MM/YYYY") + ' - ' + moment().format("DD/MM/YYYY"))

    })
}

function BindUsers() {
    $.post("/EmployeeAPI/CodeName", {}).done(function (Response) {
        var data = [];
        data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
        })
        $("#ddEmployeeCode").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data
        });
    })
}

function ShowAttendenceReport() {
    var StartDate, EndDate, DateRange = $("#ddlReportDataRange").val();
    if (DateRange == "") {
        swal("Please enter date range", { icon: "error" });
        return;
    }
    var EmployeeID = $("#ddEmployeeCode").val()
    StartDate = DateRange.split("-")[0];
    EndDate = DateRange.split("-")[1];
    if ($("#chkInOut").prop("checked")) {
        if (EmployeeID == 0) {
            swal("Please select employee", { icon: "error" });
            return falsse;
        }
        window.open("/Employee/PrintAttendenceReport?ID=" + $("#ddEmployeeCode").val() + "&ReportID=" + REPORTS.EmployeeAttendenceInOut + "&StartDate=" + $.trim(StartDate) + "&EndDate=" + $.trim(EndDate), "ReportPreview", "toolbar=no,status=yes,scrollbars=yes;width:850;height:950")
    }
    else if ($("#chkDetailAttendence").prop("checked")) {
        
        window.open("/Employee/PrintAttendenceReport?ID=" + $("#ddEmployeeCode").val() + "&ReportID=" + REPORTS.EmployeeAttendenceDetail + "&StartDate=" + $.trim(StartDate) + "&EndDate=" + $.trim(EndDate), "ReportPreview", "toolbar=no,status=yes,scrollbars=yes;width:850;height:950")
    }
}