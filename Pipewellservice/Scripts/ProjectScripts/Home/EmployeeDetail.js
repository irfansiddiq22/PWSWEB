
$(".datepicker").datepicker({
    autoclose: true,
    todayHighlight: false,
    format: 'dd/mm/yyyy'
})
$('.daterangepicker').each(function (i, dp) {
    var dp = $(this)
    var start = moment().subtract(10, 'years').startOf('year').format("DD/MM/YYYY")
    var end = end = moment().endOf('week').format("DD/MM/YYYY")
    
    $(dp).daterangepicker({
        startDate: (start != undefined ? start : moment().startOf('year')),
        endDate: (end != undefined ? end : moment().endOf('week')),
        opens: 'left'


    })

    $(dp).val(start + ' - ' + end);
})
function AddMoreExperience() {
    $("#dvMoreWordExp").append($("#tblEmployeeWorkExp").clone());
}
$(function () {
    $("#spinner").hide();
})