var PAGES = {
    Division: 1,
    Position: 2,
    Department: 3,
    Certificate: 4,
    Asset: 5,
    EmployeeID: 6,
    Family: 7,
    FamilyID: 8,
    Contract: 9,
    EmployeeDetail: 10,
    EmployeeWarning: 11,
    EmployeeClearance: 12,
    EmployeeVacation: 13,
    JobOffers: 14,
    JobContracts: 15,
    EmployeeInquiry: 16,
    Users: 17,
    Permissions: 18,
    Vendor: 19,
    EmployeeJoining: 20,
    ShortLeave: 21,
    LeaveRequest: 22,
    Approvals: 23,
    Accommodation: 24,
    WorkScheduleTime: 25,
    EmployeeWorkSchedule: 26,
    EmployeeAttendence: 27,
    ProcurementStoreItem: 28,
    ProcurementMaterial: 29,
    InternalPurchaseRequest: 30,
    PurchaseOrderManagement: 31,
    Sponsor: 32,
    Location: 33,
    EmployeeCVData: 34,
    SupplierAssessment: 35,
    Customers:36

}
var REPORTS = {
    EmployeeAttendenceInOut: 1,
    EmployeeAttendenceDetail: 2,
    EmployeeAttendenceSummary: 3

}
var PAGEGROUPS = {
    HR: 1,
    HRSetting: 2,
    Setting: 3,
    Procurement: 4,
    ProcurementStore: 5,
    Purchase:6
}
var User = { Name: 'demo', ID: 0 };
var DataChangeLog = {
    Form: 0,
    UserName: User.Name,
    RecordID: 0,
    DataUpdated: []
}


function SetPagePermission(Form, CallBack) {
    var Page = User.Permissions.find(x => x.PageID == Form);
    if (!Page.CanDelete) {
        $(".deleteble").remove();
        $(".deleteble" + Form).remove();
    }
    if (!Page.CanWrite) {
        $(".writeble").remove();
        $(".writeble" + Form).remove();
        $(".writecontainer").remove();
    }
    if (!Page.CanDelete && !Page.CanWrite) {
        if (!Page.CanView)
            RedirectHome();
    }
    CallBack();

}
function RedirectHome() {
    window.location = "/home"
}
function ResetChangeLog(Form) {
    DataChangeLog = {
        Form: Form,
        UserName: User.Name,
        RecordID: 0,
        DataUpdated: []
    }
}
var Sort = {
    Field: 'ID',
    Dir: 'ASC'
}
var pageSize = localStorage.getItem("PageLength");
if (pageSize == "" || pageSize == null) {
    pageSize = 10;
}
var pageNumber = 1;
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

function SetGroupPermissions(ID) {
    $.each(ID, function (i, gid) {
        var WritePermisssions = User.Permissions.filter(x => x.PageGroup == gid && x.CanWrite == true);
        var DeletePermisssions = User.Permissions.filter(x => x.PageGroup == gid && x.CanDelete == true);
        var ViewPermisssions = User.Permissions.filter(x => x.PageGroup == gid && x.CanView == true);
        if (!(WritePermisssions.length > 0 || DeletePermisssions.length > 0 || ViewPermisssions.length > 0)) {
            $('.page-group-' + gid).remove();
        }
    })

}

function SetUserGroupPermissions() {
    $(".page-admin-" + User.GroupID).removeClass("d-none");
}

