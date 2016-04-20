(function () {
    function ApplicantHttpService($http) {
        this.http = $http;
    }

    ApplicantHttpService.prototype.getApplicants = function () {
        var httpOptions = {
            url: '/applicant/GetApp',
            method: 'GET'
        };

        return this.http(httpOptions).then(function (resp) {
            return resp.data;
        });
    }

    angular.module('ApplicantApp').service('ApplicantHttpService', ['$http', ApplicantHttpService]);

})();
