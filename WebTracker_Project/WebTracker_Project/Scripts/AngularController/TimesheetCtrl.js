app.controller('TimesheetController',
    function TimesheetController($scope, $filter, TimesheetService, TeamService, ProjectService, DepartmentService, DesignationService) {
        $scope.Time = [];
        $scope.companyId = 0;
        $scope.projectId = 0;
        $scope.userId = 0;
        $scope.departmentId = 0;
        $scope.designationId = 0;
        $scope.fromdate = new Date();
        $scope.Todate = new Date();

        $scope.ProjectReportForm = true;
        $scope.UserReportForm = false;

        //$scope.Contract = function () {
        //    $scope.ContractReportForm = true;
        //    $scope.ProjectReportForm = false;
        //    $scope.UserReportForm = false;

        //}
        $scope.Project = function () {

            $scope.ProjectReportForm = true;
            // $scope.ContractReportForm = false;
            $scope.UserReportForm = false;
        }
        $scope.Report = function () {
            $scope.UserReportForm = true;
            //  $scope.ContractReportForm = false;
            $scope.ProjectReportForm = false;

        }

        $scope.GetUserList = function () {
            var user = TeamService.GetAll($scope.companyId);
            user.then(function (response) {
                $scope.teams = response.data;

            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.ProjectReportSP = function () {
            $scope.projectId = $scope.projectId;
            var Todate = $filter('date')($scope.Todate, 'yyyy-MM-dd');
            var fromdate = $filter('date')($scope.fromdate, 'yyyy-MM-dd');
            var Time = TimesheetService.ProjectReportSP($scope.companyId, $scope.projectId, Todate, fromdate);
            Time.then(function (response) {
                $scope.TimeProject = response.data;
                $scope.GridProjectReport();
                setTimeout(function () {
                    $scope.$apply();

                })

            });
        }

        $scope.UserReportSP = function () {
            $scope.userId = $scope.userId;
            $scope.designationId = $scope.designationId;
            $scope.departmentId = $scope.departmentId;
            var Todate = $filter('date')($scope.Todate, 'yyyy-MM-dd');
            var fromdate = $filter('date')($scope.fromdate, 'yyyy-MM-dd');
            var Time = TimesheetService.UserReportSP($scope.companyId, $scope.userId, $scope.designationId, $scope.departmentId, Todate, fromdate);
            Time.then(function (response) {
                $scope.TimeUser = response.data;
                $scope.GridUserReport();
                setTimeout(function () {
                    $scope.$apply();

                })
            });
        }
        $scope.GridUserReport = function () {
            $scope.dataGridOptions1 = $('#gridContainer').dxDataGrid({
                dataSource: $scope.TimeUser,
                showBorders: true,
                useNative: true,
                columnAutoWidth: true,
                allowColumnResizing: true,
                showScrollbar: false,

                customizeColumns: function (columns) {
                    columns[0].width = 150;
                    columns[0].fixed = true,
                        columns[0].fixedPosition = "left"
                    columns[0].FixedStyle = "Left";
                    columns[1].width = 150;
                    columns[1].fixed = true,
                        columns[1].fixedPosition = "left"
                    columns[1].FixedStyle = "Left";

                },
            }).dxDataGrid('instance');
        }
        $scope.GridProjectReport = function () {
            $scope.dataGridOptions = $('#gridContainer1').dxDataGrid({
                dataSource: $scope.TimeProject,
                showBorders: true,
                useNative: true,
                columnAutoWidth: true,
                allowColumnResizing: true,
                showScrollbar: false,

                customizeColumns: function (columns) {
                    columns[0].width = 150;
                    columns[0].fixed = true,
                        columns[0].fixedPosition = "left"
                    columns[0].FixedStyle = "Left";

                },
            }).dxDataGrid('instance');
        }
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

    })