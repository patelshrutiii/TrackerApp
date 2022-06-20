app.factory("CompanyService", ["$http", "$rootScope",
    function ($http, $rootscope) {
        var Company = {};
        Company.CreateUpdate= function (data) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Company/CreateUpdate",
                data: data,
                contentType: "application/json"
            });
        }       
        //using for setting profile
        Company.GetCompanyById = function (companyId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Company/GetCompanyById?companyId=" + companyId,
                contentType: "application/json"
            })
        }
        Company.GetAll = function () {
            return $http({
                method: "get",
                url: $rootscope.WebApiUrl + "api/Company/GetCompanyList",
                contentType: "application/json"
            });
        }
        Company.StateList = function () {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Company/StateList",
                contentType: "application/json"
            });
        }
        Company.CityList = function (StateId) {
            return $http({
                method: "GET",
                url: $rootscope.WebApiUrl + "api/Company/CityList/" + StateId,
                contentType: "application/json"
            });
        }
        Company.Delete = function (id) {
            return $http({
                method: "POST",
                url: $rootscope.WebApiUrl + "api/Company/Delete/" + id,
                contentType: "application/json"
            });

        }

        Company.GetUser = function (d) {
            return $http({
                url: '/api/Company/UserLogin',
                method: 'POST',
                data: JSON.stringify(d),
                dataType: "application/json"
            });
        };
        return Company;
    }]);
