app.factory("ScreenshotService", ["$http", "$rootScope",
    function ($http, $rootscope) {
        var Screenshot = {};       
        
        Screenshot.Delete = function (itemList) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Screenshot/Delete",
                data: JSON.stringify({ itemList } ),
                contentType: "application/json",
                async: false
            });
        }
        Screenshot.Restore = function (itemList) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Screenshot/Restore",
                data: JSON.stringify({ itemList }),
                contentType: "application/json",
                async: false
            });
        }
        Screenshot.Trash = function (itemList) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Screenshot/Trash",
                data: JSON.stringify({ itemList }),
                contentType: "application/json",
                async: false
            });
        }
        Screenshot.GetAll = function (companyId,userId,projectId,sdate) {
            return $http({
                method: "get",
                url: $rootscope.WebApiUrl + "api/Screenshot/GetSSByUser?companyId=" + companyId + "&userId=" + userId + "&projectId=" + projectId + "&sdate=" + sdate,
                contentType: "application/json"
            });
        }
        Screenshot.GetDailyTimeDetails = function (companyId,ssid) {
            return $http({
                method: "get",
                url: $rootscope.WebApiUrl + "api/Screenshot/GetDailyTimeDetails?companyId=" + companyId  + "&ssid=" + ssid,
                contentType: "application/json"
            });
        }

        Screenshot.GetArchieveTeamList = function (companyId, userId, projectId, sdate) {
            return $http({
                method: "get",
                url: $rootscope.WebApiUrl + "api/Screenshot/GetArchieveSSByUser?companyId=" + companyId + "&userId=" + userId + "&projectId=" + projectId + "&sdate=" + sdate,
                contentType: "application/json"
            });
        }    
        return Screenshot;
    }]);