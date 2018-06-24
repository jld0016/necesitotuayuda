// Write your JavaScript code.
$("body").on("click", "#loginButton", function (e) {
    e.preventDefault();
    succes = function (data) {
        $(".modal-backdrop").remove();
        $("#modal").empty();
        $("#modal").append(data);
        $('#modalActive').modal('handleUpdate')
        $("#modalActive").modal("show");
    }
    error = function (err) {
        console.log("The request is invalid")
    };
    $.ajax({
        type: "GET",
        url: "/Account/Login",
        data: {},
        success: succes,
        error: error
    });
})

$('body').on('click', '.btnDelete', function (e) {
    e.preventDefault();
    var succes = function (data) {
        $(".modal-backdrop").remove();
        $("#modal").empty();
        $("#modal").append(data);
        $('#modalActive').modal('handleUpdate')
        $("#modalActive").modal("show");
    }
    var error = function () {
        console.log("The request is invalid")
    }

    $.ajax({
        type: 'GET',
        url: $(this).attr('data-href'),
        data: { id: $(this).attr('data-id') },
        success: succes,
        error: error
    });
})


$('body').on('click', '.ModalNoData', function (e) {
    e.preventDefault();
    var islg = $(this).hasClass('islg');
    var succes = function (data) {
        $(".modal-backdrop").remove();
        $("#modal").empty();
        $("#modal").append(data);
        $('#modalActive').modal('handleUpdate')
        if (islg) {
            $('#modalActive').find(".modal-dialog").addClass('modal-lg');
        }
        $("#modalActive").modal("show");
    }
    var error = function () {
        console.log("The request is invalid")
    }

    $.ajax({
        type: 'GET',
        url: $(this).attr('data-href'),
        data: {},
        success: succes,
        error: error
    });
})

$('body').on("change", ".changeDedication", function () {
    if ($(this).is(":checked")) {
        var idChange = $(this).attr('id')
        switch (idChange) {
            case "isPainting": {
                $("#tablePainting").removeClass("d-none");
                break;
            }
            case "isMansonry": {
                $("#tableMansonry").removeClass("d-none");
                break;
            }
            case "isPlumbing": {
                $("#tablePlumbing").removeClass("d-none");
                break;
            }
            case "isElectricity": {
                $("#tableElectricity").removeClass("d-none");
                break;
            }
        }
    } else {
        var idChange = $(this).attr('id')
        switch (idChange) {
            case "isPainting": {
                disabledTable($("#tablePainting"))
                break;
            }
            case "isMansonry": {
                disabledTable($("#tableMansonry"))
                break;
            }
            case "isPlumbing": {
                disabledTable($("#tablePlumbing"))
                break;
            }
            case "isElectricity": {
                disabledTable($("#tableElectricity"))
                break;
            }
        }
    }
}); 

$('body').on("change", ".checkboxTypeJob", function () {
    $(this).closest('td').find(".ratingValue").val($(this).val())
})

function activeTable(table) {
    table.removeClass('d-none')
    table.find('tbody > tr').each(function (i, tr) {
        var rating = $(this).find('.ratingValue').val();
        $(this).find('label.active').removeClass('active')
        $(this).find("input[value='" + rating + "']").attr('checked', 'checked');
        $(this).find("input[value='" + rating + "']").closest('label').addClass('active');
    })
}

function disabledTable(table) {
    table.addClass('d-none')
    table.find('tbody > tr').each(function (i, tr) {
        $(this).find('.ratingValue').val('0');
        $(this).find('label.active').find('input').removeAttr('checked').closest('label').removeClass('active')
        $(this).find("input[value='0']").attr('checked', 'checked');
        $(this).find("input[value='0']").closest('label').addClass('active');
    })
}