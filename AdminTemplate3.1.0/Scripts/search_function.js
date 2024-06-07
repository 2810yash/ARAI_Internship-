$('#txtSearch').keyup(function () {
    debugger
    var typeValue = $(this).val();
    $('#reptCard').each(function () {
        if ($(this).text().search(new RegExp(typeValue, "i")) < 0) {
            $(this).fadeOut;
        }
        else {
            $(this).show();
        }
    });
});