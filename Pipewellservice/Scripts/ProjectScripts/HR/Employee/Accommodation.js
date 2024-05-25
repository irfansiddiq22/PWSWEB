var Buildings = [];
var Employees = [];
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
    Post("/Accommodation/ListBuilding", {}).done( function (resp) {
        Buildings = resp;
        $.each(resp.Buildings, function (i, b) {
            $('<button class="nav-link active" id="nav-building-tab-' + b.ID + '" data-bs-toggle="tab" data-bs-target="#nav-building-tab-content-' + b.ID + '" type="button" role="tab" aria-controls="#nav-building-tab-content-' + b.ID + '" aria-selected="true">' + b.Name + '</button>').insertBefore($("#nav-add-building"))
            CreateBuildingContainer(b);
        })
        $('.rooms').each(function () {
            $(this).treegrid({
                expanderExpandedClass: 'fa fa-minus',
                expanderCollapsedClass: 'fa fa-plus',
                initialState: 'expanded'
            });
        })
        
    })


}
function CreateBuildingContainer(b) {
    var dv = $('<div class="tab-pane fade active show building" id="nav-building-tab-content-' + b.ID + '" role="tabpanel" aria-labelledby="nav-building-tab-content-' + b.ID + '"></div>')
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

    $.each(Buildings.Appartments.filter(x => x.BuildingID == ID && x.FloorNumber == i), function (i,apt) {
        aptRow.append(CreateAppartment(apt));

    });
    $(aptTable).append($(aptRow));
    aptRow = $('<tr>')
    $(aptRow).append($('<td>').append($('<button class="btn btn-sm btn-primary" onclick="AddNewAppt('+ ID +',' + i  + ')">').text("Add Appartment")));
    $(aptTable).append($(aptRow));

    ftr.append($('<td>').append($(aptTable)));



    FloorTable.append($(ftr));
    return FloorTable;
}
function CreateAppartment(appt) {
    var Table = $('<table  class="table w-100 table-bordered building-floor-apt-' + appt.BuildingID + '-' + appt.FloorNumber +'"><tbody>');
    var tr = $('<tr>');
    tr.append($('<td  width="20%" class="align-middle">').text("Appartment " + appt.AppartmentNumber));


    var aptTable = $('<table  class="table w-100 table-bordered" id="building-floor-' + (appt.ID) + 'apt"><tbody>');
    var Row = $('<tr>')
    $(Row).append($('<td>').append(CreateRooms(appt.NoOfRoom, appt.ID)));
    $(aptTable).append($(Row));

    Row = $('<tr>')
    $(Row).append($('<td>').append($('<button class="btn btn-sm btn-primary" onclick="AddNewRoom(' + appt.ID + ',' + appt.BuildingID +',' + appt.FloorNumber + ')">').text("Add Room")));
    $(aptTable).append($(Row));

    tr.append($('<td>').append($(aptTable)));

    Table.append($(tr));
    return Table;

}
function CreateRooms(RoomCount,AppartmentID) {

    var table = $('<table class="table table-sm w-100 rooms">');
    var treegrid = 1;
    for (i = 1; i <= RoomCount; i++) {

        var tr = $('<tr class="rooms' + AppartmentID + '" data-id="' + i + '" class="permissiongroup treegrid-' + treegrid + '">')
        tr.append($('<td>').text("Room " + i));
        $(table).append(tr);
        var tparent = treegrid;
        var Beds = Buildings.Rooms.filter(x => x.AppartmentID == AppartmentID && x.RoomNumber==i);
        $.each(Beds, function (j, r) {
            treegrid++;
            var tr = $('<tr  data-id="' + i + '" class="treegrid-parent-' + tparent +'">')
            tr.append($('<td>').text("Bed #:" + r.BedNumber + " Employee ID:" + r.EmployeeID));
            $(table).append(tr);
            
        })


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
function AddNewAppt(BuildingID, FloorNumber) {
    //$("#dlgNewAppartment").modal("show");
    $("#dvBuildingPlan").addClass("d-none")
    $("#dvAppartmentPlan").removeClass("d-none")
    $("#trRooms").empty();
    $("#dvAppartmentLabel").text("Building - " + $("#building-" + BuildingID).text() + " Floor #" + FloorNumber + " Plan");

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
function CreateRoomPlan(sender) {
    var NumberofRoom = $(sender).val();
    var dv = $('<div>').addClass("row");

    for (i = 1; i <= NumberofRoom; i++) {
        var roomdv = $('<div>').addClass("col-md-6");
        var roomtable = $('<table class="table table-sm w-100 table-bordered"><tbody>');
        var tr = $('<tr>')
        tr.append($('<td class="blue p-2" colspan="2">').text("Room #" + i));
        roomtable.append(tr);
         tr = $('<tr>')
        tr.append($('<td width="23%">').html("<strong># of Beds:</strong>"));
        tr.append($('<td>').append($("<input type='number' class='form-control form-control-sm' onblur='AddRoomPlan(this,"+ i +")'>")));
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
    var tbed = $('<table class="table table-sm w-100 table-bordered"><tbody>');
    for (i = 1; i <= NoofBeds; i++) {

        var tr = $('<tr>')
        tr.append($('<td>').append("<strong>Bed " + i +"</strong>"))
        tr.append($('<td>').append($(CreateEmployeeList(room))))
        tbed.append(tr)

    }
    $("#roomPlan" + room).empty().append(tbed);

    $(".selectemployee" + room).select2({
        placeholder: "Select employee",
        allowClear: true,
        width: '100%',
        data: Employees
    })
}

function AddNewRoom(AppartmentID, BuildingID,FloorNumber) {
    var Rooms = $(".rooms" + AppartmentID).length;
    $("#dvRoomPlanText").text("Building - " + $("#building-" + BuildingID).text() + " Floor #" + FloorNumber + " Room #" + (Rooms+1) + " Plan");
    $("#dlgNewAppartmentRoom").modal("show");
}

function CreateEmployeeBeds(sender, n) {
    var NoofBeds = $(sender).val();
    var tbed = $('<table class="table table-sm w-100"><tbody>');
   
    for (i = 1; i <= NoofBeds; i++) {
        
        var tr = $('<tr>')
        tr.append($('<td>').text("Bed " + i))
        tr.append($('<td>').append($(CreateEmployeeList(''))))
        tbed.append(tr)

    }
    $("#" + n).empty().append(tbed);
    $(".selectemployee").select2({
        placeholder: "Select employee",
        allowClear: true,
        width: '100%',
        data: Employees
    })
}
function CreateEmployeeList(id) {
    var Select = $('<select class="form-select form-select-sm selectemployee'+ id +'">')
    
    return $(Select);
}