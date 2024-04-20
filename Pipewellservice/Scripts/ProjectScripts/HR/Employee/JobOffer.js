var JobOffer = {
    ID: 0,
    Name: '',
    NameArabic: '',
    CountryID: 0,
    JobTitle: '',
    Basic: 0,
    Transportation: 0,
    Period: 0,
    UserName: User.Name
};
var JobOfferList = [];

function _Init() {

    $("#dvEditJobOffer").addClass ("d-none")
    $("#dvJobOfferList").removeClass("d-none")
    SetPagePermission(PAGES.JobOffers, function () {
        Post("/DataList/CountryList", {}).done(function (Response) {

            var data = []
            data.push({ id: 0, text: 'Select Nationality' });
            $.each(Response, function (i, c) {
                data.push({ id: c.ID, text: c.Nationality });
            })
            $("#ddJobOfferCountries").select2({
                tags: "true",
                placeholder: "Select Nationality",
                allowClear: true,
                data: data,
                width: "100%"
            })
        });
        InitilzeJobOffer();
        BindOffers();
    });

}
$('form').on('reset', function (e) {
    InitilzeJobOffer();
})

function InitilzeJobOffer() {
    $(".breadcrumb-item.active").find("a").contents().unwrap();
    JobOffer = {
        
        Name: '',
        NameAr: '',
        CountryID: 0,
        JobTitle: '',
        Basic: 0,
        Transportation: 0,
        Period: 0,
        UserName: User.Name
    }
    ResetChangeLog(PAGES.JobOffers)
    
}

function NewJobOffer() {
    document.getElementById("frmJobOffer").reset();
    JobOffer.ID = 0;
    $("#dvEditJobOffer").removeClass("d-none")
    $("#dvJobOfferList").addClass("d-none")
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:CancelJobOffer()"));

}
function BindOffers() {
    Post("/Job/JobOffers", {}).done(function (resp) {
        JobOfferList = resp;
        FillOfferTable();
    })


}
function FillOfferTable() {
    var pageSize = localStorage.getItem("PageLength");
    if (pageSize == "" || pageSize == null) {
        pageSize = 10;
    }
    var FilteredData = JobOfferList;
    
    
    if (valOf("txtJobOfferNameFilter") != "")
        FilteredData = FilteredData.filter(x => x.Name != null && (x.Name.search(valOf("txtJobOfferNameFilter")) > -1));

    if (valOf("txtJobOfferArabicNameFilter") != "")
        FilteredData = FilteredData.filter(x => x.NameAr != null && x.NameAr.toUpperCase().indexOf(valOf("txtJobOfferArabicNameFilter").toUpperCase()) > -1);

    if (valOf("txtJobOfferTitleFilter") != "")
        FilteredData = FilteredData.filter(x => x.JobTitle != null && x.JobTitle.toUpperCase().indexOf(valOf("txtJobOfferTitleFilter").toUpperCase()) > -1);

    

    $('#dvPaging').pagination({
        dataSource: FilteredData,
        pageSize: pageSize,
        showGoInput: true,
        showGoButton: true,
        callback: function (data, pagination) {

            $("#tblJobOffers").empty();
            $.each(data, function (i, e) {
                var tr = $('<tr data-id=' + e.ID + '> ');

                tr.append($('<td>').html(e.ID));
                tr.append($('<td>').html(e.Name));
                tr.append($('<td>').html(e.NameAr));
                tr.append($('<td>').html(e.Nationality));

                tr.append($('<td>').html(e.JobTitle));
                tr.append($('<td>').html(e.Basic));
                tr.append($('<td>').html(e.Transportation == 0 ? "Will be provided by the Company" : e.Transportation + "% of the Basic"));
                tr.append($('<td>').html(e.Housing == 0 ? "Will be provided by the Company" : e.Housing + "% of the Basic"));
                tr.append($('<td>').html(e.Period));
                
                var link = $('<a>').attr("href", "/Job/DownloadOfferLetter?FileID=" + e.FileID).text(e.FileID);

                tr.append($('<td>').append(link));
                tr.append($('<td>').html('<a href="javascript:void(0)" class="writeble" onclick="EditJobOffer(\'' + e.ID + '\')"><i class="fa fa-edit"></i></a> <a class="deleteble" href="javascript:void(0)"onclick="DeleteJobOffer(\'' + e.id + '\',this)"><i class="fa fa-trash"></i></a>'));

                $("#tblJobOffers").append(tr);
            })


        }
    })
}


