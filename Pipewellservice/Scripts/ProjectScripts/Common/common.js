var PAGES = {
    Division: 1,
    Position: 2,
    Department: 3,
    Certificate: 4,
    Asset: 5,
    EmployeeID: 6,
    Family: 7,
    FamilyID: 8,
    Contract:9
}
var DataChangeLog = {
    Form: 0,
    UserName: User.Name,
    RecordID: 0,
    DataUpdated: []
}
function ResetChangeLog(Form) {
    DataChangeLog = {
        Form: Form,
        UserName: User.Name,
        RecordID: 0,
        DataUpdated: []
    }
}

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

function ShowSpinner() {
    $("#spinner").show()
}
function HideSpinner() {
    $("#spinner").hide()
}
function Post(Url, Input) {
    ShowSpinner();
  return  $.post(Url, Input, function (response) {
        HideSpinner();
    })
    .fail(function (response) {
            HideSpinner();
   });
}
function valOf(input) {
    return $("#" + input).val();
}
function SetvalOf(input,val) {
    return $("#" + input).val(val);
}
function SetChecked(input, val) {
    return $("#" + input).prop("checked",val);
}
function GetChecked(input) {
    return $("#" + input).prop("checked");
}
function Clear(input) {
    $("#" + input).val('')
}
function AppendListItem(text,value) {
    return $('<option>', {
        value: value,
        text: text
    })
}
function CheckboxSwitch(id, checked, disabled, onclick) {
    return $('<label class="switch"><input type = "checkbox" id = "' + id + '" ' + checked + ' ' + disabled + ' ' + onclick + ' class="form-check-inline"><span class="slider round"></span></label>');
}

function DownloadFile(Url,FileName) {

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

function FillIDTypeList(List) {
    Post("/EmployeeAPI/EmployeeIDTypeList", {}).done(function (Response) {
        FillList(List, Response, "FileType", "FileType","#");

    });
}
function FillRelationList(List) {
    Post("/EmployeeAPI/EmployeeRelationList", {}).done(function (Response) {
        FillList(List, Response, "Name", "Name", "#");

    });
}
function SaveLog(ID) {
    DataChangeLog.RecordID=ID
    Post("/EmployeeAPI/SaveLog", { Log: DataChangeLog }).done(function (Response) { });
}

function FillList(List, Data, Text, Value,Default) {
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
            value:d[Value]
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


function SwalConfirm(Message, CallBack) {
    swal({
        html: true,
        title: Message,
        text: "",
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