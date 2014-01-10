
function BlankUserEducationDetail(institutionTypeID) {
    if (institutionTypeID == 1) {
        var bed = {
            UserEducationDetailId: ko.observable(),
            UserId: ko.observable(),
            CollegeId: ko.observable(),
            PassingYear: ko.observable(""),
            DegreeTypeId: ko.observable(),
            CourseId: ko.observable(),
            SubjectId: ko.observable(),
            InstituitionTypeId: ko.observable(institutionTypeID),
            SchoolName: ko.observable("NoSchool")
        }

        return bed;
    }
    else {
        var bed = {
            UserEducationDetailId: ko.observable(),
            UserId: ko.observable(),
            CollegeId: ko.observable(0),
            PassingYear: ko.observable(""),
            DegreeTypeId: ko.observable(0),
            CourseId: ko.observable(0),
            SubjectId: ko.observable(0),
            InstituitionTypeId: ko.observable(institutionTypeID),
            SchoolName: ko.observable("")
        }

        return bed;
    }
}
function UserViewModel() {
    $('#loading').hide();
    var self = this;
    var bindingCompleted = false;
    var languagesLoaded = false;
    var userProfileLoaded = false;


    self.uploadimage = function () {
        $('#loading').show();
        var postdata = $('#image-upload-form').serialize();
        var file = document.getElementById('files').files[0];
        var fd = new FormData();
        fd.append("files", file);
        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/User/Profile/UploadImage", false);

        xhr.onreadystatechange = function (oEvent) {
            if (xhr.readyState === 4) {
                $('#loading').hide();
                if (xhr.status === 200) {
                    $("#infoMessages").html(JSON.parse(xhr.responseText).Message).attr("class", "message-error");
                    self.viewModel.user.UserPhoto("");
                    self.viewModel.user.UserPhoto("/upload/" + JSON.parse(xhr.responseText).FileName);
                } else {
                    $("#infoMessages").html(JSON.parse(xhr.responseText).Message).attr("class", "message-error");
                }
            }
        };
        xhr.send(fd);
    }

    self.LanguageOption = ko.observableArray([]);
    self.GenderOption = ko.observableArray([]);
    self.DegreeTypeOption = ko.observableArray([]);
    self.CourseOption = ko.observableArray([]);
    self.SubjectOption = ko.observableArray([]);
    self.viewModel = {};


    self.removeCollegeDetails = self.removePerson = function () {
        self.viewModel.UserEducationDetail.remove(this);
    }
    self.addCollegeDetails = function () {
        self.viewModel.UserEducationDetail.push(ko.mapping.fromJS(ko.mapping.toJS(new BlankUserEducationDetail(1)), validationMapping));
    }

    self.removeSchoolDetails = self.removePerson = function () {
        self.viewModel.UserEducationDetail.remove(this);
    }
    self.addSchoolDetails = function () {
        self.viewModel.UserEducationDetail.push(ko.mapping.fromJS(ko.mapping.toJS(new BlankUserEducationDetail(2)), validationMapping));
    }

    self.loadUserProfile = function () {
        $('#loading').show();
        GetGenderLists(function (output) {
            self.GenderOption(output);

        }, function (error) {
            $("#infoMessages").html(error).attr("class", "message-error");
        });

        GetDegreeTypesList(function (output) {
            self.DegreeTypeOption(output);

        }, function (error) {
            $("#infoMessages").html(error).attr("class", "message-error");
        });

        GetSubjectsList(function (output) {
            self.SubjectOption(output);

        }, function (error) {
            $("#infoMessages").html(error).attr("class", "message-error");
        });

        GetCoursesList(function (output) {
            self.CourseOption(output);

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

                          self.CollegeDetails = ko.computed(function () {
                              return ko.utils.arrayFilter(self.viewModel.UserEducationDetail(), function (eduDetails) {
                                  return eduDetails.InstituitionTypeId() === 1;
                              }
                              )
                          });

                          self.SchoolDetails = ko.computed(function () {
                              return ko.utils.arrayFilter(self.viewModel.UserEducationDetail(), function (eduDetails) {
                                  return eduDetails.InstituitionTypeId() === 2;
                              }
                              )
                          });

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
        $("#infoMessages").html("");
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

    ko.validation.configure({
        registerExtenders: true,
        decorateElement: true,
        messagesOnModified: true,
        insertMessages: true,
        parseInputAttributes: true,
        //messageTemplate: null,
        grouping: { deep: true }
    });

    this.errors = ko.validation.group(self);
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
        },
        CollegeId: {
            create: function (options) {
                return ko.observable(options.data).extend({ required: { message: 'Please supply College.' } });
            }
        },
        PassingYear: {
            create: function (options) {
                return ko.observable(options.data).extend({
                    required: { message: 'Please supply Year.' },
                    minLength: 4, maxLength: 4, pattern: {
                        message: 'Please enter valid Passing Year',
                        params: '^(0|[1-9][0-9]*)$'
                    }
                });
            }
        },
        DegreeTypeId: {
            create: function (options) {
                return ko.observable(options.data).extend({ required: { message: 'Please supply Degree Type.' } });
            }
        },
        CourseId: {
            create: function (options) {
                return ko.observable(options.data).extend({ required: { message: 'Please supply Course.' } });
            }
        },
        SubjectId: {
            create: function (options) {
                return ko.observable(options.data).extend({ required: { message: 'Please supply Major.' } });
            }
        },
        SchoolName: {
            create: function (options) {
                return ko.observable(options.data).extend({ required: { message: 'Please supply SchoolName.' } });
            }
        }

    };

}

$(function () {
    $("#BirthDate").datepicker();
});

function GetUserProfile(handleSuccess, handleFailure) {
    $("#infoMessages").html("");
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

