var IquiryList = [];
var ApprovalList = [];
var Inquiry = { ID: 0, Approvals: [] };
function _Init() {
    HideSpinner();
    pageNumber = 1
    SetvalOf("txtInquiryPreparedBy", User.Name);
    SetPagePermission(PAGES.EmployeeInquiry, function () {
        BindUsers();
    });
    SetvalOf("txtInquiryDate", moment().format("DD/MM/YYYY"));
}
function BindUsers() {
    $.post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        if (Response.length > 1) data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
        })

        $("#ddEmployeeName").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data,
            width: "100%"
        });
        if (data.length == 1) {
            $("#ddEmployeeName").val(data[0].id).trigger("change")
        }

        BindInquiryList();
    })




}

function BindInquiryList(PageNumber = 1) {
    pageNumber = PageNumber;
    $("#tblEmployeeInQuiryList").empty();

    var StartDate = "", EndDate = "";


    Inquiry = { ID: 0, Approvals: [] };
    ResetChangeLog(PAGES.EmployeeInquiry);

    $('#dvEmployeeInquiryPaging').pagination({
        dataSource: "/EmployeeAPI/EmployeeInquiryList",
        pageSize: pageSize,
        pageNumber: pageNumber,
        showGoInput: true,
        showGoButton: true,
        locator: function (response) {
            return 'Inquiry';
        },
        totalNumberLocator: function (response) {
            return response.TotalRecords;
        },

        ajax: {
            type: "POST",
            dataType: "json",
            data: {
                EmployeeID: valOf("ddEmployeeName"),
                StartDate: StartDate,
                EndDate: EndDate,
                PersonalInquiry: GetChecked("ChkInquiryPersonalFilter"),
                GeneralInquiry: GetChecked("ChkInquiryGeneralFilter"),
                LoanInquiry: GetChecked("ChkInquiryLoanFilter")
            },
            beforeSend: function () {
                ShowSpinner();
            }
        },
        callback: function (data, pagination) {
            HideSpinner();

            $("#tblEmployeeInQuiryList").empty();
            $.each(data, function (i, r) {
                var tr = $('<tr>')
                tr.append($('<td>').text(r.ID))
                tr.append($('<td>').append(r.Division))
                tr.append($('<td>').text(moment(r.InquiryDate).format("DD/MM/YYYY")))
                tr.append($('<td>').append(r.Remarks))

                tr.append($('<td>').append(r.Preparedby))
                tr.append($('<td>').append(CheckboxSwitch("", (r.PersonalInquiry ? "checked" : ""), "", "")))
                tr.append($('<td>').append(CheckboxSwitch("", (r.GeneralInquiry ? "checked" : ""), "", "")))
                tr.append($('<td>').append(CheckboxSwitch("", (r.LoanInquiry ? "checked" : ""), "", "")))


                $("#tblEmployeeInQuiryList").append(tr);

            });


        }
    })

}


function ResetNav() {
    document.getElementById("frmInquiry").reset();
    Inquiry = { ID: 0, Approvals: [] };
    
    
    $(".breadcrumb-item.active").find("a").contents().unwrap();
    SetvalOf("txtInquiryPreparedBy", User.Name);
    ResetDatePicker();
    SetvalOf("txtInquiryDate", moment().format("DD/MM/YYYY"));
}
function SaveEmployeeInquiry() {
    $("#frmInquiry").validate({
        errorClass: "text-danger",

        rules: {
            EmployeeName: "required",
            InquiryDate: "required",
            InquiryRemarks: "required",

        },
        messages: {
            EmployeeName: "Please select employee",
            InquiryDate: "Please enter date",
            InquiryRemarks: "Please enter remarks"
        },
        submitHandler: function (form) {
            if (Inquiry.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: textOf("ddEmployeeName") } });
            }
            NewInquiry = {
                ID: Inquiry.ID,
                EmployeeID: valOf("ddEmployeeName"),
                InquiryDate: valOf("txtInquiryDate"),
                Remarks: valOf("txtInquiryRemarks"),
                Preparedby: valOf("txtInquiryPreparedBy"),
                PersonalInquiry: GetChecked("chkInquiryPersonal"),
                GeneralInquiry: GetChecked("chkInquiryGeneral"),
                LoanInquiry: GetChecked("chkInquiryLoan"),
                UserName: User.Name,
                RecordCreatedBy: User.ID,
                Approvals: []
            };
            $.each(User.Supervisors, function (i, s) {
                NewInquiry.Approvals.push({ ID: s.ID, DivisionID: s.DivisionID });
            });

            
            var fileUpload = $('#InquiryFile').get(0);
            var files = fileUpload.files;
            
            Post("/EmployeeAPI/AddEmployeeInquiry", { Inquiry: NewInquiry }).done(function (ID) {
                if (ID > 0) {

                    Inquiry.ID = ID;
                    
                    if (files.length > 0) {

                        UploadFile("/EmployeeAPI/UpdateEmployeeInquiryFile", files[0], { EmployeeID: NewInquiry.EmployeeID, ID: ID }, function (Status, Response) {


                            if (Status == 1) {

                                if (NewInquiry.ID > 0)
                                    swal("Employee request record added", { icon: "success" })
                                else
                                    swal("Employee request updated added", { icon: "success" })
                                NewInquiry.ID = ID;
                                NewInquiry.FileID = Response.FileID;
                                NewInquiry.FileName = files[0].name;

                                ProcessInquiryMail(NewInquiry);
                                BindInquiryList()
                                ResetNav();
                            } else {

                                swal("Failed to upload request file.", { icon: "error" })
                            }
                        });
                    } else {

                        if (NewInquiry.ID > 0)
                            swal("Employee request record added", { icon: "success" })
                        else
                            swal("Employee request updated added", { icon: "success" })
                        NewInquiry.ID = ID;
                        ProcessInquiryMail(NewInquiry);
                        BindInquiryList()
                        ResetNav();
                    }
                } else {
                    swal("Failed to upload request.", { icon: "error" })
                }

            })
            return false;
        }
    });




}
function ProcessInquiryMail(Inquiry) {
    Post("/EmployeeAPI/ProcessInquiryMail", { record: Inquiry }).done(function (ID) { });
}


function NewInquiry() {
    ResetNav();
    
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
}
