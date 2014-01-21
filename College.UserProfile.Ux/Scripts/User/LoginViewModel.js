function UserLoginViewModel() {
    $('#loading').hide();
    var self = this;
    self.loading = ko.observableArray();
    self.IsFacebookLogin = ko.observable(false);
    self.IsEmailVerified = ko.observable(false);
    self.FBUserID = ko.observable("");
    self.NewUser = ko.observable(false);
    self.IsActive = ko.observable(true);

    self.EmailAddress = ko.observable("").extend({
        required: {
            message: globalResources.resources.EmailAddressRequiredMessage
        },
        email: {
            message: globalResources.resources.InValidEmailAddressMessage
        }

    });
    self.Password = ko.observable("").extend({
        required: {
            message: globalResources.resources.PasswordRequiredMessage
        }
    });

    // Here we run a very simple test of the Graph API after login is successful. 
    // This testAPI() function is only called in those cases. 
    self.loginWithFaceBook = function (userID, accessToken) {
        FB.api('/me', function (response) {
            if (response && !response.errors) {

                self.IsFacebookLogin(true);
                self.FBUserID(userID);
                self.EmailAddress(response.email);
                self.IsEmailVerified(true);
                self.NewUser(true);
                self.Password("temp@123");
                self.ConfirmPassword("temp@123");
                self.SignIn(accessToken);
            }
            else {
                $("#infoMessages").html(globalResources.resources.FacebookLoginErrorMessage).attr("class", "message-error");
            }
        });

    };

    self.ConfirmPassword = ko.observable("").extend({
        required: {
            message: globalResources.resources.ConfirmPasswordRequiredMessage,
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

    self.ToggleNewUser = function () {
        self.errors.showAllMessages(false);
        $("#infoMessages").html("")
        self.NewUser(true);
    }

    self.ToggleExistingUser = function () {
        self.errors.showAllMessages(false);
        $("#infoMessages").html("")

        self.NewUser(false);
    }

    self.SignIn = function (accessToken) {
        if (self.errors().length == 0) {
            $('#loading').show();
            if (self.NewUser()) {
                var userLoginJson = ko.toJSON(self);
                CreateNewUser(accessToken, userLoginJson,
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

function CreateNewUser(accessToken, data, handleSuccess, handleFailure) {
    $.ajax({
        url: '/User/Login/Create?accessToken=' + accessToken,
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