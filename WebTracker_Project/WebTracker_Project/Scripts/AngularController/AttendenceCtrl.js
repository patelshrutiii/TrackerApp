app.controller('AttendenceController',
    function AttendenceController($scope, $filter, AttendenceService, TeamService, DepartmentService, DesignationService) {
        $scope.attend = [];
        $scope.companyId = 0;
        $scope.userId = 0;
        $scope.deptId = 0;
        $scope.desId = 0;
        $scope.sdate = new Date();
        /*$scope.isshowtable = false;*/

        $scope.GetTeamList = function () {
            var team = TeamService.GetAll($scope.companyId);
            team.then(function (response) {
                $scope.teams = response.data;
            //    $scope.userId = $scope.teams[0].UserId;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetTeamList();

        $scope.GetDeptList = function () {
            var dept = DepartmentService.GetAll($scope.companyId);
            dept.then(function (response) {
                $scope.depts = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetDeptList();

        $scope.GetDesList = function () {
            var des = DesignationService.GetAll($scope.companyId);
            des.then(function (response) {
                $scope.deslist = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetDesList();

        $scope.GetAttendence = function () {
          /*  $scope.isshowtable = true;*/
            $scope.userId = $scope.userId;
            $scope.deptId = $scope.deptId;
            $scope.desId = $scope.desId;
            var sdate = $scope.sdate;
            $scope.sdate = $filter('date')(sdate, 'yyyy-MM-dd');
            var attend = AttendenceService.GetAll($scope.companyId, $scope.userId, $scope.deptId, $scope.desId, $scope.sdate);

            attend.then(function (response) {
                $scope.attends = response.data;
                console.log($scope.screens);
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.sortColumn = "UserName";
        $scope.reverseSort = false;

        $scope.sortData = function (column) {
            $scope.reverseSort = ($scope.sortColumn == column) ? !$scope.reverseSort : false;
            $scope.sortColumn = column;
        }

        $scope.getSortClass = function (column) {

            if ($scope.sortColumn == column) {
                return $scope.reverseSort
                    ? 'arrow-up'
                    : 'arrow-down';
            }

            return '';
        }

    });
