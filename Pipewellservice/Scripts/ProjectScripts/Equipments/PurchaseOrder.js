var Items = []
var OrderToEdit = {};
function _Init() {
	HideSpinner();
	$("#txtRecordCreatedBy").val(User.Name);
	$('.datepicker').val(moment().format("DD/MM/YYYY"));
	BindSparePartRequestSearch();
	SetPagePermission(PAGES.EquipmentOrderForm, function () {
		BindLists();

		$("#txtOrderDateFilter").val(moment().subtract(3, 'month').startOf('month').format("DD/MM/YYYY") + ' - ' + moment().endOf('month').format("DD/MM/YYYY"))
		$("#frmPurchaseOrderForm").validate()

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
		ListOrders();

	});
}
function BindLists() {

	$.post("/DataList/SupplierList", {}, function (Response) {
		$("#ddSuppliers,#ddSupplierFilter").empty();
		var data = []
		if (Response.length > 1) data.push({ id: 0, text: 'Select Supplier' });
		$.each(Response, function (i, s) {
			data.push({ id: s.Code, text: s.Code + " - " + s.Name });
		})
		$("#ddSuppliers,#ddSupplierFilter").select2({
			placeholder: "Select Supplier",
			allowClear: true,
			data: data,
			width: "100%"
		})

	})
	$.post("/DataList/EquipmentPurchaseOrderStatus", {}, function (Response) {
		$("#ddStatus").empty();
		var types = []
		types.push({ id: 0, text: 'Select Status' });

		$.each(Response, function (i, s) {
			types.push({ id: s.Value, text: s.Name });
		})
		$("#ddStatus").select2({

			placeholder: "Select Status",
			allowClear: true,
			data: types,
			width: "100%"
		})


	})

	$.post("/EquipmentsAPI/EquipmentPurchaseOrder/OrderListData", {}, function (Response) {
	    FillList("shippingmenthodlistOptions", Response.ShipmentMethods, "Value", "Value", "#")
	    FillList("shippingInstructionslistOptions", Response.ShippingInstructions, "Value", "Value", "#")
	    FillList("NotifyInstructionsListOptions", Response.NotifyInstructions, "Value", "Value", "#")
	    FillList("ItemShippingMethodListOptions", Response.ItemShipmentMethods, "Value", "Value", "#")
	    FillList("ItemCurrencyListOptions", Response.Currency, "Value", "Value", "#")



	})


}
function ListOrders() {
	ResetChangeLog(PAGES.EquipmentOrderForm);
	$("#dvEdit").hide();


	var StartDate = "", EndDate = "";
	if (valOf("txtOrderDateFilter") != "") {
	    StartDate = $.trim(valOf("txtOrderDateFilter").split("-")[0]);
	    EndDate = $.trim(valOf("txtOrderDateFilter").split("-")[1]);
	}
	document.getElementById("frmPurchaseOrderForm").reset();
	$("#dvList").show();
	$('#dvPaging').pagination({
	    dataSource: "/EquipmentsAPI/EquipmentPurchaseOrder/List",
		pageSize: pageSize,
		pageNumber: 1,
		showGoInput: true,
		showGoButton: true,
		locator: function (response) {
			return 'List';
		},
		totalNumberLocator: function (response) {
		    $("#txtorderId").val(response.ID + 1);
			return response.List.length == 0 ? 0 : response.List[0].Total;
		},

		ajax: {
			type: "POST",
			dataType: "json",
			data: {
				StartDate: StartDate,
				EndDate: EndDate,
				SupplierID: valOf("ddSupplierFilter"),
				OrderID: valOf("txtOrderIDFilter"),
				PONO: valOf("txtPONONumberFilter")
			},
			beforeSend: function () {
				ShowSpinner();
			}
		},
		callback: function (data, pagination) {
			HideSpinner();
			$("#tblList").empty();
			
			$.each(data, function (i, r) {
				var tr = $('<tr>')
				tr.append($('<td>').text(r.ID))
				tr.append($('<td>').text(r.SupplierName))
				tr.append($('<td>').append(r.OrderID))
				tr.append($('<td>').append(moment(r.OrderDate).format("DD/MM/YYYY")));

				tr.append($('<td>').append(r.PONO))
				tr.append($('<td>').append(r.ShipmentMethod))
				tr.append($('<td>').append(r.BackOrderTo))
				tr.append($('<td>').append(r.ShippingInstructions))
				tr.append($('<td>').append(r.PaymentTerms))

				tr.append($('<td>').append(r.RecordCreatedByName))


				var Icons = $('<div class="icons">');
				$(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary writeble me-2" onclick="EditOrder(' + r.ID + ')"><i class="fa fa-edit"></i></a>'));
				$(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger deleteble" onclick="DeleteItem(' + i + ')"><i class="fa fa-trash"></i></a>'));
				tr.append($('<td>').append($(Icons)));


				$("#tblList").append(tr);

			});


		}
	})

}

function SaveOrder() {
	ResetChangeLog(PAGES.EquipmentOrderForm);
	if ($("#frmPurchaseOrderForm").valid()) {

		var Order = {
			ID: OrderToEdit.ID,
			SupplierID: valOf("ddSuppliers"),
			Status:valOf("ddStatus"),
			OrderDate: valOf("txtorderDate"),
			OrderID:valOf("txtorderId"),
			PONO: valOf("txtpono"),
			BackOrderTo: valOf("txtbackOrderTo"),
			PaymentTerms: valOf("txtPaymentTerms"),
			ShipmentMethod: valOf("txtShipmentMethod"),
			ShippingInstructions: valOf("txtShippingInstructions"),
			DocumentRequired: valOf("ddDocumentRequired"),
			NotifyInstructions: valOf("txtNotifyInstructions")
		};
		
		var valid = true;
		Order.Items = Array.from(document.getElementById('tblItems').rows).map(row => ({
			SparePartItemID: parseInt($(row).attr("data-id")),
			Description: $(row.cells[2]).find(":input").val(),
			Quantity: parseInt($(row.cells[3]).find(":input").val()),
			UnitPrice: parseFloat($(row.cells[4]).find(":input").val()),
			ShippingMethod	: $(row.cells[7]).find(":input").val(),
			Currency: $(row.cells[8]).find(":input").val(),
			Received: $(row.cells[9]).find(":checkbox").prop("checked"),

		}));


		if (Order.ID == 0) {
			DataChangeLog.DataUpdated.push({ Field: "SupplierID", Data: { OLD: "", New: textOf("SupplierID") } });
			DataChangeLog.DataUpdated.push({ Field: "PONO", Data: { OLD: "", New: textOf("txtpono") } });
            DataChangeLog.DataUpdated.push({ Field: "OrderID", Data: { OLD: "", New: textOf("txtorderId") } });
		}
		else {
			DataChangeLog.DataUpdated = [];
			/*
            if (OrderToEdit.PartNumber != SparePartItem.PartNumber) {
                DataChangeLog.DataUpdated.push({ Field: "Part Number", Data: { OLD: OrderToEdit.PartNumber, New: SparePartItem.PartNumber } });
            }

            if (OrderToEdit.PartName != SparePartItem.PartName) {
                DataChangeLog.DataUpdated.push({ Field: "Part Name", Data: { OLD: OrderToEdit.PartName, New: SparePartItem.PartName } });
            }

            if (OrderToEdit.Application != SparePartItem.Application) {
                DataChangeLog.DataUpdated.push({ Field: "Application", Data: { OLD: OrderToEdit.Application, New: SparePartItem.Application } });
            }

            if (OrderToEdit.Alternatives != SparePartItem.Alternatives) {
                DataChangeLog.DataUpdated.push({ Field: "Alternatives", Data: { OLD: OrderToEdit.Alternatives, New: SparePartItem.Alternatives } });
            }

            if (OrderToEdit.PurchasePrice != SparePartItem.PurchasePrice) {
                DataChangeLog.DataUpdated.push({ Field: "PurchasePrice", Data: { OLD: OrderToEdit.PurchasePrice, New: SparePartItem.PurchasePrice } });
            }
            if (OrderToEdit.SalesPrice != SparePartItem.SalesPrice) {
                DataChangeLog.DataUpdated.push({ Field: "SalesPrice", Data: { OLD: OrderToEdit.SalesPrice, New: SparePartItem.SalesPrice } });
            }
            if (OrderToEdit.ReOrderLimit != SparePartItem.ReOrderLimit) {
                DataChangeLog.DataUpdated.push({ Field: "ReOrderLimit", Data: { OLD: OrderToEdit.ReOrderLimit, New: SparePartItem.ReOrderLimit } });
            }
            if (OrderToEdit.Notes != SparePartItem.Notes) {
                DataChangeLog.DataUpdated.push({ Field: "Notes", Data: { OLD: OrderToEdit.Notes, New: SparePartItem.Notes } });
            }   

            if (OrderToEdit.InventoryPart != SparePartItem.InventoryPart) {
                DataChangeLog.DataUpdated.push({ Field: "InventoryPart", Data: { OLD: OrderToEdit.InventoryPart, New: SparePartItem.InventoryPart } });
            }
            if (OrderToEdit.PartGroup != SparePartItem.PartGroup) {
                DataChangeLog.DataUpdated.push({ Field: "PartGroup", Data: { OLD: OrderToEdit.PartGroup, New: SparePartItem.PartGroup } });
            }
            if (OrderToEdit.Notes != SparePartItem.Location) {
                DataChangeLog.DataUpdated.push({ Field: "Location", Data: { OLD: OrderToEdit.Location, New: SparePartItem.Location } });
            }
            */

		}



		Post("/EquipmentsAPI/EquipmentPurchaseOrder/SaveOrder", { order: Order }).done(function (resp) {
			if (resp.ID > 0) {
				document.getElementById("frmPurchaseOrderForm").reset();
				SaveLog(resp.ID);
				$("#tblItems").empty();
				swal("order saved successfully", { icon: "success" });
				NewOrder();
				ListOrders();
			} else {
				swal("failed to save order ", { icon: "error" });
			}
		})
		return false;
	}
}

function EditOrder(ID) {
	NewOrder();
	Post("/EquipmentsAPI/EquipmentPurchaseOrder/Detail", { ID: ID }).done(function (resp) {
		OrderToEdit = resp;
        
	    SetvalOf("ddSuppliers", OrderToEdit.SupplierID).trigger("change");
	    SetvalOf("ddStatus", OrderToEdit.Status).trigger("change");

	    SetvalOf("txtPaymentTerms", OrderToEdit.PaymentTerms);
		SetvalOf("txtpono", OrderToEdit.PONO);
		SetvalOf("txtorderDate", moment(OrderToEdit.OrderDate).format("DD/MM/YYYY"));
        SetvalOf("txtorderId", OrderToEdit.OrderID);

		SetvalOf("txtbackOrderTo", OrderToEdit.BackOrderTo);
		

		

		SetvalOf("txtShipmentMethod", OrderToEdit.ShipmentMethod);

		SetvalOf("ddDocumentRequired", OrderToEdit.DocumentRequired);
		SetvalOf("txtNotifyInstructions", OrderToEdit.NotifyInstructions);
		SetvalOf("txtShippingInstructions", OrderToEdit.ShippingInstructions);

		SetvalOf("txtRecordCreatedBy", OrderToEdit.RecordCreatedByName);
		$("#tblItems").empty();
		$.each(resp.Items, function (i, itm) {
			var tr = $('<tr>')


			tr.attr("data-id", itm == null ? 0 : itm.ID);


			tr.append($('<td>').text(itm.PartNumber));
			tr.append($('<td>').text(itm.PartName));
			tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(itm.Description)));
			tr.append($('<td>').append($('<input type="number" onchange="CalculateTotal(this,1)" onblur="CalculateTotal(this,1)" class="form-control form-control-sm">').val(itm.Quantity)));
			tr.append($('<td>').append($('<input type="number" onchange="CalculateTotal(this,2)" onblur="CalculateTotal(this,2)"  class="form-control form-control-sm">').val(itm.UnitPrice)));
			tr.append($('<td>').append($('<input type="number" readonly  class="form-control form-control-sm total">').val(itm.Quantity * itm.UnitPrice)));

			tr.append($('<td>').append($('<input type="text "  class="form-control form-control-sm">').val(itm.Application)));
			tr.append($('<td>').append($('<input type="text "  class="form-control form-control-sm">').val(itm.ShippingMethod)));
			tr.append($('<td>').append($('<input type="text "  class="form-control form-control-sm">').val(itm.Currency)));
			tr.append($('<td>').append($('<input type="checkbox">').prop("checked", itm.Received)));

			var a = $('<a>').attr("href", "javascript:void(0)")
			$(a).click(function () {
				$(this).closest('tr').remove()
			})
			$(a).append($('<i class="fa fa-trash text-danger"></i>'))
			tr.append($('<td>').append($(a)));
			$("#tblItems").append(tr);

		});

	});



}
function NewOrder() {
    $('.datepicker').val(moment().format("DD/MM/YYYY"));
	OrderToEdit = { ID: 0 };
	SetvalOf("txtRecordCreatedBy", User.Name);
	$("#dvEdit").show();
	$("#dvList").hide();
	$(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
}
function ResetNav() {
	OrderToEdit = { ID: 0 };
	$(".breadcrumb-item.active").find("a").contents().unwrap();
	ListOrders();
}
function BindSparePartRequestSearch() {
	$('#txtItemCode').typeahead({
		minLength: 3,
		items: 500,

		source: function (query, result) {
			$.ajax({
				url: "/EquipmentsAPI/SpacePartItem/FindByName",
				data: 'Name=' + query,
				dataType: "json",
				type: "POST",
				success: function (data) {
					Items = data;
					result($.map(data, function (item) {
						return `${item.PartNumber} - ${item.PartName} - ${item.Application} - ${item.Alternatives}`;
					}));
				}
			});
		}
	});

}

function AddItem() {
    var itm = Items.find(x => `${x.PartNumber} - ${x.PartName} - ${x.Application} - ${x.Alternatives}` == valOf("txtItemCode"));

	var newItem = {
		PartNumber: itm.PartNumber,
		PartName: itm.PartName,
        Application:itm.Application,
		UnitPrice: parseFloat(valOf("txtItemUnitPrice")),
		Quantity: parseInt(valOf("txtItemQuantity")),
		ShippingMethod: valOf("txtItemShippingMethod"),
		Currency: valOf("txtItemCurrency"),
		Received: GetChecked("chkItemReceived"),
		Description: valOf("txtItemDescription"),

	}
	if (newItem.PartNumber == "") {
		swal("Please enter item to purchase")
		return false;
	}
	if (newItem.Quantity == "" || isNaN(newItem.Quantity)) {
		swal("Please enter quantity to request")
		return false;
	}

	
	var tr = $('<tr>')

	tr.attr("data-id", itm == null ? 0 : itm.ID);


	tr.append($('<td>').text(itm.PartNumber));
	tr.append($('<td>').text(itm.PartName));
	tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(newItem.Description)));
	tr.append($('<td>').append($('<input type="number" onchange="CalculateTotal(this,1)" onblur="CalculateTotal(this,1)" class="form-control form-control-sm">').val(newItem.Quantity)));
	tr.append($('<td>').append($('<input type="number" onchange="CalculateTotal(this,2)" onblur="CalculateTotal(this,2)"  class="form-control form-control-sm">').val(newItem.UnitPrice)));
	tr.append($('<td>').append($('<input type="number" readonly  class="form-control form-control-sm total">').val(newItem.Quantity * newItem.UnitPrice)));

	tr.append($('<td>').append($('<input type="text "  class="form-control form-control-sm">').val(newItem.Application)));
	tr.append($('<td>').append($('<input type="text "  class="form-control form-control-sm">').val(newItem.ShippingMethod)));
	tr.append($('<td>').append($('<input type="text "  class="form-control form-control-sm">').val(newItem.Currency)));
	tr.append($('<td>').append($('<input type="checkbox">').prop("checked", newItem.Received)));

	var a = $('<a>').attr("href", "javascript:void(0)")
	$(a).click(function () {
		$(this).closest('tr').remove()
	})
	$(a).append($('<i class="fa fa-trash text-danger"></i>'))
	tr.append($('<td>').append($(a)));
	$("#tblItems").append(tr);

	SetvalOf("txtItemUnitPrice", "");
	SetvalOf("txtItemQuantity", "");
	SetvalOf("txtItemShippingMethod", "")
	SetvalOf("txtItemCurrency", "")
	SetvalOf("txtItemDescription", "");
	SetChecked("chkItemReceived",false)
    
    
    

}

function CalculateTotal(sender, type) {
	var value1 = $(sender).val();
	var val2 = 0;
	if (type == 1) {
		val2 = $(sender).parent().next().find(":input").val()
	} else {
		val2 = $(sender).parent().prev().find(":input").val()
	}
	var total = parseFloat(value1) * parseFloat(val2);

	$(sender).closest("tr").find("input.total").val(total);
}