app.factory("TeamService", ["$http", "$rootScope",
    function ($http, $rootscope) {
        var Team = {};
        Team.CreateUpdate = function (data,companyId) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Team/CreateUpdate?companyId=" + companyId,
                data: data,
                contentType: "application/json"
            });
        }        
        Team.GetAll = function (companyId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Team/GetTeamList?companyId="+companyId,
                contentType: "application/json"
            });
        }        
        Team.ArchieveTeamList = function (companyId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Team/ArchieveTeamList?companyId=" + companyId,
                contentType: "application/json"
            });
        }
        Team.Delete = function (id) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Team/Delete/" + id,
                contentType: "application/json"
            });
        }
        Team.Restore = function (id) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Team/Restore/" + id,
                contentType: "application/json"
            });
        }

        Team.Trash = function (id) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Team/Trash/" + id,
                contentType: "application/json"
            });
        }
        return Team;
    }]);