app.controller('ProjectController',
    function ProjectController($scope, ProjectService, TeamService) {
        $scope.Project = [];
        $scope.currentPage = 1;
        $scope.itemsPerPage = 2;
        $scope.companyId=0;
        $scope.isshowtable = true;
        $scope.isshowadd = false;
        $scope.isshowedit = false;
        $scope.ResetForm = function () {
            $scope.Project = {
                ProjectId: 0,
                CompanyId: 0,
                ProjectName: '',
                StartDate: '',
                DeadLine: '',
                EstimationHour: '',
                IsActive: '',
                Remark: '',
                EntryUser: 0,
                ModifiedUser: 0,
                EntryDate: '',
                ModifiedDate: '',
                IsDeleted: '',
                assign: []
            }
            $scope.txtWeeklyLimit = null;
            $scope.txtRate = null;
        }
        $scope.Create = function (data) {
            var project = {
                ProjectId: data.ProjectId,
                CompanyId: data.CompanyId,
                ProjectName: data.ProjectName,
                StartDate: data.StartDate,
                DeadLine: data.DeadLine,
                EstimationHour: data.EstimationHour,
                IsActive: data.IsActive,
                Remark: data.Remark,
                EntryUser: data.EntryUser,
                ModifiedUser: data.ModifiedUser,
                EntryDate: data.EntryDate,
                ModifiedDate: data.ModifiedDate,
                IsDeleted: data.IsDeleted,
                assign: data.assign
            }
            ProjectService.CreateUpdate(project,$scope.companyId).then(function (response) {             
                if (response.data != "") {
                    swal({
                        type: "success",
                        title: "Success!",
                        icon: "success",
                        text: "Project Saved Successfully",
                        confirmButtonText: "OK",
                        showCancelButton: true
                    })
                    $("span").html("");
                    $scope.GetProjectList();
                    $scope.isshowtable = true;
                    $scope.isshowadd = false;
                    $scope.isshowedit = false;
                    $scope.ResetForm();
                }
            }, function (err) {
                swal({
                    type: "error",
                    title: "Error!",
                    icon: "error",
                    text: err.data.ExceptionMessage,
                    confirmButtonText: "OK",
                    showCancelButton: true
                })
                $scope.ResetForm();
                $("span").html("");
            });            
        }
        $scope.Edit = function (data) {
            $scope.isshowtable = false;
            $scope.isshowadd = false;
            $scope.isshowedit = true;
            $scope.Project = {
                ProjectId: data.ProjectId,
                CompanyId: data.CompanyId,
                ProjectName: data.ProjectName,
                StartDate: data.StartDate,
                DeadLine: data.DeadLine,
                EstimationHour: data.EstimationHour,
                IsActive: data.IsActive,
                Remark: data.Remark,
                EntryUser: data.EntryUser,
                ModifiedUser: data.ModifiedUser,
                EntryDate: data.EntryDate,
                ModifiedDate: data.ModifiedDate,
                IsDeleted: data.IsDeleted,
                assign: data.assign
            }
        }
        $scope.GetProjectList = function () {
            var project = ProjectService.GetAll($scope.companyId);
            project.then(function (response) {
                $scope.projects = response.data;    
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.Delete = function (id) {
            swal({
                title: "Are you sure?",
                text: "You want to delete this Item!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        var deleteProject = ProjectService.Delete(id);
                        deleteProject.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "Project Deleted Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            $scope.GetProjectList();
                        });

                    } else {

                    }
                });
        }
        $scope.Restore = function (id) {
            swal({
                title: "Are you sure?",
                text: "You want to restore this Item!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        var restoreproj = ProjectService.Restore(id);
                        restoreproj.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "Project Restored Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            $scope.ArchieveProjList();
                        });

                    } else {

                    }
                });
        }

        $scope.Trash = function (id) {
            swal({
                title: "Are you sure?",
                text: "You want to Delete this Item!",
                icon: "error",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        var trashProj = ProjectService.Trash(id);
                        trashProj.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "Project Deleted Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            $scope.ArchieveProjList();
                        });

                    } else {

                    }
                });
        }

        $scope.ArchieveProjList = function () {
            var archieveproject = ProjectService.ArchieveProjList($scope.companyId);
            archieveproject.then(function (response) {
                $scope.archieveprojects = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.GetTeamList = function () {
            var team = TeamService.GetAll($scope.companyId);
            team.then(function (response) {
                $scope.teams = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetTeamList();                
        $scope.AddOne = function () {
            $scope.Project.assign.push({
                UserId: '',
                WeeklyLimit: '',
                Rate: ''
            });
        };
        $scope.AssignAll = function () {
            $scope.Project.assign = [];
            for (var i = 0; i < $scope.teams.length; i++) {
                $scope.Project.assign.push({
                    UserId: $scope.teams[i].UserId,
                    UserName: $scope.teams[i].FirstName + ' ' + $scope.teams[i].LastName,
                    WeeklyLimit: $scope.txtWeeklyLimit,
                    Rate: $scope.txtRate
                });
            };
        }
        $scope.DeleteOne = function (index) {
           // $scope.Project.assign.pop();
            $scope.Project.assign.splice(index, 1);
        }
        $scope.deleteOne = function (index1) {
            // $scope.Project.assign.pop();
            $scope.Project.assign.splice(index1, 1);
        }
        $scope.DeleteAll = function () {
            for (var i = 0; i < $scope.teams.length; i++) {
                $scope.Project.assign.pop();
            }
        }       
        $scope.GetValue = function () {
            var id = $scope.usersid;
            var result = $scope.teams.filter(function (o1) {
                return o1.UserId == id;
            });
            $scope.SelectedId = result[0].UserId;
            $scope.SelectedUsername = result[0].FirstName + ' ' + result[0].LastName;
        }
        $scope.Project.assign = [];
        $scope.addnewrow = function () {
            $scope.Project.assign.push({
                UserId: $scope.SelectedId,
                UserName: $scope.SelectedUsername,
                WeeklyLimit: $scope.weeklylimit,
                Rate: $scope.rate
            });
            $scope.resetModal();
        };

        $scope.resetModal = function () {
            $scope.usersid = null;
            $scope.weeklylimit = null;
            $scope.rate = null;
        }

        //$scope.GetProjectAssignedUsers = function (ProjectId) {

        //    var user = ProjectService.GetProjectAssignedUsers($scope.companyId, ProjectId);
        //    user.then(function (response) {
        //        $scope.users = response.data;
        //    }, function (error) {
        //        console.log("Error: " + error);
        //    });
        //}

        $scope.AddNew = function () {
            $scope.ResetForm();
            $scope.isshowtable = false;
            $scope.isshowadd = true;
            $scope.isshowedit = false; 
            $scope.AddOne();           
        }
        $scope.Close = function () {
            $scope.isshowtable = true;
            $scope.ResetForm();
        }

        $scope.InsertDiv = function () {
            $scope.isshowtable = true;
            $scope.isshowadd = false;
            $scope.isshowedit = false;
            $("span").html("");
            $scope.ResetForm();
        }

        $scope.sortColumn = "ProjectName";
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
    })
