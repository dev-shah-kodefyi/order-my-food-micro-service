

$(document).ready(function () {
    $("#btnclick").click(function () {
        var i = $("#location").val();
        var j = $("#restName").val();
        var k = $("#rating").val();
        var a = $("#CusineId").val();
        var b = $("#dist").val();
        var c = $("#budget").val();
        if ((i != "" && j != "") && (k != "0.0" && a != "0") && (b != "0" && c != "0")) {

            alert("you can only select one filter at a time");

        }
        else if ((i != "" || j != "") && (k != "0.0" || a != "0")) {
            alert("you can only select one filter at a time");
            return false;
        }
        else if ((i != "" || j != "") && (b != "0" || c != "0")) {
            alert("you can only select one filter at a time");
            return false;
        }
        else if ((k != "0.0" || a != "0") && (b != "0" || c != "0")) {
            alert("you can only select one filter at a time");
            return false;
        }
        
        else {
            return true;
        }

    });
});