function SetPagePermissions(ID) {
    $.each(ID, function (i, gid) {
        var WritePermisssions = User.Permissions.filter(x => x.PageID == gid && x.CanWrite == true);
        var DeletePermisssions = User.Permissions.filter(x => x.PageID == gid && x.CanDelete == true);
        var ViewPermisssions = User.Permissions.filter(x => x.PageID == gid && x.CanView == true);
        if (!(WritePermisssions.length > 0 || DeletePermisssions.length > 0 || ViewPermisssions.length > 0)) {
            $('.page-' + gid).remove();
        }
    })

}
function BindEmployeeLists(FillEmployeeData) {
    Post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        if (Response.length > 1) data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
        })
        $("#ddEmployeeCode").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data,
            width: "100%"
        })
        $("#ddEmployeeName").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data,
            width: "100%"
        }).on('select2:select', function (e) {
            if (FillEmployeeData) {
                BindEmployeePositionDivision();
                BindEmployeeAssets();
            }
        });

        if (data.length == 1) {
            $("#ddEmployeeCode,#ddEmployeeName").val(data[0].id);
            if (FillEmployeeData) {
                BindEmployeePositionDivision();
                BindEmployeeAssets();
            }
        }
    })
    if (FillEmployeeData) {
        Post("/SettingAPI/DivisionList", {}).done(function (Response) {
            FillList("ddEmployeeDivision", Response, "Name", "ID", "Select Division")

        });
        Post("/SettingAPI/PositionList", {}).done(function (Response) {
            FillList("ddEmployeePosition", Response, "Name", "ID", "Select Position")
        });
        Post("/SettingAPI/NationalityList", {}).done(function (Response) {
            FillList("ddEmployeeNationality", Response, "Name", "ID", "Select Nationality")
        });
    }
    if ($(".supervisor").length > 0) {
        Post("/EmployeeAPI/Supervisors", {}).done(function (Response) {
            var data = []
            data.push({ id: 0, text: 'Select Supervisor' });
            $.each(Response, function (i, emp) {
                data.push({ id: emp.DivisionID, text: emp.Name });
            })
            $(".supervisor").select2({
                placeholder: "Select Supervisor",
                data: data,
                width: "100%"
            })
        });
    }


}

function ShowSpinner() {
    $("#spinner").show()
}
function HideSpinner() {
    $("#spinner").hide()
}
function Post(Url, Input) {
    ShowSpinner();
    return $.post(Url, Input, function (response) {
        HideSpinner();
    })
        .fail(function (response) {
            HideSpinner();
        });
}
function valOf(input) {
    return $("#" + input).val();
}
function textOf(input) {
    return $("#" + input + " option:selected").text();
}
function SetvalOf(input, val) {
    return $("#" + input).val(val);
}
function SetChecked(input, val) {
    return $("#" + input).prop("checked", val);
}
function GetChecked(input) {
    return $("#" + input).prop("checked");
}
function Clear(input) {
    $("#" + input).val('')
}
function NullToString(val) {
    if (val == null) return "";
    return val.toString();
}
function AppendListItem(text, value) {
    return $('<option>', {
        value: value,
        text: text
    })
}
function CheckboxSwitch(id, checked, disabled, onclick) {
    return $('<label class="switch"><input type = "checkbox" id = "' + id + '" ' + checked + ' ' + disabled + ' ' + onclick + ' class="form-check-inline"><span class="slider round"></span></label>');
}

function DownloadFile(Url, FileName) {

    var req = new XMLHttpRequest();
    req.open("GET", Url, true);
    req.responseType = "blob";

    req.onload = function (event) {

        var blob = req.response;
        var link = document.createElement('a');
        link.href = window.URL.createObjectURL(blob);
        link.download = FileName;
        HideSpinner();
        link.click();

    };
    req.send();
}
function UploadFile(Url, file, Data, CallBack) {
    var fileData = new FormData();
    fileData.append(file.name, file);
    fileData.append("EmployeeID", Data.EmployeeID);
    fileData.append("ID", Data.ID);
    $.ajax({
        url: Url,
        type: "POST",
        contentType: false,
        processData: false,
        data: fileData,
        success: function (Response) {
            CallBack(1, Response)
        }, error: function (Response) {
            CallBack(0, Response)
        }
    });
}

function FillIDTypeList(List) {
    Post("/EmployeeAPI/EmployeeIDTypeList", {}).done(function (Response) {
        FillList(List, Response, "FileType", "FileType", "#");

    });
}
function FillRelationList(List) {
    Post("/EmployeeAPI/EmployeeRelationList", {}).done(function (Response) {
        FillList(List, Response, "Name", "Name", "#");

    });
}
function SaveLog(ID) {
    DataChangeLog.RecordID = ID
    Post("/EmployeeAPI/SaveLog", { Log: DataChangeLog }).done(function (Response) { });
}

