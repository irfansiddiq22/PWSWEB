var AdminLogin = 1;
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

    $("#frmEmployeeLogin").validate({
        errorClass: "is-invalid",

        rules: {
            EmailAdress: "required"

        },
        messages: {
            EmailAdress: "Enter your email address",
        },


    });
    $("#frmEmployeeOTPLogin").validate({
        errorClass: "is-invalid",

        rules: {
            OTP: "required"

        },
        messages: {
            OTP: "Enter your OTP Password.",
        },


    });
    $("#spinner").hide()
})
function Login() {
    if ($("#frmLogin").valid()) {
        $("#spinner").show()
        $.post('/Auth/ProcessLogin', {
            UserName: $("#txtUserName").val(),
            Password: $("#txtPassword").val(),
            RememberMe: $("#chkRememberME").prop("checked")
        }, function (resp) {
            if (resp)
                window.location = "/home";
            else
                swal("Please enter valid credentials", { icon: 'error' });
            $("#spinner").hide()
        })
    }
    return false;
}
function GenerateOTP() {
    if ($("#frmEmployeeLogin").valid()) {
        $("#spinner").show()
        $.post('/Auth/GenerateOTP', {
            EmailAddress: $("#txtEmailAddress").val(),

        }, function (resp) {
            if (resp) {
                swal("OTP is sent to your email address, Enter OTP below to gain access.", { icon: "success" });
                $("#dvEmployeeLogin").addClass("d-none");
                $("#dvEmployeeOTPLogin").removeClass("d-none");

            } else {
                swal("No login id found for this email address, please enter a valid email address.", { icon: "error" });
            }
            $("#spinner").hide()
        })
    }
    return false;
}
function VerifyOTP() {
    if ($("#frmEmployeeOTPLogin").valid()) {
        $("#spinner").show()
        $.post('/Auth/VerifyOTP', {
            EmailAddress: $("#txtEmailAddress").val(),
            OTPPassword: $("#txtOTP").val()
        }, function (resp) {
            if (resp)
                window.location = "/home";
            else
                swal("Please enter valid OPT or regenate OTP.", { icon: 'error' });

            $("#spinner").hide()
        })
    }
    return false;
}
$("#lnkEmployeeLogin").click(function () {

    $("#dvEmployeeOTPLogin").addClass("d-none")
    AdminLogin = (AdminLogin == 1 ? 0 : 1);
    $("#lnkEmployeeLogin").text(AdminLogin == 1 ? "Employee Login" : "Admin Login");
    if (AdminLogin == 1) {
        $("#dvAdminLogin").removeClass("d-none");
        $("#dvEmployeeLogin").addClass("d-none");
    } else {
        $("#dvAdminLogin").addClass("d-none");
        $("#dvEmployeeLogin").removeClass("d-none");
    }
})