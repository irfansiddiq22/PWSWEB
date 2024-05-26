var Buildings = [];
var Employees = [];

var Room = {};
var EditRoomPlanData = [];
var NewAppartmentPlan = {}
var treegrid = 1;
function _Init() {
    HideSpinner();
    SetPagePermission(PAGES.Accommodation, function () {
        ShowBuildings();

        $.post("/EmployeeAPI/CodeName", {}).done(function (Response) {

             Employees = []
            if (Response.length > 1)
                Employees.push({ id: 0, text: 'Select an employee' });
            $.each(Response, function (i, emp) {
                Employees.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
            })
            //$("#ddCertificateEmployeeCode").select2({
            //    tags: "true",
            //    placeholder: "Select an option",
            //    allowClear: true,
            //    width: '100%',
            //    data: data
            //})
        })
    })
}
//$('form').on('reset', function (e) {
//    InitilzeAsset();
//})



function ShowBuildings() {
    $(".building").remove();
    treegrid = 0;
    Post("/Accommodation/ListBuilding", {}).done( function (resp) {
        Buildings = resp;
        $.each(resp.Buildings, function (i, b) {
            $('<button class="nav-link" id="nav-building-tab-' + b.ID + '" data-bs-toggle="tab" data-bs-target="#nav-building-tab-content-' + b.ID + '" type="button" role="tab" aria-controls="#nav-building-tab-content-' + b.ID + '" aria-selected="true">' + b.Name + '</button>').insertBefore($("#nav-add-building"))
            CreateBuildingContainer(b);
        })

        $('.rooms').each(function () {
            $(this).treegrid({
                expanderExpandedClass: 'fa fa-minus',
                expanderCollapsedClass: 'fa fa-plus',
                initialState: 'expanded'
            });
        })
        $('.apartments').each(function () {
            $(this).treegrid({
                expanderExpandedClass: 'fa fa-minus',
                expanderCollapsedClass: 'fa fa-plus',
                initialState: 'collapsed'
            });
        })
        $($(".nav-link")[0]).trigger("click");
    })

    

}
function CreateBuildingContainer(b) {
    var dv = $('<div class="tab-pane fade building" id="nav-building-tab-content-' + b.ID + '" role="tabpanel" aria-labelledby="nav-building-tab-content-' + b.ID + '"></div>')
    var table = $('<table class="table w-100 table-bordered building  m-0"><tbody>');
    var Row = $('<tr>')
    $(Row).append($('<td class="align-middle" width="20%" id="building-'+ b.ID +'">').text(b.Name));

    var floorsCol = $('<td>');
    var i;
    for (i = 1; i <= b.NoOfFloor; i++) {
        $(floorsCol).append($(CreateFloor(i,b.ID)));
    }
    $(floorsCol).append($('<button class="btn btn-sm btn-primary" onclick="AddNewFloor(this,'+ (b.ID) + ')">').text("Add Floor"));
    $(Row).append($(floorsCol))
    $(table).append($(Row));
    $(dv).append($(table));
    $(dv).insertBefore( $("#nav-new-building"));
}
function AddNewFloor(sender, ID) {
    var floorcount = $('.building-floor-' + ID + '').length + 1;
    Post("/Accommodation/AddFloor", {ID:ID}).done(function () {
        $(CreateFloor(floorcount, ID)).insertBefore($(sender));
    })
    
}
function CreateFloor(i,ID) {
    var FloorTable = $('<table  class="table w-100 table-bordered m-0 building-floor-' + ID +'" id="building-floor-' + (ID + '-' + i) + '"><tbody>');
    var ftr = $('<tr>');

    var floorCol = $('<div class="col p-0 border-end border-bottom" >');
    var floorname = ''
    if (i == 1)
        floorname = 'Ground Floor'
    else if (i == 2)
        floorname = "1st Floor"
    else if (i == 3)
        floorname = "2nd Floor"
    else if (i == 4)
        floorname = "3rd Floor"
    else
        floorname = (i-1) + "th Floor";
    ftr.append($('<td   width="20%" class="align-middle">').text(floorname));

    var aptTable = $('<table  class="table w-100 table-bordered" id="building-floor-' + (ID + '-' + i) + 'apt"><tbody>');
    var aptRow = $('<tr>')
    var ApptCount = 0;
    
    $.each(Buildings.Appartments.filter(x => x.BuildingID == ID && x.FloorNumber == i), function (i, apt) {
        treegrid++;
        aptRow = $('<tr class="treegrid-' + treegrid + '">')
        var EmpBeds = Buildings.Rooms.filter(x => x.AppartmentID == apt.ID && x.EmployeeID == 0);

        $(aptRow).append($('<td  class="align-middle blue">').append("Appartment " + apt.AppartmentNumber + (EmpBeds.length > 0 ? " Empty Beds: <span class='badge bg-danger' style='font-size:17px'>" + EmpBeds.length + "</span>" : "")));
        $(aptTable).append($(aptRow));
        aptRow = $('<tr class="treegrid-parent-' + treegrid +'">')
        aptRow.append($('<td>').append(CreateAppartment(apt)));
        $(aptTable).append($(aptRow));

        ApptCount++;
    });
    if (ApptCount > 0)
        $(aptTable).addClass("apartments");
    aptRow = $('<tr class="">')
    $(aptRow).append($('<td class="bg-warning">').append($('<button class="btn btn-sm btn-primary" onclick="AddNewAppt(' + ID + ',' + i + ',' + ApptCount +')">').text("Add Appartment to " + floorname)));
    $(aptTable).append($(aptRow));
    ftr.append($('<td>').append($(aptTable)));

    FloorTable.append($(ftr));
    return FloorTable;
}
function CreateAppartment(appt) {
    //var Table = $('<table  class="table w-100 table-bordered building-floor-apt-' + appt.BuildingID + '-' + appt.FloorNumber +'"><tbody>');
    //var tr = $('<tr>');
    


    var aptTable = $('<table  class="table w-100 table-bordered" id="building-floor-' + (appt.ID) + 'apt"><tbody>');
    var Row = $('<tr>')
    $(Row).append($('<td>').append(CreateRooms(appt.NoOfRoom, appt.ID)));
    $(aptTable).append($(Row));

    Row = $('<tr>')
    $(Row).append($('<td>').append($('<button class="btn btn-sm btn-primary" onclick="AddNewRoom(' + appt.ID + ',' + appt.BuildingID +',' + appt.FloorNumber + ')">').text("Add Room")));
    $(aptTable).append($(Row));

    //tr.append($('<td>').append($(aptTable)));

  //  Table.append($(tr));
    return aptTable;

}
function CreateRooms(RoomCount,AppartmentID) {

    var table = $('<table class="table table-sm w-100 rooms">');
    
    treegrid++;
    var parent = treegrid;  
    for (i = 1; i <= RoomCount; i++) {
        var Beds = Buildings.Rooms.filter(x => x.AppartmentID == AppartmentID && x.RoomNumber == i);
        var EmpBeds = Buildings.Rooms.filter(x => x.AppartmentID == AppartmentID && x.RoomNumber == i && x.EmployeeID==0);
        var tr = $('<tr data-id="' + i + '" class="rooms' + AppartmentID + ' treegrid-' + treegrid + ' treegrid-parent-' + parent +'">')
         
        tr.append($('<td>').append("<strong>Room " + i + " </strong><strong> Beds: <span class='badge bg-success' style='font-size:17px'>" + Beds.length + "</span>" + (EmpBeds.length > 0 ?" Empty Beds: <span class='badge bg-danger' style='font-size:17px'>" + EmpBeds.length +"</span>" : "")+ "</strong> ").append($('<a href="javascript:void(0)" class="" onclick="EditRoomPlan(' + i + ', ' + AppartmentID + ')">').append($('<i class="fa fa-edit">'))));
        $(table).append(tr);
        var tparent = treegrid;
        
        tr = $('<tr class="treegrid-parent-' + treegrid +'">')
        var tblbed = $('<div class="row ms-3">');
        $.each(Beds, function (j, r) {
            $(tblbed).append($('<div class="col-4 my-2">').text("Bed #:" + r.BedNumber + " Employee ID:" + r.EmployeeID));
        })
        $(tr).append($('<td>').append(tblbed));
        $(table).append($(tr));
        treegrid++;

    }
    return $(table);
}
function CreateNewBuilding() {
    Post("/Accommodation/AddBuilding", {
        ID: 0, Name: valOf("txtbuildingName"), NoOfFloor: valOf("txtBuildingFloor")
    }, function (resp) {
        ShowBuildings();
    });
}
function AddNewAppt(BuildingID, FloorNumber, ApptCount) {
    //$("#dlgNewAppartment").modal("show");
    $("#dvBuildingPlan").addClass("d-none")
    $("#dvAppartmentPlan").removeClass("d-none")
    $("#trRooms").empty();

    var floorname = ''
    if (FloorNumber == 1)
        floorname = 'Ground Floor'
    else if (FloorNumber == 2)
        floorname = "1st Floor"
    else if (FloorNumber == 3)
        floorname = "2nd Floor"
    else if (FloorNumber == 4)
        floorname = "3rd Floor"
    else
        floorname = (FloorNumber - 1) + "th Floor";

    $("#dvAppartmentLabel").text("Building - " + $("#building-" + BuildingID).text() + " Floor #" + floorname + " Appartment#:" + (ApptCount+1) +" Plan");
    NewAppartmentPlan = { BuildingID: BuildingID, FloorNumber: FloorNumber}
    return;

    Post("/Accommodation/AddAppartment", {
        ID: 0, BuildingID: BuildingID, FloorNumber: FloorNumber, AppartmentNumber: $(".building-floor-apt-" + BuildingID + '-' + FloorNumber).length + 1
    }).done( function (resp) {
        ShowBuildings();
    }); 
}
function CancelAppartmentPlan() {
    $("#dvAppartmentPlan").addClass("d-none")
    $("#dvBuildingPlan").removeClass("d-none")
    $("#trRooms").empty();
}
function CreateAppartmentRoomPlan(sender) {
    var NumberofRoom = $(sender).val();
    var dv = $('<div>').addClass("row");

    for (i = 1; i <= NumberofRoom; i++) {
        var roomdv = $('<div>').addClass("col-md-6");
        var roomtable = $('<table class="table table-sm w-100 table-bordered appartmentroom"><tbody>');
        var tr = $('<tr>')
        tr.append($('<td class="blue p-2" colspan="2">').text("Room #" + i));
        roomtable.append(tr);
         tr = $('<tr>')
        tr.append($('<td width="23%">').html("<strong># of Beds:</strong>"));
        tr.append($('<td>').append($("<input type='number' class='form-control form-control-sm' onblur='AddRoomPlan(this," + i + ")'>")));
        
        roomtable.append(tr);

        tr = $('<tr>')
        tr.append($('<td colspan="2" id="roomPlan'+ i +'">'));
        roomtable.append(tr);
        $(roomdv).append($(roomtable));
        $(dv).append(roomdv)
    }
    $("#trRooms").empty().append($(dv));
}
function AddRoomPlan(sender,room) {
    var NoofBeds = $(sender).val();
    var tbed = $('<table class="table table-sm w-100 table-bordered appartmentroomplan"><tbody>');
    for (i = 1; i <= NoofBeds; i++) {

        var tr = $('<tr>')
        tr.append($('<td>').append("<strong>Bed " + i +"</strong>"))
        tr.append($('<td>').append($(CreateEmployeeList(room))))
        tr.append($('<td>'));
        tbed.append(tr)

    }
    $("#roomPlan" + room).empty().append(tbed);

    $(".selectemployee" + room).select2({
        placeholder: "Select employee",
        allowClear: true,
        width: '100%',
        data: Employees,
        dropdownParent: $("#dvAppartmentPlan")

    })
}

