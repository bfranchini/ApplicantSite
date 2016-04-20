var ApplicantApp = angular.module('ApplicantApp', []);

ApplicantApp.controller('ApplicantController', function ($scope, ApplicantHttpService) {

    ApplicantHttpService.getApplicants().then(function (response) {
        $scope.applicants = response;
    });
});

//applicantController.$inject = ['$scope'];