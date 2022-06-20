app.factory("SettingService", ["$http", "$rootScope",
    function ($http, $rootscope) {
        var setting = {};
        setting.GetAccountInfo = function (companyId,cname) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/setting/GetAccountInfo?companyId=" + companyId + "&cname=" + cname,
                contentType: "application/json"
            });
        }
        return setting;
    }]);