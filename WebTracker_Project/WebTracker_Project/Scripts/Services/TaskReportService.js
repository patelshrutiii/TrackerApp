app.factory("TaskReportService", ["$http", "$rootScope",
    function ($http, $rootscope) {
        var Mtask = {};

        Mtask.GetManageTaskList = function (companyId, projectId, deptId, desId, sdate, edate) {

            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/TaskReport/GetManageTaskList?companyId=" + companyId + "&projectId=" + projectId + "&deptId=" + deptId + "&desId=" + desId + "&sdate=" + sdate + "&edate=" + edate,

                contentType: "application/json"
            });
        }
        return Mtask;
    }]);

