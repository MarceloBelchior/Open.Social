/// <reference path="../assets/js/angular/angular.js" />
/// <reference path="../assets/js/angular/angular-route.js" />
/// <reference path="../assets/js/angular/angular-cookies.js" />
/// <reference path="../assets/js/angular/angular-resource.js" />

(function () {

    var application = angular.module('Trade4B', ['ngRoute', 'ngCookies', 'chieffancypants.loadingBar', 'ngAnimate']);

  
    application.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

        $routeProvider.when('/', { templateUrl: '/Login/Index', controller: 'AuthenticateController' });
        $routeProvider.when('/Extract', { templateUrl: '/Home/Extract', controller: 'ExtractController' });
        $routeProvider.when('/TimeSheet', { templateUrl: '/TimeSheet/Index', controller: 'TimeSheetController' });
        $routeProvider.when('/User', { templateUrl: '/User/Index', controller: 'UserController' });
        $routeProvider.when('/ProfileUser', { templateUrl: '/User/ProfileUser', controller: 'UserController' });
        $routeProvider.when('/Profile', { templateUrl: '/Profile/Index', controller: 'ProfileController' });
        $routeProvider.when('/Account', { templateUrl: '/Account/Index', controller: 'AccountController' });
        $routeProvider.when('/CustomSetup', { templateUrl: '/Account/CustomSetup', controller: 'AccountCustomController' });
        $routeProvider.when('/Site', { templateUrl: '/WebSite/Index', controller: 'WebSiteController' });
        $routeProvider.when('/File', { templateUrl: '/File/Index', controller: 'FileController' });
        $routeProvider.when('/404', { templateUrl: '/Home/NotFound', controller: 'homeController' });
        $routeProvider.otherwise({ redirectTo: '/404' });
        $locationProvider.html5Mode(false);
        $locationProvider.hashPrefix = '#';
    }]);
    application.config(function (cfpLoadingBarProvider) {
        cfpLoadingBarProvider.includeSpinner = true;
    })

    application.config(function ($provide, $httpProvider) {

        // Intercept http calls.
        $provide.factory('httpAuthenticationResponseInterceptor', function ($q) {
            return {
                // On request failure
                requestError: function (rejection) {
                    // Return the promise rejection.
                    return $q.reject(rejection);
                },

                // On response failture
                responseError: function (rejection) {

                    if (rejection.status == 401) {
                        window.location = "/404";
                    }
                    // Return the promise rejection.
                    return $q.reject(rejection);
                }
            };
        });
    });


}());