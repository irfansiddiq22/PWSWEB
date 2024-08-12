
function _Init() {
    HideSpinner();

    SetPagePermission(PAGES.SparePartItems, function () {


        $("#frmSpartPartItems").validate()

        $.each($("select[data-msg]"), function (i, c) {
            $(this).attr("name", $(this).attr("id"));

            if ($(this).attr("data-min")) {
                $(this).rules("add", {
                    required: true,
                    min: 1,
                    messages: {
                        required: $(this).attr("msg"),
                        min: $(this).attr("msg")
                    }

                });
            }
            else {
                $(this).rules("add", {
                    required: true,
                    messages: {
                        required: $(this).attr("msg"),
                    }

                });
            }

        });
        $.each($(":text[data-msg]"), function (i, c) {
            $(this).attr("name", $(this).attr("id"));
            if ($(this).attr("data-min")) {
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
        ListItems();
    });
}
function ListItems() {
    ResetChangeLog(PAGES.ProcurementStoreItem);

    $('#dvSparepartItemPaging').pagination({
        dataSource: "/EquipmentsAPI/SpacePartItem/List",
        pageSize: pageSize,
        pageNumber: 1,
        showGoInput: true,
        showGoButton: true,
        locator: function (response) {
            return 'Data';
        },
        totalNumberLocator: function (response) {
            return response.TotalRecord;
        },

        ajax: {
            type: "POST",
            dataType: "json",
            data: {
                PartNumber: valOf("txtSearchPartNumber"),
                Application: valOf("txtSearchPartApplication"),
                PartName: valOf("txtSearchPartName")
            },
            beforeSend: function () {
                ShowSpinner();
            }
        },
        callback: function (data, pagination) {
            HideSpinner();
            Items = data;
            SetvalOf("txtItemCode", data.length > 0 ? data[0].NextCode : 0);
            MaxID = data.length > 0 ? data[0].NextCode : 0;
            $("#tblStoreItemList").empty();
            $.each(data, function (i, r) {
                var tr = $('<tr>')
                tr.append($('<td>').text(r.ItemCode))
                tr.append($('<td>').append(r.Name))

                tr.append($('<td>').append(r.Unit))

                tr.append($('<td>').append(r.OpeningStock));
                tr.append($('<td>').append(r.ReOrderLimit));
                tr.append($('<td>').append(r.Location))
                tr.append($('<td>').append(r.Packing))
                tr.append($('<td>').append(r.PartNumber))
                tr.append($('<td>').append(r.StockItem ? "Yes" : "NO"))
                tr.append($('<td>').append(r.CreticalItem ? "Yes" : "NO"))
                tr.append($('<td>').append(r.Active ? "Yes" : "NO"))
                tr.append($('<td>').append(r.Tengible ? "Yes" : "NO"))

                var Icons = $('<div class="icons">');
                $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary writeble me-2" onclick="EditItem(' + i + ')"><i class="fa fa-edit"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger deleteble" onclick="DeleteItem(' + i + ')"><i class="fa fa-trash"></i></a>'));
                tr.append($('<td>').append($(Icons)));


                $("#tblStoreItemList").append(tr);

            });


        }
    })

}

function SaveItem() {
    ResetChangeLog(PAGES.SparePartItems);
    if ($("#frmSpartPartItems").valid()) {
        alert("valid")
        var SparePartItem = {
            PartNumber: valOf("txtSparePartNumber"),
            PartName: valOf("txtSparePartName"),
            Application: valOf("txtSparePartApplication"),
            Alternatives: valOf("txtSparePartAlternative"),
            PurchasePrice: valOf("txtSparePartPurchasePrice"),
            SalesPrice: valOf("txtSparePartSalesPrice"),
            ReOrderLimit: valOf("txtSparePartReOrderLimit"),
            Notes: valOf("txtNotes"),
            InventoryPart: GetChecked("chkInventoryPart"),
            PartGroup: valOf("txtSparePartPurchasePartGroup"),
            Location: valOf("txtSparePartLocation"),
        };
        

        Post("/EquipmentsAPI/SpacePartItem/SaveItem", { item: SparePartItem }).done(function (resp) {
            if (resp.ID > 0) {
                document.getElementById("frmSpartPartItems").reset();
                swal("Item added successfully", { icon: "success" });
            } else {
                swal("failed to add Item ", { icon: "error" });
            }
        })
        return false;
    }
    /*
    $("#frmSpartPartItems").validate({
        errorClass: "text-danger",

        rules: {
            PartNumber: "required",
            PartName: "required",
            Application: "required",
            Alternatives: "required",
            Location: "required",
            PurchasePrice: {
                required: true,
                min: 0.01,
            },
            SalesPrice: {
                required: true,
                min: 0.01,
            },
            ReOrderLimit: {
                required: true,
                min: 0,
            },
            PartGroup:"required"
        },
        messages: {
            PartNumber: "Please enter part number",
            PartName: "Please enter part name",
            Application: "Please enter application",
            Alternatives: "Please enter alternatives",
            Location: "Please enter location",
            PurchasePrice: {
                required: "Please enter purchase price",
                min: "Please enter purchase price",
            },
            SalesPrice: {
                required: "Please enter sales price",
                min: "Please enter sales price",
            }, ReOrderLimit: {
                required: "Please enter reorder limit",
                min: "Please enter reorder limit",
            },
            PartGroup:"Please enter part group"
        },

        submitHandler: function (form) {
            swal("form validated");

            return false;
            if (Inquiry.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: textOf("ddEmployeeName") } });
            } else {
                DataChangeLog.DataUpdated = [];

                if (moment(Inquiry.InquiryDate).format("DD/MM/YYYY") != valOf("txtInquiryDate")) {
                    DataChangeLog.DataUpdated.push({ Field: "InquiryDate", Data: { OLD: Inquiry.InquiryDate, New: valOf("txtInquiryDate") } });
                }

                if (Inquiry.EmployeeID != valOf("ddEmployeeName")) {
                    DataChangeLog.DataUpdated.push({ Field: "Employee", Data: { OLD: Inquiry.EmployeeID, New: valOf("ddEmployeeName") } });
                }

                if (Inquiry.EmployeeID != GetChecked("chkInquiryPersonal")) {
                    DataChangeLog.DataUpdated.push({ Field: "PersonalInquiry", Data: { OLD: Inquiry.PersonalInquiry, New: GetChecked("chkInquiryPersonal") } });
                }
                if (Inquiry.GeneralInquiry != GetChecked("chkInquiryGeneral")) {
                    DataChangeLog.DataUpdated.push({ Field: "GeneralInquiry", Data: { OLD: Inquiry.GeneralInquiry, New: GetChecked("chkInquiryGeneral") } });
                }
                if (Inquiry.LoanInquiry != GetChecked("chkInquiryLoan")) {
                    DataChangeLog.DataUpdated.push({ Field: "LoanInquiry", Data: { OLD: Inquiry.LoanInquiry, New: GetChecked("chkInquiryLoan") } });
                }


                for (i = 1; i <= 4; i++) {
                    if (i <= Inquiry.Approvals.length) {
                        if (Inquiry.Approvals[i - 1].DivisionID != valOf("ddSupervisorApproval" + (i))) {
                            if (valOf("ddSupervisorApproval" + (i)) == 0)
                                DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: Inquiry.Approvals[i - 1].Name, New: "-" } });
                            else
                                DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: Inquiry.Approvals[i - 1].Name, New: textOf("ddSupervisorApproval" + (i)) } });
                        }
                    } else if (valOf("ddSupervisorApproval" + (i)) > 0) {
                        DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: "-", New: textOf("ddSupervisorApproval" + (i)) } });
                    }

                }

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
                PriorityLevelID: valOf("ddlPriorityLevel"),
                Approvals: []
            };

            for (i = 1; i <= 4; i++) {
                if (valOf("ddSupervisorApproval" + (i)) > 0) {
                    NewInquiry.Approvals.push({ ID: i, DivisionID: parseInt(valOf("ddSupervisorApproval" + (i))) });
                }
            }
            var PriorityLevel = PriorityLevels.find(x => x.ID = NewInquiry.PriorityLevel)
            Post("/EmployeeAPI/UpdateEmployeeInquiry", { Inquiry: NewInquiry }).done(function (ID) {
                if (ID > 0) {

                    Inquiry.ID = ID;

                    SaveLog(ID);

                    var fileUpload = $('#InquiryFile').get(0);
                    var files = fileUpload.files;
                    if (files.length > 0) {

                        UploadFile("/EmployeeAPI/UpdateEmployeeInquiryFile", files[0], { EmployeeID: NewInquiry.EmployeeID, ID: ID }, function (Status, Response) {


                            if (Status == 1) {

                                if (NewInquiry.ID > 0)
                                    swal("Employee request record added", { icon: "success" })
                                else
                                    swal("Employee request updated", { icon: "success" })

                                ProcessInquiryMail(NewInquiry, PriorityLevel);
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
                            swal("Employee request updated", { icon: "success" })

                        ProcessInquiryMail(NewInquiry, PriorityLevel);
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
    */
}