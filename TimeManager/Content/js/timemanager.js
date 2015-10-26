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

$("#SignInButton").on('click', function(jQueryEvent) {
    jQueryEvent.preventDefault();
    $.post("../Account/SignInAjax", { UserName: $('#UserName').val(), Password: $('#Password').val() }, function(data) {
        var model = $.parseJSON(data);
        $("#CustomErrors").empty();
        $("#UserNameError").empty();
        $("#PasswordError").empty();
        if (!model.CustomErrors && !model.UserName.Errors.length && !model.Password.Errors.length) {
            location.reload();
        }
        if (model.CustomErrors) {
            $.each(model.CustomErrors.Errors, function (index, value) {
                $("#CustomErrors").append("<li>"+value.ErrorMessage+"</li>");
            });
        }
        if (model.UserName.Errors.length > 0) {
            $.each(model.UserName.Errors, function (index, value) {
                $("#UserNameError").append(value.ErrorMessage);
            });
        }
        if (model.Password.Errors.length > 0) {
            $.each(model.Password.Errors, function (index, value) {
                $("#PasswordError").append(value.ErrorMessage);
            });
        }
        console.log(jQuery.parseJSON(data));
    });
});