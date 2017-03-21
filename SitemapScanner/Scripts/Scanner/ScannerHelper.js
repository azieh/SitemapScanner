//option to send url after presing enter key
var ScannerHelper = {
    bindUrlAction: function (action, viewModel, addressListViewModel) {
        $('#url').bind("enterKey", function (e) {
            action.sendUrlAddress(viewModel, addressListViewModel);
        });
        $('#url').keyup(function (e) {
            if (e.keyCode == 13) {
                $(this).trigger("enterKey");
            }
        });
    }
}