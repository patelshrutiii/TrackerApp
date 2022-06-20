app.controller('TeamReportController',
    function TeamReportController($scope, $filter, $location, TeamReportService) {
        $scope.TeamReport = [];
        $scope.userName = "";
        $scope.companyId = 0;
        $scope.userId = 0;
        $scope.fromdate = new Date();
        $scope.Todate = new Date();
        $scope.url = '';
        $scope.url = $location.absUrl();
        $scope.firstUrl = ($scope.url).toString().split("?");
        $scope.secUrl = ($scope.firstUrl[1]).toString().split("&");
        $scope.cid = ($scope.secUrl[0]).toString().split("=");
        $scope.companyId = $scope.cid[1];
        $scope.uid = ($scope.secUrl[1]).toString().split("=");
        $scope.userId = $scope.uid[1];


        $scope.GetTeamList = function () {
            var team = TeamReportService.GetTeam($scope.companyId);
            team.then(function (response) {
                $scope.teams = response.data;
                for (i = 0; i < $scope.teams.length; i++) {
                    if ($scope.userId == $scope.teams[i].UserId) {
                        $scope.userName = $scope.teams[i].FirstName + " " + $scope.teams[i].LastName;
                    }
                }
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetTeamList();

        $scope.TeamReportSP = function () {
            $scope.userId = $scope.userId;
            $scope.designationId = $scope.designationId;
            $scope.departmentId = $scope.departmentId;
            var Todate = $filter('date')($scope.Todate, 'yyyy-MM-dd');
            var fromdate = $filter('date')($scope.fromdate, 'yyyy-MM-dd');
            var TeamReport = TeamReportService.TeamReportSP($scope.companyId, $scope.userId, Todate, fromdate);
            TeamReport.then(function (response) {
                $scope.TimeUser = response.data;
                $scope.GridTeamReport();
                setTimeout(function () {
                    $scope.$apply();

                })
            });
        }
        $scope.GridTeamReport = function () {
            $scope.dataGridOptions = $('#gridContainer').dxDataGrid({
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

    });