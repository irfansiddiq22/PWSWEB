function _Init() {
    $("#spinner").hide();
    $("#txtName").val(User.Name)
    SetvalOf("txtEmailAddress", User.EmailAddress)
    $("#txtUserName").val(User.UserName)
}
function SaveProfile() {
    if (valOf("txtName") == "") {
        swal("Please enter your name", { icon: "warning" });
        return false;
    }
    if (valOf("txtEmailAddress") == "") {
        swal("Please enter your email address", { icon: "warning" });
        return false;
    }
    if (valOf("txtUserName") == "") {
        swal("Please enter user name", { icon: "warning" });
        return false;
    }
    if (valOf("txtPassword") != "" && (valOf("txtPassword").length < 6 || valOf("txtPassword").length>10)) {
        swal("Password is invalid. It must be 6 to 8 characters long.", { icon: "warning" });
        return false;
    }
    Post("/Home/UpdateProfile", { Name: valOf("txtName"), UserName: valOf("txtUserName"), Password: valOf("txtPassword"), EmailAddress: valOf("txtEmailAddress") }).done(function (resp) {
        if (resp) 
            swal("Profile updated successfully", { icon: "success" });
        else
            swal("Failed to update profile, please try again or contact with admin.", { icon: "error" });
    })
}