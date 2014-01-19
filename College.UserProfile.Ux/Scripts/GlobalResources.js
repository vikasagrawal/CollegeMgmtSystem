var globalResources;
$.ajax({
    url: '/Localization/GlobalResources?files=ClientResources.resx',
    dataType: 'json',
    async: false
}).
    done(function (data) {
        globalResources = data
    }).fail(function (data) {
        globalResources = data
    });
