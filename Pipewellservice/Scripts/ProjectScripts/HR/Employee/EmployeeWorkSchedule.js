var WorkSchedule = {
    ID: 0,
    EmployeeID: 0,
    Name: '',
    FridayTime: 0,
    SaturdayTime: 0,
    SundayTime: 0,
    MondayTime: 0,
    TuesdayTime: 0,
    WednesdayTime: 0,
    ThursdayTime: 0,

    RecordAddedBy: User.Name
};
var WorkScheduleList = [];

function _Init() {
    $("#ddlDataRange").val(moment().startOf('month').format('DD/MM/YYYY') + ' - ' + moment().endOf('week').format('DD/MM/YYYY'));
    HideSpinner();
    SetPagePermission(PAGES.EmployeeWorkSchedule, function () {
        BindUsers();
        BindTime();
    });



}
function BindTime() {
    Post("/SettingAPI/WorkTimeList", {}).done(function (Response) {
        $.each(Response, function (i, t) {
            $(".worktime").append(AppendListItem(t.Time, t.ID))
        })

    })
}
function BindUsers() {
    Post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        if (Response.length > 1)
            data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
        })
        $("#ddEmployeeCode,#ddWorkScheduleEmployeeCode").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            width: '100%',
            data: data
        })
        FillWorkSchedule();

    })


}


function ResetNav() {
    window.location = "/home"
}
$('form').on('reset', function (e) {
    InitializeSchedule();
})
function InitializeSchedule() {
    WorkSchedule = {
        ID: 0,
        EmployeeID: 0,
        Name: '',
        FridayTime: 0,
        SaturdayTime: 0,
        SundayTime: 0,
        MondayTime: 0,
        TuesdayTime: 0,
        WednesdayTime: 0,
        ThursdayTime: 0,

        RecordAddedBy: User.Name
    }
    ResetChangeLog(PAGES.EmployeeWorkSchedule);
}

