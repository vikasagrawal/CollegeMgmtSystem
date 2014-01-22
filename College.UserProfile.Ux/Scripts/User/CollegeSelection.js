function CollegeSelectionViewModel() {
    var self = this;

    self.loading = ko.observableArray();
    self.currentPage = ko.observable();
    self.pageSize = ko.observable(5);
    self.currentPageIndex = ko.observable(0);
    self.availableColleges = ko.observableArray([]);
    self.userShortListedColleges = ko.observableArray();
    self.sortType = "ascending";

    self.sortTable = function (viewModel, e) {
        var orderProp = $(e.target).attr("data-column")
        self.availableColleges.sort(function (left, right) {
            leftVal = left[orderProp];
            rightVal = right[orderProp];
            if (self.sortType == "ascending") {
                return leftVal < rightVal ? 1 : -1;
            }
            else {
                return leftVal > rightVal ? 1 : -1;
            }
        });
        self.sortType = (self.sortType == "ascending") ? "descending" : "ascending";
    };

    self.nextPage = function () {
        if (((self.currentPageIndex() + 1) * self.pageSize()) < self.availableColleges().length) {
            self.currentPageIndex(self.currentPageIndex() + 1);
        }
        else {
            self.currentPageIndex(0);
        }
    }
    self.previousPage = function () {
        if (self.currentPageIndex() > 0) {
            self.currentPageIndex(self.currentPageIndex() - 1);
        }
        else {
            self.currentPageIndex((Math.ceil(self.availableColleges().length / self.pageSize())) - 1);
        }
    }

    self.availableColleges.sort(function (left, right) {
        return left.Name < right.Name ? 1 : -1;
    });

    self.loadShortListedColleges = function (ctx) {
        self.loading.push(true);
        GetSelectedColleges(
         function (data, textStatus, jqXHR) {
             if (textStatus == "success") {
                 self.userShortListedColleges = ko.mapping.fromJSON(jqXHR.responseText);
             }
             if (ctx && ctx.success !== 'undefined') { ctx.success(); }
         },
         function (data, textStatus, jqXHR) {
             $("#infoMessages").html(JSON.parse(jqXHR.responseText).Message).attr("class", "message-error");
             if (ctx && ctx.success !== 'undefined') { ctx.success(); }
         });
    }

    self.loadAvailableColleges = function (ctx) {
        self.loading.push(true);
        GetAvailableColleges(
          function (data, textStatus, jqXHR) {
              if (textStatus == "success") {
                  self.availableColleges = ko.mapping.fromJSON(jqXHR.responseText);
              }
              if (ctx && ctx.success !== 'undefined') { ctx.success(); }
          },
          function (data, textStatus, jqXHR) {
              $("#infoMessages").html(JSON.parse(jqXHR.responseText).Message).attr("class", "message-error");
              if (ctx && ctx.success !== 'undefined') { ctx.success(); }
          });
    }

    self.load = function () {
        $('#loading').show();
        // Important: we need to load countries and languages first and only then load the user, to make
        // sure that corresponding drop-downs are populated before loaded user will try to set values on them

        // loadUser() is run once, after both loadCountries() and loadLanguages() have run (they do run in parallel!)
        var parallelExecutions = [self.loadShortListedColleges, self.loadAvailableColleges];
        var delayedLoadUser = _.after(parallelExecutions.length, self.bindViewModel);
        _.each(parallelExecutions, function (func) {
            func({ success: delayedLoadUser });
        });
    };

    self.bindViewModel = function () {
        self.currentPage = ko.computed(function () {
            var pagesize = parseInt(self.pageSize(), 10),
            startIndex = pagesize * self.currentPageIndex(),
            endIndex = startIndex + pagesize;
            return self.availableColleges.slice(startIndex, endIndex);
        });
        ko.applyBindings(self);
        $("#pageform").show();
        $('#loading').hide();
    }

    self.SaveCollegeShortListing = function () {
        $("#infoMessages").html("");

        $('#loading').show();
        var shortListedColleges = ko.toJSON(self.userShortListedColleges);
        UpdateUserShortListedColleges(shortListedColleges,
            function (data, textStatus, jqXHR) {
                $('#loading').hide();
                $("#infoMessages").html(JSON.parse(jqXHR.responseText).Message).attr("class", "message-info");
            },
            function (jqXHR, textStatus, errorThrown) {
                $("#infoMessages").html(JSON.parse(jqXHR.responseText).Message).attr("class", "message-error");

                $('#loading').hide();
            });

    }
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

function GetSelectedColleges(handleSuccess, handleFailure) {
    $("#infoMessages").html("");
    $.getJSON("/user/CollegeSelection/GetCollegeSelection")
    .done(
        function (data, textStatus, jqXHR) {
            handleSuccess(data, textStatus, jqXHR);
        })
    .fail(
        function (data, textStatus, jqXHR) {
            handleFailure(data, textStatus, jqXHR);
        });
}

function UpdateUserShortListedColleges(data, handleSuccess, handleFailure) {
    $.ajax({
        url: '/user/CollegeSelection/CreateOrUpdate',
        type: "POST",
        data: data,
        datatype: "json",
        processData: false,
        contentType: "application/json; charset=utf-8"
    })
.done(
    function (data, textStatus, jqXHR) {
        handleSuccess(data, textStatus, jqXHR);
    })
.fail(
    function (data, textStatus, jqXHR) {
        handleFailure(data, textStatus, jqXHR);
    });
}