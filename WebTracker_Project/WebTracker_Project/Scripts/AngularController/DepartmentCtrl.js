app.controller('DepartmentController',
    function DepartmentController($scope , DepartmentService) {
        $scope.Dept = [];
        $scope.companyId = 0;
        $scope.ResetForm = function () {
            $scope.Dept = {
                DepartmentId: 0,
                CompanyId: 0,
                DepartmentName: '',               
                IsActive: '',
                EntryUser: 0,
                ModifiedUser: 0,
                EntryDate: '',
                ModifiedDate: '',
            }
        }
        $scope.Create = function (data) {
            if (data.DepartmentName != null) {
            var dept = {
                DepartmentId: data.DepartmentId,
                CompanyId: data.CompanyId,
                DepartmentName: data.DepartmentName,
                IsActive: data.IsActive,
                EntryUser: data.EntryUser,
                ModifiedUser: data.ModifiedUser,
                EntryDate: data.EntryDate,
                ModifiedDate: data.ModifiedDate
                }
            }
            else {
                return;
            }
            DepartmentService.CreateUpdate(dept,$scope.companyId).then(function (response) {
                if (response.data != "") {
                    swal({
                        type: "success",
                        title: "Success!",
                        icon: "success",
                        text: "Department Saves Successfully",
                        confirmButtonText: "OK",
                        showCancelButton: true
                    })
                    $scope.selectedDEptId = 0;
                    $scope.GetDeptList();                
                  
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
                $scope.GetDeptList();
                $scope.ResetForm();
            });
        }
        $scope.Edit = function (data) {
            $scope.selectedDEptId = data.DepartmentId
            $scope.isshowtable = true;
            $scope.Dept = {
                DepartmentId: data.DepartmentId,
                CompanyId: data.CompanyId,
                DepartmentName: data.DepartmentName,
                IsActive: data.IsActive,
                EntryUser: data.EntryUser,
                ModifiedUser: data.ModifiedUser,
                EntryDate: data.EntryDate,
                ModifiedDate: data.ModifiedDate
            }          
        }
        $scope.GetDeptList = function () {
            var dept = DepartmentService.GetAll($scope.companyId);
            dept.then(function (response) {
                $scope.depts = response.data;
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
                        var deleteDept = DepartmentService.Delete(id);
                        deleteDept.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "Department Deleted Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            $scope.GetDeptList();
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
                        var restoreDept = DepartmentService.Restore(id);
                        restoreDept.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "Department Restored Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            $scope.ArchieveDeptList();
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
                        var trashDept = DepartmentService.Trash(id);
                        trashDept.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "Department Deleted Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            $scope.ArchieveDeptList();
                        });

                    } else {

                    }
                });
        }

        $scope.ArchieveDeptList = function () {
            var archievedept = DepartmentService.ArchieveDeptList($scope.companyId);
            archievedept.then(function (response) {
                $scope.archievedepts = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.PassignDetails = [{
            department: '',
            add: '',
            delete: ''
        }];
        $scope.AddRow = function () {
            //$scope.isshowtable = false;
            $scope.depts.push({
                DepartmentId : 0,
                department: '',
                delete: ''
            });         
        }
        $scope.DeleteRow = function () {
            $scope.PassignDetails.pop();
        }

          //$scope.sortColumn = "DepartmentName";
        //$scope.reverseSort = false;

        //$scope.sortData = function (column) {
        //    $scope.reverseSort = ($scope.sortColumn == column) ? !$scope.reverseSort : false;
        //    $scope.sortColumn = column;
        //}

        //$scope.getSortClass = function (column) {

        //    if ($scope.sortColumn == column) {
        //        return $scope.reverseSort
        //            ? 'arrow-up'
        //            : 'arrow-down';
        //    }

        //    return '';
        //}

    });
        