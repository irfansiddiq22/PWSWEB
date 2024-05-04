var LeaveRequest = {
    ID: 0,
    EmployeeID: 0,
    StartDate: '',
    EndDate: '',
    LeaveType: 0,
    Remarks:'',
    RecordCreatedBy: User.ID
};


function _Init() {

    HideSpinner();
    SetPagePermission(PAGES.LeaveRequest, function () {
        BindUsers();
        $.post("/DataList/LeaveTypes", {}, function (Response) {
            var data = []
            data.push({ id: 0, text: 'Leave Type' });
            $.each(Response, function (i, Lv) {
                data.push({ id: Lv.Value, text: Lv.Value + " - " + Lv.Name });
            })
            $("#ddlLeaveTypes").select2({
                tags: "true",
                placeholder: "Leave Type",
                allowClear: true,
                width: '100%',
                data: data
            })

            
        })
    });

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

