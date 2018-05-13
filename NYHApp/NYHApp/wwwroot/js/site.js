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