
function BlankUserEducationDetail(institutionTypeID) {
    var self = this;

    self.UserEducationDetailId = ko.observable();
    self.UserId = ko.observable();
    self.PassingYear = ko.observable("");
    self.CollegeId = ko.observable();
    self.DegreeTypeId = ko.observable();
    self.CourseId = ko.observable();
    self.SubjectId = ko.observable();
    self.InstituitionTypeId = ko.observable(institutionTypeID);
    self.SchoolName = ko.observable("NoSchool");

    if (institutionTypeID != 1) {
        self.CollegeId = ko.observable(0);
        self.DegreeTypeId = ko.observable(0);
        self.CourseId = ko.observable(0);
        self.SubjectId = ko.observable(0);
        self.InstituitionTypeId = ko.observable(institutionTypeID);
        self.SchoolName = ko.observable("");
    }

    return self;
}

function UserViewModel() {
    $('#loading').hide();
    var self = this;

    self.loading = ko.observableArray();

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
                    $("#infoMessages").html(JSON.parse(xhr.responseText).Message).attr("class", "message-success");
                    self.viewModel.user.UserPhoto("");
                    d = new Date();
                    self.viewModel.user.UserPhoto("/upload/" + JSON.parse(xhr.responseText).FileName + "?" + d.getTime());
                } else {
                    $("#infoMessages").html(JSON.parse(xhr.responseText).Message).attr("class", "message-error");
                }
            }
        };
        xhr.send(fd);
    }

    self.CollegeOption = ko.observableArray([]);
    self.LanguageOption = ko.observableArray([]);
    self.GenderOption = ko.observableArray([]);
    self.DegreeTypeOption = ko.observableArray([]);
    self.CourseOption = ko.observableArray([]);
    self.CourseFieldOption = ko.observableArray([]);
    self.SubjectOption = ko.observableArray([]);
    self.viewModel = {};

    self.loadDependentCourses = function (degreetype) {
        var filteredCourses = ko.utils.arrayFilter(self.CourseOption(), function (courseOption) {
            return courseOption.DegreeTypeId === degreetype();
        });

        return filteredCourses;
    };

    self.loadDependentSubjects = function (course) {
        var filteredCourses = ko.utils.arrayFilter(self.SubjectOption(), function (subjectOption) {
            return subjectOption.CourseId === course();
        });

        return filteredCourses;
    };

    self.removeCollegeDetails = self.removePerson = function () {
        self.viewModel.UserEducationDetail.remove(this);
    };
    self.addCollegeDetails = function () {
        self.viewModel.UserEducationDetail.push(ko.mapping.fromJS(ko.mapping.toJS(new BlankUserEducationDetail(1)), validationMapping));
    };

    self.removeSchoolDetails = self.removePerson = function () {
        self.viewModel.UserEducationDetail.remove(this);
    };

    self.addSchoolDetails = function () {
        self.viewModel.UserEducationDetail.push(ko.mapping.fromJS(ko.mapping.toJS(new BlankUserEducationDetail(2)), validationMapping));
    };

    self.loadGenders = function (ctx) {
        self.loading.push(true);
        GetGenderLists(function (output) {
            self.GenderOption(output);
            console.log("loaded genders")
            console.dir(output);
            self.loading.pop();
            if (ctx && ctx.success !== 'undefined') { ctx.success(); }
        }, function (error) {
            $("#infoMessages").html(error).attr("class", "message-error");
            self.loading.pop();
            if (ctx && ctx.success !== 'undefined') { ctx.success(); }
        });
    };

    self.loadCourseFields = function (ctx) {
        self.loading.push(true);
        GetCourseFieldLists(function (output) {
            self.CourseFieldOption(output);
            console.log("loaded course fields")
            console.dir(output);
            self.loading.pop();
            if (ctx && ctx.success !== 'undefined') { ctx.success(); }
        }, function (error) {
            $("#infoMessages").html(error).attr("class", "message-error");
            self.loading.pop();
            if (ctx && ctx.success !== 'undefined') { ctx.success(); }
        });
    };

    self.loadColleges = function (ctx) {
        self.loading.push(true);
        GetCollegeLists(function (output) {
            self.CollegeOption(output);
            console.log("loaded colleges")
            console.dir(output);
            self.loading.pop();
            if (ctx && ctx.success !== 'undefined') { ctx.success(); }
        }, function (error) {
            $("#infoMessages").html(error).attr("class", "message-error");
            self.loading.pop();
            if (ctx && ctx.success !== 'undefined') { ctx.success(); }
        });
    };

    self.loadDegreeTypes = function (ctx) {
        self.loading.push(true);
        GetDegreeTypesList(function (output) {
            self.DegreeTypeOption(output);
            console.log("loaded degreetypes")
            console.dir(output);
            self.loading.pop();
            if (ctx && ctx.success !== 'undefined') { ctx.success(); }

        }, function (error) {
            $("#infoMessages").html(error).attr("class", "message-error");
            self.loading.pop();
            if (ctx && ctx.success !== 'undefined') { ctx.success(); }
        });
    };

    self.loadSubjects = function (ctx) {
        self.loading.push(true);
        GetSubjectsList(function (output) {
            self.SubjectOption(output);
            console.log("loaded subjects")
            console.dir(output);
            self.loading.pop();
            if (ctx && ctx.success !== 'undefined') { ctx.success(); }

        }, function (error) {
            $("#infoMessages").html(error).attr("class", "message-error");
            self.loading.pop();
            if (ctx && ctx.success !== 'undefined') { ctx.success(); }
        });
    };

    self.loadCourses = function (ctx) {
        self.loading.push(true);
        GetCoursesList(function (output) {
            self.CourseOption(output);
            console.log("loaded courses")
            console.dir(output);
            self.loading.pop();
            if (ctx && ctx.success !== 'undefined') { ctx.success(); }

        }, function (error) {
            $("#infoMessages").html(error).attr("class", "message-error");
            self.loading.pop();
            if (ctx && ctx.success !== 'undefined') { ctx.success(); }
        });
    };

    self.loadLanguages = function (ctx) {
        self.loading.push(true);
        GetLanguagesList(function (output) {
            self.LanguageOption(output);
            console.log("loaded languages")
            console.dir(output);
            self.loading.pop();
            if (ctx && ctx.success !== 'undefined') { ctx.success(); }
        }, function (error) {
            $("#infoMessages").html(error).attr("class", "message-error");
            self.loading.pop();
            if (ctx && ctx.success !== 'undefined') { ctx.success(); }
        });
    }

    // Loads user.
    self.load = function () {
        $('#loading').show();
        // Important: we need to load countries and languages first and only then load the user, to make
        // sure that corresponding drop-downs are populated before loaded user will try to set values on them

        // loadUser() is run once, after both loadCountries() and loadLanguages() have run (they do run in parallel!)
        var parallelExecutions = [self.loadColleges, self.loadGenders, self.loadDegreeTypes, self.loadSubjects, self.loadCourses, self.loadLanguages, self.loadCourseFields];
        var delayedLoadUser = _.after(parallelExecutions.length, self.loadUserProfile);
        _.each(parallelExecutions, function (func) {
            func({ success: delayedLoadUser });
        });
    };


    self.loadUserProfile = function () {
        $('#loading').show();
        GetUserProfile(
            function (data, textStatus, jqXHR) {
                if (textStatus == "success") {
                    self.viewModel = ko.mapping.fromJSON(jqXHR.responseText, validationMapping);

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

    self.SaveUserProfile = function () {
        $("#infoMessages").html("");
        if (self.errors().length == 0) {
            $('#loading').show();
            var userProfile = ko.toJSON(self.viewModel);
            UpdateUserProfile(userProfile,
                function (data, textStatus, jqXHR) {
                    $('#loading').hide();
                    self.viewModel.user.UserID(JSON.parse(jqXHR.responseText).userProfile.user.UserID)
                    var output = JSON.parse(jqXHR.responseText);
                    window.location.href = JSON.parse(jqXHR.responseText).redirectToUrl;
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
                return ko.observable(options.data).extend({ required: { message: globalResources.resources.FirstNameRequiredMessage }, maxLength: 50 });
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
                        message: globalResources.resources.InvalidZipCodeMessage,
                        params: '^(0|[1-9][0-9]*)$'
                    }
                });
            }
        },
        MobileNo: {
            create: function (options) {
                return ko.observable(options.data).extend({
                    minLength: 10, maxLength: 10, pattern: {
                        message: globalResources.resources.InvalidPhoneNumberMessage,
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
                return ko.observable(options.data).extend({ required: { message: globalResources.resources.CollegeRequiredMessage } });
            }
        },
        PassingYear: {
            create: function (options) {
                return ko.observable(options.data).extend({
                    required: { message: globalResources.resources.FirstNameRequiredMessage },
                    minLength: 4, maxLength: 4, pattern: {
                        message: 'Please enter valid Passing Year',
                        params: '^(0|[1-9][0-9]*)$'
                    }
                });
            }
        },
        DegreeTypeId: {
            create: function (options) {
                return ko.observable(options.data).extend({ required: { message: globalResources.resources.DegreeTypeRequiredMessage } });
            }
        },
        CourseId: {
            create: function (options) {
                return ko.observable(options.data).extend({ required: { message: globalResources.resources.CourseRequiredMessage } });
            }
        },
        SubjectId: {
            create: function (options) {
                return ko.observable(options.data).extend({ required: { message: globalResources.resources.SubjectRequiredMessage } });
            }
        },
        SchoolName: {
            create: function (options) {
                return ko.observable(options.data).extend({ required: { message: globalResources.resources.SchoolNameRequiredMessage } });
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