function AddNewRoom(AppartmentID, BuildingID, FloorNumber) {
    
    var Rooms = $(".rooms" + AppartmentID).length;
    Room = { AppartmentID: AppartmentID, BuildingID: BuildingID, FloorNumber: FloorNumber, RoomNumber: Rooms + 1 };
    $("#tdDuplicateBeds").empty();
    $("#dvRoomPlanText").text("Building - " + $("#building-" + BuildingID).text() + " Floor #" + FloorNumber + " Room #" + (Rooms+1) + " Plan");
    $("#dlgNewAppartmentRoom").modal("show");
}

function CreateEmployeeBeds(sender, n) {
    var NoofBeds = $(sender).val();
    var tbed = $('<table class="table table-sm w-100"><tbody>');
   
    for (i = 1; i <= NoofBeds; i++) {
        
        var tr = $('<tr>')
        tr.append($('<td width="25%">').text("Bed " + i))
        tr.append($('<td>').append($(CreateEmployeeList(''))))
        tr.append($('<td>'))
        tbed.append(tr)

    }
    


    $("#" + n).empty().append(tbed);
    $(".selectemployee").select2({
        placeholder: "Select employee",
        allowClear: true,
        width: '100%',
        data: Employees,
        dropdownParent: $("#dlgNewAppartmentRoom .modal-content")
    })

    if (EditRoomPlanData != null && EditRoomPlanData.length > 0)
        $.each($("#trBeds > table > tbody > tr"), function (i, tr) {
            if (i<EditRoomPlanData.length)
                $($(tr).find("select")[0]).val(EditRoomPlanData[i].EmployeeID).trigger("change")
        });

}
function CreateEmployeeList(id) {
    var Select = $('<select class="form-select form-select-sm selectemployee'+ id +'">')
    
    return $(Select);
}

