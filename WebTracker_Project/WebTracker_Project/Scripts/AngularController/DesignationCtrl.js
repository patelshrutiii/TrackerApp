app.controller('DesignationController',
    function DesignationController($scope, DesignationService) {
        $scope.Des = [];
        $scope.companyId = 0;
        $scope.isshowtable = false;
        $scope.ResetForm = function () {
            $scope.Des = {
                DesignationId: 0,
                CompanyId: 0,
                DesignationName: '',
                IsActive: '',
                EntryUser: 0,
                ModifiedUser: 0,
                EntryDate: '',
                ModifiedDate: '',
            }
        }
        $scope.Create = function (data) {
            if (data.DesignationName != null) {
                var des = {
                    DesignationId: data.DesignationId,
                    CompanyId: data.CompanyId,
                    DesignationName: data.DesignationName,
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
            DesignationService.CreateUpdate(des, $scope.companyId).then(function (response) {
                if (response.data != "") {
                    swal({
                        type: "success",
                        title: "Success!",
                        icon: "success",
                        text: "Designation Saves Successfully",
                        confirmButtonText: "OK",
                        showCancelButton: true
                    })
                    $scope.selectedDesId = 0;
                    $scope.GetDesList();

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
                $scope.GetDesList();
            });
        }

        $scope.Edit = function (data) {
            $scope.selectedDesId = data.DesignationId
            $scope.Des = {
                DesignationId: data.DesignationId,
                CompanyId: data.CompanyId,
                DesignationName: data.DesignationName,
                IsActive: data.IsActive,
                EntryUser: data.EntryUser,
                ModifiedUser: data.ModifiedUser,
                EntryDate: data.EntryDate,
                ModifiedDate: data.ModifiedDate
            }
        }
        $scope.GetDesList = function () {
            var des = DesignationService.GetAll($scope.companyId);
            des.then(function (response) {
                $scope.deslist = response.data;
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
                        var deleteDes = DesignationService.Delete(id);
                        deleteDes.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "Designation Deleted Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            $scope.GetDesList();
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
                        var restoreDes = DesignationService.Restore(id);
                        restoreDes.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "Department Restored Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            $scope.ArchieveDesList();
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
                        var trashDes = DesignationService.Trash(id);
                        trashDes.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "Department Deleted Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            $scope.ArchieveDesList();
                        });

                    } else {

                    }
                });
        }

        $scope.ArchieveDesList = function () {
            var archievedes = DesignationService.ArchieveDesList($scope.companyId);
            archievedes.then(function (response) {
                $scope.archievedess = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }

        $scope.PassignDetails = [{
            designation: '',
            add: '',
            delete: ''
        }];
        $scope.AddRow = function () {
            $scope.deslist.push({
                DesignationId: 0,
                designation: '',
                delete: ''
            });
        }
        $scope.DeleteRow = function () {
            $scope.PassignDetails.pop();
        }

        //$scope.sortColumn = "DesignationName";
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
