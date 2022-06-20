app.controller('RoleController',
    function RoleController($scope, RoleService) {
        $scope.companyId = 0;
     
        $scope.GetRoleList = function () {
            var role = RoleService.GetAll($scope.companyId);
            role.then(function (response) {
                $scope.roles = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetRoleList();   
    });
