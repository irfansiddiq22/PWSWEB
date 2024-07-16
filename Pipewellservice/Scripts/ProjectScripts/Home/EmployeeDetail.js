
$(".datepicker").datepicker({
    autoclose: true,
    todayHighlight: false,
    format: 'dd/mm/yyyy'
})

function ResetDateRangePicker() {
    $('.daterange').each(function (i, dp) {
        var dp = $(this)
        var start = moment().subtract(10, 'years').startOf('year').format("DD/MM/YYYY")
        var end = end = moment().endOf('week').format("DD/MM/YYYY")

        $(dp).daterangepicker({
            open: 'left',
            showDropdowns:true, 

        })
        if ($(dp).val() == "")
            $(dp).val(start + ' - ' + end);
    })
}
function AddMoreExperience() {
    var clone = $("#tblEmployeeWorkExp").clone();
    $(clone).find(":input").each(function () {
        $(this).val('');
    })
    $("#dvMoreWordExp").append($(clone));
    $("#btnRemoveWordExp").removeClass("d-none")

    ResetDateRangePicker();
}
function RemoveMoreExperience() {
    var WorkExperience = $(".WorkExperience")
    if (WorkExperience.length > 1) {
        $(WorkExperience[WorkExperience.length - 1]).remove();
    }
    if ($(".WorkExperience").length == 1) {
        $("#btnRemoveWordExp").addClass("d-none")
    }
}
$(function () {
    $("#spinner").hide();
    ResetDateRangePicker();
    $("#frmPersonalDetails").validate({
        errorClass: "text-danger",

        rules: {
            EmployeeName: "required",
            EmployeeNumber: "required",
            InquiryRemarks: "required",

        },
        messages: {
            EmployeeName: "Please select employee name",
            EmployeeNumber: "Please enter employee number",

        }
    });
})
function SaveDetails(token) {
    var r = 1;
    if (location.hostname !="localhost")
      r = grecaptcha.getResponse()
    
    if (r != "") {

        if ($("#frmPersonalDetails").valid()) {



            var EmployeeDetails = {}
            $.each($("input[data-id],textarea[data-id],select[data-id]"), function (i, c) {
                EmployeeDetails[$(this).attr("data-id")] = $(this).val();

                if ($(this).attr("data-type") == "date") {
                    EmployeeDetails[$(this).attr("data-id")] = moment($(this).val(),"DD/MM/YYYY").format("DD/MM/YYYY");
                    if (EmployeeDetails[$(this).attr("data-id")] == "Invalid date")
                        EmployeeDetails[$(this).attr("data-id")] = '';
                }

            });
            var WorkExp = Array.from($(".WorkExperience")).map(table => ({
                CompanyName: $(table).find("#txtEmployeeExpCompnanyName").val(),
                Duration: $(table).find("#txtEmployeeExpDuration").val(),
                
                Designation: $(table).find("#txtEmployeeExpDesignation").val(),
                JobNature: $(table).find("#txtEmployeeExpJobNature").val(),
                Notes: $(table).find("#txtEmployeeExpNotes").val(),
            }));
            var result = true;
            WorkExp.forEach(exp => {

                if (exp.Duration == "") {
                    swal("Enter work experience duration", { icon: "error" });
                    result = false;
                    return false;
                }
                exp.StartDate = $.trim(exp.Duration.split('-')[0]);
                exp.EndDate = $.trim(exp.Duration.split('-')[1]);

            })
            if (!result) return false;

            $("#spinner").show();
            $.post("/Home/SavePersonalDetails", { PersonalDetail: EmployeeDetails, WorkExperience: WorkExp }, function (resp) {
                $("#spinner").hide();
                if (resp) {
                    swal("Thank you! we have received your details", { icon: "success" });
                    $("#btnResetForm").trigger("click");

                    var WorkExperience = $(".WorkExperience")
                    $.each(WorkExperience, function (i, e) {
                        if (i > 0) {
                            $(this).remove()
                        }
                    });

                } else {
                    swal("Sorry! data not saved, Please try again or contact Admin", { icon: "error" });
                }
                });
            return false;
        };

    }
}
