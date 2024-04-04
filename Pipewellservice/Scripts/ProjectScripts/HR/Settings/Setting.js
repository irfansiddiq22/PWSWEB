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
    BindDivision();
    BindPositions();
    BindDepartments();
    BindUsers();
}

///////////////////////////

function BindDivision() {
    Post("/SettingAPI/DivisionList", {}).done(function (Response) {
        $("#tblDivisionList").empty();

        FillDivisionList(Response)
    });

}
function FillDivisionList(Response) {
    $("#tblDivisionList").empty();
    Settings.Division = Response;
    $.each(Response, function (i, r) {
        var tr = $('<tr>');
        tr.append($('<td class="text-center">').text(i + 1))
        tr.append($('<td>').text(r.Name))

        var Icons = $('<div class="icons">');
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary me-2" onclick="EditDivision(' + i + ')"><i class="fa fa-edit"></i></a>'));
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="DeleteDivision(' + i + ')"><i class="fa fa-trash"></i></a>'));
        tr.append($('<td>').append($(Icons)));

        $("#tblDivisionList").append(tr);
    })
}
function EditDivision(i) {
    SetvalOf("txtDivisionName", Settings.Division[i].Name)
    Settings.Data = Settings.Division[i];

}
function SaveDivision() {
    DataChangeLog.Form = PAGES.Division;
    DataChangeLog.RecordID = Settings.Data.ID;
    if (Settings.Data.ID > 0 && $.trim(Settings.Data.Name) != $.trim(valOf("txtDivisionName"))) {
        DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: Settings.Data.Name, New: valOf("txtDivisionName") } });
    } else if (Settings.Data.ID == 0) {
        DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: valOf("txtDivisionName") }});
    }

    Post("/SettingAPI/UpdateDivision", { ID: Settings.Data.ID, Name: valOf("txtDivisionName"), Log: DataChangeLog }).done(function (Response) {
        if (Settings.Data.ID == 0)
            swal({ text: "New division record added.", icon: "success" });
        else
            swal({ text: "Division data record updated.", icon: "success" });
        Clear("txtDivisionName")

        ResetForm();

        FillDivisionList(Response);
    }).fail(function () {
        swal({ text: "Failed to create new division record.", icon: "error" });
    });

}
function DeleteDivision(i) {
    SwalConfirm("Are you sure to delete this record", function () {
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
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary me-2" onclick="EditPosition(' + i + ')"><i class="fa fa-edit"></i></a>'));
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="DeletePosition(' + i + ')"><i class="fa fa-trash"></i></a>'));
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
    SwalConfirm("Are you sure to delete this record", function () {
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
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary me-2" onclick="EditDepartment(' + i + ')"><i class="fa fa-edit"></i></a>'));
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="DeleteDepartment(' + i + ')"><i class="fa fa-trash"></i></a>'));
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
    SwalConfirm("Are you sure to delete this record", function () {
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
///////////////////

function BindUsers() {
    Post("/SettingAPI/UserList", {}).done(function (Response) {
        $("#tblUserList").empty();
        FillUserList(Response)
    });

}
function FillUserList(Response) {
    $("#tblUserList").empty();
    $.each(Response, function (i, r) {
        var tr = $('<tr>');
        tr.append($('<td class="text-center">').text(i + 1))
        tr.append($('<td>').text(r.Name))
        tr.append($('<td>').text(""))
        $("#tblUserList").append(tr);
    })
}

function SaveUser() {
    $("#frmUsers").validate({
        errorClass: "text-danger",

        rules: {
            txtUserName: "required",
            txtUserPassword: {
                required: true,
                minlength: 5,
            }
        },
        messages: {
            txtUserName: "Please specify user name",
            txtUserPassword: {
                required: "Please enter user password",
                minlength: "Password should be 5 character long"
            }
        },
        submitHandler: function (form) {
            Post("/SettingAPI/UpdateUser", { ID: 0, Name: valOf("txtUserName"), Password: valOf("txtUserPassword") }).done(function (Response) {
                swal({ text: "New user record added.", icon: "success" });
                Clear("txtUserName")
                Clear("txtUserPassword")

                FillUserList(Response);
            }).fail(function () {
                swal({ text: "Failed to create new user record.", icon: "error" });
            });
            return false;
        }

    });
    // return false;
}