app.controller('TeamScreenshotController',
    function TeamScreenshotController($scope, $filter, $location, TeamScreenshotService) {
        $scope.Tss = [];
        $scope.companyId = 0;
        $scope.projectId = 0;
        $scope.userId = 0;
        $scope.userName = "";
        //$scope.ssid = 0;
        $scope.sdate = new Date();
        $scope.localtime = null;
        $scope.time = null;
        $scope.localhour = null;
        $scope.url = '';
        $scope.returnArry = [];
        // $scope.detail = [];
        $scope.url = $location.absUrl();
        $scope.firstUrl = ($scope.url).toString().split("?");
        $scope.secUrl = ($scope.firstUrl[1]).toString().split("&");
        $scope.cid = ($scope.secUrl[0]).toString().split("=");
        $scope.companyId = $scope.cid[1];
        $scope.uid = ($scope.secUrl[1]).toString().split("=");
        $scope.userId = $scope.uid[1];

        //$scope.Delete = function (id) {
        //    var deletess = TeamScreenshotService.Delete(id);
        //    deletess.then(function () {
        //        swal({
        //            type: "success",
        //            title: "Success!",
        //            icon: "success",
        //            text: "Department Deleted Successfully",
        //            confirmButtonText: "OK",
        //            showCancelButton: true
        //        });
        //        $scope.GetSSList();
        //    });
        //}
        $scope.GetTeamList = function () {
            var team = TeamScreenshotService.GetTeam($scope.companyId);
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
        
        $scope.GetProjectList = function () {
            var project = TeamScreenshotService.GetProject($scope.companyId);
            project.then(function (response) {
                $scope.projects = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetProjectList();

        $scope.GetSSByUser = function () {
            $scope.returnArry = [];
            $scope.projectId = $scope.projectId;
            var sdate = $scope.sdate;
            $scope.sdate = $filter('date')(sdate, 'yyyy-MM-dd');
            var screen = TeamScreenshotService.GetAll($scope.companyId, $scope.userId, $scope.projectId, $scope.sdate);

            screen.then(function (response) {
                $scope.screens = response.data;
                //var returnArry[];

                for (i = 0; i < $scope.screens.length; i++) {

                    $scope.localtime = ($scope.screens[i].ScreenShotTime).toString().split("T");
                    $scope.screens[i].time = $scope.localtime[1];
                    $scope.localhour = ($scope.screens[i].time).toString().split(":");
                    $scope.screens[i].Hour = $scope.localhour[0];

                    var hrcnt = $scope.returnArry.filter(function (s) { return s.hour == $scope.screens[i].Hour });
                    if (hrcnt.length > 0) {
                        var index = $scope.returnArry.indexOf(hrcnt[hrcnt.length - 1]);
                        $scope.returnArry[index].detail.push($scope.screens[i]);
                    }
                    else {
                        var det = [];
                        det.push($scope.screens[i]);
                        $scope.returnArry.push({
                            hour: $scope.screens[i].Hour,
                            detail: det
                        });
                    }
                }
            }, function (error) {
                console.log("Error: " + error);
            });


        }

        $scope.GetDailyTimeDetails = function (ssid) {
            var ssdetail = TeamScreenshotService.GetDailyTimeDetails($scope.companyId, ssid);
            ssdetail.then(function (response) {
                $scope.ssdetails = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.SelectAll = function () {
            $(".scid").prop('checked', true);
        }

        $scope.DeselectAll = function () {
            $(".scid").prop('checked', false);
        }

        $scope.PrevDate = function () {
            document.getElementById("dateto1").stepDown(1);
            var p = document.getElementById("dateto1").value;
            $scope.sdate = p;
            $scope.GetSSByUser();
        }

        $scope.nextDate = function () {
            document.getElementById("dateto1").stepUp(1);
            var n = document.getElementById("dateto1").value;
            $scope.sdate = n;
            $scope.GetSSByUser();
        }


    });
