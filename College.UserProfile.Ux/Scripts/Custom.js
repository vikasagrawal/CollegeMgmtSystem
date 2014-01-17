ko.validation.rules['areSame'] = {
    getValue: function (o) {
        return (typeof o === 'function' ? o() : o);
    },
    validator: function (val, params) {
        return val === this.getValue(params);
    },
    message: 'Passwords must match.'
};

ko.validation.rules['passwordComplexity'] = {
    validator: function (val) {
        return /(?=^[^\s]{6,128}$)((?=.*?\d)(?=.*?[A-Z])(?=.*?[a-z])|(?=.*?\d)(?=.*?[^\w\d\s])(?=.*?[a-z])|(?=.*?[^\w\d\s])(?=.*?[A-Z])(?=.*?[a-z])|(?=.*?\d)(?=.*?[A-Z])(?=.*?[^\w\d\s]))^.*/.test('' + val + '');
    },
    message: 'Password must be between 6 and 128 characters long and contain three of the following 4 items: upper case letter, lower case letter, a symbol, a number'
};

ko.validation.registerExtenders();

ko.bindingHandlers.datepicker = {
    init: function (element, valueAccessor, allBindingsAccessor) {

        var options = allBindingsAccessor().datepickerOptions || {},
           $el = $(element);
        //initialize datepicker with some optional options
        $el.datepicker();
        $el.datepicker('option', options);
        var jsonDate = valueAccessor();

        if (jsonDate() != null) {
            var value = new Date(parseInt(jsonDate().replace("/Date(", "").replace(")/", ""), 10));
            $el.datepicker("setDate", value);
            valueAccessor()(value);
        }
        //handle the field changing
        ko.utils.registerEventHandler(element, "change", function () {
            var observable = valueAccessor();
            observable($el.datepicker("getDate"));
        });

        //handle disposal (if KO removes by the template binding)
        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $el.datepicker("destroy");
        });

    },
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor()),
            $el = $(element),
            current = $el.datepicker("getDate");
    }
};

ko.bindingHandlers.trueFalseRadioButton =
{
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        // event handler for the element change event
        var changeHandler = function () {
            var elementValue = $(element).val();
            var observable = valueAccessor();      // set the observable value to the boolean value of the element value
            observable($.parseJSON(elementValue));
        };    // register change handler for element
        ko.utils.registerEventHandler(element,
                                      "change",
                                      changeHandler);
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var elementValue = $.parseJSON($(element).val());
        var observableValue = ko.utils.unwrapObservable(valueAccessor());
        if (elementValue === observableValue) {
            element.checked = true;
        }
        else {
            element.checked = false;
        }
    }
};

function GetGenderLists(handleData, handleException) {
    $.ajax({
        url: "/CodeLookup/Gender/Index",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        error: function (data, textStatus, jqXHR) {
            handleException(JSON.parse(jqXHR.responseText).Message);
        },
        success: function (data) {
            handleData(data);
        }
    });
}


function GetLanguagesList(handleData, handleException) {
    $.ajax({
        url: "/CodeLookup/Language/Index",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        error: function (data, textStatus, jqXHR) {
            handleException(JSON.parse(jqXHR.responseText).Message);
        },
        success: function (data) {
            handleData(data);
        }
    });
}

function GetDegreeTypesList(handleData, handleException) {
    $.ajax({
        url: "/CodeLookup/DegreeType/Index",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        error: function (data, textStatus, jqXHR) {
            handleException(JSON.parse(jqXHR.responseText).Message);
        },
        success: function (data) {
            handleData(data);
        }
    });
}

function GetSubjectsList(handleData, handleException) {
    $.ajax({
        url: "/CodeLookup/Subject/Index",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        error: function (data, textStatus, jqXHR) {
            handleException(JSON.parse(jqXHR.responseText).Message);
        },
        success: function (data) {
            handleData(data);
        }
    });
}


function GetCoursesList(handleData, handleException) {
    $.ajax({
        url: "/CodeLookup/Course/Index",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        error: function (data, textStatus, jqXHR) {
            handleException(JSON.parse(jqXHR.responseText).Message);
        },
        success: function (data) {
            handleData(data);
        }
    });
}

function GetCourseFieldLists(handleData, handleException) {
    $.ajax({
        url: "/CodeLookup/CourseField/Index",
        type: "GET",
        contentType: "application/json",
        dataType: "json",
        error: function (data, textStatus, jqXHR) {
            handleException(JSON.parse(jqXHR.responseText).Message);
        },
        success: function (data) {
            handleData(data);
        }
    });
}