function FillList(List, Data, Text, Value, Default) {
    $("#" + List).empty();
    if (Default != "#") {
        $("#" + List).append($('<option>', {
            text: Default,
            value: 0
        }))
    }
    $.each(Data, function (i, d) {
        $("#" + List).append($('<option>', {
            text: d[Text],
            value: d[Value]
        }))
    })
}
function FormatPhone(value) {
    if (value == null) return "";
    var cleaned = ('' + value).replace(/\D/g, '');
    if (cleaned.length > 11) {
        cleaned = cleaned.substring(0, 11);
    }
    if (!cleaned.startsWith("1") && cleaned.length > 10) {
        cleaned = cleaned.substring(0, 10);
    }
    var match = cleaned.match(/^(1|)?(\d{3})(\d{3})(\d{4})$/);
    if (match) {
        var intlCode = (match[1] ? '+1 ' : '');
        return [intlCode, '(', match[2], ') ', match[3], '-', match[4]].join('');
    }
    return value;
    return value.replace(/(\d{3})(\d{3})(\d{4})/, '($1) $2-$3');
}


function SwalConfirm(Message, Text, CallBack) {
    swal({
        html: true,
        title: Message,
        text: Text,
        icon: "warning",
        buttons: {
            catch: {
                text: "Confirm",
                value: "Confirm"
            },
            cancel: "Cancel"
        },
        dangerMode: false,
    })
        .then((value) => {
            switch (value) {
                case "Cancel":
                    break;
                case "Confirm":
                    CallBack();
                    break;
            }

        });

}
$('.daterangepicker').each(function (i, dp) {
    var dp = $(this)
    var start = $(dp).attr("start");
    var end = $(dp).attr("end");
    var startrange = $(dp).attr("startrange");
    if (start != undefined) {
        if (isNaN(start)) {
            if (startrange != undefined)
                start = moment().subtract(startrange, start).startOf(start).format("DD/MM/YYYY")
            else
                start = moment().startOf(start).format("DD/MM/YYYY")
        }
        else
            start = moment().subtract(start, 'days').format("DD/MM/YYYY")

    } else 
        moment().startOf('year')
    if (end != undefined) {
        if (isNaN(end))
            end = moment().endOf(end).format("DD/MM/YYYY")
        else
            end = moment().subtract(end, 'days').format("DD/MM/YYYY")

    } else
        end = moment().endOf('week')

    $(dp).daterangepicker({
        startDate: (start != undefined ? start : moment().startOf('year')),
        endDate: (end != undefined ? end : moment().endOf('week')),
        ranges: {
            'Current Month': [moment().startOf('month'), moment().endOf('month')],
            'Current Week': [moment().startOf('week'), moment().endOf('week')],
            'Today': [moment(), moment()],
            'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')],
            'This Year': [moment().startOf('year'), moment().endOf('year')],
            'Last Year': [moment().subtract(1, 'year').startOf('year'), moment().subtract(1, 'year').endOf('year')],
            'All Time': [moment().subtract(20, 'year').startOf('year'), moment().endOf('year')]
        }
    })
    
    $(dp).val(start + ' - ' + end);
})

function LoadBreadCrumb(Parent, Page) {
    $(".breadcrumb-item").remove();
    $("#breadcrumb").append($('<li class="breadcrumb-item home"><a href="/home">Home</a></li>'));
    if (Parent != null)
        $("#breadcrumb").append($('<li class="breadcrumb-item"><a href="' + Parent.URL + '">' + Parent.Title + '</a></li>'));
    if (Page != null && Page != "")
        $("#breadcrumb").append($('<li class="breadcrumb-item active">' + Page + '</li>'));
}

function ResetDatePicker() {
    $(".datepicker").each(function () {
        $(this).datepicker('update', $(this).val());
    });
}
function ExportToExcel(html, fileName) {
    var element = document.createElement('a');


    var template = '<html xmlns: o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><meta charset="UTF-8"><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>Report</x:Name><x:WorksheetOptions><x:DisplayGridlines="1"/></x:WorksheetOptions></x:ExcelWorksheet ></x:ExcelWorksheets ></x:ExcelWorkbook ></xml ></head> <body>' + html + '</body></html > ';



    element.setAttribute('href', 'data:application/vnd.ms-excel,' + encodeURIComponent(template));
    element.setAttribute('download', fileName);
    element.style.display = 'none';
    document.body.appendChild(element);
    element.click();
    document.body.removeChild(element);
}
