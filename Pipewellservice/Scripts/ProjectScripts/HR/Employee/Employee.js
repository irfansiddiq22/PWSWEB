var EmployeeList = [];

function _Int() {
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
function FillEmployee() {


    $("#tblEmployeeList").empty();
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
        $("#nav-list-tab").trigger("click")
        $("#dvEditEmplyee").addClass("d-none")
        $("#dvEmployeeList").removeClass("d-none")
    });


}
function FillEmployeeTable() {
    var pageSize = localStorage.getItem("PageLength");
    if (pageSize == "" || pageSize == null) {
        pageSize = 5;
    }

    $('#dvEmployeePaging').pagination({
        dataSource: EmployeeList,
        pageSize: pageSize,
        showGoInput: true,
        showGoButton: true,
        callback: function (data, pagination) {
            $("#tblEmployeeList").empty();
            $.each(data, function (i, e) {
                var tr = $('<tr data-id=' + e.ID + '> ');

                tr.append($('<td>').html(e.ID));
                tr.append($('<td>').html(e.Name));
                tr.append($('<td>').html(e.Iqama));
                tr.append($('<td>').html(e.ArabicName));
                tr.append($('<td>').html(e.Nationality));
                tr.append($('<td>').html(e.PhoneNumber));
                tr.append($('<td>').html(e.DataOfBirth == null ? "" : moment(e.DataOfBirth).format("MM/DD/YYYY")));
                tr.append($('<td>').html(e.DataOfBirth == null ? "" : moment(e.DataOfBirth).format("MM/DD/YYYY")));
                tr.append($('<td>').html(e.Company));
                tr.append($('<td>').html(e.Division));
                tr.append($('<td>').html(e.Position));
                tr.append($('<td>').html(e.Supervisor));

                tr.append($('<td>').html(e.ExpiryDate == null ? "" : moment(e.ExpiryDate).format("MM/DD/YYYY")));
                tr.append($('<td>').html(e.Passport));
                tr.append($('<td>').html(e.VacationRotation));
                tr.append($('<td>').html(e.NextVacation));

                tr.append($('<td>').html(e.JobStatus));
                tr.append($('<td>').html(e.HiringDate == null ? "" : moment(e.HiringDate).format("MM/DD/YYYY")));
                tr.append($('<td>').html(e.JobLeftDate == null ? "" : moment(e.JobLeftDate).format("MM/DD/YYYY")));

                tr.append($('<td>').html(e.ShowInAttendence));
                tr.append($('<td>').html(e.DeductSalary));

                tr.append($('<td>').html('<a href="javascript:void(0)" onclick="EditEmployee(\'' + e.ID + '\')"><i class="fa fa-edit"></i></a> <a href="javascript:void(0)"onclick="DeleteEmployee(\'' + e.id + '\',this)"><i class="fa fa-trash"></i></a>'));

                $("#tblEmployeeList").append(tr);//'<a class="fc-event fc-daygrid-event fc-daygrid-dot-event fc-event fc-event-draggable fc-event-resizable fc-event-start fc-event-end fc-event-future fc-event-upcoming p-1" style="color:#FFF!important;" data-id=\'' + e.PostIDEnc + '\'>' + e.title + ' ' + new moment(e.start).format("MM/DD/YY") + '</a>')
            })
        }
    })
}

function EditEmployee(ID) {
    var employee;
    Post("/EmployeeAPI/EmployeeDetail", { EmployeeID: ID }).done(function (Response) {
        employee = Response[0];
        $.each($("input[data-id],select[data-id]"), function (i, c) {
            if ($(this).attr("data-type") == "date")
                $(this).val(employee[$(this).attr("data-id")] == null ? "" : moment(employee[$(this).attr("data-id")]).format("MM/DD/YYYY"));
            else
                $(this).val(employee[$(this).attr("data-id")]);
        })
        $("#ddEmployeeHiringSource").trigger("change")
        $("#ddEmployeeNationality").trigger("change")
        $("#nav-detail-tab").trigger("click")
        $("#dvEditEmplyee").removeClass("d-none")
        $("#dvEmployeeList").addClass("d-none")

    });
}

function UpdateEmployee() {
    if ($("#frmEmployeeData").valid()) {
        var employee = {};
        $.each($("input[data-id],select[data-id]"), function (i, c) {
            employee[$(this).attr("data-id")] = $(this).val();
        })
        Post("/EmployeeAPI/UpdateEmployee", { Employee: employee }).done(function (Response) {
            if (Response.Status) {
                swal({ text: "Employee record updated.", icon: "success" });
                FillEmployee();
                document.getElementById("frmEmployeeData").reset();


            } else {
                swal({ text: "Employee record failed to update.", icon: "error" });
            }
        });
        
        return false;
    }
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