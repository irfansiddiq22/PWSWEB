var SponsorData = [];
var Sponsor = {};
function LoadSponsor() {
    Post("/DataList/SponsorList", {}).done(function (resp) {
        SponsorData = resp;
        FillSponsorList();
    })
    $("#frmSponsor").validate({
        errorClass: "text-danger",
        rules: {
            txtSponsorName: "required",
            txtSponsorCR: "required",
        },
        messages: {
            txtSponsorName: "Please enter sponsor Name",
            txtSponsorCR: "Please enter sponsor CR",
            
        }
    });
}
function ShowSponsorList() {
    $("#frmSponsor").validate()
    $("#dlgSponsorList").modal("show")
}
function AddSponsorData() {
    ShowSponsorList();
    EditSponsor(0)
    Sponsor = { ID: 0 };
    SetvalOf("txtSponsorName", "");
    SetvalOf("txtSponsorCR", "");
}
function EditSponsorData() {

    ShowSponsorList();
    EditSponsor(valOf("ddEmployeeSponsor"));
}
function EditSponsor(ID) {
    ID = parseInt(ID);
    if (ID == 0) return;
        Sponsor = SponsorData.find(x => x.ID == ID);
        SetvalOf("txtSponsorName", Sponsor.Name);
        SetvalOf("txtSponsorCR", Sponsor.CRNumber);
}
function SaveSponsor() {


    if ($("#frmSponsor").valid()) {


        ResetChangeLog(PAGES.Sponsor);
        var NewData = {
            ID: Sponsor.ID,
            Name: valOf("txtSponsorName"),
            CRNumber: valOf("txtSponsorCR")
        };

        if (Sponsor.ID == 0) {
            DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: valOf("txtSponsorName") } });
        } else {
            jQuery.each(NewData, function (name, value) {
                if ($.trim(value) != $.trim(Sponsor[name])) {
                    DataChangeLog.DataUpdated.push({ Field: name, Data: { OLD: Sponsor[name], New: $.trim(value) } });
                }
            });

        }

        Post("/EmployeeAPI/UpdateSponsor", { Sponsor: NewData }).done(function (resp) {
            SaveLog(Sponsor.ID);
            LoadSponsor();

            Sponsor = {ID:0}
            SetvalOf("txtSponsorName", "");
            SetvalOf("txtSponsorCR", "");
        })
    }
}