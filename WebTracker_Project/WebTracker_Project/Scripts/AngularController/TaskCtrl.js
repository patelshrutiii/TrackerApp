app.controller('TaskController',
    function TaskController($scope, TaskService, ProjectService) {
        $scope.Task = [];
        $scope.companyId = 0;
        $scope.maxNumberOfChar = 1;
        $scope.isshowtable = true;
        $scope.TaskFilter = function (x) {
            $scope.Tasktab = x;
            if (x == 'Active') {
                $scope.GetActiveTask();
            }
            else if (x == 'Completed') {
                $scope.GetCompletedList();
            }
            else {
                $scope.GetTaskList();
            }
            /* console.log(x);*/
        }

        //var x = 'some string';
        //alert(x.charAt(0));

        $scope.ResetForm = function () {
            $scope.Task = {
                TaskId: 0,
                ProjectId: '',
                CompanyId: '',
                IsActive: '',
                TaskName: '',
                StartDate: '',
                Deadline: '',
                PriorityId: '',
                StatusId: '',
                TaskNotes: '',
                EntryUser: '',
                ModifiedUser: '',
                EntryDate: '',
                ModifiedDate: '',
                IsDeleted: '',
                userassign: []

            }
        }
        $scope.ProjectsTab = function (pid) {
            $('.projecttab').removeClass('project-Active');
            $('#projecttab-' + pid).addClass('project-Active');
        }
        $scope.Create = function (data) {
            if (data.TaskName != null) {
                var task = {
                    TaskId: data.TaskId,
                    ProjectId: $scope.selectedProjectId,
                    CompanyId: data.CompanyId,
                    IsActive: data.IsActive,
                    TaskName: $.trim(data.TaskName.replace(/\s+/g, ' ')),
                    StartDate: data.StartDate,
                    Deadline: data.Deadline,
                    PriorityId: data.PriorityId,
                    StatusId: data.StatusId,
                    TaskNotes: data.TaskNotes,
                    EntryUser: data.EntryUser,
                    ModifiedUser: data.ModifiedUser,
                    EntryDate: data.EntryDate,
                    ModifiedDate: data.ModifiedDate,
                    IsDeleted: data.IsDeleted,
                    userassign: data.userassign
                }

            }
            else {
                return;
            }


            TaskService.CreateUpdate(task, $scope.companyId).then(function (response) {

                if (response.data != "") {
                    //if ($scope.Tasktab == 'Active')
                    //    $scope.GetActiveTask();
                    //else if ($scope.Tasktab == 'Completed') {
                    //    $scope.GetCompletedList();
                    //}
                    //else {
                    setTimeout(function () {
                        $("#alltask").click();
                    })
                    $scope.GetTaskList();
                    /* }*/
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
            });
        }

        $scope.Edit = function (data) {
            $scope.isshowtable = false;
            $scope.start = (data.StartDate).toString().split("T");
            if (data.Deadline != null) {
                $scope.deadline = (data.Deadline).toString().split("T");
                $scope.end = $scope.deadline[0];
            }
            else {
                $scope.end = data.Deadline;
            }
            $scope.Task = {
                TaskId: data.TaskId,
                ProjectId: data.ProjectId,
                CompanyId: data.CompanyId,
                IsActive: data.IsActive,
                TaskName: data.TaskName,
                StartDate: $scope.start[0],
                Deadline: $scope.end,
                PriorityId: data.PriorityId,
                StatusId: data.StatusId,
                TaskNotes: data.TaskNotes,
                EntryUser: data.EntryUser,
                ModifiedUser: data.ModifiedUser,
                EntryDate: data.EntryDate,
                ModifiedDate: data.ModifiedDate,
                PriorityName: data.PriorityName,
                StatusName: data.StatusName,
                IsDeleted: data.IsDeleted,
                userassign: data.userassign

            }
            $scope.TaskId = data.TaskId;
        }


        $scope.TaskAssign = function (UserId, task) {
            if (UserId == 'AssignToAll') {
                $scope.TaskAssignToAll(task);
            }
            else {

                $scope.TaskAssignUser(task);
            }
            /*console.log(UserId);*/
        }


        $scope.TaskAssignToAll = function (data) {

            var user = {
                TaskAssinId: data.TaskAssignId,
                TaskId: data.TaskId,
                ProjectId: $scope.selectedProjectId,
                UserID: data.UserId,
                CompanyId: data.CompanyId,
                EntryUser: data.EntryUser,
                ModifiedUser: data.ModifiedUser,
                EntryDate: data.EntryDate,
                ModifiedDate: data.ModifiedDate
            }
            $scope.selectedOption = null
            TaskService.TaskAssignToAll(user).then(function (response) {

                //if (response.data != "") {
                //    swal({
                //        type: "success",
                //        title: "Success!",
                //        icon: "success",
                //        text: "All user Inserted Successfully",
                //        confirmButtonText: "OK",
                //        showCancelButton: true
                //    })

                /* }*/
                if ($scope.Tasktab == 'Active')
                    $scope.GetActiveTask();
                else if ($scope.Tasktab == 'Completed') {
                    $scope.GetCompletedList();
                }
                else if ($scope.isshowtable == false) {
                    $scope.refreshedit();
                    //    console.log($scope.Task);
                }
                else {
                    $scope.GetTaskList();
                }
            })

        }
        $scope.TaskAssignUser = function (data) {

            var user = {
                TaskAssinId: data.TaskAssignId,
                TaskId: data.TaskId,
                ProjectId: $scope.selectedProjectId,
                UserID: data.UserId,
                CompanyId: data.CompanyId,
                EntryUser: data.EntryUser,
                ModifiedUser: data.ModifiedUser,
                EntryDate: data.EntryDate,
                ModifiedDate: data.ModifiedDate
            }

            TaskService.TaskAssignUser(user).then(function (response) {

                if (response.data != "") {
                    //swal({
                    //    type: "success",
                    //    title: "Success!",
                    //    icon: "success",
                    //    text: "user Inserted Successfully",
                    //    confirmButtonText: "OK",
                    //    showCancelButton: true
                    //})


                }
                if ($scope.Tasktab == 'Active' && $scope.isshowtable)
                    $scope.GetActiveTask();
                else if ($scope.Tasktab == 'Completed' && $scope.isshowtable) {
                    $scope.GetCompletedList();
                }
                else if ($scope.isshowtable == false) {
                    $scope.refreshedit();
                    //    console.log($scope.Task);
                }
                else {
                    $scope.GetTaskList();
                }
            })

        }

        $scope.GetActiveTask = function () {
            $scope.isshowtable = true;
            var task = TaskService.GetActiveTask($scope.companyId, $scope.selectedProjectId);
            task.then(function (response) {
                $scope.tasks = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetCompletedList = function () {
            $scope.isshowtable = true;
            var task = TaskService.GetCompletedList($scope.companyId, $scope.selectedProjectId);
            task.then(function (response) {
                $scope.tasks = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetTaskList = function () {

            var task = TaskService.GetAll($scope.companyId, $scope.selectedProjectId);
            /*$scope.LastName = task.LastName;*/
            task.then(function (response) {
                $scope.tasks = response.data;
                console.log($scope.tasks);
                $scope.GetProjectname();
            }
                , function (error) {
                    console.log("Error: " + error);
                });
        }

        $scope.GetPriorityList = function () {
            var priority = TaskService.GetPriorityList();
            priority.then(function (response) {
                $scope.Priorities = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetPriorityList();
        $scope.GetStatusList = function () {
            var status = TaskService.GetStatusList();
            status.then(function (response) {
                $scope.statuses = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetStatusList();

        $scope.GetTaskByProject = function (projectId) {
            $scope.isshowtable = true;
            $scope.selectedProjectId = projectId;
            if ($scope.Tasktab == 'Active')
                $scope.GetActiveTask();
            else if ($scope.Tasktab == 'Completed') {
                $scope.GetCompletedList();
            }
            else {
                $scope.GetTaskList();
            }
            //var task = TaskService.GetTaskByProject($scope.companyId, projectId);
            //task.then(function (response) {
            //    $scope.tasks = response.data;
            //}, function (error) {
            //    console.log("Error: " + error);
            //});
        }
        $scope.GetTaskAssignedUsers = function (TaskId) {

            var user = TaskService.GetTaskAssignedUsers($scope.companyId, $scope.selectedProjectId, TaskId);
            user.then(function (response) {
                $scope.users = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        /*   $scope.GetTaskAssignedUsers();*/


        $scope.DeleteUser = function (AssignId) {
            $scope.AssignId = AssignId;
            var DeleteUser = TaskService.DeleteUser(AssignId);
            DeleteUser.then(function () {
                if ($scope.Tasktab == 'Active' && $scope.isshowtable)
                    $scope.GetActiveTask();
                else if ($scope.Tasktab == 'Completed' && $scope.isshowtable) {
                    $scope.GetCompletedList();
                }
                else if ($scope.isshowtable == false ) {
                    $scope.refreshedit();
                    $scope.GetTaskList();
                    console.log($scope.Task);
                }
                else {
                    $scope.GetTaskList();
                }
            });
        }

        $scope.Delete = function (TaskId) {
            swal({
                title: "Are you sure?",
                text: "You want to delete this Item!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        var deleteTask = TaskService.Delete($scope.companyId, $scope.selectedProjectId, TaskId);
                        deleteTask.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "Task Deleted Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            if ($scope.Tasktab == 'Active')
                                $scope.GetActiveTask();
                            else if ($scope.Tasktab == 'Completed') {
                                $scope.GetCompletedList();
                            }
                            else {
                                $scope.GetTaskList();
                            }
                        });

                    } else {

                    }
                });
        }
        $scope.DeleteAllTask = function () {
            swal({
                title: "Are you sure?",
                text: "You want to delete this Item!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        var DeleteAllTask = TaskService.DeleteAllTask($scope.companyId, $scope.selectedProjectId);
                        DeleteAllTask.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "All Task Deleted Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            if ($scope.Tasktab == 'Active')
                                $scope.GetActiveTask();
                            else if ($scope.Tasktab == 'Completed') {
                                $scope.GetCompletedList();
                            }
                            else {
                                $scope.GetTaskList();
                            }
                        });
                    } else {

                    }
                });
        }
        $scope.DeleteCompletedTask = function () {
            swal({
                title: "Are you sure?",
                text: "You want to delete this Item!",
                icon: "warning",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        var DeleteCompletedTask = TaskService.DeleteCompletedTask($scope.companyId, $scope.selectedProjectId);
                        DeleteCompletedTask.then(function () {
                            swal({
                                type: "success",
                                title: "Success!",
                                icon: "success",
                                text: "All Completed Task Deleted Successfully",
                                confirmButtonText: "OK",
                                showCancelButton: true
                            });
                            if ($scope.Tasktab == 'Active')
                                $scope.GetActiveTask();
                            else if ($scope.Tasktab == 'Completed') {
                                $scope.GetCompletedList();
                            }
                            else {
                                $scope.GetTaskList();
                            }
                        });
                    } else {

                    }
                });
        }
        $scope.AddNew = function () {
            $scope.ResetForm();
            $scope.isshowtable = false;
        }
        $scope.Close = function () {
            $scope.isshowtable = true;
            $scope.ResetForm();
            $("p").html("");
            if ($scope.Tasktab == 'Active')
                $scope.GetActiveTask();
            else if ($scope.Tasktab == 'Completed') {
                $scope.GetCompletedList();
            }
            else {
                $scope.GetTaskList();
            }

        }

        $scope.GetProjectList = function () {
            var project = ProjectService.GetAll($scope.companyId);
            project.then(function (response) {
                $scope.projects = response.data;
                //console.log($scope.projects)
                $scope.GetTaskByProject($scope.projects[0].ProjectId)

            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetProjectList();
        $scope.GetProjectname = function () {
            var GetProjectname = TaskService.GetProjectname($scope.companyId, $scope.selectedProjectId);
            GetProjectname.then(function (response) {
                $scope.pnames = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.refreshedit = function () {
            var user = TaskService.refreshedit($scope.companyId, $scope.selectedProjectId, $scope.TaskId);
            user.then(function (response) {
                console.log(response.data);
                /* if*/
                $scope.Edit(response.data[0]);
                setTimeout(() => {
                    $scope.$apply();
                }, 100);
            }, function (error) {
                console.log("Error: " + error);
            });
            $scope.GetTaskAssignedUsers($scope.TaskId);
        }

        $scope.UpdateStatus = function (TaskId) {
            var update = TaskService.UpdateStatus(TaskId);
            update.then(function (response) {
                $scope.updateStatus = response.data;

            }, function (error) {
                console.log("Error: " + error);
            });
            if ($scope.Tasktab == 'Active')
                $scope.GetActiveTask();
            else if ($scope.Tasktab == 'Completed') {
                $scope.GetCompletedList();
            }
            else {
                $scope.GetTaskList();
            }
        }
    })