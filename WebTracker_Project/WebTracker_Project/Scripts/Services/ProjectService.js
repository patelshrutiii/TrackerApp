app.factory("ProjectService", ["$http", "$rootScope",
        function ($http, $rootscope) {
            var Project = {};
            Project.CreateUpdate = function (data,companyId) {
                return $http({
                    method: "POST",
                    url: $rootscope.WebApiUrl + "api/Project/CreateUpdate?companyId=" + companyId,
                    data: data,
                    contentType: "application/json"
                });
            }
            //Project.GetAssignById = function (id) {
            //    return $http({
            //        method: "POST",
            //        url: $rootscope.WebApiUrl + "api/Project/GetAssignById" + id,
            //        contentType: "application/json"
            //    })
            //}
            Project.GetAll = function (companyId) {
                return $http({
                    method: "get",
                    url: $rootscope.WebApiUrl + "api/Project/GetProjectList?companyId=" + companyId,
                    contentType: "application/json"
                });
            }           
            Project.ArchieveProjList = function (companyId) {
                return $http({
                    method: "get",
                    url: $rootscope.WebApiUrl + "api/Project/ArchieveProjList?companyId=" + companyId,
                    contentType: "application/json"
                });
            }
            Project.Delete = function (id) {
                return $http({
                    method: "POST",
                    url: $rootscope.WebApiUrl + "api/Project/Delete/" + id,
                    contentType: "application/json"
                });

            }
            Project.Restore = function (id) {
                return $http({
                    method: "POST",
                    url: $rootscope.WebApiUrl + "api/Project/Restore/" + id,
                    contentType: "application/json"
                });

            }
            Project.Trash = function (id) {
                return $http({
                    method: "POST",
                    url: $rootscope.WebApiUrl + "api/Project/Trash/" + id,
                    contentType: "application/json"
                });

            }
            //Project.GetProjectAssignedUsers = function (companyId, ProjectId) {
            //    return $http({
            //        method: "GET",
            //        url: $rootscope.WebApiUrl + "api/Project/GetProjectAssignedUsers?companyId=" + companyId + "&ProjectId=" + ProjectId,
            //        /*  data: data,*/
            //        contentType: "application/json"
            //    });
            //}
            return Project;
        }]);