function SaveEmployeeBeds() {
    var Beds = [];
    var Result = true;
    var DuplEmployee = [];
    $.each($("#trBeds > table > tbody > tr"), function (i, tr) {
        if (parseInt($($(tr).find("select")[0]).val()) > 0 && Buildings.Rooms.filter(x => x.EmployeeID == parseInt($($(tr).find("select")[0]).val()) && x.AppartmentID != Room.AppartmentID).length > 0) {
            var EmpBed = Buildings.Rooms.find(x => x.EmployeeID == parseInt($($(tr).find("select")[0]).val()));
            var Appt = Buildings.Appartments.find(x => x.ID = EmpBed.AppartmentID);
            var build = Buildings.Buildings.find(x => x.ID == Appt.BuildingID);
            DuplEmployee.push({ EmployeeID: EmpBed.EmployeeID, BuildingName: build.Name, Floor: Appt.FloorNumber, AppartmentNumber: Appt.AppartmentNumber, Room: EmpBed.RoomNumber, BedNumber: EmpBed.BedNumber });
            $(tr).find("td:eq(2)").text("Employee " + EmpBed.EmployeeID + " has already have a bed assigned in building " + build.Name + " Floor #:" + Appt.FloorNumber + " Appartment #:" + Appt.AppartmentNumber + " Room#:" + EmpBed.RoomNumber + " Bed #:" + EmpBed.BedNumber);
            Result = false;
        } else {
            $(tr).find("td:eq(2)").text("")
        }
        Beds.push({ AppartmentID: Room.AppartmentID, RoomNumber: Room.RoomNumber,BedNumber: (i + 1), EmployeeID:$($(tr).find("select")[0]).val() })

    })
    $("#tdDuplicateBeds").empty();
    if (DuplEmployee.length > 0) {
        $("#tdDuplicateBeds").append("<div class='blue'> The following employees already have accommodation assigned.</div><div class='p-2 bg-warning'>Select the employees to unlink from old room to assign new room, Or select Ignore to continue selection.</div>")
        var DuplicateTable = $('<table class="table table-sm w-100 table-bordered"><tbody>')
        var tr = $('<tr class="bg-success text-white">')
        tr.append("<td>Unlink</td>")
        tr.append("<td>Emp#</td>")
        tr.append("<td>Building</td>")
        tr.append("<td>Floor #</td>")
        tr.append("<td>Appartment #</td>")
        tr.append("<td>Room #</td>")
        tr.append("<td>Bed #</td>")
        ///tr.append("<td>Ignore</td>")

        DuplicateTable.append(tr);
        $.each(DuplEmployee, function (i, e) {
            tr = $('<tr >')
            tr.append("<td><input type='checkbox' class='unlinkbed' id='Unlink" + i + "' data-empid='" + e.EmployeeID + "'></td>")
            tr.append("<td>" + e.EmployeeID + "</td>")
            tr.append("<td>" + e.BuildingName + "</td>")
            tr.append("<td>" + e.Floor + "</td>")
            tr.append("<td>" + e.AppartmentNumber + "</td>")
            tr.append("<td>" + e.Room + "</td>")
            tr.append("<td>" + e.BedNumber + "</td>")
            // tr.append("<td><input type='checkbox' class='ignorebed' id='ignore" + i + "' data-empid='" + e.EmployeeID + "'></td>")
            DuplicateTable.append(tr);

        })
        $("#tdDuplicateBeds").append(DuplicateTable)
        $("#tdDuplicateBeds").append($('<button class="btn btn-sm btn-primary" onclick="AssignEmployeeBeds()">Unlink and Continue Assignment </button>'))
    } else {
        SaveRoomBedPlan(Beds);
    }
    


}

