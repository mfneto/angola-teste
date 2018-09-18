// Write your JavaScript code.
$(function () {
    //bootstrap for form errors
    $('.validation-summary-errors').each(function () {
        $(this).addClass('alert');
        $(this).addClass('alert-danger');
    });

    $('form').each(function () {
        $(this).find('div.form-group').each(function () {
            if ($(this).find('span.field-validation-error').length > 0) {
                $(this).addClass('has-error');
                $(this).find('span.field-validation-error').
                    removeClass('field-validation-error');
            }
        });
    });
    //

    //phone-mask
    $("input.phone-mask")
        .mask("(99) 99999-9999")
        .focusout(function (event) {
            var target, phone, element;
            target = (event.currentTarget) ? event.currentTarget : event.srcElement;
            phone = target.value.replace(/\D/g, '');
            element = $(target);
            element.unmask();
            if (phone.length > 10) {
                element.mask("(99) 99999-9999");
            } else {
                element.mask("(99) 9999-99999");
            }
        });
    //

    //modal-delete
    $('#confirm-delete').on('show.bs.modal', function (e) {
        $(this).find('.btn-ok').attr('href', $(e.relatedTarget).data('href'));
    });
    //

    //datepicker
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        language: 'pt-BR',
        weekStart: 0,
        startDate: '0d',
        todayHighlight: true
    });

    $(".half-hour,.service").blur(function() {
        if ($(".service").val() && $(".service").val() !== "" && $("#HalfServices").val().indexOf($(".service").val()) >= 0) {
            $(".hour").hide();
            $(".hour").attr("name", "xpto1");
            $(".half-hour").show();
            $(".half-hour").attr("name", "Hour");
        } else {
            $(".hour").show();
            $(".hour").attr("name", "Hour");
            $(".half-hour").hide();
            $(".half-hour").attr("name", "xpto2");
        }
    });
    $(".service").blur();
})