
function _Int() {
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
    $.each(Response, function (i, r) {
        var tr = $('<tr>');
        tr.append($('<td class="text-center">').text(i+1))
        tr.append($('<td>').text(r.Name))
        tr.append($('<td>').text(""))
        $("#tblDivisionList").append(tr);
    })
}
function SaveDivision() {
    Post("/SettingAPI/UpdateDivision", { ID: 0, Name: valOf("txtDivisionName") }).done(function (Response) {
        swal({ text: "New division record added.", icon: "success" });
        Clear("txtDivisionName")
        FillDivisionList(Response);
    }).fail(function () {
        swal({ text: "Failed to create new division record.", icon: "error" });
    });

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
    $.each(Response, function (i, r) {
        var tr = $('<tr>');
        tr.append($('<td class="text-center">').text(i + 1))
        tr.append($('<td>').text(r.Name))
        tr.append($('<td>').text(""))
        $("#tblPositionList").append(tr);
    })
}
function SavePosition() {
    Post("/SettingAPI/UpdatePosition", { ID: 0, Name: valOf("txtPositionName") }).done(function (Response) {
        swal({ text: "New position record added.", icon: "success" });
        Clear("txtPositionName")
        FillPositionList(Response);
    }).fail(function () {
        swal({ text: "Failed to create new division record.", icon: "error" });
    });

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
    $.each(Response, function (i, r) {
        var tr = $('<tr>');
        tr.append($('<td class="text-center">').text(i + 1))
        tr.append($('<td>').text(r.Name))
        tr.append($('<td>').text(""))
        $("#tblDepartmentList").append(tr);
    })
}
function SaveDepartment() {
    Post("/SettingAPI/UpdateDepartment", { ID: 0, Name: valOf("txtDepartmentName") }).done(function (Response) {
        swal({ text: "New department record added.", icon: "success" });
        Clear("txtDepartmentName")
        FillDepartmentList(Response);
    }).fail(function () {
        swal({ text: "Failed to create new department record.", icon: "error" });
    });

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