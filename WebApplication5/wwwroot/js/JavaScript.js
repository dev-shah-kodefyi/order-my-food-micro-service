
$(document).ready(function () {
    $('#plus').click(function add() {

        var a = $("#units").val();
        a++;
        $("#subs").prop("disabled", !a);
        $("#units").val(a);



    });
    // Set initial disabled state
    $("#subs").prop("disabled", !$("#units").val());

    $('#subs').click(function subst() {

        var b = $("#units").val();
        if (b >= 1) {
            b--;
            $("#units").val(b);
            $.ajax({
                type: "POST",
                url: "/Home/AddedToCart",
                data: { 'units': $("#units").val(b) },
                dataType: 'html',

            });
        }
        else {
            $("#subs").prop("disabled", true);
        }

    });
    //$("#btnGet").click(function () {
    //    $.ajax({
    //        type: "POST",
    //        url: "/Home/AddedToCart",
    //        //data: { 'units': $("#units").val(), 'id': $("#units").val() },
    //        data: { 'units': $("#units").val(), 'id': $("#units").val(), 'foodname': $("#foodname").val(), 'price': $("#price").val(), 'foodId': $("#foodId").val() },
    //        dataType: 'html',

    //    });
    //});


});

