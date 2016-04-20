var ApplicantSite = angular.module('ApplicantSite', ['ui.router', 'ui.bootstrap']);

ApplicantSite.controller('LandingPageController', LandingPageController);
ApplicantSite.controller('LoginController', LoginController);

ApplicantSite.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
ApplicantSite.factory('LoginFactory', LoginFactory);
ApplicantSite.factory('RegistrationFactory', RegistrationFactory);

var configFunction = function ($stateprovider, $httpProvider, $locationProvider) {

    $locationProvider.hashPrefix('!').html5Mode(true);

    $stateProvider
        .state('stateOne', {
            url: '/stateOne?donuts',
            views: {
                "containerOne": {
                    templateUrl: '/routesDemo/one'
                },
                "containerTwo": {
                    templateUrl: function (params) { return '/routesDemo/two?donuts=' + params.donuts; }
                }
            }
        })
        .state('stateTwo', {
            url: '/stateTwo',
            views: {
                "containerOne": {
                    templateUrl: '/routesDemo/one'
                },
                "containerTwo": {
                    templateUrl: '/routesDemo/three'
                }
            }
        })
        .state('stateThree', {
            url: '/stateThree?donuts',
            views: {
                "containerOne": {
                    templateUrl: function (params) { return '/routesDemo/two?donuts=' + params.donuts; }
                },
                "containerTwo": {
                    templateUrl: '/routesDemo/three'
                }
            }
        })
        .state('loginRegister', {
            url: '/loginRegister?returnUrl',
            views: {
                "containerOne": {
                    templateUrl: '/Account/Login',
                    controller: LoginController
                },
                "containerTwo": {
                    templateUrl: '/Account/Register',
                    controller: RegisterController
                }
            }
        });

$httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$stateProvider', '$httpProvider', '$locationProvider'];

ApplicantSite.config(configFunction);