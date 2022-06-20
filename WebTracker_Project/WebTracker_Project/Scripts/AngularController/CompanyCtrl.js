app.controller('CompanyController',
    function CompanyController($window,$scope, CompanyService) {
        $scope.Company = [];
        $scope.isshowtable = true;

        $scope.IsLogedIn = false;
        $scope.Message = '';
        $scope.Submitted = false;
        $scope.IsFormValid = false;

        $scope.LoginData = {
            CompanyEmail: '',
            Password: '',
            RememberMe: false
        };

        //Check is Form Valid or Not // Here f1 is our form Name
        $scope.$watch('f1.$valid', function (newVal) {
            $scope.IsFormValid = newVal;
        });      

        $scope.Login = function () {
            $scope.Submitted = true;
            if ($scope.IsFormValid) {
                CompanyService.GetUser($scope.LoginData).then(function (d) {
                    if (d.data != null && d.data.CompanyEmail != null) {
                        $scope.IsLogedIn = true;
                        $window.location.href = '/Dashboard/List';

                    }
                    else {
                        /*alert('Invalid Credential!');*/
                        swal({
                            type: "error",
                            title: "Error!",
                            icon: "error",
                            text: "Invalid Credentials !",
                            confirmButtonText: "OK",
                            showCancelButton: true
                        })
                    }
                });
            }
        };

        $scope.ResetForm = function () {
            $scope.Company = {
                CompanyId: 0,
                CompanyName: '',
                CompanyLastName: '',
                CompanyEmail: '',
                CompanyPassword: '',
                StateId: '',
                CityId: '',
                StreetAddress: '',
                MobileNo: '',
                PhoneNo: '',
                Extension: '',
                IsActive: '',                               
                EntryDate: '',
                ModifiedDate: ''
            }
        }

        $scope.CreateCompany = function (data) {
            let instance1 = $('#register').parsley({});
            let isvalid1 = instance1.isValid();
            if (!isvalid1) {
                //swal('warning', 'Please enter valid Company Email!', 'warning');
                $('#register').focus();
                return;
            }
            var company = {
                CompanyId: data.CompanyId,
                CompanyName: data.CompanyName,
                CompanyLastName: data.CompanyLastName,
                CompanyEmail: data.CompanyEmail,
                CompanyPassword: data.CompanyPassword,
                StateId: data.StateId,
                CityId: data.CityId,
                StreetAddress: data.StreetAddress,
                MobileNo: data.MobileNo,
                PhoneNo: data.PhoneNo,
                Extension: data.Extension,
                IsActive: data.IsActive,
                EntryDate: data.EntryDate,
                ModifiedDate: data.ModifiedDate
            }

            CompanyService.CreateUpdate(company).then(function (response) {
                if (response.data != "") {
                    $window.location.href = '/Company/Login';
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

        $scope.StateList = function () {
            var state = CompanyService.StateList();
            state.then(function (response) {
                $scope.states = response.data;                
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.StateList();

        $scope.CityList = function (StateId) {
            var city = CompanyService.CityList(StateId);
            city.then(function (response) {
                console.log(response.data)
                $scope.cities = response.data;
            }, function (error) {
                console.log(error)
                console.log("Error: " + error);
            });
        }

   
        $scope.GetCompanyList = function () {
            var company = CompanyService.GetAll();
            company.then(function (response) {
                $scope.companys = response.data;
            }, function (error) {
                console.log("Error: " + error);
            });
        }       

        $scope.setDefaultVal = function (user, pass, rem) {
            $scope.LoginData.CompanyEmail = user;
            $scope.LoginData.Password = pass;
            $scope.LoginData.RememberMe = (rem == 'True' ? true : false);
        }

    })


