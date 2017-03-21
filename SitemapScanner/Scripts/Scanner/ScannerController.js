var ScannerController = {
    sendUrlAddress: function (viewModel, addressListViewModel) {
        viewModel.urlResponse("Request has been sent. Please wait...")
        $.ajax({
            method: "Get",
            url: "/Scanner/GetSiteMapUrlAddress/",
            data: { 'urlAddress': viewModel.urlAddress() },
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                viewModel.urlList([]);
                //when we get all urls, start time response test
                data.forEach(function (d) {
                    var newAddressModel = new addressListViewModel();
                    newAddressModel.url(d);
                    viewModel.urlList.push(newAddressModel);
                });
                viewModel.urlResponse("Request sended OK");
                ko.utils.arrayForEach(viewModel.urlList(), function (d) {
                    ScannerController.getPageTimeResponse(d);
                });
            },
            error: function (data) {
                viewModel.urlResponse("Error on request");
            }
        });

    },
    getPageTimeResponse: function (addressListViewModel) {
        addressListViewModel.testResponse("Test has been started...");
        $.ajax({
            method: "Get",
            url: "/Scanner/GetPageTimeResponse/",
            data: { 'urlAddress': addressListViewModel.url() },
            contentType: "application/json",
            dataType: "json",
            success: function (data) {
                addressListViewModel.testTime(data);
                addressListViewModel.testResponse("Test OK");
            },
            error: function (data) {
                addressListViewModel.testResponse("Error on request");
            }
        });
    }
}