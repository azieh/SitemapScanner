function addressListViewModel() {
    var self = this;
    self.url = ko.observable("");
    self.testTime = ko.observable("");
    self.testResponse = ko.observable("");
};

var viewModel = {
    urlAddress: ko.observable(""),
    urlResponse: ko.observable(""),
    urlList: ko.observableArray([])
};

ko.applyBindings(viewModel);


var scannerController = ScannerController;
var scannerHelper = ScannerHelper;
scannerHelper.bindUrlAction(scannerController, viewModel, addressListViewModel);