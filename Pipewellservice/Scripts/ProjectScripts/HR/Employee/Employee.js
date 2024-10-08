﻿var EmployeeList = [];
var Employee = {ID:0}
function _Init() {
    SetPagePermissions([32,33])
    SetPagePermission(PAGES.EmployeeDetail, function () {

        FillEmployee();


        BindUsers();
        FillEmployeeDataList()
        LoadVendor();
        LoadSponsor();
        LoadLocations();
        BindPermission();
        $.post("/DataList/JobStatus", {}, function (Response) {
            FillList("ddEmployeeStatus", Response, "Name", "Value", " ")
        });
        var rules = [];

        $("#frmEmployeeData").validate()

        $.each($("select[data-msg]"), function (i, c) {
            $(this).attr("name", $(this).attr("id"));
            /*
            $(this).rules("add", {
                required: true,
                messages: {
                    required: $(this).attr("msg")
                }

            });*/

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
        $.each($("email[data-msg],input[data-msg]"), function (i, c) {
            //if (!$(this).attr("name"))
            $(this).attr("name", $(this).attr("id"));
            if ($(this).attr("data-min")) {
                $(this).rules("add", {
                    required: true,
                    min: 1,
                    messages: {
                        required: $(this).attr("msg"),
                        min:$(this).attr("msg")
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
    });

}
$(".keyupfilter").keyup(function () {
    /// FillEmployeeTable();
})
function FillEmployeeDataList() {
    $.post("/EmployeeAPI/EmployeeDataList", {}).done(function (Response) {
        var Divisions = Response.divisions;
        var Positions = Response.positions;
        var Sponsors = Response.sponsors;
        var Worktime = Response.worktime;

        FillList("ddEmployeeDivision", Divisions, "Name", "ID", "Select Division")
        FillList("ddEmployeePosition", Positions, "Name", "ID", "Select Position")
        FillList("ddEmployeeSponsor", Sponsors, "Display", "ID", "Select PWS CR")
        FillList("ddVendorPWSCR", Sponsors, "Display", "CRNumber", "#")
        
        
        FillList("ddEmployeeWorkInOutTime", Worktime, "Time", "ID", "")
        FillList("ddEmployeeNationality", Response.nationalities, "Name", "ID", "Select Nationality")
    });
}
function FillSponsorList() {

    FillList("ddEmployeeSponsor", SponsorData, "Display", "ID", "Select PWS CR")
    $("#ddEmployeeSponsor").val(Employee.SponsorID)
    $("#dlgSponsorList").modal("hide");
}

function FillLocationList() {

    FillList("ddEmployeeLocation", LocationData, "Name", "ID", "Select Location")
    $("#ddEmployeeLocation").val(Employee.Location)
    $("#dlgLocationList").modal("hide");

        
    $("#ddEmployeeLocation").rules("add", {
                required: true,
                min: 1,
                messages: {
                    required: $(this).attr("msg"),
                    min: $(this).attr("msg")
                }

            });
         

    

}

function BindUsers() {
    $.post("/EmployeeAPI/CodeName", {}).done(function (Response) {



        var data = [];
        data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
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
function ResetNav() {
    document.getElementById("frmEmployeeData").reset();
    Employee = { ID: 0 }
    $("#dvEditEmplyee").addClass("d-none")
    $("#imgEmployeePicture").attr("src","")

    $("#dvEmployeeList").removeClass("d-none")
    $(".breadcrumb-item.active").find("a").contents().unwrap();

}
function FillEmployee() {


    $("#tblEmployeeList").empty();
    Employee = { ID: 0};
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
/*        var Supervisor = Response.filter(x => x.Position == "HSE Officer").reduce(function (memo, e1) {
            var matches = memo.filter(function (e2) {
                return e1.Name == e2.Name
            })
            if (matches.length == 0)
                memo.push({ "Name": e1.Name, ID: e1.ID })
            return memo;
        }, [])*/

        Post("/EmployeeAPI/Supervisors", {}).done(function (Response) {
            var data = []
            data.push({ id: 0, text: 'Select Supervisor' });
            $.each(Response, function (i, emp) {
                data.push({ id: emp.ID, text: emp.Name });
            })
            $("#ddEmployeeSupervisor").select2({
                placeholder: "Select Supervisor",
                data: data,
                width: "100%"
            })
        });

        //FillList("ddEmployeeSupervisor", Supervisor, "Name", "ID")


        //FillList("ddEmployeeNationality", Nationality, "Nationality", "Nationality", "#")

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
                var link = $('<a>').attr("href", "javascript:void(0)").attr("onclick", "DownloadIDFile(" + e.ID + ",'" + e.IqamaFileName + "','" + e.IqamaFileID +"','Iqama')").text(e.Iqama)

                tr.append($('<td>').append((e.Iqama == null || e.Iqama == "" ? "" : link)));

                tr.append($('<td>').append((e.IqamaProfession == null || e.IqamaProfession == "" ? "" : e.IqamaProfession)));

                tr.append($('<td class="iqamadata">').html(e.IqamaExpiryDate == null ? "" : moment(e.IqamaExpiryDate).format("DD/MM/YYYY")))
                link = $('<a>').attr("href", "javascript:void(0)").attr("onclick", "DownloadIDFile(" + e.ID + ",'" + e.FileName + "','" + e.FileID + "','Passport')").text(e.Passport)

                tr.append($('<td class="iqamadata">').append((e.Passport == null || e.Passport == "" ? "" : link)));

                
                tr.append($('<td class="iqamadata">').html(e.PassportExpiryDate == null ? "" : moment(e.PassportExpiryDate).format("DD/MM/YYYY")))
                tr.append($('<td>').append((e.LocationName == null || e.LocationName == "" ? "" : e.LocationName  )));
                tr.append($('<td>').html(e.PhoneNumber));
                tr.append($('<td>').html(e.DataOfBirth == null ? "" : moment().diff(e.DataOfBirth, "years")));
                tr.append($('<td>').html(e.SponsorCompany));
                tr.append($('<td>').html(e.Division));
                tr.append($('<td>').html(e.Position));

                tr.append($('<td>').html(e.Supervisor));
                
                tr.append($('<td>').append((e.ContractTypeName == null || e.ContractTypeName == "" ? "" : e.ContractTypeName)));
                tr.append($('<td>').append((e.HiringSourceName == null || e.HiringSourceName == "" ? "" : e.HiringSourceName)));
                tr.append($('<td>').append((e.AccommodationRequired ?"Yes":"No")));
                tr.append($('<td>').append((e.QiwaContract ?"Yes":"No")));

                tr.append($('<td>').html(e.HiringDate == null ? "" : moment(e.HiringDate).format("DD/MM/YYYY")));
                tr.append($('<td>').html(e.VacationRotation + ' Month'));
                tr.append($('<td>').html(e.VacationDestination == null ? "" : e.VacationDestination));
                tr.append($('<td>').html(e.LastJoinDate == null ? "" : moment(e.LastJoinDate).format("DD/MM/YYYY")));
                tr.append($('<td class="jobstatus">').html(e.CurrentJobStatus));
                tr.append($('<td class="jobstatus">').html(e.JobLeftDate == null ? "" : moment(e.JobLeftDate).format("DD/MM/YYYY")));
                /*tr.append($('<td>').html(e.JobLeftDate == null ? "" : moment(e.JobLeftDate).format("DD/MM/YYYY")));
                
                tr.append($('<td>').html(e.ShowInAttendence));
                tr.append($('<td>').html(e.DeductSalary));*/

                tr.append($('<td>').html('<a href="javascript:void(0)" class="writeble" onclick="EditEmployee(\'' + e.ID + '\')"><i class="fa fa-edit"></i></a> <a class="deleteble" href="javascript:void(0)"onclick="DeleteEmployee(\'' + e.id + '\',this)"><i class="fa fa-trash"></i></a>'));

                $("#tblEmployeeList").append(tr);//'<a class="fc-event fc-daygrid-event fc-daygrid-dot-event fc-event fc-event-draggable fc-event-resizable fc-event-start fc-event-end fc-event-future fc-event-upcoming p-1" style="color:#FFF!important;" data-id=\'' + e.PostIDEnc + '\'>' + e.title + ' ' + new moment(e.start).format("MM/DD/YY") + '</a>')
            })

            if (GetChecked("chkEmployeeIqamainfo"))
                $(".iqamadata").show()
            else
                $(".iqamadata").hide()

            if (GetChecked("chkEmployeeOnJobEmployee"))
                $(".jobstatus").hide()
            else
                $(".jobstatus").show()

        }
    })
}

function BindPermission() {
    $.post("/SettingAPI/ListGroupNPermissions", {},function (Response) {
        $("#tblPermissionGroups").empty();
        FillList("ddEmployeeWorkPortalPermission", Response.Groups,"Name","ID","Select Permission")
    });
}

function DownloadIDFile(EmployeeID, FileName, FileID,Type) {
    ShowSpinner();
    DownloadFile("/EmployeeAPI/DownloadIDFile?EmployeeID=" + String(EmployeeID) + "&FileName=" + FileName + "&FileID=" + FileID + "&Type=" + Type, FileName);
}
function ToggleIqamaData() {

    if (GetChecked("chkEmployeeIqamainfo"))
        $(".iqamadata").show()
    else
        $(".iqamadata").hide()
}

function ShowJobLeft() {
    var staus=[2,4,7,8]
    if (staus.includes(parseInt( valOf("ddEmployeeStatus"))))
        $(".jobleftdate").show();
    else
        $(".jobleftdate").hide();
}
function NewEmployee() {
    ResetChangeLog(PAGES.EmployeeDetail);
    document.getElementById("frmEmployeeData").reset();
    $("#ddEmployeeHiringSource").trigger("change")
    $("#ddEmployeeStatus").trigger("change")
    $("#ddEmployeeNationality").trigger("change")
    $("#nav-detail-tab").trigger("click")
    $("#dvEditEmplyee").removeClass("d-none")
    $("#dvEmployeeList").addClass("d-none")
    $("#imgEmployeePicture").attr("src", "")
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
    
    ResetDatePicker();
}
function FindEmployee(ID) {
    if (!isNaN(parseInt(ID)) && Employee.ID != parseInt(ID)) {
        var EmployeeSearch = EmployeeList.find(x => x.ID == parseInt(ID))
        if (EmployeeSearch != null) {
            //if  (Employee.ID == 0)
                EditEmployee(EmployeeSearch.ID)
            //else
                //SwalConfirm("Do you want to cancel ")
        }
    }
}
function EditEmployee(ID) {

    Post("/EmployeeAPI/EmployeeDetail", { EmployeeID: ID }).done(function (Response) {
        Employee = Response[0];
        ResetChangeLog(PAGES.EmployeeDetail);
        if (Employee.PermissionGroupID == "0") Employee.PermissionGroupID = 4;

        $.each($("input[data-id],select[data-id],textarea[data-id]"), function (i, c) {
            if ($(this).attr("data-type") == "date")
                $(this).val(Employee[$(this).attr("data-id")] == null ? "" : moment(Employee[$(this).attr("data-id")]).format("DD/MM/YYYY"));
            else if ($(this).is(':checkbox') || $(this).is(':radio'))
                  $(this).prop("checked", Employee[$(this).attr("data-id")]);
            else
                $(this).val(Employee[$(this).attr("data-id")]);
        })
        
        $("#imgEmployeePicture").attr("src", "/EmployeeAPI/EmployeePicture?EmployeeID=" + Employee.ID + "&FileID=" + Employee.FileID + "&FileName=" + Employee.FileName)
        $("#ddEmployeeHiringSource").trigger("change")
        $("#ddEmployeeStatus").trigger("change")
        $("#ddEmployeeNationality").trigger("change")
        $("#nav-detail-tab").trigger("click")
        $("#ddEmployeeSupervisor").trigger("change")
        $("#dvEditEmplyee").removeClass("d-none")
        $("#dvEmployeeList").addClass("d-none")
        $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
        ResetDatePicker();
    });
}

function UpdateEmployee() {
    if ($("#frmEmployeeData").valid()) {
        if (valOf("txtEmployeeIqama") != "") {
            if (valOf("txtEmployeeIssueDate") == "") {
                swal("Enter Iqama Issue date", { icon: "error" });
                return false;
            }
            if (valOf("txtIqmaExpiryDate") == "") {
                swal("Enter Iqama Expiry date", { icon: "error" });
                return false;
            }
        }
        var employeeToUpdate = {};
        $.each($("input[data-id],select[data-id],:checkbox[data-id],:radio[data-id],textarea[data-id]"), function (i, c) {
            if ($(this).is(':checkbox') || $(this).is(':radio'))
                employeeToUpdate[$(this).attr("data-id")] = $(this).prop("checked");
            else
            employeeToUpdate[$(this).attr("data-id")] = $(this).val();
        })

        $.each($("input[data-id],textarea[data-id]"), function (i, c) {
            if ($(this).attr("data-type") == "date") {
                Employee[$(this).attr("data-id")] = moment(Employee[$(this).attr("data-id")]).format("DD/MM/YYYY");
                if (Employee[$(this).attr("data-id")] == "Invalid date")
                    Employee[$(this).attr("data-id")] = '';
            }

            if (employeeToUpdate[$(this).attr("data-id")] != NullToString(Employee[$(this).attr("data-id")])) {
                DataChangeLog.DataUpdated.push({ Field: $(this).attr("data-id"), Data: { OLD: NullToString(Employee[$(this).attr("data-id")]), New: employeeToUpdate[$(this).attr("data-id")] } });
            }
        });

        $.each($("select[data-id]"), function (i, c) {

            if ($(this).val() != NullToString(Employee[$(this).attr("data-id")])) {
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
                    ResetNav();
                    $("#txtEmployeePicture").val('');
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
        url: '/EmployeeAPI/UpdateEmployeePicture',
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
            ResetNav();
            $("#txtEmployeePicture").val('');

        }, error: function (errormessage) {
            HideSpinner();
            swal({ text: "Failed to upload Employee Picture.", icon: "error" });
        }
    });

}
$("#ddEmployeeHiringSource").change(function () {
    if ($(this).val() == 1) {
        $("#txtEmployeeHiringCost").attr("readonly", "readonly")
        $(".vendor").hide();
        $(".emppwscr").show();
    }
    else {
        $("#txtEmployeeHiringCost").removeAttr("readonly")
        $(".vendor").show();
        $(".emppwscr").hide()
    }
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

function ExportEmployeeData() {
    
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

    var table = $('<table>');

    var tr = $('<tr> ');

    tr.append($('<td>').text("Employee ID"));
    tr.append($('<td>').text("Employee Name"));
    tr.append($('<td>').text("Employee Arabic Name"));
    tr.append($('<td>').text("Nationality"));

    tr.append($('<td>').text("Iqama"));
    tr.append($('<td>').text("Iqama Profession"));
    if ($("#chkEmployeeIqamainfo").prop("checked")) {
        tr.append($('<td>').text("Expiry Date"))

        tr.append($('<td>').text("Passport"));
        tr.append($('<td>').text("Expiry Date"));
    }
    tr.append($('<td>').text("Location"));
    tr.append($('<td>').text("Phone Number"));
    tr.append($('<td>').text("Age"));
    tr.append($('<td>').text("Company"));
    tr.append($('<td>').text("Division"));
    tr.append($('<td>').text("Position"));

    tr.append($('<td>').text("Supervisor"));
    tr.append($('<td>').text("Contract Type"));
    tr.append($('<td>').text("Source Of Hiring"));
    tr.append($('<td>').text("Accommodation Required"));
    tr.append($('<td>').text("Qiwa"));
    

    
    tr.append($('<td>').text("Hiring Date"));
    tr.append($('<td>').text("Vacation Rotation"));
    tr.append($('<td>').text("Destination"));
    if (!GetChecked("chkEmployeeOnJobEmployee")) {
        tr.append($('<td>').text("Job Status"));
        tr.append($('<td>').text("Job Left Date"));
    }
    tr.append($('<td>').text("Last Working Date"));
    
    $(table).append(tr);

    $.each(FilteredData, function (i, e) {
         tr = $('<tr> ');

        tr.append($('<td>').html(e.ID));
        tr.append($('<td>').html(e.Name));
        tr.append($('<td>').html(e.ArabicName));
        tr.append($('<td>').html(e.Nationality));
        
        tr.append($('<td>').append((e.Iqama == null || e.Iqama == "" ? "" : e.Iqama)));
        tr.append($('<td>').append((e.IqamaProfession == null || e.IqamaProfession == "" ? "" : e.IqamaProfession)));
        if ($("#chkEmployeeIqamainfo").prop("checked")) {
        tr.append($('<td class="iqamadata">').html(e.IqamaExpiryDate == null ? "" : moment(e.IqamaExpiryDate).format("DD/MM/YYYY")))
        
            tr.append($('<td class="iqamadata">').append((e.Passport == null || e.Passport == "" ? "" : e.Passport)));
            tr.append($('<td class="iqamadata">').html(e.PassportExpiryDate == null ? "" : moment(e.PassportExpiryDate).format("DD/MM/YYYY")))
        }
        tr.append($('<td>').append((e.LocationName == null || e.LocationName == "" ? "" : e.LocationName)));
        tr.append($('<td>').html(e.PhoneNumber));
        tr.append($('<td>').html(e.DataOfBirth == null ? "" : moment().diff(e.DataOfBirth, "years")));
        tr.append($('<td>').html(e.SponsorCompany));
        tr.append($('<td>').html(e.Division));
        tr.append($('<td>').html(e.Position));

        tr.append($('<td>').html(e.Supervisor));

        tr.append($('<td>').append((e.ContractTypeName == null || e.ContractTypeName == "" ? "" : e.ContractTypeName)));
        tr.append($('<td>').append((e.HiringSourceName == null || e.HiringSourceName == "" ? "" : e.HiringSourceName)));
        tr.append($('<td>').append((e.AccommodationRequired ? "Yes" : "No")));
        tr.append($('<td>').append((e.QiwaContract ? "Yes" : "No")));

        tr.append($('<td>').html(e.HiringDate == null ? "" : moment(e.HiringDate).format("DD/MM/YYYY")));
        tr.append($('<td>').html(e.VacationRotation + ' Month'));
        tr.append($('<td>').html(e.VacationDestination == null ? "" : e.VacationDestination));
        
       

        
        if (!GetChecked("chkEmployeeOnJobEmployee")) {
            tr.append($('<td>').html(e.CurrentJobStatus));
            tr.append($('<td>').html(e.JobLeftDate == null ? "" : moment(e.JobLeftDate).format("DD/MM/YYYY")));
        }
        tr.append($('<td>').html(e.LastJoinDate == null ? "" : moment(e.LastJoinDate).format("DD/MM/YYYY")));

        $(table).append(tr);
    })

    
    var data = $("<div>");
    $(data).append(table);
    ExportToExcel($(data).html(),"Employee.xls")
}