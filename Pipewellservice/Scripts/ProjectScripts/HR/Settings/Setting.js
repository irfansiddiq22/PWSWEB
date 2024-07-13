var Settings = {
    Division: [],
    Postions :[],
    Departments :[],
    Nationalities :[],
    Data: {ID:0},
}

function ResetForm() {
    Settings.Data.ID = 0;
    ResetChangeLog();
}
function _Init() {
    SetPagePermission(PAGES.Division, function () { BindDivision(); });
    SetPagePermission(PAGES.Position, function () { BindPositions(); });
    LoadSponsor();
    FillWorkTimeSchedule();
    for (i = 0; i <= 24; i++) {
        $("#ddScheduleHourStart,#ddScheduleHourEnd").append(AppendListItem(i,i))
    }
    for (i = 0; i <= 60; i++) {
        $("#ddScheduleMinStart,#ddScheduleMinEnd").append(AppendListItem(i, i))
    }
    for (i = 0; i <= 30; i++) {
        $("#ddScheduleMartingIn,#ddScheduleMarginOut").append(AppendListItem(i, i))
    }
    //SetPagePermission(PAGES.Department, function () { BindDepartments(); });

    
}

///////////////////////////

function BindDivision() {
    Post("/SettingAPI/DivisionList", {}).done(function (Response) {
        $("#tblDivisionList").empty();

        FillDivisionList(Response)

        FillList("ddlParentDivisionID",Response,"Name","ID","Select ")
    });
    Post("/DataList/Supervisors", {}).done(function (Response) {
        FillList("ddlSupervisorID", Response, "Name", "ID", "Select Supervisor")
    });

}
function FillSponsorList() {
    $("#tblSponsorList").empty();
    $.each(SponsorData, function (i, s) {
        var tr = $('<tr>')
        tr.append($('<td>').text(s.Name))
        tr.append($('<td>').text(s.CRNumber))
        tr.append($('<td>').append($('<a class="btn btn-sm btn-primary" onclick="EditSponsor('+ s.ID +')">').append($('<i class="fa fa-edit">'))));

        $("#tblSponsorList").append(tr)
    })
}
function FillDivisionList(Response) {
    $("#tblDivisionList").empty();
    Settings.Division = Response;
    $.each(Response, function (i, r) {
        var tr = $('<tr>');
        tr.append($('<td class="text-center">').text(r.ID))
        tr.append($('<td>').text(r.Name))
        tr.append($('<td>').text(r.ParentDivisionName))
        tr.append($('<td>').text(r.SupervisorName))

        var Icons = $('<div class="icons">');
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary writeble1 me-2" onclick="EditDivision(' + i + ')"><i class="fa fa-edit"></i></a>'));
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger deleteble1" onclick="DeleteDivision(' + i + ')"><i class="fa fa-trash"></i></a>'));
        tr.append($('<td>').append($(Icons)));

        $("#tblDivisionList").append(tr);
    })
}
function EditDivision(i) {
    SetvalOf("txtDivisionName", Settings.Division[i].Name)
    SetvalOf("ddlSupervisorID", Settings.Division[i].SupervisorID)
    SetvalOf("ddlParentDivisionID", Settings.Division[i].ParentDivision)
    Settings.Data = Settings.Division[i];

}
function SaveDivision() {
    DataChangeLog.Form = PAGES.Division;
    DataChangeLog.RecordID = Settings.Data.ID;
    if (Settings.Data.ID > 0) {
        if($.trim(Settings.Data.Name) != $.trim(valOf("txtDivisionName"))) 
            DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: Settings.Data.Name, New: valOf("txtDivisionName") } });
        if ($.trim(Settings.Data.SupervisorID) != $.trim(valOf("ddlSupervisorID")))
            DataChangeLog.DataUpdated.push({ Field: "SupervisorID", Data: { OLD: Settings.Data.SupervisorID, New: valOf("ddlSupervisorID") } });
        if ($.trim(Settings.Data.ParentDivision) != $.trim(valOf("ddlParentDivisionID")))
            DataChangeLog.DataUpdated.push({ Field: "ParentDivision", Data: { OLD: Settings.Data.ParentDivision, New: valOf("ddlParentDivisionID") } });

    } else if (Settings.Data.ID == 0) {
        DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: valOf("txtDivisionName") }});
    }

    Post("/SettingAPI/UpdateDivision", { ID: Settings.Data.ID, Name: valOf("txtDivisionName"), SupervisorID: valOf("ddlSupervisorID"), ParentDivision: valOf("ddlParentDivisionID") , Log: DataChangeLog }).done(function (Response) {
        if (Settings.Data.ID == 0)
            swal({ text: "New division record added.", icon: "success" });
        else
            swal({ text: "Division data record updated.", icon: "success" });
        Clear("txtDivisionName")
        valOf("ddlSupervisorID", 0);
        SetvalOf("ddlParentDivisionID",0)
        ResetForm();
        FillDivisionList(Response);
    }).fail(function () {
        swal({ text: "Failed to create new division record.", icon: "error" });
    });

}
function DeleteDivision(i) {
    SwalConfirm("Are you sure to delete this record", "",function () {
        Post("/SettingAPI/RemoveDivision", { ID: Settings.Division[i].ID, Name: User.Name }).done(function (Response) {
            ResetForm();
            if (Response) {
                swal({ text: "Division record deleted.", icon: "success" });
                BindDivision();
            } else {
                swal({ text: "Failed to remove division.", icon: "error" });
            }
        });
    })
}
//////////////////////////////////////


