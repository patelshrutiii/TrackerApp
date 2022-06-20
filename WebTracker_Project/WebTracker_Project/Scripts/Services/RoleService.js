app.factory("RoleService", ["$http", "$rootScope",
    function ($http, $rootscope) {
        var Role = {};       
        Role.GetAll = function (companyId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Role/GetRoleList?companyId=" + companyId,
                contentType: "application/json"
            });
        }
        return Role;
    }]);