function AssignEmployeeBeds() {
    var UnlinkedBeds = [];
    var IgnoreBeds = [];
    var Beds = [];
    $.each($(".unlinkbed:checked"), function (i, c) {
        UnlinkedBeds.push(parseInt($(this).attr("data-empid")));
    })
    $.each($(".unlinkbed"), function (i, c) {
        if(!$(this).prop("checked"))
            IgnoreBeds.push(parseInt($(this).attr("data-empid")));
    })

    $.each($("#trBeds > table > tbody > tr"), function (i, tr) {
        if (!IgnoreBeds.includes(parseInt($($(tr).find("select")[0]).val()))) {
            if ( Beds.find(x => x.EmployeeID == parseInt($($(tr).find("select")[0]).val())) == null)
                Beds.push({ AppartmentID: Room.AppartmentID, RoomNumber: Room.RoomNumber, BedNumber: (i + 1), EmployeeID: parseInt($($(tr).find("select")[0]).val()) })
            else
                Beds.push({ AppartmentID: Room.AppartmentID, RoomNumber: Room.RoomNumber, BedNumber: (i + 1), EmployeeID: 0 })
        }
    })

    SaveRoomBedPlan(Beds);
}
function SaveRoomBedPlan(Beds) {

    Post("/Accommodation/AssignRoomBeds", {
        beds: Beds
    }).done(function (resp) {
        ShowBuildings();
        });
    EditRoomPlanData = [];
}

