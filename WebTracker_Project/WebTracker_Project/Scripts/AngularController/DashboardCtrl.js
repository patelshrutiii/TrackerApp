app.controller('DashboardController',
    function DashboardController($scope, DashboardService,TeamService,ProjectService) {
        $scope.companyId = 0;
        function GetData() {

            var k = $.ajax({
                method: "get",
                url: "/Dashboard/piechartdata",
                dataType: "application/json",
                async: false,
            });
            var values = JSON.parse(k.responseText);           
            Highcharts.chart('container', {
                chart: {
                    plotBackgroundColor: null,
                    plotBorderWidth: null,
                    plotShadow: false,
                    type: 'pie'
                },
                title: {
                    text: 'Statistics'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                accessibility: {
                    point: {
                        valueSuffix: '%'
                    }
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        dataLabels: {
                            enabled: false
                        },
                        showInLegend: true
                    }
                },
                series: [{
                    name: 'Percentage',
                    colorByPoint: true,
                    data: [{
                        name: 'User',
                        y: values.user,
                        sliced: true,
                        selected: true
                    }, {
                        name: 'Project',
                        y: values.proj
                    }, {
                        name: 'Task',
                        y: values.task
                    }]
                }]
            });
        }
        GetData();
        $scope.TaskProgress = function () {
            var progress = DashboardService.TaskProgress($scope.companyId);
            progress.then(function (response) {
                $scope.progresses = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetAllUsers = function () {
            var user = DashboardService.GetAllUsers($scope.companyId);
            user.then(function (response) {
                $scope.users = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetAllProjects = function () {           
            var allproject = DashboardService.GetAllProjects($scope.companyId);
            allproject.then(function (response) {
                $scope.allprojects = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetAllTasks = function () {
            var task = DashboardService.GetAllTasks($scope.companyId);
            task.then(function (response) {
                $scope.tasks = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetAllRoles = function () {
            var role = DashboardService.GetAllRoles($scope.companyId);
            role.then(function (response) {
                $scope.roles = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetAllDepartments = function () {
            var department = DashboardService.GetAllDepartments($scope.companyId);
            department.then(function (response) {
                $scope.departments = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetAllDesignations = function () {
            var designation = DashboardService.GetAllDesignations($scope.companyId);
            designation.then(function (response) {
                $scope.designations = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
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

        $scope.GetTeamList = function () {
            var team = TeamService.GetAll($scope.companyId);
            team.then(function (response) {
                $scope.teams = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetTeamList();

        $scope.GetTotalDailyTime = function () {
            var daily = DashboardService.GetTotalDailyTime($scope.companyId);
            daily.then(function (response) {
                $scope.dailytime = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetTotalWeeklyTime = function () {
            var weekly = DashboardService.GetTotalWeeklyTime($scope.companyId);
            weekly.then(function (response) {
                $scope.weeklytime = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetAll = function () {
            $scope.GetTotalDailyTime();
            $scope.GetTotalWeeklyTime();
            $scope.GetAllUsers();
            $scope.TaskProgress();
            $scope.GetAllProjects();
            $scope.GetAllTasks();
            $scope.GetAllRoles();
            $scope.GetAllDepartments();
            $scope.GetAllDesignations();
        }
    });
