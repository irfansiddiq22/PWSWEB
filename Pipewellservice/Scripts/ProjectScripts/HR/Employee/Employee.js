var EmployeeList = [];
var Employee = {}
function _Init() {

    HideSpinner();
    BindUsers();
    FillEmployeeDataList()
    FillEmployee();
    var rules = [];
    /* $.each($("input[data-msg],select[data-msg]"), function (i, c) {
         
         $(this).rules("add", {
             required: true,
             messages: {
                 required: $(this).attr("msg")
             }
 
         });
 
     });
     */
    $("#frmEmployeeData").validate()

    $.each($("select[data-msg]"), function (i, c) {
        $(this).attr("name", $(this).attr("id"));

        $(this).rules("add", {
            required: true,
            messages: {
                required: $(this).attr("msg")

            }

        });

    });
    $.each($("select[data-msg]"), function (i, c) {
        $(this).attr("name", $(this).attr("id"));
        if (!$(this).attr("data-min")) {
            $(this).rules("add", {
                required: true,
                min: 1,
                messages: {
                    required: $(this).attr("msg"),
                    min: $(this).attr("msg")
                }

            });
        } else {
            $(this).rules("add", {
                required: true,
                messages: {
                    required: $(this).attr("msg"),
                }

            });
        }


    });
}
$(".keyupfilter").keyup(function () {
    /// FillEmployeeTable();
})
function FillEmployeeDataList() {
    Post("/EmployeeAPI/EmployeeDataList", {}).done(function (Response) {
        var Departments = Response.departments;
        var Positions = Response.positions;
        var Sponsors = Response.sponsors;
        var Worktime = Response.worktime;

        FillList("ddEmployeeDivision", Departments, "Name", "ID", "Select Division")
        FillList("ddEmployeePosition", Positions, "Name", "ID", "Select Posstion")
        FillList("ddEmployeeSponsor", Sponsors, "Name", "ID", "Select Sponsor")
        FillList("ddEmployeeWorkInOutTime", Worktime, "Time", "ID", "")
    });
}
function BindUsers() {
    Post("/EmployeeAPI/CodeName", {}).done(function (Response) {



        var data = [];
        data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.Code + " - " + emp.Name });
        })
        $("#ddIDFileEmployeeCode").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data
        }).on('select2:select', function (e) {
            var data = e.params.data;
            FillIDFiles(parseInt(data.id));
        });
    })
    //FillIDTypeList("datalistOptions")

}
function CancelEdit() {
    $("#dvEditEmplyee").addClass("d-none")
    $("#dvEmployeeList").removeClass("d-none")
    $(".breadcrumb-item.active").find("a").contents().unwrap();

}
function FillEmployee() {


    $("#tblEmployeeList").empty();
    Employee = {};
    ShowSpinner();
    Post("/EmployeeAPI/EmployeeList", {}).done(function (Response) {
        EmployeeList = Response;

        //var Nationality = [];
        var Nationality = Response.reduce(function (memo, e1) {
            var matches = memo.filter(function (e2) {
                return e1.Nationality == e2.Nationality
            })
            if (matches.length == 0)
                memo.push({ "Nationality": e1.Nationality })
            return memo;
        }, [])
        var Supervisor = Response.filter(x => x.Position == "HSE Officer").reduce(function (memo, e1) {
            var matches = memo.filter(function (e2) {
                return e1.Name == e2.Name
            })
            if (matches.length == 0)
                memo.push({ "Name": e1.Name, ID: e1.ID })
            return memo;
        }, [])
        FillList("ddEmployeeSupervisor", Supervisor, "Name", "ID")


        FillList("ddEmployeeNationality", Nationality, "Nationality", "Nationality", "#")

        FillEmployeeTable();

        $("#dvEditEmplyee").addClass("d-none")
        $("#dvEmployeeList").removeClass("d-none")
        HideSpinner();
    });


}
function FillEmployeeTable() {
    var pageSize = localStorage.getItem("PageLength");
    if (pageSize == "" || pageSize == null) {
        pageSize = 10;
    }
    var FilteredData = EmployeeList;
    if (valOf("txtEmployeeIDFilter") != "")
        FilteredData = FilteredData.filter(x => x.ID == valOf("txtEmployeeIDFilter"));

    if (valOf("txtEmployeeIqamaFilter") != "")
        FilteredData = FilteredData.filter(x => x.Iqama != null && (x.Iqama.search(valOf("txtEmployeeIqamaFilter")) > -1));

    if (valOf("txtEmployeeNameFilter") != "")
        FilteredData = FilteredData.filter(x => x.Name != null && x.Name.toUpperCase().indexOf(valOf("txtEmployeeNameFilter").toUpperCase()) > -1);

    if (valOf("txtEmployeeArabicNameFilter") != "")
        FilteredData = FilteredData.filter(x => x.ArabicName != null && x.ArabicName.toUpperCase().indexOf(valOf("txtEmployeeArabicNameFilter").toUpperCase()) > -1);

    if (GetChecked("chkEmployeeOnJobEmployee")) {
        FilteredData = FilteredData.filter(x => x.JobStatus == 1);
    }

    $('#dvEmployeePaging').pagination({
        dataSource: FilteredData,
        pageSize: pageSize,
        showGoInput: true,
        showGoButton: true,
        callback: function (data, pagination) {

            $("#tblEmployeeList").empty();
            $.each(data, function (i, e) {
                var tr = $('<tr data-id=' + e.ID + '> ');

                tr.append($('<td>').html(e.ID));
                tr.append($('<td>').html(e.Name));
                tr.append($('<td>').html(e.ArabicName));
                tr.append($('<td>').html(e.Nationality));
                tr.append($('<td class="iqamadata">').html(e.Iqama))
                tr.append($('<td class="iqamadata">').html(e.IqamaExpiryDate == null ? "" : moment(e.IqamaExpiryDate).format("MM/DD/YYYY")))

                tr.append($('<td class="iqamadata">').html(e.Passport));
                tr.append($('<td class="iqamadata">').html(e.PassportExpiryDate == null ? "" : moment(e.PassportExpiryDate).format("MM/DD/YYYY")))

                tr.append($('<td>').html(e.PhoneNumber));
                tr.append($('<td>').html(e.DataOfBirth == null ? "" : moment().diff(e.DataOfBirth, "years")));
                tr.append($('<td>').html(e.SponsorCompany));
                tr.append($('<td>').html(e.Division));
                tr.append($('<td>').html(e.Position));

                tr.append($('<td>').html(e.Supervisor));


                tr.append($('<td>').html(e.HiringDate == null ? "" : moment(e.HiringDate).format("MM/DD/YYYY")));
                tr.append($('<td class="jobstatus">').html(e.CurrentJobStatus));
                tr.append($('<td class="jobstatus">').html(e.JobLeftDate == null ? "" : moment(e.JobLeftDate).format("MM/DD/YYYY")));
                /*tr.append($('<td>').html(e.JobLeftDate == null ? "" : moment(e.JobLeftDate).format("MM/DD/YYYY")));
                
                tr.append($('<td>').html(e.ShowInAttendence));
                tr.append($('<td>').html(e.DeductSalary));*/

                tr.append($('<td>').html('<a href="javascript:void(0)" onclick="EditEmployee(\'' + e.ID + '\')"><i class="fa fa-edit"></i></a> <a href="javascript:void(0)"onclick="DeleteEmployee(\'' + e.id + '\',this)"><i class="fa fa-trash"></i></a>'));

                $("#tblEmployeeList").append(tr);//'<a class="fc-event fc-daygrid-event fc-daygrid-dot-event fc-event fc-event-draggable fc-event-resizable fc-event-start fc-event-end fc-event-future fc-event-upcoming p-1" style="color:#FFF!important;" data-id=\'' + e.PostIDEnc + '\'>' + e.title + ' ' + new moment(e.start).format("MM/DD/YY") + '</a>')
            })

            if (GetChecked("chkEmployeeIqamainfo"))
                $(".iqamadata").show()
            else
                $(".iqamadata").hide()

            if (GetChecked("chkEmployeeOnJobEmployee"))
                $(".jobstatus").show()
            else
                $(".jobstatus").hide()

        }
    })
}
function ToggleIqamaData() {

    if (GetChecked("chkEmployeeIqamainfo"))
        $(".iqamadata").show()
    else
        $(".iqamadata").hide()
}

