app.controller('TaskReportController',
    function TaskReportController($scope, $filter, DepartmentService, TaskReportService, DesignationService, ProjectService) {
        $scope.companyId = 0;
        $scope.projectId = 0;
        $scope.deptId = 0;
        $scope.desId = 0;

        $scope.sdate = new Date();
        $scope.edate = new Date();
        $scope.GetProjectList = function () {
            var project = ProjectService.GetAll($scope.companyId);
            project.then(function (response) {
                $scope.projects = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetProjectList();
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

        $scope.GetManageTaskList = function () {
            $scope.projectId = $scope.projectId;
            $scope.deptId = $scope.deptId;
            $scope.desId = $scope.desId;
            var sdate = $scope.sdate;
            var edate = $scope.edate;
            $scope.sdate = $filter('date')(sdate, 'yyyy-MM-dd');
            $scope.edate = $filter('date')(edate, 'yyyy-MM-dd');
            var Mtask = TaskReportService.GetManageTaskList($scope.companyId, $scope.projectId, $scope.deptId, $scope.desId, $scope.sdate, $scope.edate);
            console.log(Mtask);
            Mtask.then(function (response) {                
                    $scope.Mtasklist = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.sortColumn = "TaskName";
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