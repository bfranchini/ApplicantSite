var LandingPageController = function ($scope) {
    $scope.models = {
        helloAngular: 'I work!'
    };

    $scope.navbarProperties = {
        isCollapsed: true
    };
}

LandingPageController.$inject = ['$scope'];