app.controller('TeamController',
    function TeamController($scope , TeamService, DepartmentService, DesignationService,RoleService) {
        $scope.Team = [];   
        $scope.companyId = 0;
        $scope.isshowtable = true;

        $scope.ResetForm = function () {
            $scope.Team = {
                UserId: 0,
                CompanyId: 0,
                FirstName: '',               
                LastName: '',
                Email: '',
                Password: '',
                ConfirmPassword: '',
                JobTitle: '',
                PhoneNo: '',
                Address: '',
                Additionalinfo: '',
                JoiningDate: '',
                RoleId: '',
                IsActive: '',
                EntryUser: 0,
                ModifiedUser: 0,
                EntryDate: '',
                ModifiedDate: ''
            }
        }
        $scope.Create = function (data) {
            let instance1 = $('#Teamform').parsley({});
            let isvalid1 = instance1.isValid();
            if (!isvalid1) {
                //swal('warning', 'Please enter valid Company Email!', 'warning');
                $('#Teamform').focus();
                return;
            }
            var team = {
                UserId: data.UserId,
                CompanyId: data.CompanyId,
                DepartmentId: data.DepartmentId,
                DesignationId: data.DesignationId,
                FirstName: data.FirstName,
                LastName: data.LastName,
                Email: data.Email,
                Password: data.Password,
                ConfirmPassword: data.ConfirmPassword,
                JobTitle: data.JobTitle,
                PhoneNo: data.PhoneNo,
                Address: data.Address,
                Additionalinfo: data.Additionalinfo,
                JoiningDate: data.JoiningDate,
                RoleId: data.RoleId,
                IsActive: data.IsActive,
                EntryUser: data.EntryUser,
                ModifiedUser: data.ModifiedUser,
                EntryDate: data.EntryDate,
                ModifiedDate: data.ModifiedDate,
                IsDeleted: data.IsDeleted
            }
            TeamService.CreateUpdate(team, $scope.companyId).then(function (response) {
                if (response.data != null) {
                    swal({
                        type: "success",
                        title: "Success!",
                        icon: "success",
                        text: "User Saved Successfully",
                        confirmButtonText: "OK",
                        showCancelButton: true
                    })
                    $("span").html("");
                    $("#UserModal").modal("hide");
                    $scope.GetTeamList();
                    $scope.isshowtable = true;
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
            $scope.Team = {
                UserId: data.UserId,
                CompanyId: data.CompanyId,
                DepartmentId: data.DepartmentId,
                DesignationId: data.DesignationId,
                FirstName: data.FirstName,
                LastName: data.LastName,
                Email: data.Email,
                Password: data.Password,
                ConfirmPassword: data.ConfirmPassword,
                JobTitle: data.JobTitle,
                PhoneNo: data.PhoneNo,
                Address: data.Address,
                Additionalinfo: data.Additionalinfo,
                JoiningDate: data.JoiningDate,
                RoleId: data.RoleId,
                IsActive: data.IsActive,
                EntryUser: data.EntryUser,
                ModifiedUser: data.ModifiedUser,
                EntryDate: data.EntryDate,
                ModifiedDate: data.ModifiedDate,
                IsDeleted: data.IsDeleted
            }
            $scope.fname = data.FirstName.substr(0, 1) + '' + data.LastName.substr(0, 1);
        }
        $scope.GetTeamList = function () {
            var team = TeamService.GetAll($scope.companyId);
            team.then(function (response) {
                $scope.teams = response.data;
                console.log($scope.teams);
            }, function (error) {
                console.log("Error: " + error);
            });
        }
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
        $scope.GetRoleList = function () {
            var role = RoleService.GetAll($scope.companyId);
            role.then(function (response) {
                $scope.roles = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetRoleList();         

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
                        var deleteTeam = TeamService.Delete(id);
                        deleteTeam.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "User Deleted Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            $scope.GetTeamList();
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
                        var restoreTeam = TeamService.Restore(id);
                        restoreTeam.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "Team Restored Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            $scope.ArchieveTeamList();
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
                        var trashTeam = TeamService.Trash(id);
                        trashTeam.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "Team Deleted Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            $scope.ArchieveTeamList();
                        });

                    } else {

                    }
                });
        }

        $scope.ArchieveTeamList = function () {
            var archieveteam = TeamService.ArchieveTeamList($scope.companyId);
            archieveteam.then(function (response) {
                $scope.archieveteams = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.Close = function () {
            $scope.ResetForm();
            /*$('#Teamform').blur();*/
            $("li").html("");
        }  
        $scope.EditDiv = function () {
            $scope.isshowtable = false;

        }
        $scope.InsertDiv = function () {

            $scope.isshowtable = true;
            $("span").html("");
            $scope.ResetForm();
        }

        $scope.sortColumn = "FirstName";
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
       