///////////////////////////

function BindPositions() {
    Post("/SettingAPI/PositionList", {}).done(function (Response) {
        $("#tblPositionList").empty();
        
        FillPositionList(Response)
    });

}
function FillPositionList(Response) {
    $("#tblPositionList").empty();
    Settings.Postions = Response;
    $.each(Response, function (i, r) {
        var tr = $('<tr>');
        tr.append($('<td class="text-center">').text(i + 1))
        tr.append($('<td>').text(r.Name))

        var Icons = $('<div class="icons">');
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary writeble2 me-2" onclick="EditPosition(' + i + ')"><i class="fa fa-edit"></i></a>'));
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger deleteble2" onclick="DeletePosition(' + i + ')"><i class="fa fa-trash"></i></a>'));
        tr.append($('<td>').append($(Icons)));

        $("#tblPositionList").append(tr);
    })
}
function EditPosition(i) {
    SetvalOf("txtPositionName", Settings.Postions[i].Name)
    Settings.Data = Settings.Postions[i];
}
function SavePosition() {

    DataChangeLog.Form = PAGES.Position;
    DataChangeLog.RecordID = Settings.Data.ID;
    if (Settings.Data.ID > 0 && $.trim(Settings.Data.Name) != $.trim(valOf("txtPositionName"))) {
        DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: Settings.Data.Name, New: valOf("txtPositionName") } });
    } else if (Settings.Data.ID == 0) {
        DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: valOf("txtPositionName") } });
    }


    Post("/SettingAPI/UpdatePosition", { ID: Settings.Data.ID, Name: valOf("txtPositionName"), Log: DataChangeLog  }).done(function (Response) {
        
        if (Settings.Data.ID == 0)
            swal({ text: "New position record added.", icon: "success" });
        else
            swal({ text: "Position data record updated.", icon: "success" });

        Clear("txtPositionName")

        ResetForm();

        FillPositionList(Response);
    }).fail(function () {
        swal({ text: "Failed to create new division record.", icon: "error" });
    });

}
function DeletePosition(i) {
    SwalConfirm("Are you sure to delete this record", "",function () {
        Post("/SettingAPI/RemovePosition", { ID: Settings.Postions[i].ID, Name: User.Name }).done(function (Response) {
            ResetForm();
            if (Response) {
                swal({ text: "Position record deleted.", icon: "success" });
                BindPositions();
            } else {
                swal({ text: "Failed to remove position.", icon: "error" });
            }
        });
    })
}




///////////////////////////

