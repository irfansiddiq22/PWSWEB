var Settings = {
    
    Users: [],
    Data: { ID: 0 },
}

function ResetForm() {
    Settings.Data.ID = 0;
    document.getElementById("frmUsers").reset();
    ResetChangeLog();
}
function _Init() {
    BindUsers();
    BindPermission();
    BindUserGroups();
}


function BindUsers() {
    Post("/SettingAPI/UserList", {}).done(function (Response) {
        $("#tblUserList").empty();
        Settings.Users = Response
        FillUserList(Response)
    });

}

$('#frmUsers').on('reset', function (e) {
    ResetForm();
})

function FillUserList(Response) {
    $("#tblUserList").empty();
    $.each(Response, function (i, r) {
        var tr = $('<tr>');
        tr.append($('<td class="text-center">').text( r.ID))
        tr.append($('<td>').text(r.Name))
        tr.append($('<td>').text(r.UserName))
        tr.append($('<td>').text(r.EmployeeID))
        var Icons = $('<div class="icons">');
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary me-2" onclick="EditUser(' + r.ID + ')"><i class="fa fa-edit"></i></a>'));
        tr.append($('<td>').append($(Icons)));

        $("#tblUserList").append(tr);
    })
}
$("#txtFindUser").keyup(function () {
    FillUserList(Settings.Users.filter(x => x.Name.toLowerCase().indexOf($(this).val().toLowerCase())>-1));
});

function EditUser(i) {
    Settings.Data = Settings.Users.find(x=>x.ID==i);
    SetvalOf("txtName", Settings.Data.Name)
    SetvalOf("txtUserName", Settings.Data.UserName)
    SetvalOf("txtUserPassword", Settings.Data.Password)
    SetvalOf("txtUserEmailAddress", Settings.Data.EmailAddress)
    
    
    SetvalOf("ddUserPermissions", Settings.Data.PermissionGroupID)
    SetvalOf("ddUserGroups", Settings.Data.GroupID)
    
}
function SaveUser() {
    $("#frmUsers").validate({
        errorClass: "text-danger",

        rules: {
            txtName: "required",
            txtUserName: "required",
            txtUserPassword: {
                required: true,
                minlength: 5,
            },
            txtUserEmailAddress: {
                required: true,
                email:true
            }
        },
        messages: {
            txtName: "Please specify name",
            txtUserName: "Please specify user name",
            txtUserPassword: {
                required: "Please enter user password",
                minlength: "Password should be 5 character long"
            },
            txtUserEmailAddress: {
                required: "Please enter user email address",
                email: "Please enter a valid email address"
            }
        },
        submitHandler: function (form) {
            Post("/SettingAPI/UpdateUser", {
                ID: Settings.Data.ID, Name: valOf("txtName"), UserName: valOf("txtUserName"), Password: valOf("txtUserPassword"), GroupID: valOf("ddUserGroups"), PermissionGroupID: valOf("ddUserPermissions"), EmailAddress: valOf("txtUserEmailAddress")
            }).done(function (Response) {
                if (Settings.Data.ID==0)
                    swal({ text: "New user record added.", icon: "success" });
                else
                    swal({ text: "User record updated.", icon: "success" });

                Clear("txtUserName")
                Clear("txtUserPassword")

                ResetForm();
                Settings.Users = Response
                FillUserList(Response);
            }).fail(function () {
                swal({ text: "Failed to create new user record.", icon: "error" });
            });
            return false;
        }

    });
    // return false;
}

///////////////////////////////////////////////////
var PermissionData = {};
var PermissionGroup = {};
function BindPermission() {
    Post("/SettingAPI/ListGroupNPermissions", {}).done(function (Response) {
        $("#tblPermissionGroups").empty();
        PermissionData = Response;
        FillPermissionGroupList(Response.Groups)
        FillPermissons(Response.PageGroups, Response.Pages);
        PermissionGroup = { ID: 0, Name: '', Permissions: [] }
    });
}
function BindUserGroups() {
    Post("/SettingAPI/ListUserGroups", {}).done(function (Response) {
        console.log(Response);
        FillList("ddUserGroups", Response,"Name","Value","User Group"  )
    });
}
function FillPermissionGroupList(Response) {
    $("#tblPermissionGroups,#ddUserPermissions").empty();
    $.each(Response, function (i, r) {
        var tr = $('<tr>');
        tr.append($('<td class="text-center">').text(i + 1))
        tr.append($('<td>').text(r.Name))
        $("#ddUserPermissions").append(AppendListItem(r.Name, r.ID));
        var Icons = $('<div class="icons">');
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary me-2" onclick="EditGroupPermissions(' + i + ')"><i class="fa fa-edit"></i></a>'));
        $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger" onclick="DeleteGroup(' + i + ')"><i class="fa fa-trash"></i></a>'));
        tr.append($('<td>').append($(Icons)));

        $("#tblPermissionGroups").append(tr);
    })
}

$('#frmPermissions').on('reset', function (e) {
    PermissionGroup = { ID: 0, Name: '', Permissions: [] }
})

