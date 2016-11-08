$(document).ready(function () {

    $('#myTable').DataTable();
    
    ////set all as default checked on the form if nothing else is picked
    //if (getParameterByName("foodFilter") != null) {
    //    if (getParameterByName("foodFilter").lastIndexOf("all") > -1) {
    //        $('.foodFilter').prop('checked', true);
    //    }
    //    if (getParameterByName("foodFilter").lastIndexOf("vegan") > -1) {
    //        $('.vegan').prop('checked', true);
    //    }
    //    if (getParameterByName("foodFilter").lastIndexOf("kosher") > -1) {
    //        $('.kosher').prop('checked', true);
    //    }
    //    if (getParameterByName("foodFilter").lastIndexOf("vegetarian") > -1) {
    //        $('.vegetarian').prop('checked', true);
    //    }
    //}

    $('.showHide').click(function () {
        $(this).next().slideToggle();
    });

    if (getParameterByName("query") != null) {
        $('.queryInput').val(getParameterByName("query"));
    }

    $('#myTable_next').removeClass("disabled");

    $('#myTable_next').click(function () {
        var URL = window.location.href.split('?')[0];
        var query = "";
        var offset = 10;

        if (getParameterByName("query") != null) {
            query = getParameterByName("query");
        }

        if (getParameterByName("offset") != null) {
            offset = parseInt(getParameterByName("offset")) + 10; 
        }

        window.location.href = URL + "?query=" + query + "&offset=" + offset;
    });


});



function getParameterByName(name, url) {
    if (!url) {
        url = window.location.href;
    }
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}