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
    $("#RecordDate").val(moment().format("DD/MM/YYYY"))
    $("#spinner").hide();
    $("#initialAssessment,#local,#individualCompany,#iso9001No,#apiSpecQ1No,#apiSpecQ2No,#nonCritical").prop("checked", true);
    $("#directEmployees,#IndirectEmployees,#TechnicalEmployees,#OtherEmployees").val(0)
    $("#frmSupplierAssessment").validate()

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
function AddItems() {
    var tb = $("#tblItemsServices")
    var SR = $(tb).find("tr").length + 1;
    $(tb).append(`<tr><td>${SR}</td><td><input type="text" class="form-control form-control-sm"></td></tr>`)
}
function AddNewOption(tblName) {
    var tb = $("#" + tblName)
    var SR = $(tb).find("tr").length + 1;
    $(tb).append(`<tr><td>${SR}</td><td><input type="text" class="form-control form-control-sm"></td><td><input type="text" class="form-control form-control-sm"></td><td><input type="${tblName == "tblCustomers" ? "text" : "number"}" class="form-control form-control-sm"></td></tr>`)
}
function SaveAssesment() {
    if ($("#frmSupplierAssessment").valid()) {
        var assessment = {};
        $.each($("input[data-id],select[data-id],:checkbox[data-id],:radio[data-id],textarea[data-id]"), function (i, c) {
            if ($(this).is(':checkbox') || $(this).is(':radio'))
                assessment[$(this).attr("data-id")] = $(this).prop("checked");
            else
                assessment[$(this).attr("data-id")] = $(this).val();
        })

        


        var SupplierItems = Array.from(document.getElementById('tblItemsServices').rows).map(row => ({
            ItemServiceName: $(row.cells[1]).find(":input").val(),
        }));

        var SupplierCustomers = Array.from(document.getElementById('tblCustomers').rows).map(row => ({
            CustomerName: $(row.cells[1]).find(":input").val(),
            ItemServiceName: $(row.cells[2]).find(":input").val(),
            TurnOver: $(row.cells[3]).find(":input").val()
        }));
        var SupplierProductionFacilities = Array.from(document.getElementById('tblProductions').rows).map(row => ({
            MachineName: $(row.cells[1]).find(":input").val(),
            Model: $(row.cells[2]).find(":input").val(),
            NoOfMachines: $(row.cells[3]).find(":input").val()
        }));

        var SupplierQualityControlFacilities = Array.from(document.getElementById('tblEquipments').rows).map(row => ({
            EquipmentDescription: $(row.cells[1]).find(":input").val(),
            Range: $(row.cells[2]).find(":input").val(),
            Quantity: $(row.cells[3]).find(":input").val()
        }));

        assessment.SupplierItems = SupplierItems;
        assessment.SupplierCustomers = SupplierCustomers;
        assessment.SupplierProductionFacilities = SupplierProductionFacilities;
        assessment.SupplierQualityControlFacilities = SupplierQualityControlFacilities;
        
        $("#spinner").show();
        $.post("/Home/SaveSupplierAssesment", { assesment: assessment }, function (resp) {
            $("#spinner").hide();
            if (resp > 0) {
                swal("Thank you for submitting data for assessment", { icon: "success" });
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


                fileUpload = $('#flChamberMemberShipFile').get(0);
                files = fileUpload.files;
                if (files.length > 0)
                    fileData.append("ChamberMemberShipFile", files[0]);

                fileUpload = $('#flQRFile').get(0);
                files = fileUpload.files;
                if (files.length > 0)
                    fileData.append("QualityManagementCertificateFile", files[0]);


                fileUpload = $('#flCustomerFile').get(0);
                files = fileUpload.files;
                if (files.length > 0)
                    fileData.append("MajorCustomerFile", files[0]);

                fileUpload = $('#flProductionFile').get(0);
                files = fileUpload.files;
                if (files.length > 0)
                    fileData.append("ProductionFile", files[0]);

                fileUpload = $('#flEquippmentFile').get(0);
                files = fileUpload.files;
                if (files.length > 0)
                    fileData.append("QualityControlFile", files[0]);

                fileUpload = $('#flNationAddressFile').get(0);
                files = fileUpload.files;
                if (files.length > 0)
                    fileData.append("NationalAddressFile", files[0]);

                
                $("#spinner").show();
                $.ajax({
                    url: '/Home/UploadSupplierAssessmentFiles',
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


                
                document.getElementById("frmSupplierAssessment").reset();
            } else {
                swal("Sorry! Failed to submit data for assessment", { icon: "danger" });
                return false;
            }
        })

    }
}
var FileType = '';
function UploadDataFile(_FileType) {
    $("#dlgSupplierFile").modal("show");
    $("#tblFileFields").empty();
    FileType = _FileType;
}
var FileData = [];
function UploadSupplierFile() {
    var fileUpload = $('#flSupplierFile').get(0);
    var files = fileUpload.files;
    if ($("#flSupplierFile").val() == "" || files.length == 0) {
        swal("Please choose data file.", { icon: "error" });
        return false;
    }
    var ext = $('#flSupplierFile').val().split('.').pop().toLowerCase();
    if ($.inArray(ext, ['csv', 'xls', 'xlsx']) == -1) {
        alert('Choose CSV,XlS,XLSX file type only', { icon: "error" });
        return false;
    }
    $("#spinner").show();

    var fileData = new FormData();


    if (files.length > 0)
        fileData.append(files[0].name, files[0]);

    $.ajax({
        url: '/Home/UploadSupplierDataFile',
        type: "POST",
        contentType: false,
        processData: false,
        data: fileData,
        success: function (Response) {
            $("#spinner").hide();

            if (!Response.Result) {
                swal({ text: "Failed to upload data file, please try again.", icon: "error" });
                return false;
            }
            FileData = Response.Data;
            var select = $('<select class="form-select form-select-sm"  id="col1">');
            var select2 = $('<select class="form-select form-select-sm"  id="col2">');
            var select3 = $('<select class="form-select form-select-sm"  id="col3">');
            $.each(FileData[0].Data, function (i, d) {
                $(select).append($('<option>', {
                    value: i,
                    text: d
                }));
                $(select2).append($('<option>', {
                    value: i,
                    text: d
                }));
                $(select3).append($('<option>', {
                    value: i,
                    text: d
                }));
            })

            if (FileType == 'items') {
                var tr = $('<tr>')
                tr.append("<td>Items/Services</td>");
                tr.append($("<td>").append($(select)));
                $("#tblFileFields").append(tr);
            }
            else if (FileType == 'customers') {
                var tr = $('<tr>')
                tr.append("<td>Customer Name</td>");

                tr.append($("<td>").append($(select)));
                $("#tblFileFields").append(tr);
                tr = $('<tr>')
                tr.append("<td>Items/Services</td>");
                tr.append($("<td>").append($(select2)));
                $("#tblFileFields").append(tr);
                tr = $('<tr>')

                tr.append("<td>Approx. Turnover</td>");
                tr.append($("<td>").append($(select3)));
                $("#tblFileFields").append(tr);
            }
            else if (FileType == 'production') {
                var tr = $('<tr>')
                tr.append("<td>Machine/Facility Name & Specification</td>");
                tr.append($("<td>").append($(select)));
                $("#tblFileFields").append(tr);
                tr = $('<tr>')
                tr.append("<td>Make & Model</td>");
                tr.append($("<td>").append($(select2)));
                $("#tblFileFields").append(tr);
                tr = $('<tr>')

                tr.append("<td>No. of machines</td>");
                tr.append($("<td>").append($(select3)));
                $("#tblFileFields").append(tr);
            }
            else if (FileType == 'equipments') {
                var tr = $('<tr>')
                tr.append("<td>Equipment Description</td>");
                tr.append($("<td>").append($(select)));
                $("#tblFileFields").append(tr);
                tr = $('<tr>')
                tr.append("<td>Range</td>");
                tr.append($("<td>").append($(select2)));
                $("#tblFileFields").append(tr);
                tr = $('<tr>')

                tr.append("<td>Quantity</td>");
                tr.append($("<td>").append($(select3)));
                $("#tblFileFields").append(tr);
            }

        }, error: function (errormessage) {
            $("#spinner").hide();
            swal({ text: "Failed to upload data file, please try again.", icon: "error" });
        }
    });

}
function ShowFileData() {
    if (FileType == 'items') {
        var tb = $("#tblItemsServices")
        $(tb).empty();
        $.each(FileData, function (i, d) {
            if (i > 0) {
                var SR = $(tb).find("tr").length + 1;
                $(tb).append(`<tr><td>${SR}</td><td><input type="text" class="form-control form-control-sm" value=${d.Data[$("#col1").val()]}></td></tr>`)

            }
        });
    } else {
        var tb = $("#tblItemsServices")
        if (FileType == 'customers')
              tb = $("#tblCustomers")
        else if (FileType == 'production')
            tb = $("#tblProductions")
        else if (FileType == 'equipments')
            tb = $("#tblEquipments")

        $(tb).empty();
        $.each(FileData, function (i, d) {
            if (i > 0) {
                var SR = $(tb).find("tr").length + 1;
                $(tb).append(`<tr><td>${SR}</td><td><input type="text" class="form-control form-control-sm" value=${d.Data[$("#col1").val()]}></td><td><input type="text" class="form-control form-control-sm" value=${d.Data[$("#col2").val()]}></td><td><input type="text" class="form-control form-control-sm" value=${d.Data[$("#col3").val()]}></td></tr>`)

            }
        });
    }
}