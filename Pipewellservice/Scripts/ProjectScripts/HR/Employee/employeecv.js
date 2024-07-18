function _Init() {

    HideSpinner();

    SetPagePermission(PAGES.EmployeeInquiry, function () {
        Post("/DataList/CountryList", {}).done(function (Response) {

            var data = []
            data.push({ id: "", text: 'Select Nationality' });
            $.each(Response, function (i, c) {
                data.push({ id: c.Nationality, text: c.Nationality, NationalityAR: c.ArabicNationality, Country: c.Name, CountryAR: c.NameArabic });
            })
            Nationalites = Response
            $("#ddEmployeeCVNationality").select2({
                tags: "true",
                placeholder: "Select Nationality",
                allowClear: true,
                data: data,
                width: "100%",

            })
            FillEmployeeCV();
        });

        txtEmployeeCVID

    });
    

}
function FillEmployeeCV() {


    var pageSize = localStorage.getItem("PageLength");
    if (pageSize == "" || pageSize == null) {
        pageSize = 10;
    }
   

    ShowSpinner();
    $('#dvPaging').pagination({
        dataSource: "/EmployeeAPI/EmployeeCVData",
        pageSize: pageSize,
        showGoInput: true,
        locator: function (response) {
            return '';
        },
        totalNumberLocator: function (response) {
            return response != null && response.length>0 ? response[0].TotalRecords:0;
        },

        showGoButton: true,
        ajax: {
            type: "POST",
            dataType: "json",
            data: {
                Name:valOf("txtEmployeeCVName"),
                EmployeeNumber: valOf("txtEmployeeCVID"),
                PassportNumber: valOf("txtEmployeeCVPassport"),
                Nationality: valOf("ddEmployeeCVNationality"),
                AramcoID: valOf("ddEmployeeCVNationality")
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

                tr.append($('<td>').html(e.EmployeeNumber));
                tr.append($('<td>').html(e.Name));
                tr.append($('<td>').html(e.Nationality));
                tr.append($('<td>').html(e.PassportNumber));
                tr.append($('<td>').html(e.AramcoID));

                tr.append($('<td>').html((e.DateOfBirth == null ? "" : moment().diff(e.DateOfBirth, "years")  +" Years")));
                tr.append($('<td>').html(e.EducationQualification));
                tr.append($('<td>').html(e.Languages));

                tr.append($('<td>').html(e.PersonalQualification));
                

                var link = $('<a class="btn btn-sm btn-success">').attr("href", "/EmployeeAPI/DownloadCV?ID=" + e.ID).append('<i class="fa fa-download"></i>');

                tr.append($('<td>').append(link));
                
                $("#tblEmployeeCV").append(tr);
            })


        }
    })
    
}