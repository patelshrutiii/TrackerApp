app.factory("TeamReportService", ["$http", "$rootScope",
    function ($http, $rootscope) {
        var TeamReports = {};

        TeamReports.GetTeam = function (companyId) {
            return $http({
                method: "get",
                url: $rootscope.WebApiUrl + "api/TeamReport/GetTeamList?companyId=" + companyId,
                contentType: "application/json"
            });
        }

        TeamReports.TeamReportSP = function (companyId, userId, Todate, fromdate) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/TeamReport/TeamReportSP?companyId=" + companyId + "&userId=" + userId + "&Todate=" + Todate + "&fromdate=" + fromdate,
                contentType: "application/json"
            });
        }
        return TeamReports;
    }]);