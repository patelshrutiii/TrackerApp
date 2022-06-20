app.factory("TeamScreenshotService", ["$http", "$rootScope",
    function ($http, $rootscope) {
        var TeamScreenshot = {};       
        TeamScreenshot.GetAll = function (companyId, userId, projectId, sdate) {
            return $http({
                method: "get",
                url: $rootscope.WebApiUrl + "api/TeamScreenshot/GetSSByUser?companyId=" + companyId + "&userId=" + userId + "&projectId=" + projectId + "&sdate=" + sdate,
                contentType: "application/json"
            });
        }

        TeamScreenshot.GetProject = function (companyId) {
            return $http({
                method: "get",
                url: $rootscope.WebApiUrl + "api/TeamScreenshot/GetProjectList?companyId=" + companyId,
                contentType: "application/json"
            });
        }

        TeamScreenshot.GetTeam = function (companyId) {
            return $http({
                method: "get",
                url: $rootscope.WebApiUrl + "api/TeamScreenshot/GetTeamList?companyId=" + companyId,
                contentType: "application/json"
            });
        }

        TeamScreenshot.GetDailyTimeDetails = function (companyId, ssid) {
            return $http({
                method: "get",
                url: $rootscope.WebApiUrl + "api/TeamScreenshot/GetDailyTimeDetails?companyId=" + companyId + "&ssid=" + ssid,
                contentType: "application/json"
            });
        }
        return TeamScreenshot;
    }]);