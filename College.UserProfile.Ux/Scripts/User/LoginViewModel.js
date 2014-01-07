function UserLoginViewModel() {
    $('#loading').hide();
    var self = this;
    self.NewUser = ko.observable(false);
    self.EmailAddress = ko.observable("").extend({
        required: {
            message: 'Please supply Email Address.'
        },
        email: {
            message: 'Please enter Valid Email Address.'
        }

    });
    self.Password = ko.observable("").extend({
        required: {
            message: 'Please supply Password.'
        }
    });

    self.ConfirmPassword = ko.observable("").extend({
        required: {
            message: 'Please supply Confirm Password.',
            onlyIf: self.NewUser
        },
        areSame:
            {
                params: self.Password,
                onlyIf: self.NewUser
            },
        passwordComplexity: {
            onlyIf: self.NewUser
        }
    });

    self.SignIn = function () {
        if (self.errors().length == 0) {
            $('#loading').show();
            if (self.NewUser()) {
                var userLoginJson = ko.toJSON(self);
                $.ajax({
                    url: '/User/Login/Create',
                    type: "POST",
                    data: userLoginJson,
                    datatype: "json",
                    processData: false,
                    contentType: "application/json; charset=utf-8"
                }).done(function (data, textStatus, jqXHR) {
                    $('#loading').hide();
                    var output = JSON.parse(jqXHR.responseText);
                    window.location.href = JSON.parse(jqXHR.responseText).redirectToUrl;
                }).fail(function (jqXHR, textStatus, errorThrown) {
                    $("#infoMessages").html(JSON.parse(jqXHR.responseText).Message).attr("class", "message-error");
                    self.ConfirmPassword("");
                    self.Password("");
                    $('#loading').hide();
                });
            }
            else {
                var userLoginJson = ko.toJSON(self);
                $.ajax({
                    url: '/User/Login/ValidateUserLogin',
                    type: "POST",
                    data: userLoginJson,
                    datatype: "json",
                    processData: false,
                    contentType: "application/json; charset=utf-8"
                }).done(function (data, textStatus, jqXHR) {
                    $('#loading').hide();
                    var output = JSON.parse(jqXHR.responseText);
                    window.location.href = JSON.parse(jqXHR.responseText).redirectToUrl;
                }).fail(function (jqXHR, textStatus, errorThrown) {
                    $("#infoMessages").html(JSON.parse(jqXHR.responseText).Message).attr("class", "message-error");
                    self.ConfirmPassword("");
                    self.Password("");
                    $('#loading').hide();
                });
            }
            self.errors.showAllMessages(false);
        }
        else {
            self.errors.showAllMessages(true);
        }
    };

    this.errors = ko.validation.group(self);

}