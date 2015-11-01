$(function () {
   	$('#datetimepickerStart').datetimepicker({locale: 'uk'});
   	$('#datetimepickerEnd').datetimepicker({locale: 'uk'});
  	$("#datetimepickerStart").on("dp.change", function (e) {$('#datetimepickerEnd').data("DateTimePicker").minDate(e.date);});
   	$("#datetimepickerEnd").on("dp.change", function (e) {$('#datetimepickerStart').data("DateTimePicker").maxDate(e.date);});
});

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
    console.log("signin");
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
    });
});

function clearAddTodoErrorMessages() {
    $('#ShortDescriptionError').empty();
    $('#DescriptionError').empty();
    $('#StartDateError').empty();
    $('#IsDoneError').empty();
    $('#EndDateError').empty();
    $('#CategoryError').empty();
    $('#PriorityError').empty();
}

$('#AddTodoButton').on('click', function(jQueryEvent) {
    jQueryEvent.preventDefault();
    $.post('../Todos/AddAjax', {
        ShortDescription: $('#ShortDescription').val(),
        Description: $('#Description').val(),
        StartDate: $('#StartDate').val(),
        IsDone: $('#IsDone').prop('checked'),
        EndDate: $('#EndDate').val(),
        CategoryName: $('#CategoryName').val(),
        Priority: $('#Priority').val()
    }, function (data) {
        var modelState = $.parseJSON(data);
        if (modelState.IsValid) {
            clearAddTodoErrorMessages();
            $('#ShortDescription').val('');
                $('#Description').val('');
                $('#StartDate').val('');
                $('#IsDone').prop('checked','');
                $('#EndDate').val('');
                $('#CategoryName').val('');
                $('#Priority').val('');
            location.reload();
            
        }
        clearAddTodoErrorMessages();
        if (modelState.ShortDescription.Errors.length) $('#ShortDescriptionError').html(modelState.ShortDescription.Errors[0].ErrorMessage);
        if (modelState.Description.Errors.length) $('#DescriptionError').html(modelState.Description.Errors[0].ErrorMessage);
        if (modelState.StartDate.Errors.length) $('#StartDateError').html(modelState.StartDate.Errors[0].ErrorMessage);
        if (modelState.IsDone.Errors.length) $('#IsDoneError').html(modelState.IsDone.Errors[0].ErrorMessage);
        if (modelState.EndDate.Errors.length) $('#EndDateError').html(modelState.EndDate.Errors[0].ErrorMessage);
        if (modelState.CategoryName.Errors.length) $('#CategoryError').html(modelState.CategoryName.Errors[0].ErrorMessage);
        if (modelState.Priority.Errors.lenght) $('#PriorityError').html(modelState.Priority.Errors[0].ErrorMessage);
    });
});

if ($.find('#CategoryName').length) {
    $.post('../Categories/GetCurrentUserCategoriesAjax', '', function (data) {
        var dataModel = $.parseJSON(data);
        $.each(dataModel, function(index, item) {
            $('#CategoryName').append('<option value="' + item.Name + '">' + item.Name + '</option>');
        });
    });
};

$('#IsDone').change(function () {
    $('#EndDate').prop('disabled', !$('#IsDone').is(':checked'));
});