function EditJobOffer(ID) {
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:CancelJobOffer()"));
    JobOffer = JobOfferList.find(x => x.ID == ID);

    SetvalOf("txtemployeeName", JobOffer.Name);
    SetvalOf("txtemployeeNameArabic", JobOffer.NameAr);
    SetvalOf("ddJobOfferCountries", JobOffer.CountryID).trigger("change");
    SetvalOf("txtJobOfferTitle", JobOffer.JobTitle);
    SetvalOf("txtJobOfferBasic", JobOffer.Basic);
    SetvalOf("txtJobOfferTransportation", JobOffer.Transportation);
    SetvalOf("txtJobOfferHosing", JobOffer.Housing);
    SetvalOf("txtJobOfferPeriod", JobOffer.Period);
    $("#dvEditJobOffer").removeClass("d-none")
    $("#dvJobOfferList").addClass("d-none")
}
function SaveJobOffer() {
    $("#frmJobOffer").validate({
        errorClass: "text-danger",

        rules: {
            employeeName: "required",
            employeeNameArabic: "required",
            JobOfferCountries: { min: 1 },
            JobOfferTitle: "required",
            JobOfferBasic: "required",
            JobOfferTransportation: "required",
            JobOfferHosing:"required",
            JobOfferPeriod: "required"

        },
        messages: {
            employeeName: "Please enter employee name",
            employeeNameArabic: "Please enter employee name in arabic",
            JobOfferCountries: { min: "Please select nationality"},
            JobOfferTitle: "Please enter job title",
            JobOfferBasic: "Please enter basic salary",
            JobOfferTransportation: "Please enter transportation ",
            JobOfferHosing:"Please enter housing",
            JobOfferPeriod: "Please enter job period"

        },
        submitHandler: function (form) {
            

            if (JobOffer.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: valOf("txtemployeeName") } });
            } else {
                if ($.trim(JobOffer.Name) != $.trim(valOf("txtemployeeName"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: JobOffer.Name, New: valOf("txtemployeeName") } });
                }
                if ($.trim(JobOffer.NameAr) != $.trim(valOf("txtemployeeNameArabic"))) {
                    DataChangeLog.DataUpdated.push({ Field: "NameAr", Data: { OLD: JobOffer.NameAr, New: valOf("txtemployeeNameArabic") } });
                }
                if (JobOffer.CountryID != valOf("ddJobOfferCountries")) {
                    DataChangeLog.DataUpdated.push({ Field: "Nationality", Data: { OLD: JobOffer.CountryID, New: valOf("ddJobOfferCountries") } });
                }
                if ($.trim(JobOffer.JobTitle) != $.trim(valOf("txtJobOfferTitle"))) {
                    DataChangeLog.DataUpdated.push({ Field: "JobTitle", Data: { OLD: JobOffer.JobTitle, New: valOf("txtJobOfferTitle") } });
                }
                if ($.trim(JobOffer.Basic) != $.trim(valOf("txtJobOfferBasic"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Basic", Data: { OLD: JobOffer.Basic, New: valOf("txtJobOfferBasic") } });
                }

                if ($.trim(JobOffer.Transportation) != $.trim(valOf("txtJobOfferTransportation"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Transportation", Data: { OLD: JobOffer.Transportation, New: valOf("txtJobOfferTransportation") } });
                }

                if ($.trim(JobOffer.Housing) != $.trim(valOf("txtJobOfferHosing"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Housing", Data: { OLD: JobOffer.Housing, New: valOf("txtJobOfferHosing") } });
                }
                
                if ($.trim(JobOffer.Transportation) != $.trim(valOf("txtJobOfferPeriod"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Period", Data: { OLD: JobOffer.Period, New: valOf("txtJobOfferPeriod") } });
                }



            }

            Post("/Job/UpdateJobOffer", {
                job: {
                    ID: JobOffer.ID,
                    Name: valOf("txtemployeeName"),
                    NameAr: valOf("txtemployeeNameArabic"),
                    Nationality: textOf("ddJobOfferCountries"),
                    CountryID: valOf("ddJobOfferCountries"),
                    JobTitle: valOf("txtJobOfferTitle"),
                    Basic: valOf("txtJobOfferBasic"),
                    Transportation: valOf("txtJobOfferTransportation"),
                    Housing: valOf("txtJobOfferHosing"),
                    Period: valOf("txtJobOfferPeriod"),
                    UserName: User.Name

                }
            }).done(function (Response) {
                if (JobOffer.ID > 0)
                    swal({ text: "Job Offer Updated Successfully", icon: "success" });
                else
                    swal({ text: "Job Offer Added Successfully", icon: "success" });

                document.getElementById("frmJobOffer").reset();
                JobOffer.ID = 0;
                $("#dvEditJobOffer").addClass("d-none")
                $("#dvJobOfferList").removeClass("d-none")
                BindOffers();
            }).fail(function () {
                swal({ text: "Failed to Update Job Offer Record.", icon: "error" });
            });
            return false;
        }

    });
}
function CancelJobOffer() {
    document.getElementById("frmJobOffer").reset();
    JobOffer.ID = 0;
    $("#dvEditJobOffer").addClass("d-none")
    $("#dvJobOfferList").removeClass("d-none")
}