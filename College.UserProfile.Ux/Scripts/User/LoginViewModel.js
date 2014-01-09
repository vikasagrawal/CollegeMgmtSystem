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

    self.ToggleNewUser = function()
    {
        self.errors.showAllMessages(false);
        $("#infoMessages").html("")
        self.NewUser(true);
    }

    self.ToggleExistingUser = function () {
        self.errors.showAllMessages(false);
        $("#infoMessages").html("")

        self.NewUser(false);
    }

    self.SignIn = function () {
        if (self.errors().length == 0) {
            $('#loading').show();
            if (self.NewUser()) {
                var userLoginJson = ko.toJSON(self);
                CreateNewUser(userLoginJson,
                    function (data, textStatus, jqXHR) {
                        $('#loading').hide();
                        var output = JSON.parse(jqXHR.responseText);
                        window.location.href = JSON.parse(jqXHR.responseText).redirectToUrl;
                    },
                    function (jqXHR, textStatus, errorThrown) {
                        $("#infoMessages").html(JSON.parse(jqXHR.responseText).Message).attr("class", "message-error");
                        self.ConfirmPassword("");
                        self.Password("");
                        $('#loading').hide();
                    });
            }
            else {
                var userLoginJson = ko.toJSON(self);
                ValidateUser(userLoginJson,
                    function (data, textStatus, jqXHR) {
                        $('#loading').hide();
                        var output = JSON.parse(jqXHR.responseText);
                        window.location.href = JSON.parse(jqXHR.responseText).redirectToUrl;
                    },
                    function (jqXHR, textStatus, errorThrown) {
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

function CreateNewUser(data, handleSuccess, handleFailure) {
    $.ajax({
        url: '/User/Login/Create',
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

function ValidateUser(data, handleSuccess, handleFailure) {
    $.ajax({
        url: '/User/Login/ValidateUserLogin',
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