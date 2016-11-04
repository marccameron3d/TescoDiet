$(document).ready(function () {

    //set all as default checked on the form if nothing else is picked
    if (getParameterByName("vegan") == null &&
        getParameterByName("kosher") == null &&
        getParameterByName("vegetarian") == null) {
        $('.foodFilter').prop('checked', true);
    }

    if (getParameterByName("foodFilter") != null) {
       $('.foodFilter').prop('checked', true);
    }
    if (getParameterByName("vegan") != null) {
        $('.vegan').prop('checked', true);
    }
    if (getParameterByName("kosher") != null) {
        $('.kosher').prop('checked', true);
    }
    if (getParameterByName("vegetarian") != null) {
        $('.vegetarian').prop('checked', true);
    }


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