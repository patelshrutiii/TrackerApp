app.factory("AttendenceService", ["$http", "$rootScope",
    function ($http, $rootscope) {
        var Attendence = {};       

        Attendence.GetAll = function (companyId, userId, deptId, desId, sdate) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Attendence/GetAttendence?companyId=" + companyId + "&userId=" + userId + "&deptId=" + deptId + "&desId=" + desId + "&sdate=" + sdate,
                contentType: "application/json"
            });
        }
        return Attendence;
    }]);