function ShowJobLeft() {
    if (valOf("ddEmployeeStatus") == 2)
        $(".jobleftdate").show();
    else
        $(".jobleftdate").hide();
}
function EditEmployee(ID) {

    Post("/EmployeeAPI/EmployeeDetail", { EmployeeID: ID }).done(function (Response) {
        Employee = Response[0];
        ResetChangeLog(PAGES.EmployeeDetail);

        $.each($("input[data-id],select[data-id]"), function (i, c) {
            if ($(this).attr("data-type") == "date")
                $(this).val(Employee[$(this).attr("data-id")] == null ? "" : moment(Employee[$(this).attr("data-id")]).format("MM/DD/YYYY"));
            else
                $(this).val(Employee[$(this).attr("data-id")]);
        })
        $("#imgEmployeePicture").attr("src", "/EmployeeAPI/EmployeePicture?FileID=" + Employee.FileID + "&FileName=" + Employee.FileName)
        $("#ddEmployeeHiringSource").trigger("change")
        $("#ddEmployeeStatus").trigger("change")
        $("#ddEmployeeNationality").trigger("change")
        $("#nav-detail-tab").trigger("click")
        $("#dvEditEmplyee").removeClass("d-none")
        $("#dvEmployeeList").addClass("d-none")
        $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:CancelEdit()"));

    });
}

