$(function () {

    $.validator.setDefaults({
        highlight: function (element) {
            if ($(element).closest('.form-group').length)
                $(element).closest('.form-group').addClass('has-error');
            else
                $(element).addClass('has-error');

        },
        unhighlight: function (element) {
            if ($(element).closest('.form-group').length)
                $(element).closest('.form-group').removeClass('has-error');
            else
                $(element).removeClass('has-error');

        },
        errorElement: 'div',
        errorClass: 'text-danger text-start',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        }
    });
    $(".datepicker").datepicker({
        autoclose: true,
        todayHighlight: false,
        format: 'dd/mm/yyyy'
    })
    $("#dateBusinessCommenced").val(moment().format("DD/MM/YYYY"))
    $("#spinner").hide();
    
    
    $("#frmCustomerRegistration").validate()

    $.each($("input[data-msg]"), function (i, c) {
        $(this).attr("name", $(this).attr("id"));

        $(this).rules("add", {
            required: true,
            messages: {
                required: $(this).attr("msg")

            }

        });
    });

})

function SaveRegistration() {
    if ($("#frmCustomerRegistration").valid()) {
        var registration = {};
        $.each($("input[data-id]"), function (i, c) {
            
                registration[$(this).attr("data-id")] = $(this).val();
        })

        
        
        $("#spinner").show();
        $.post("/Customer/SaveRegistration", { dto: registration }, function (resp) {
            $("#spinner").hide();
            if (resp > 0) {
                swal("Thank you for submitting data for registration", { icon: "success" });
                var fileData = new FormData();
                fileData.append("ID",resp);

                var fileUpload = $('#flCRFile').get(0);
                var files = fileUpload.files;

                if (files.length > 0)
                    fileData.append("CRFile", files[0]);

                fileUpload = $('#flZakatFile').get(0);
                files = fileUpload.files;
                if (files.length > 0)
                    fileData.append("ZakatFile", files[0]);


                fileUpload = $('#flVATFile').get(0);
                files = fileUpload.files;
                if (files.length > 0)
                    fileData.append("VATFile", files[0]);

                
                $("#spinner").show();
                $.ajax({
                    url: '/Customer/UploadRegistrationFiles',
                    type: "POST",
                    contentType: false,
                    processData: false,
                    data: fileData,
                    success: function (Response) {
                        $("#spinner").hide();

                    },
                    error: function (errormessage) {
                        $("#spinner").hide();
                        swal({ text: "Failed to upload data file, please try again.", icon: "error" });
                    }
                });


                
                document.getElementById("frmCustomerRegistration").reset();
            } else {
                swal("Sorry! Failed to submit data for registration", { icon: "danger" });
                return false;
            }
        })

    }
}

