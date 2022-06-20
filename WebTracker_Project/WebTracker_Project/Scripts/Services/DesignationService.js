app.factory("DesignationService", ["$http", "$rootScope",
    function ($http, $rootscope) {
        var Designation = {};
        Designation.CreateUpdate = function (data, companyId) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Designation/CreateUpdate?companyId=" + companyId,
                data: data,
                contentType: "application/json"
            });
        }
        Designation.GetAll = function (companyId) {
            return $http({
                method: "get",
                url: $rootscope.WebApiUrl + "api/Designation/GetDesList?companyId=" + companyId,
                contentType: "application/json"
            });
        }
        Designation.ArchieveDesList = function (companyId) {
            return $http({
                method: "get",
                url: $rootscope.WebApiUrl + "api/Designation/ArchieveDesList?companyId=" + companyId,
                contentType: "application/json"
            });
        }
        Designation.Delete = function (id) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Designation/Delete/" + id,
                contentType: "application/json"
            });
        }
        Designation.Restore = function (id) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Designation/Restore/" + id,
                contentType: "application/json"
            });
        }
        Designation.Trash = function (id) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Designation/Trash/" + id,
                contentType: "application/json"
            });
        }
        return Designation;
    }]);