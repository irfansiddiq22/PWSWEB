var JobContract = {
    ID: 0,
    Name: '',
    NameArabic: '',
    CountryID: 0,
    IDNumber: '',
    EmailAddress: '',
    MobileNumber:'',
    JobTitle: '',
    Basic: 0,
    Transportation: 0,
    Period: 0,
    UserName: User.Name
};
var JobContractList = [];

function _Init() {

    $("#dvEditJobContract").addClass("d-none")
    $("#dvJobContractList").removeClass("d-none")

    Post("/DataList/CountryList", {}).done(function (Response) {

        var data = []
        data.push({ id: 0, text: 'Select Nationality' });
        $.each(Response, function (i, c) {
            data.push({ id: c.ID, text: c.Nationality });
        })
        $("#ddJobContractCountries").select2({
            tags: "true",
            placeholder: "Select Nationality",
            allowClear: true,
            data: data,
            width: "100%"
        })
    });
    InitilzeJobContract();
    BindContracts();
}
$('form').on('reset', function (e) {
    InitilzeJobContract();
})

function InitilzeJobContract() {
    $(".breadcrumb-item.active").find("a").contents().unwrap();
    JobContract = {

        Name: '',
        NameArabic: '',
        CountryID: 0,
        JobTitle: '',
        IDNumber: '',
        EmailAddress: '',
        MobileNumber: '',
        Basic: 0,
        Transportation: 0,
        Period: 0,
        UserName: User.Name
    }
    ResetChangeLog(PAGES.JobContracts)

}

function NewJobContract() {
    document.getElementById("frmJobContract").reset();
    JobContract.ID = 0;
    $("#dvEditJobContract").removeClass("d-none")
    $("#dvJobContractList").addClass("d-none")
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:CancelJobContract()"));

}
function BindContracts() {
    Post("/Job/JobContracts", {}).done(function (resp) {
        JobContractList = resp;
        FillContactTable();
    })


}
function FillContactTable() {
    var pageSize = localStorage.getItem("PageLength");
    if (pageSize == "" || pageSize == null) {
        pageSize = 10;
    }
    var FilteredData = JobContractList;


    if (valOf("txtJobContractNameFilter") != "")
        FilteredData = FilteredData.filter(x => x.Name != null && (x.Name.search(valOf("txtJobContractNameFilter")) > -1));

    if (valOf("txtJobContractArabicNameFilter") != "")
        FilteredData = FilteredData.filter(x => x.ArabicName != null && x.ArabicName.toUpperCase().indexOf(valOf("txtJobContractArabicNameFilter").toUpperCase()) > -1);

    if (valOf("txtJobContractTitleFilter") != "")
        FilteredData = FilteredData.filter(x => x.JobTitle != null && x.JobTitle.toUpperCase().indexOf(valOf("txtJobContractTitleFilter").toUpperCase()) > -1);



    $('#dvPaging').pagination({
        dataSource: FilteredData,
        pageSize: pageSize,
        showGoInput: true,
        showGoButton: true,
        callback: function (data, pagination) {

            $("#tblJobContracts").empty();
            $.each(data, function (i, e) {
                var tr = $('<tr data-id=' + e.ID + '> ');

                tr.append($('<td>').html(e.ID));
                tr.append($('<td>').html(e.Name));
                tr.append($('<td>').html(e.ArabicName));
                tr.append($('<td>').html(e.Nationality));
                tr.append($('<td>').html(e.JobTitle));
                tr.append($('<td>').html(e.IDNumber));

                tr.append($('<td>').html(e.EmailAddress));
                tr.append($('<td>').html(e.MobileNumber));

                
                tr.append($('<td>').html(e.Basic));
                tr.append($('<td>').html(e.Transportation));
                tr.append($('<td>').html(e.Period));

                tr.append($('<td>'));
                tr.append($('<td>').html('<a href="javascript:void(0)" onclick="EditJobContract(\'' + e.ID + '\')"><i class="fa fa-edit"></i></a> <a href="javascript:void(0)"onclick="DeleteJobContract(\'' + e.id + '\',this)"><i class="fa fa-trash"></i></a>'));

                $("#tblJobContracts").append(tr);
            })


        }
    })
}