function FillPermissons(PageGroups, Pages) {
    $("#tblPermissionGroup").empty();
    var treeIndex = 0;
    var head = '<tr class="blue"><td>Group</th><td>Permissions</th></tr>'
    $("#tblPermissionGroup").append(head);
    var parentindex = 0;

    $.each(PageGroups, function (i, g) {
        treeIndex++;
        var tr = $('<tr data-id="' + g.Value + '" class="permissiongroup treegrid-' + treeIndex + '">')
        tr.append($('<td>').text(g.Name));
        var btng = '<div class="btn-group" role="group"><input type="checkbox" class="btn-check" id="btnGroupWrite' + g.Value + '" autocomplete="off" onclick="TogglePermission(\'write' + g.Value + '\',this)"><label class="btn btn-sm btn-outline-success" for="btnGroupWrite' + g.Value + '">Write</label>';
        btng += '  <input type="checkbox" class="btn-check" onclick="TogglePermission(\'view' + g.Value + '\',this)" id="btnGroupView' + g.Value + '" autocomplete="off">'
        btng += '  <label class="btn btn-sm btn-outline-primary" for="btnGroupView' + g.Value + '">View</label>'
        btng += '  <input type="checkbox" class="btn-check" onclick="TogglePermission(\'delete' + g.Value + '\',this)" id="btnGroupDelete' + g.Value + '" autocomplete="off">'
        btng += '  <label class="btn btn-sm btn-outline-danger" for="btnGroupDelete' + g.Value + '">Delete</label>'
        btng += '  </div>'
        tr.append($('<td>').append(btng));

        
        $("#tblPermissionGroup").append(tr);
        parentindex = treeIndex;
        $.each(Pages.filter(x => x.SubParentID == g.Value), function (j, p) {
            treeIndex++;
            tr = $('<tr  data-id="' + p.Value + '" class="permissionpage treegrid-' + treeIndex + ' treegrid-parent-' + (parentindex) + '">')
            tr.append($('<td>').text(p.Name));
            var btng = '<div class="btn-group" role="group"><input type="checkbox" class="btn-check write' + p.SubParentID + '" id="btnWrite' + p.Value + '" autocomplete="off"><label class="btn btn-sm btn-outline-success" for="btnWrite' + p.Value + '">Write</label>';
            btng += '  <input type="checkbox" class="btn-check view' + p.SubParentID + '" id="btnView' + p.Value + '" autocomplete="off">'
            btng += '  <label class="btn btn-sm btn-outline-primary" for="btnView' + p.Value + '">View</label>'
            btng += '  <input type="checkbox" class="btn-check delete' + p.SubParentID + '" id="btnDelete' + p.Value + '" autocomplete="off">'
            btng += '  <label class="btn btn-sm btn-outline-danger" for="btnDelete' + p.Value + '">Delete</label>'
            btng += '  </div>'
            tr.append($('<td>').append(btng));
            $("#tblPermissionGroup").append(tr);

        })
    })


    $('#tblPermissionGroup').treegrid({
        expanderExpandedClass: 'fa fa-minus',
        expanderCollapsedClass: 'fa fa-plus',
        initialState: 'expanded'
    });
}

function TogglePermission(Permission, sender) {
    $("." + Permission).each(function () {
        $(this).prop("checked", $(sender).prop("checked"));
    })
}
function EditGroupPermissions(index) {
    PermissionGroup = PermissionData.Groups[index];
    PermissionGroup.Permissions = PermissionData.Permissions.filter(x => x.GroupID == PermissionGroup.ID);
    SetvalOf("txtPermissionGroupName", PermissionGroup.Name)
    $("#tblPermissionGroup tr.permissionpage").each(function (i, t) {

        var page = PermissionGroup.Permissions.find(x => x.PageID == parseInt($(t).attr("data-id")));
        if (page != undefined) {
            SetChecked("btnWrite" + page.PageID, page.CanWrite);
            SetChecked("btnView" + page.PageID, page.CanView);
            SetChecked("btnDelete" + page.PageID, page.CanDelete);
        }
    });
    
}
function SaveGroupPermissions() {
    if (valOf("txtPermissionGroupName") == "") {
        swal("Please enter permission group name", {icon:"error"});
        return false;
    }
    var pagepermissions = [];

    $("#tblPermissionGroup tr.permissionpage").each(function (i, t) {
        var PageID = parseInt($(this).attr("data-id"));
        var CanWrite = $("#btnWrite" + PageID).prop("checked")
        var CanView = $("#btnView" + PageID).prop("checked")
        var CanDelete = $("#btnDelete" + PageID).prop("checked")
        pagepermissions.push({
            PageID: PageID,
            CanWrite: CanWrite,
            CanDelete: CanDelete,
            CanView: CanView
        });
    });
    PermissionGroup.Name = valOf("txtPermissionGroupName")
    PermissionGroup.Permissions = pagepermissions;

    
    
    Post("/SettingAPI/UpdateGroupPermissions", { group: PermissionGroup }).done(function (Resp) {

        if (Resp) {
            swal("Permissions saved", { icon: "success" });
            BindPermission();
        } else {
            swal("Failed to update permissions", { icon: "error" });
        }
    });
}