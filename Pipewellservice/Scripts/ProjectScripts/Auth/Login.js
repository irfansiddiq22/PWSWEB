$(function () {
    $("#frmLogin").validate({
        errorClass: "is-invalid",

        rules: {
            UserName: "required",
            Password: "required",

        },
        messages: {
            UserName: "Enter your user name",
            Password: "Enter your password.",

        },
        

    });
    $("#spinner").hide()
})
function Login() {
    if ($("#frmLogin").valid()) {
        $("#spinner").show()
        $.post('/Auth/ProcessLogin', {
            UserName: $("#txtUserName").val(),
            Password: $("#txtPassword").val()
        }, function (resp) {
            if (resp)
                window.location = "/Employee/home";
            else
                swal("Please enter valid credentials",{ icon: 'error' });
            $("#spinner").hide()
        })
    }
    return false;
}