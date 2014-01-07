
function UserViewModel() {
    $('#loading').hide();
    var self = this;
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

    self.GenderOption = ko.observableArray([]);
    self.viewModel = {};
    self.loadUserProfile = function () {
        $('#loading').show();
        GetGenderLists(function (output) {
            self.GenderOption(output);
        }, function (error) {
            $("#infoMessages").html(error).attr("class", "message-error");
        });

        $.getJSON(
            "/user/profile/GetUserProfileInformation")
            .done(
                function (data, textStatus, jqXHR) {
                    if (textStatus == "success") {
                        self.viewModel = ko.mapping.fromJSON(jqXHR.responseText, validationMapping);
                         ko.applyBindings(self);
                    }
                    $('#loading').hide();
                    //todo: redirect to error page
                })
            .fail(
                    function (data, textStatus, jqXHR) {
                        $("#infoMessages").html(JSON.parse(jqXHR.responseText).Message).attr("class", "message-error");
                        $('#loading').hide();
                    });
    }
}

$(function () {
    $("#BirthDate").datepicker();
});