function EditJobContract(ID) {
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:CancelJobContract()"));
    JobContract = JobContractList.find(x => x.ID == ID);

    SetvalOf("txtemployeeName", JobContract.Name);
    SetvalOf("txtemployeeNameArabic", JobContract.ArabicName);
    SetvalOf("ddJobContractCountries", JobContract.CountryID).trigger("change");

    SetvalOf("txtemployeeID", JobContract.IDNumber);
    SetvalOf("txtEmployeeEmailAddress", JobContract.EmailAddress);
    SetvalOf("txtEmployeeMobileNumber", JobContract.MobileNumber);

    SetvalOf("txtJobContractTitle", JobContract.JobTitle);
    SetvalOf("txtJobContractBasic", JobContract.Basic);
    SetvalOf("txtJobContractTransportation", JobContract.Transportation);
    SetvalOf("txtJobContractPeriod", JobContract.Period);
    $("#dvEditJobContract").removeClass("d-none")
    $("#dvJobContractList").addClass("d-none")
}
function SaveJobContract() {
    $("#frmJobContract").validate({
        errorClass: "text-danger",

        rules: {
            employeeName: "required",
            employeeNameArabic: "required",
            JobContractCountries: { min: 1 },
            employeeID: "required",
            EmployeeEmailAddress: "required",
            EmployeeMobileNumber: "required",

            JobContractTitle: "required",
            JobContractBasic: "required",
            JobContractTransportation: "required",
            JobContractPeriod: "required"

        },
        messages: {
            employeeName: "Please enter employee name",
            employeeNameArabic: "Please enter employee name in arabic",
            JobContractCountries: { min: "Please select nationality" },
            employeeID: "Please enter ID number",
            EmployeeEmailAddress: "Please enter email address",
            EmployeeMobileNumber: "Please enter mobile number",
            JobContractTitle: "Please enter job title",
            JobContractBasic: "Please enter basic salary",
            JobContractTransportation: "please enter transportation ",
            JobContractPeriod: "Please enter job period"

        },
        submitHandler: function (form) {


            if (JobContract.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: valOf("txtemployeeName") } });
            } else {
                if ($.trim(JobContract.Name) != $.trim(valOf("txtemployeeName"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: JobContract.Name, New: valOf("txtemployeeName") } });
                }
                if ($.trim(JobContract.ArabicName) != $.trim(valOf("txtemployeeNameArabic"))) {
                    DataChangeLog.DataUpdated.push({ Field: "ArabicName", Data: { OLD: JobContract.ArabicName, New: valOf("txtemployeeNameArabic") } });
                }
                if (JobContract.CountryID != valOf("ddJobContractCountries")) {
                    DataChangeLog.DataUpdated.push({ Field: "Nationality", Data: { OLD: JobContract.CountryID, New: valOf("ddJobContractCountries") } });
                }
                if ($.trim(JobContract.JobTitle) != $.trim(valOf("txtJobContractTitle"))) {
                    DataChangeLog.DataUpdated.push({ Field: "JobTitle", Data: { OLD: JobContract.JobTitle, New: valOf("txtJobContractTitle") } });
                }

                if ($.trim(JobContract.IDNumber) != $.trim(valOf("txtemployeeID"))) {
                    DataChangeLog.DataUpdated.push({ Field: "IDNumber", Data: { OLD: JobContract.IDNumber, New: valOf("txtemployeeID") } });
                }
                if ($.trim(JobContract.EmailAddress) != $.trim(valOf("txtEmployeeEmailAddress"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Email Address", Data: { OLD: JobContract.EmailAddress, New: valOf("txtEmployeeEmailAddress") } });
                }
                if ($.trim(JobContract.MobileNumber) != $.trim(valOf("txtEmployeeMobileNumber"))) {
                    DataChangeLog.DataUpdated.push({ Field: "MobileNumber", Data: { OLD: JobContract.MobileNumber, New: valOf("txtEmployeeMobileNumber") } });
                }


                if ($.trim(JobContract.Basic) != $.trim(valOf("txtJobContractBasic"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Basic", Data: { OLD: JobContract.Basic, New: valOf("txtJobContractBasic") } });
                }

                if ($.trim(JobContract.Transportation) != $.trim(valOf("txtJobContractTransportation"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Transportation", Data: { OLD: JobContract.Transportation, New: valOf("txtJobContractTransportation") } });
                }

                if ($.trim(JobContract.Transportation) != $.trim(valOf("txtJobContractPeriod"))) {
                    DataChangeLog.DataUpdated.push({ Field: "Period", Data: { OLD: JobContract.Period, New: valOf("txtJobContractPeriod") } });
                }



            }

            Post("/Job/UpdateJobContract", {
                job: {
                    ID: JobContract.ID,
                    Name: valOf("txtemployeeName"),
                    ArabicName: valOf("txtemployeeNameArabic"),
                    CountryID: valOf("ddJobContractCountries"),
                    JobTitle: valOf("txtJobContractTitle"),

                    IDNumber: valOf("txtemployeeID"),
                    EmailAddress: valOf("txtEmployeeEmailAddress"),
                    MobileNumber: valOf("txtEmployeeMobileNumber"),

                    Basic: valOf("txtJobContractBasic"),
                    Transportation: valOf("txtJobContractTransportation"),
                    Period: valOf("txtJobContractPeriod"),
                    UserName: User.Name

                }
            }).done(function (Response) {
                if (JobContract.ID > 0)
                    swal({ text: "Job Contract Updated Successfully", icon: "success" });
                else
                    swal({ text: "Job Contract Added Successfully", icon: "success" });

                document.getElementById("frmJobContract").reset();
                JobContract.ID = 0;
                $("#dvEditJobContract").addClass("d-none")
                $("#dvJobContractList").removeClass("d-none")
                BindContracts();

            }).fail(function () {
                swal({ text: "Failed to Update Job Contract Record.", icon: "error" });
            });
            return false;
        }

    });
}
function CancelJobContract() {
    document.getElementById("frmJobContract").reset();
    JobContract.ID = 0;
    $("#dvEditJobContract").addClass("d-none")
    $("#dvJobContractList").removeClass("d-none")
}