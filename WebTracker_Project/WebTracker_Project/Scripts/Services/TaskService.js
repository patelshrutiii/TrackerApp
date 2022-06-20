app.factory("TaskService", ["$http", "$rootScope",
    function ($http, $rootscope) {
        var Task = {};
        Task.CreateUpdate = function (data,companyId) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Task/CreateUpdate?companyId=" + companyId,
                data: data,
                contentType: "application/json"
            });
        }

        Task.TaskAssignToAll = function (data) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Task/TaskAssignToAll",
                data: data,
                contentType: "application/json"
            });
        }

        Task.refreshedit = function (companyId, ProjectId, TaskId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Task/refreshedit?companyId=" + companyId + "&ProjectId=" + ProjectId + "&TaskId=" + TaskId,

                contentType: "application/json"
            });
        }
        Task.TaskAssignUser = function (data) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Task/TaskAssignUser",
                data: data,
                contentType: "application/json"
            });
        }
        Task.GetAssignusers = function (companyId, ProjectId, TaskId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Task/GetAssignusers?companyId=" + companyId + "&ProjectId=" + ProjectId + "&TaskId=" + TaskId,

                contentType: "application/json"
            });
        }
        Task.GetActiveTask = function (companyId, ProjectId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Task/GetActiveTask?companyId=" + companyId + "&ProjectId=" + ProjectId,

                contentType: "application/json"
            });
        }
        Task.GetCompletedList = function (companyId, ProjectId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Task/GetCompletedList?companyId=" + companyId + "&ProjectId=" + ProjectId,

                contentType: "application/json"
            });
        }
        Task.GetProjectname = function (companyId, ProjectId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Task/GetProjectname?companyId=" + companyId + "&ProjectId=" + ProjectId,
                contentType: "application/json"
            });
        }
        Task.GetAll = function (companyId, ProjectId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Task/GetTaskList?companyId=" + companyId + "&ProjectId=" + ProjectId,

                contentType: "application/json"
            });

        }
        Task.GetPriorityList = function () {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Task/GetPriorityList",

                contentType: "application/json"
            });
        }
        Task.GetStatusList = function () {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Task/GetStatusList",

                contentType: "application/json"
            });
        }
        Task.GetTaskByProject = function (companyId, projectID) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Task/GetTaskByProject?companyId=" + companyId + "&projectID=" + projectID,
                /*  data: data,*/
                contentType: "application/json"
            });
        }

        Task.GetTaskAssignedUsers = function (companyId, selectedProjectId, TaskId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Task/GetTaskAssignedUsers?companyId=" + companyId + "&selectedProjectId=" + selectedProjectId + "&TaskId=" + TaskId,
                /*  data: data,*/
                contentType: "application/json"
            });
        }

        Task.DeleteAllTask = function (companyId, Pid) {

            //var data = { Cid: Cid, Pid: Pid }

            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Task/DeleteAllTask?companyId=" + companyId + "&Pid=" + Pid,
                //data: JSON.stringify(data),
                contentType: "application/json"
            });

        }

        Task.DeleteCompletedTask = function (companyId, Pid) {

            //var data = { Cid: Cid, Pid: Pid }

            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Task/DeleteCompletedTask?companyId=" + companyId + "&Pid=" + Pid,
                /*  data: JSON.stringify(data),*/
                contentType: "application/json"
            });

        }
        Task.Delete = function (companyId, selectedProjectId, TaskId) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Task/Delete?companyId=" + companyId + "&selectedProjectId=" + selectedProjectId + "&TaskId=" + TaskId,
                //data: JSON.stringify(data),
                contentType: "application/json"
            });
        }

        Task.DeleteUser = function (AssignId) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Task/DeleteUser/" + AssignId,
                //data: JSON.stringify(data),
                contentType: "application/json"
            });
        }

        Task.UpdateStatus = function (TaskId) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Task/UpdateStatus/" + TaskId,
                contentType: "application/json"
            });
        }
        return Task;
    }]);