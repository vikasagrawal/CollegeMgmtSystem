
function UserViewModel() {
    $('#loading').hide();
    var self = this;
    var bindingCompleted = false;
    var languagesLoaded = false;
    var userProfileLoaded = false;
    self.LanguageOption = ko.observableArray([]);
    self.GenderOption = ko.observableArray([]);
    self.viewModel = {};
    self.loadUserProfile = function () {
        $('#loading').show();
        GetGenderLists(function (output) {
            self.GenderOption(output);

        }, function (error) {
            $("#infoMessages").html(error).attr("class", "message-error");
        });

        GetLanguagesList(function (output) {
            self.LanguageOption(output);
            languagesLoaded = true;
            if (bindingCompleted == false && userProfileLoaded) {
                ko.applyBindings(self);
            }
        }, function (error) {
            languagesLoaded = true;
            if (bindingCompleted == false && userProfileLoaded) {
                ko.applyBindings(self);
            }
            $("#infoMessages").html(error).attr("class", "message-error");
        });

        GetUserProfile(
                  function (data, textStatus, jqXHR) {
                      if (textStatus == "success") {
                          self.viewModel = ko.mapping.fromJSON(jqXHR.responseText, validationMapping);
                          userProfileLoaded = true;
                          if (languagesLoaded) {
                              ko.applyBindings(self);
                              bindingCompleted = true;
                          }
                      }
                      $('#loading').hide();
                      //todo: redirect to error page
                  },
                  function (data, textStatus, jqXHR) {
                      $("#infoMessages").html(JSON.parse(jqXHR.responseText).Message).attr("class", "message-error");
                      $('#loading').hide();
                  });
    }

    //self.toJSON = function () {
    //    var copy = ko.toJS(this); //easy way to get a clean copy
    //    delete copy.full; //remove an extra property
    //    return copy; //return the copy to be serialized
    //};

    self.SaveUserProfile = function () {
        if (self.errors().length == 0) {
            $('#loading').show();
            var userProfile = ko.toJSON(self.viewModel);
            UpdateUserProfile(userProfile,
                function (data, textStatus, jqXHR) {
                    $('#loading').hide();
                    $("#infoMessages").html(JSON.parse(jqXHR.responseText).Message).attr("class", "message-error");
                },
                function (jqXHR, textStatus, errorThrown) {
                    $("#infoMessages").html(JSON.parse(jqXHR.responseText).Message).attr("class", "message-error");

                    $('#loading').hide();
                });

            self.errors.showAllMessages(false);
        }
        else {
            self.errors.showAllMessages(true);
        }
    };

    var validationMapping = {
        // customize the creation of the name property so that it provides validation
        FirstName: {
            create: function (options) {
                return ko.observable(options.data).extend({ required: { message: 'Please supply First Name.' }, maxLength: 50 });
            }
        },
        MiddleName: {
            create: function (options) {
                return ko.observable(options.data).extend({ maxLength: 50 });
            }
        },
        LastName: {
            create: function (options) {
                return ko.observable(options.data).extend({ maxLength: 50 });
            }
        },
        HomeTown: {
            create: function (options) {
                return ko.observable(options.data).extend({ maxLength: 100 });
            }
        },
        ZipCode: {
            create: function (options) {
                return ko.observable(options.data).extend({
                    maxLength: 10, pattern: {
                        message: 'Please enter valid Zip Code',
                        params: '^(0|[1-9][0-9]*)$'
                    }
                });
            }
        },
        MobileNo: {
            create: function (options) {
                return ko.observable(options.data).extend({
                    minLength: 10, maxLength: 10, pattern: {
                        message: 'Please enter valid Phone Number',
                        params: '^(0|[1-9][0-9]*)$'
                    }
                });
            }
        },
        AboutUser: {
            create: function (options) {
                return ko.observable(options.data).extend({ maxLength: 500 });
            }
        }
    };



    this.errors = ko.validation.group(self);
}

$(function () {
    $("#BirthDate").datepicker();
});

function GetUserProfile(handleSuccess, handleFailure) {
    $.getJSON("/user/profile/GetUserProfileInformation")
    .done(
        function (data, textStatus, jqXHR) {
            handleSuccess(data, textStatus, jqXHR);
        })
    .fail(
        function (data, textStatus, jqXHR) {
            handleFailure(data, textStatus, jqXHR);
        });
}

function UpdateUserProfile(data, handleSuccess, handleFailure) {
    $.ajax({
        url: '/user/profile/CreateOrUpdate',
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

