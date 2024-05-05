var LeaveRequest = {
    ID: 0,
    EmployeeID: 0,
    StartDate: '',
    EndDate: '',
    LeaveType: 0,
    Remarks:'',
    RecordCreatedBy: User.ID
};

var Message = " Sir,\n\rIt is requested that i want to avail #leave# for #day# day(s), kindly allow me leave for #startdate# to #enddate#.Kindly do the needful and oblige.\n\rThanks ,"
function _Init() {

    HideSpinner();
    SetPagePermission(PAGES.LeaveRequest, function () {
        BindUsers();
        $.post("/DataList/LeaveTypes", {}, function (Response) {
            var data = []
            data.push({ id: 0, text: 'Leave Type' });
            $.each(Response, function (i, Lv) {
                data.push({ id: Lv.Value, text: Lv.Name });
            })
            $("#ddlLeaveTypes").select2({
                tags: "true",
                placeholder: "Leave Type",
                allowClear: true,
                width: '100%',
                data: data
            }).on('select2:select', function (e) {
                ResetMessageText();
            });

            
        })

        $("#txtRecordStartDate").on('changeDate', function (selected) {
            $('#txtRecrordEndDate').datepicker('setStartDate', selected.date)
        });

    });

}
function ResetMessageText() {
    var LeaveMessage = Message;
    LeaveMessage = LeaveMessage.replace("#leave#", $("#ddlLeaveTypes option:selected").text())
    LeaveMessage = LeaveMessage.replace("#startdate#", $("#txtRecordStartDate").val())
    LeaveMessage = LeaveMessage.replace("#enddate#", $("#txtRecrordEndDate").val())
    LeaveMessage = LeaveMessage.replace("#day#", moment($("#txtRecrordEndDate").val()).diff(moment("txtRecordStartDate"), 'days'));

    $("#txtRemarks").val(LeaveMessage);
}
function ResetNav() {
    window.location = "/home"
}

$('form').on('reset', function (e) {
    InitializeLeave();
})
function InitializeLeave() {
    LeaveRequest = {
        ID: 0,
        
        StartDate: '',
        EndDate: '',
        LeaveType: 0,
        Remarks: '',
        RecordCreatedBy: User.ID
    }

    ResetChangeLog(PAGES.LeaveRequest);
}

function BindUsers() {
    Post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        if (Response.length > 1)
            data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
        })
        $("#ddEmployeeName").select2({
            tags: "true",
            placeholder: "Select Employee",
            allowClear: true,
            width: '100%',
            data: data
        })

        if (Response.length == 1) {
            $("#ddEmployeeName").val(Response[0].ID).trigger("change")
        }
    })
}