function EditRoomPlan(RoomNumber, AppartmentID) {
    EditRoomPlanData = Buildings.Rooms.filter(x => x.RoomNumber == RoomNumber && x.AppartmentID == AppartmentID);
    EditRoomPlanData.sort(function (a, b) {
        return parseInt(a.BedNumber) - parseInt(b.BedNumber);
    });


    SetvalOf("txtNoOfBeds", EditRoomPlanData.length);
    $("#txtNoOfBeds").trigger("blur");

    var Appt = Buildings.Appartments.find(x => x.ID = AppartmentID);
    var build = Buildings.Buildings.find(x => x.ID == Appt.BuildingID);

    $("#dvRoomPlanText").text("Building - " + build.Name + " Floor #" + Appt.FloorNumber + " Room #" + (RoomNumber) + " Plan");
    $("#dlgNewAppartmentRoom").modal("show");
    Room = { AppartmentID: AppartmentID, BuildingID: build.ID, FloorNumber: Appt.FloorNumber, RoomNumber: RoomNumber };
    

}

function SaveAppartmentPlan() {
    var appartmentrooms = $(".appartmentroom");
    var DuplEmployee = [];
    var Beds = [];
    $.each(appartmentrooms, function (i, room) {
        $.each($(room).find(".appartmentroomplan > tbody >tr"), function (b, tr) {
            if (parseInt($($(tr).find("select")[0]).val())>0 && Buildings.Rooms.filter(x => x.EmployeeID == parseInt($($(tr).find("select")[0]).val())).length > 0) {
                var EmpBed = Buildings.Rooms.find(x => x.EmployeeID == parseInt($($(tr).find("select")[0]).val()));
                var Appt = Buildings.Appartments.find(x => x.ID = EmpBed.AppartmentID);
                var build = Buildings.Buildings.find(x => x.ID == Appt.BuildingID);
                DuplEmployee.push({ EmployeeID: EmpBed.EmployeeID, BuildingName: build.Name, Floor: Appt.FloorNumber, AppartmentNumber: Appt.AppartmentNumber, Room: EmpBed.RoomNumber, BedNumber: EmpBed.BedNumber });
                $(tr).find("td:eq(2)").text("Employee " + EmpBed.EmployeeID + " has already have a bed assigned in building " + build.Name + " Floor #:" + Appt.FloorNumber + " Appartment #:" + Appt.AppartmentNumber + " Room#:" + EmpBed.RoomNumber + " Bed #:" + EmpBed.BedNumber);
                
            }
            else {
                $(tr).find("td:eq(2)").text("")
            }
            if (Beds.find(x => x.EmployeeID == parseInt($($(tr).find("select")[0]).val())) == null)
                Beds.push({ AppartmentID: 0, RoomNumber: i + 1, BedNumber: (b + 1), EmployeeID: parseInt($($(tr).find("select")[0]).val()) })
           else
                Beds.push({ AppartmentID: 0, RoomNumber: i+1, BedNumber: (b + 1), EmployeeID: 0 })
        });
    })
    if (DuplEmployee.length > 0) {
        swal("Please check the duplicate room assignments and try again", { icon: "error" });
        return false;
    }
    Post("/Accommodation/AssignAppartmentPlan", { appertment: NewAppartmentPlan, beds: Beds}).done(function (resp) {
        ShowBuildings();
        NewAppartmentPlan = {}
    });
}