$(document).ready(function() {
    
    //set all as default checked on the form if nothing else is picked
    if (getParameterByName("foodFilter") != null) {
        if (getParameterByName("foodFilter").lastIndexOf("all") > -1) {
            $('.foodFilter').prop('checked', true);
        }
        if (getParameterByName("foodFilter").lastIndexOf("vegan") > -1) {
            $('.vegan').prop('checked', true);
        }
        if (getParameterByName("foodFilter").lastIndexOf("kosher") > -1) {
            $('.kosher').prop('checked', true);
        }
        if (getParameterByName("foodFilter").lastIndexOf("vegetarian") > -1) {
            $('.vegetarian').prop('checked', true);
        }
    }

    $('.showHide').click(function () {
        $(this).next().slideToggle();
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