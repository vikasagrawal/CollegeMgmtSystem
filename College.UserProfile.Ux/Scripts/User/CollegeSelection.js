function CollegeSelectionViewModel() {
    var self = this;

    self.availableColleges = ko.observableArray([]);
    self.userSortListedColleges = ko.observableArray();
    self.load = function () {
        GetAvailableColleges(
           function (data, textStatus, jqXHR) {
               if (textStatus == "success") {
                   self.availableColleges = ko.mapping.fromJSON(jqXHR.responseText);
                   ko.applyBindings(self);
                   $("#pageform").show();
               }
               $('#loading').hide();
           },
           function (data, textStatus, jqXHR) {
               $("#infoMessages").html(JSON.parse(jqXHR.responseText).Message).attr("class", "message-error");
               $('#loading').hide();
           });

    };
}

function GetAvailableColleges(handleSuccess, handleFailure) {
    $("#infoMessages").html("");
    $.getJSON("/CodeLookup/College/GetAvailableColleges")
    .done(
        function (data, textStatus, jqXHR) {
            handleSuccess(data, textStatus, jqXHR);
        })
    .fail(
        function (data, textStatus, jqXHR) {
            handleFailure(data, textStatus, jqXHR);
        });
}