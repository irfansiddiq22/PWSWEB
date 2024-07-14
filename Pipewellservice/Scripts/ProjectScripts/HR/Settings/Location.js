var LocationData = [];
var Location = {};
function LoadLocations() {
    Post("/DataList/LocationList", {}).done(function (resp) {
        LocationData = resp;
        FillLocationList();
    })
    $("#frmLocation").validate({
        errorClass: "text-danger",
        rules: {
            txtLocationName: "required",
        },
        messages: {
            txtLocationName: "Please enter Location Name",
            
        }
    });
}
function ShowLocationList() {
    $("#frmLocation").validate()
    $("#dlgLocationList").modal("show")
}
function AddLocationData() {
    ShowLocationList();
    EditLocation(0)
    Location = { ID: 0 };
    SetvalOf("txtLocationName", "");
}
function EditLocationData() {

    ShowLocationList();
    EditLocation(valOf("ddEmployeeLocation"));
}
function EditLocation(ID) {
    ID = parseInt(ID);
    if (ID == 0) return;
        Location = LocationData.find(x => x.ID == ID);
        SetvalOf("txtLocationName", Location.Name);
}
function SaveLocation() {


    if ($("#frmLocation").valid()) {


        ResetChangeLog(PAGES.Location);
        var NewData = {
            ID: Location.ID,
            Name: valOf("txtLocationName"),
        };

        if (Location.ID == 0) {
            DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: valOf("txtLocationName") } });
        } else {
            jQuery.each(NewData, function (name, value) {
                if ($.trim(value) != $.trim(Location[name])) {
                    DataChangeLog.DataUpdated.push({ Field: name, Data: { OLD: Location[name], New: $.trim(value) } });
                }
            });

        }

        Post("/EmployeeAPI/UpdateLocation", { Location: NewData }).done(function (resp) {
            SaveLog(Location.ID);
            LoadLocations();
            Location = {ID:0}
            SetvalOf("txtLocationName", "");
        })
    }
}