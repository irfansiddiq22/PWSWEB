function _Init() {
    HideSpinner();
}
document.getElementById('addItem').addEventListener('click', function () {
    const itemName = document.getElementById('itemName').value;
    const code = document.getElementById('code').value;
    const unit = document.getElementById('unit').value;
    const qty = document.getElementById('qty').value;
    const unitCost = document.getElementById('unitCost').value;
    const amount = document.getElementById('amount').value;
    const msds = document.getElementById('msds').checked ? 'Yes' : 'No';

    const table = document.getElementById('itemsTable');
    const row = table.insertRow();
    row.innerHTML = `<td>${itemName}</td>
                             <td>${code}</td>
                             <td>${unit}</td>
                             <td>${qty}</td>
                             <td>${unitCost}</td>
                             <td>${amount}</td>
                             <td>${msds}</td>`;
});

document.getElementById('purchaseOrderForm').addEventListener('submit', function (e) {
    e.preventDefault();

    const formData = {
        date: document.getElementById('date').value,
        iprNo: document.getElementById('iprNo').value,
        poNo: document.getElementById('poNo').value,
        attn: document.getElementById('attn').value,
        requiredDate: document.getElementById('requiredDate').value,
        contractPeriodFrom: document.getElementById('contractPeriodFrom').value,
        contractPeriodTo: document.getElementById('contractPeriodTo').value,
        note: document.getElementById('note').value,
        partyName: document.getElementById('partyName').value,
        items: Array.from(document.getElementById('itemsTable').rows).map(row => ({
            itemName: row.cells[0].innerText,
            code: row.cells[1].innerText,
            unit: row.cells[2].innerText,
            qty: row.cells[3].innerText,
            unitCost: row.cells[4].innerText,
            amount: row.cells[5].innerText,
            msds: row.cells[6].innerText
        })),
        paymentType: document.getElementById('paymentType').value,
        warrantyPeriod: document.getElementById('warrantyPeriod').value,
        deliveryType: document.getElementById('deliveryType').value,
        longTermContract: document.getElementById('longTermContract').checked,
        calibrationNeeded: document.querySelector('input[name="calibrationNeeded"]:checked').value,
        certificationNeeded: document.querySelector('input[name="certificationNeeded"]:checked').value,
        currency: document.getElementById('currency').value,
        freight: document.getElementById('freight').value,
        discount: document.getElementById('discount').value,
        vat: document.getElementById('vat').value,
        total: document.getElementById('total').value,
        showVatOnInvoice: document.getElementById('showVatOnInvoice').checked,
        remarks: document.getElementById('remarks').value,
        preparedBy: document.getElementById('preparedBy').value,
        preparedDate: document.getElementById('preparedDate').value,
        requestedBy: document.getElementById('requestedBy').value,
        requestedDate: document.getElementById('requestedDate').value,
        department: document.getElementById('department').value,
        departmentCode: document.getElementById('departmentCode').value,
        approvalFrom1: document.getElementById('approvalFrom1').value,
        approvalFrom2: document.getElementById('approvalFrom2').value,
        approvalFrom3: document.getElementById('approvalFrom3').value,
        approvalFrom4: document.getElementById('approvalFrom4').value
    };

    fetch('your-api-endpoint-url', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    }).then(response => {
        if (response.ok) {
            alert('Form submitted successfully');
        } else {
            alert('Failed to submit form');
        }
    }).catch(error => {
        alert('An error occurred: ' + error.message);
    });
});