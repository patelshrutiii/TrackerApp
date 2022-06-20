app.factory("DepartmentService", ["$http", "$rootScope",
    function ($http, $rootscope) {
        var Department = {};
        Department.CreateUpdate = function (data,companyId) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Department/CreateUpdate?companyId=" + companyId,
                data: data,
                contentType: "application/json"
            });
        }        
        Department.GetAll = function (companyId) {
            return $http({
                method: "get",
                url: $rootscope.WebApiUrl + "api/Department/GetDeptList?companyId=" + companyId,
                contentType: "application/json"
            });
        }
        Department.ArchieveDeptList = function (companyId) {
            return $http({
                method: "get",
                url: $rootscope.WebApiUrl + "api/Department/ArchieveDeptList?companyId=" + companyId,
                contentType: "application/json"
            });
        }
        Department.Delete = function (id) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Department/Delete/" + id,
                contentType: "application/json"
            });
        }
        Department.Restore = function (id) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Department/Restore/" + id,
                contentType: "application/json"
            });
        }
        Department.Trash = function (id) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Department/Trash/" + id,
                contentType: "application/json"
            });
        }
        return Department;
    }]);