function UpdateEmployee() {
    if ($("#frmEmployeeData").valid()) {

        var employeeToUpdate = {};
        $.each($("input[data-id],select[data-id]"), function (i, c) {
            employeeToUpdate[$(this).attr("data-id")] = $(this).val();
        })

        $.each($("input[data-id]"), function (i, c) {
            if ($(this).attr("data-type") == "date") {
                Employee[$(this).attr("data-id")] = moment(Employee[$(this).attr("data-id")]).format("MM/DD/YYYY");
                if (Employee[$(this).attr("data-id")] == "Invalid date")
                    Employee[$(this).attr("data-id")] = '';
            }

            if (employeeToUpdate[$(this).attr("data-id")] != Employee[$(this).attr("data-id")].toString()) {
                DataChangeLog.DataUpdated.push({ Field: $(this).attr("data-id"), Data: { OLD: Employee[$(this).attr("data-id")], New: employeeToUpdate[$(this).attr("data-id")] } });
            }
        });

        $.each($("select[data-id]"), function (i, c) {
            console.log($(this).attr("data-id"));
            if ($(this).val() != Employee[$(this).attr("data-id")].toString()) {
                DataChangeLog.DataUpdated.push({ Field: $(this).attr("data-id"), Data: { OLD: $(this).find("option[value='" + Employee[$(this).attr("data-id")] + "']").text(), New: $(this).find("option:selected").text() } });
            }
        });

        Post("/EmployeeAPI/UpdateEmployee", { Employee: employeeToUpdate }).done(function (Response) {
            if (Response.Status) {

                var fileUpload = $('#txtEmployeePicture').get(0);
                var files = fileUpload.files;
                if (files.length > 0) {
                    SaveLog(Response.ID);
                    UploadEmployeePicture(files[0], Response.ID)

                } else {
                    document.getElementById("txtEmployeePicture").reset();
                    if (Response.Status) {
                        swal({ text: "Employee record updated.", icon: "success" });
                        SaveLog(Response.ID);
                        FillEmployee();
                        document.getElementById("frmEmployeeData").reset();
                    }
                }
            } else {
                swal({ text: "Employee record failed to update.", icon: "error" });
            }


        });

        return false;
    }
}
function UploadEmployeePicture(file, EmployeeID) {
    var fileData = new FormData();
    fileData.append(file.name, file);
    fileData.append("EmployeeID", EmployeeID);

    $.ajax({
        url: '/EmployeeAPI/UpdateEmployeePicure',
        type: "POST",
        contentType: false,
        processData: false,
        data: fileData,
        success: function (Response) {
            HideSpinner();
            if (Response.Status) {
                swal({ text: "Employee record updated.", icon: "success" });
                DataChangeLog.DataUpdated = [];
                DataChangeLog.DataUpdated.push({ Field: "Employee Picture", Data: { OLD: Employee[$(this).attr("FileName")], New: file.Name } });
                SaveLog(Response.ID);

            }
            FillEmployee();
            document.getElementById("frmEmployeeData").reset();

            document.getElementById("txtEmployeePicture").reset();

        }, error: function (errormessage) {
            HideSpinner();
            swal({ text: "Failed to upload Employee Picture.", icon: "error" });
        }
    });

}
$("#ddEmployeeHiringSource").change(function () {
    if ($(this).val() == 3)
        $("#txtEmployeeHiringCost").removeAttr("readonly")
    else
        $("#txtEmployeeHiringCost").attr("readonly", "readonly")

})
$("#ddEmployeeNationality").change(function () {
    if ($(this).val() == "Saudi")
        $("#txtEmployeeHomeCountryPhoneNumber").attr("readonly", "readonly")
    else
        $("#txtEmployeeHomeCountryPhoneNumber").removeAttr("readonly")

})
$("#ddEmployeeNationality").blur(function () {
    if ($(this).val() == "Saudi")
        $("#txtEmployeeHomeCountryPhoneNumber").attr("readonly", "readonly")
    else
        $("#txtEmployeeHomeCountryPhoneNumber").removeAttr("readonly")

});

function SortData(sender, field) {
    if (Sort.Field == field) {
        if (Sort.Dir == 'asc')
            Sort.Dir = 'desc'
        else
            Sort.Dir = 'asc'
    } else
        Sort.Dir = 'asc'

    var table = $(sender).closest('table');
    table.find("i.sort").remove();
    Sort.Field = field;
    if (Sort.Dir == "asc") {
        $(sender).append($('<i>').addClass("fa ms-1 fa fa-sort-asc sort"))

    }
    else {
        $(sender).append($('<i>').addClass("fa ms-1 fa fa-sort-desc sort"))
    }
    //EmployeeList=    _.sortBy(EmployeeList, Sort.Field);

    EmployeeList = EmployeeList.sort(sortdata(Sort.Field, Sort.Dir));
    FillEmployeeTable();
}
function sortdata(key, order = 'asc') {
    return function innerSort(a, b) {
        if (!a.hasOwnProperty(key) || !b.hasOwnProperty(key)) {
            // property doesn't exist on either object
            return 0;
        }

        const varA = (typeof a[key] === 'string')
            ? a[key].toUpperCase() : a[key];
        const varB = (typeof b[key] === 'string')
            ? b[key].toUpperCase() : b[key];

        let comparison = 0;
        if (varA > varB) {
            comparison = 1;
        } else if (varA < varB) {
            comparison = -1;
        }
        return (
            (order === 'desc') ? (comparison * -1) : comparison
        );
    };
}
