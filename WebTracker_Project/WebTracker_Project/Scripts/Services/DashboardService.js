app.factory("DashboardService", ["$http", "$rootScope",
    function ($http, $rootscope) {
        var Dashboard = {};
        Dashboard.TaskProgress = function (companyId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Dashboard/TaskProgress?companyId=" + companyId,
                contentType: "application/json"
            });
        }

        Dashboard.GetAllUsers = function (companyId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Dashboard/GetAllUsers?companyId=" + companyId,
                contentType: "application/json"
            });
        }

        Dashboard.GetAllProjects = function (companyId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Dashboard/GetAllProjects?companyId=" + companyId,
                contentType: "application/json"
            });
        }

        Dashboard.GetAllTasks = function (companyId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Dashboard/GetAllTasks?companyId=" + companyId,
                contentType: "application/json"
            });
        }

        Dashboard.GetAllRoles = function (companyId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Dashboard/GetAllRoles?companyId=" + companyId,
                contentType: "application/json"
            });
        }


        Dashboard.GetAllDepartments = function (companyId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Dashboard/GetAllDepartments?companyId=" + companyId,
                contentType: "application/json"
            });
        }

        Dashboard.GetAllDesignations = function (companyId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Dashboard/GetAllDesignations?companyId=" + companyId,
                contentType: "application/json"
            });
        }
        Dashboard.GetTotalDailyTime = function (companyId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Dashboard/GetTotalDailyTime?companyId=" + companyId,
                contentType: "application/json"
            });
        }

        Dashboard.GetTotalWeeklyTime = function (companyId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Dashboard/GetTotalWeeklyTime?companyId=" + companyId,
                contentType: "application/json"
            });
        }

        return Dashboard;
    }]);