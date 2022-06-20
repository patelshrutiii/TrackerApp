app.factory("TimesheetService", ["$http", "$rootScope",
    function ($http, $rootscope) {
        var TimeSheet = {}; 

        TimeSheet.ProjectReportSP = function (companyId, projectId, Todate, fromdate) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Timesheet/ProjectReportSP?companyId=" + companyId + "&projectId=" + projectId + "&Todate=" + Todate + "&fromdate=" + fromdate,
                contentType: "application/json"
            });
        }

        TimeSheet.UserReportSP = function (companyId, userId, designationId, departmentId, Todate, fromdate) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Timesheet/UserReportSP?companyId=" + companyId + "&userId=" + userId + "&designationId=" + designationId + "&departmentId=" + departmentId + "&Todate=" + Todate + "&fromdate=" + fromdate,
                contentType: "application/json"
            });
        }
        return TimeSheet;
    }]);