function FillWorkSchedule() {
    $("#tblEmployeeScheduleTimeList").empty();
    InitializeSchedule();
    var DateRange = $("#ddlDataRange").val().split("-");


    Post("/EmployeeAPI/EmployeeWorkTimeList", {
        EmployeeID: valOf("ddEmployeeCode"), StartDate: DateRange[0], EndDate: DateRange[1]
    }).done(function (Response) {
        WorkScheduleList = Response;

        $.each(Response, function (i, c) {
            var tr = $('<tr>');
            tr.append($('<td>').text((c.ID)))
            tr.append($('<td>').text((c.EmployeeID)))
            tr.append($('<td>').text(c.EmployeeName))
            tr.append($('<td>').text(moment(c.RecordDate).format("DD/MM/YYYY")))
            tr.append($('<td>').text(c.FridayTime))
            tr.append($('<td>').text(c.SaturdayTime))
            tr.append($('<td>').text(c.SundayTime))
            tr.append($('<td>').text(c.MondayTime))
            tr.append($('<td>').text(c.TuesdayTime))
            tr.append($('<td>').text(c.WednesdayTime))
            tr.append($('<td>').text(c.ThursdayTime))

            var Icons = $('<div class="icons">');
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary writeble me-2" onclick="EditWorkSchedule(' + i + ')"><i class="fa fa-edit"></i></a>'));
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger deleteble" onclick="DeleteWorkSchedule(' + i + ')"><i class="fa fa-trash"></i></a>'));
            tr.append($('<td>').append($(Icons)));

            $("#tblEmployeeScheduleTimeList").append(tr)
        })
        SetPagePermission(PAGES.EmployeeWorkSchedule, function () { });
    });
}
function EditWorkSchedule(index) {
    WorkSchedule = WorkScheduleList[index];


    SetvalOf("ddWorktimeFriday", WorkSchedule.FridayTime );
    SetvalOf("ddWorktimeSaturday", WorkSchedule.SaturdayTime );
    SetvalOf("ddWorktimeSunday", WorkSchedule.SundayTime );
    SetvalOf("ddWorktimeMonday", WorkSchedule.MondayTime );
    SetvalOf("ddWorktimeTuesday", WorkSchedule.TuesdayTime );
    SetvalOf("ddWorktimeWednesday", WorkSchedule.WednesdayTime );
    SetvalOf("ddWorktimeThursday", WorkSchedule.ThursdayTime );
    SetvalOf("ddWorkScheduleEmployeeCode", WorkSchedule.EmployeeID);
    $("#ddWorkScheduleEmployeeCode").trigger("change")

    ResetDatePicker();
}
function SaveWorkSchedule() {
    if (valOf("ddWorkScheduleEmployeeCode") == 0) {
        swal("Please select employee", { icon: "danger" });
        return false;
    }



    if (WorkSchedule.ID == 0) {
        DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: textOf("ddWorkScheduleEmployeeCode") } });
    } else {

        if (WorkSchedule.FridayTime != valOf("ddWorktimeFriday")) {
            DataChangeLog.DataUpdated.push({ Field: "Friday", Data: { OLD: WorkSchedule.FridayTime,New:valOf("ddWorktimeFriday") } });
        }
        if (WorkSchedule.SaturdayTime != valOf("ddWorktimeSaturday")) {
            DataChangeLog.DataUpdated.push({ Field: "Saturday", Data: { OLD: WorkSchedule.SaturdayTime, New: valOf("ddWorktimeSaturday") } });
        }
        if (WorkSchedule.SundayTime != valOf("ddWorktimeSunday")) {
            DataChangeLog.DataUpdated.push({ Field: "Sunday", Data: { OLD: WorkSchedule.SundayTime, New: valOf("ddWorktimeFriday") } });
        }
        if (WorkSchedule.MondayTime != valOf("ddWorktimeMonday")) {
            DataChangeLog.DataUpdated.push({ Field: "Monday", Data: { OLD: WorkSchedule.MondayTime, New: valOf("ddWorktimeMonday") } });
        }
        if (WorkSchedule.TuesdayTime != valOf("ddWorktimeTuesday")) {
            DataChangeLog.DataUpdated.push({ Field: "Tuesday", Data: { OLD: WorkSchedule.TuesdayTime, New: valOf("ddWorktimeTuesday") } });
        }
        if (WorkSchedule.WednesdayTime != valOf("ddWorktimeWednesday")) {
            DataChangeLog.DataUpdated.push({ Field: "Wednesday", Data: { OLD: WorkSchedule.WednesdayTime, New: valOf("ddWorktimeWednesday") } });
        }
        if (WorkSchedule.ThursdayTime != valOf("ddWorktimeThursday")) {
            DataChangeLog.DataUpdated.push({ Field: "Thursday", Data: { OLD: WorkSchedule.ThursdayTime, New: valOf("ddWorktimeThursday") } });
        }
        

    }
    WorkSchedule.FridayTime = valOf("ddWorktimeFriday");
    WorkSchedule.SaturdayTime = valOf("ddWorktimeSaturday");
    WorkSchedule.SundayTime = valOf("ddWorktimeSunday");
    WorkSchedule.MondayTime = valOf("ddWorktimeMonday");
    WorkSchedule.TuesdayTime = valOf("ddWorktimeTuesday");
    WorkSchedule.WednesdayTime = valOf("ddWorktimeWednesday");
    WorkSchedule.ThursdayTime = valOf("ddWorktimeThursday");
    WorkSchedule.EmployeeID = valOf("ddWorkScheduleEmployeeCode");

    Post("/EmployeeAPI/UpdateEmployeeWorkScheduleTime", { employeetime: WorkSchedule }).done(function (resp) {
        if (resp) {
            document.getElementById("frmEmployeeScheduleTime").reset();
            swal("Employee work schedule updated", { icon: "success" });
            FillWorkSchedule()
        } else {
            swal("Failed to update work schedule", { icon: "error" });
        }
    })

    
    return false;



}
function DeleteWorkSchedule(i) { }
