app.controller('SettingController',
    function SettingController($scope, CompanyService, SettingService) {
        $scope.company = [];
        $scope.companyId = 0;
        $scope.cname = null;
        $scope.ProfileForm = false;
        $scope.AccountInfo = false;

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
                EntryUser: 0,
                ModifiedUser: 0,
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
                EntryUser: data.EntryUser,
                ModifiedUser: data.ModifiedUser,
                EntryDate: data.EntryDate,
                ModifiedDate: data.ModifiedDate
            }

            CompanyService.CreateUpdate(company).then(function (response) {
                if (response.data != "") {                  
                        swal({
                            type: "success",
                            title: "Success!",
                            icon: "success",
                            text: "Your Profile Updated Successfully",
                            confirmButtonText: "OK",
                            showCancelButton: true
                        })                    
                }
            })
        }

        $scope.GetCompanyById = function () {
            $scope.ProfileForm = true;
            $scope.AccountInfo = false;

            var Company = CompanyService.GetCompanyById($scope.companyId);
            Company.then(function (response) {
                $scope.company = response.data[0];
                $scope.cname = $scope.company.CompanyName.substr(0, 1) + "" + $scope.company.CompanyLastName.substr(0, 1);
                $scope.CityList($scope.company.StateId)
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetCompanyById();
        $scope.GetAccountInfo = function () {
            $scope.ProfileForm = false;
            $scope.AccountInfo = true;

            var Account = SettingService.GetAccountInfo($scope.companyId, $scope.cname);
            Account.then(function (response) {
                $scope.Accounts = response.data[0];

            }, function (error) {
                console.log("Error: " + error);
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
                $scope.cities = response.data;
            }, function (error) {
                console.log(error)
                console.log("Error: " + error);
            });
        }

    })