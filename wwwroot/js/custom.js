$(document).ready(function () {
	var url = window.location.pathname;
	if(url.indexOf('adm') == -1)
    {
        $('#admMenu').hide();
        $('#nMenu').show();    
    }
    else
    {
        $('#nMenu').hide();   
        $('#admMenu').show();
    }
});