var Items = [];
var Item = { ID: 0 };
var MaxID = 0;
function _Init() {
    HideSpinner();
    pageNumber = 1
    $("#ddItemCodeAbv").empty();
    var a = [], i = 'A'.charCodeAt(0), j = 'Z'.charCodeAt(0);
    for (; i <= j; ++i) {
        $("#ddItemCodeAbv").append(AppendListItem(String.fromCharCode(i), String.fromCharCode(i)));
    }

    SetPagePermission(PAGES.ProcurementStoreItem, function () {
        FillItemUnits();
        FillStoreItems();
    });

}
function FillItemUnits() {
    $.post("/ProcurementAPI/GetStoreItemUnit", {}, function (resp) {
        FillList("ddItemUnits", resp, "Unit", "Unit", "");
    })
}
$('form').on('reset', function (e) {
    setTimeout(function () { SetvalOf("txtItemCode", MaxID); }, 1000);
});
function FillStoreItems() {

    document.getElementById("frmItemManagement").reset();
    SetvalOf("txtItemCode", MaxID);
    $("#tblStoreItemList").empty();





    ResetChangeLog(PAGES.ProcurementStoreItem);

    $('#dvStoreItemPaging').pagination({
        dataSource: "/ProcurementAPI/GetStoreItemList",
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
                Name: $("#txtFindStoreItem").val()
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
function EditItem(Index) {
    Item = Items[Index];
    var Code = Item.ItemCode;
    SetvalOf("ddItemCodeAbv", Code.substring(0, 1));
    SetvalOf("txtItemCode", Code.substring(1))
    SetvalOf("txtItemName", Item.Name)
    SetvalOf("txtItemPart", Item.PartNumber)
    SetvalOf("txtItemLocation", Item.Location)
    SetvalOf("txtItemUnit", Item.Unit);
    SetvalOf("txtItemStockQty", Item.OpeningStock)
    SetvalOf("txtItemReOrderLimit", Item.ReOrderLimit);
    SetvalOf("txtItemPacking", Item.Packing);
    SetvalOf("ddItemType", Item.Tengible ? 1 : 2);
    SetChecked("ChkStockItem", Item.StockItem);
    SetChecked("ChkCriticalItem", Item.CreticalItem);
    SetChecked("ChkActiveItem", Item.Active);
}
function DeleteItem(Index) {
    SwalConfirm("Are you sure to delete this record ?", function () {

    })
}

function SaveItem() {
    $("#frmItemManagement").validate({
        errorClass: "text-danger",

        rules: {
            ItemName: "required",
            ItemUnit: "required",
            ItemStockQty: "required",
            ItemReOrderLimit: "required",


        },
        messages: {
            ItemName: "Please enter item Name",
            ItemUnit: "Please enter unit",
            ItemStockQty: "Please enter stock quantity",
            ItemReOrderLimit: "Please enter reorder limit",

        },
        submitHandler: function (form) {
            if (Item.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: textOf("txtItemName") } });
            }


            var NewItem = {
                ID: Item.ID,
                ItemCode: valOf("ddItemCodeAbv") + valOf("txtItemCode"),
                Name: valOf("txtItemName"),
                Unit: valOf("txtItemUnit"),
                OpeningStock: valOf("txtItemStockQty"),
                ReOrderLimit: valOf("txtItemReOrderLimit"),
                Packing: valOf("txtItemPacking"),
                Location: valOf("txtItemLocation"),
                PartNumber: valOf("txtItemPart"),
                StockItem: GetChecked("ChkStockItem"),
                CreticalItem: GetChecked("ChkCriticalItem"),
                Active: GetChecked("ChkActiveItem"),
                Tengible: valOf("ddItemType"),
                Image: ''
            };



            var fileUpload = $('#ItemFile').get(0);
            var files = fileUpload.files;
            if (files.length > 0) {
                NewItem.Image = files[0].FileName;
            }
            Post("/ProcurementAPI/AddStoreItem", { item: NewItem }).done(function (ID) {
                if (ID > 0) {

                    Item.ID = ID;

                    if (files.length > 0) {

                        UploadFile("/ProcurementAPI/UpdateItemFile", files[0], { ID: ID }, function (Status, Response) {


                            if (Status == 1) {

                                if (NewItem.ID > 0)
                                    swal("Item record added", { icon: "success" })
                                else
                                    swal("Item record updated", { icon: "success" })

                                FillStoreItems()

                            } else {

                                swal("Failed to upload item file.", { icon: "error" })
                            }
                        });
                    }
                    else {

                        if (NewItem.ID > 0)
                            swal("Item record added", { icon: "success" })
                        else
                            swal("Item record updated", { icon: "success" })
                        FillStoreItems();
                    }
                } else {
                    swal("Failed to update item.", { icon: "error" })
                }

            })
            return false;
        }
    });




}

