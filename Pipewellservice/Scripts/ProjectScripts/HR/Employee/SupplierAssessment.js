function _Init() {

    HideSpinner();

    SetPagePermission(PAGES.SupplierAssessment, function () {
        FillSupplierData()
        

    });


}
function FillSupplierData() {


    var pageSize = localStorage.getItem("PageLength");
    if (pageSize == "" || pageSize == null) {
        pageSize = 10;
    }


    ShowSpinner();
    $('#dvPaging').pagination({
        dataSource: "/EmployeeAPI/SupplierAssessment",
        pageSize: pageSize,
        showGoInput: true,
        locator: function (response) {
            return '';
        },
        totalNumberLocator: function (response) {
            return response != null && response.length > 0 ? response[0].TotalRecords : 0;
        },

        showGoButton: true,
        ajax: {
            type: "POST",
            dataType: "json",
            data: {
                Name: valOf("txtCompanyName"),
                City: valOf("txtCityName"),
                Country: valOf("txtCountryName")
            },
            beforeSend: function () {
                ShowSpinner();
            }
        },
        callback: function (data, pagination) {
            HideSpinner();
            $("#tblEmployeeCV").empty();
            $.each(data, function (i, e) {
                var tr = $('<tr data-id=' + e.ID + '> ');
                tr.append($('<td>').html(e.ID));
                tr.append($('<td>').html(e.CompanyName));
                tr.append($('<td>').html(e.City));
                tr.append($('<td>').html(e.Country));


                var link = $('<a class="btn btn-sm btn-success">').attr("target","_blank").attr("href", "/Employee/PrintSupplierAssessmentReport?ID=" + e.ID).append('<i class="fa fa-download"></i>');

                tr.append($('<td>').append(link));

                $("#tblSupplierAssessmentData").append(tr);
            })


        }
    })

}