function BindDepartments() {
    Post("/SettingAPI/DepartmentList", {}).done(function (Response) {
        $("#tblDepartmentList").empty();
        FillDepartmentList(Response)
    });
    

}
function FillDepartmentList(Response) {
    $("#tblDepartmentList").empty();
    Settings.Departments = Response;
    $.each(Response, function (i, r) {
        var tr = $('<tr>');
        tr.append($('<td class="text-center">').text(i + 1))
        tr.append($('<td>').text(r.Name))
        var Icons = $('<div class="icons">');
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary me-2 writeble3" onclick="EditDepartment(' + i + ')"><i class="fa fa-edit"></i></a>'));
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger deleteble3" onclick="DeleteDepartment(' + i + ')"><i class="fa fa-trash"></i></a>'));
        tr.append($('<td>').append($(Icons)));

        $("#tblDepartmentList").append(tr);
    })
}
function EditDepartment(i) {
    SetvalOf("txtDepartmentName", Settings.Departments[i].Name)
    Settings.Data = Settings.Departments[i];
}
function SaveDepartment() {
    DataChangeLog.Form = PAGES.Department;
    DataChangeLog.RecordID = Settings.Data.ID;
    if (Settings.Data.ID > 0 && $.trim(Settings.Data.Name) != $.trim(valOf("txtDepartmentName"))) {
        DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: Settings.Data.Name, New: valOf("txtDepartmentName") } });
    } else if (Settings.Data.ID == 0) {
        DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: valOf("txtDepartmentName") } });
    }

    Post("/SettingAPI/UpdateDepartment", { ID: Settings.Data.ID, Name: valOf("txtDepartmentName"), Log: DataChangeLog }).done(function (Response) {
        if (Settings.Data.ID == 0)
            swal({ text: "New department record added.", icon: "success" });
        else
            swal({ text: "Department record updated.", icon: "success" });

        ResetForm();
        Clear("txtDepartmentName")
        FillDepartmentList(Response);
    }).fail(function () {
        swal({ text: "Failed to create new department record.", icon: "error" });
    });

}
function DeleteDepartment(i) {
    SwalConfirm("Are you sure to delete this record","", function () {
        Post("/SettingAPI/RemovePosition", { ID: Settings.Postions[i].ID, Name: User.Name }).done(function (Response) {
            ResetForm();
            if (Response) {
                swal({ text: "Position record deleted.", icon: "success" });
                BindPositions();
            } else {
                swal({ text: "Failed to remove position.", icon: "error" });
            }
        });
    })
}


//////////////////////////////////////////

var WorkTimeList = [];

function FillWorkTimeSchedule() {

    $("#tblWorkScheduleList").empty();
    Post("/SettingAPI/WorkTimeList", {}).done(function (Response) {
        WorkTimeList = Response;
    $.each(Response, function (i, r) {
        var tr = $('<tr>');
        tr.append($('<td class="text-center">').text(r.ID))
        tr.append($('<td>').text(r.StartHour))
        tr.append($('<td>').text(r.StartMin))
        tr.append($('<td>').text(r.EndHour))
        tr.append($('<td>').text(r.EndMin))
        tr.append($('<td>').text(r.MarginIn))
        tr.append($('<td>').text(r.MarginOut))
        var Icons = $('<div class="icons">');
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary me-2 writeble3" onclick="EditWorkTimeSchedule(' + i + ')"><i class="fa fa-edit"></i></a>'));
        tr.append($('<td>').append($(Icons)));

        $("#tblWorkScheduleList").append(tr);
        })
    })
}
function EditWorkTimeSchedule(i) {
    var WorkTime = WorkTimeList[i];
    Settings.Data.ID = WorkTime.ID;
    SetvalOf("ddScheduleHourStart", WorkTime.StartHour)
    SetvalOf("ddScheduleMinStart", WorkTime.StartMin)

    SetvalOf("ddScheduleHourEnd", WorkTime.EndHour)
    SetvalOf("ddScheduleMinEnd", WorkTime.EndMin)

    SetvalOf("ddScheduleMartingIn", WorkTime.MarginIn)
    SetvalOf("ddScheduleMarginOut", WorkTime.MarginOut)
}
function SaveWorkScheduleTime() {
    var WorkTime = {
        ID: Settings.Data.ID,
        StartHour: valOf("ddScheduleHourStart"),
        StartMin: valOf("ddScheduleMinStart"),
        EndHour: valOf("ddScheduleHourEnd"),
        EndMin: valOf("ddScheduleMinEnd"),
        MarginIn: valOf("ddScheduleMartingIn"),
        MarginOut: valOf("ddScheduleMarginOut")
    }
    Post("/SettingAPI/UpdateWorkTime", { time: WorkTime }).done(function (resp) {
        Settings.Data.ID = 0;
        if (resp) {
            swal("Schedule time updated", { icon: "success" });
            SetvalOf("ddScheduleHourStart", 0)
            SetvalOf("ddScheduleMinStart", 0)

            SetvalOf("ddScheduleHourEnd", 0)
            SetvalOf("ddScheduleMinEnd", 0)

            SetvalOf("ddScheduleMartingIn", 0)
            SetvalOf("ddScheduleMarginOut", 0)
            FillWorkTimeSchedule();
        }
        else
            swal("Fail to update schedule time", { icon: "error" });
    })
}