app.controller('ScreenshotController',
    function ScreenshotController($scope,$filter, ScreenshotService,TeamService,ProjectService) {
        $scope.SS = [];
        $scope.companyId = 0;
        $scope.projectId = 0;
        $scope.userId = 0;
        //$scope.ssid = 0;
        $scope.sdate = new Date();
        $scope.localtime = null;
        $scope.time = null;
        $scope.localhour = null;
        $scope.returnArry = [];
        $scope.ArchreturnArry = [];
        var u = 0;
       // $scope.detail = [];


        $scope.Delete = function () {
            var itemList = [];
            $("input:checkbox[class=scid]:checked").each(function () {
                itemList.push($(this).val());
            });
            swal({
                title: "Are you sure?",
                text: "You want to delete this Item!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        var deletess = ScreenshotService.Delete(itemList);
                        deletess.then(function () {
                             swal({
                                 type: "success",
                                 title: "Success!",
                                 icon: "success",
                                 text: "Screenshot Deleted Successfully",
                                 confirmButtonText: "OK",
                                 showCancelButton: true
                             });
                            $scope.GetSSByUser();
                        });
                    } else {
                        $(".scid").prop('checked', false);
                    }
             });
        }

        $scope.Restore = function () {
            var itemList = [];
            $("input:checkbox[class=scid]:checked").each(function () {
                itemList.push($(this).val());
            });
            swal({
                title: "Are you sure?",
                text: "You want to restore this Item!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        var archieverestore = ScreenshotService.Restore(itemList);
                        archieverestore.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "Screenshot Restored Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            $scope.GetArchieveSSByUser();
                        });
                    } else {
                        $(".scid").prop('checked', false);
                    }
                });
        }

        $scope.Trash = function () {
            var itemList = [];
            $("input:checkbox[class=scid]:checked").each(function () {
                itemList.push($(this).val());
            });
            swal({
                title: "Are you sure?",
                text: "You want to Delete this Item!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        var archievetrash = ScreenshotService.Trash(itemList);
                        archievetrash.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "Screenshot Deleted Successfully.",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            $scope.GetArchieveSSByUser();
                        });
                    } else {
                        $(".scid").prop('checked', false);
                    }
                });
        }

        $scope.GetTeamList = function () {
            var team = TeamService.GetAll($scope.companyId);
            team.then(function (response) {
                $scope.teams = response.data;
                $scope.userId = $scope.teams[0].UserId;
                $scope.GetSSByUser();
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetTeamList();  

        $scope.GetProjectList = function () {
            var project = ProjectService.GetAll($scope.companyId);
            project.then(function (response) {
                $scope.projects = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetProjectList();  

        $scope.GetSSByUser = function () {
            $scope.returnArry = [];
            $scope.userId = $scope.userId;
            $scope.projectId = $scope.projectId;
            var sdate = $scope.sdate;
            $scope.sdate = $filter('date')(sdate, 'yyyy-MM-dd');
            var screen = ScreenshotService.GetAll($scope.companyId, $scope.userId, $scope.projectId, $scope.sdate);
            
            screen.then(function (response) {
                $scope.screens = response.data;
                //var returnArry[];

                for (i = 0; i < $scope.screens.length; i++) {

                    $scope.localtime = ($scope.screens[i].ScreenShotTime).toString().split("T");
                    $scope.screens[i].time = $scope.localtime[1];
                    $scope.localhour = ($scope.screens[i].time).toString().split(":");
                    $scope.screens[i].Hour = $scope.localhour[0];

                    var hrcnt = $scope.returnArry.filter(function (s) {return  s.hour == $scope.screens[i].Hour });
                    if (hrcnt.length > 0) {
                        var index = $scope.returnArry.indexOf(hrcnt[hrcnt.length-1]);
                        $scope.returnArry[index].detail.push($scope.screens[i]);
                    }
                        else {
                        var det=[];
                        det.push($scope.screens[i]);
                            $scope.returnArry.push({
                                hour: $scope.screens[i].Hour,
                                detail:det
                             });
                    }
                }
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetArchieveTeamList = function () {
            var archieveteam = TeamService.ArchieveTeamList($scope.companyId);
            archieveteam.then(function (response) {
                $scope.archieveteams = response.data;
                $scope.userId = $scope.teams[0].UserId;
                $scope.GetArchieveSSByUser();
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetArchieveTeamList();

        $scope.GetArchieveSSByUser = function () {
            $scope.ArchreturnArry = [];
            $scope.userId = $scope.userId;
            $scope.projectId = $scope.projectId;
            var Archsdate = $scope.sdate;
            $scope.sdate = $filter('date')(Archsdate, 'yyyy-MM-dd');
            var archievescreen = ScreenshotService.GetArchieveTeamList($scope.companyId, $scope.userId, $scope.projectId, $scope.sdate);

            archievescreen.then(function (response) {
                $scope.archievescreens = response.data;
                //var returnArry[];

                for (i = 0; i < $scope.archievescreens.length; i++) {

                    $scope.localtime = ($scope.archievescreens[i].ScreenShotTime).toString().split("T");
                    $scope.archievescreens[i].time = $scope.localtime[1];
                    $scope.localhour = ($scope.archievescreens[i].time).toString().split(":");
                    $scope.archievescreens[i].Hour = $scope.localhour[0];

                    var hrcnt = $scope.ArchreturnArry.filter(function (s) { return s.hour == $scope.archievescreens[i].Hour });
                    if (hrcnt.length > 0) {
                        var index = $scope.ArchreturnArry.indexOf(hrcnt[hrcnt.length - 1]);
                        $scope.ArchreturnArry[index].detail.push($scope.archievescreens[i]);
                    }
                    else {
                        var det = [];
                        det.push($scope.archievescreens[i]);
                        $scope.ArchreturnArry.push({
                            hour: $scope.archievescreens[i].Hour,
                            detail: det
                        });
                    }
                }
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetDailyTimeDetails = function (ssid) {
            var ssdetail = ScreenshotService.GetDailyTimeDetails($scope.companyId,ssid);
            ssdetail.then(function (response) {
                $scope.ssdetails = response.data;
                console.log($scope.ssdetails);
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

        $scope.PrevArchDate = function () {
            document.getElementById("dateto1").stepDown(1);
            var pArch = document.getElementById("dateto1").value;
            $scope.sdate = pArch;
            $scope.GetArchieveSSByUser();
        }

        $scope.nextArchDate = function () {
            document.getElementById("dateto1").stepUp(1);
            var nArch = document.getElementById("dateto1").value;
            $scope.sdate = nArch;
            $scope.GetArchieveSSByUser();
        }
    });
