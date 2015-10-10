$(function () {
   	$('#datetimepickerStart').datetimepicker({locale: 'uk', format: 'DD/MM/YYYY'});
   	$('#datetimepickerEnd').datetimepicker({locale: 'uk', format: 'DD/MM/YYYY'});
  	$("#datetimepickerStart").on("dp.change", function (e) {$('#datetimepickerEnd').data("DateTimePicker").minDate(e.date);});
   	$("#datetimepickerEnd").on("dp.change", function (e) {$('#datetimepickerStart').data("DateTimePicker").maxDate(e.date);});
});

function selectionchanged(id) {
	$(id).css('color','#000');
}
function showdiv(id) {
	$(id).css('display','block');
}
function hidediv(id) {
	$(id).css('display','none');
}
$('tr > td > div > label').click(function () {
	checkbox = $(this).children('input');
	if (checkbox.prop('checked')) {
		checkbox.parents('tr').css('text-decoration','line-through');
	}
	else {
		checkbox.parents('tr').css('text-decoration','none');	
	}
});