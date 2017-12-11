/// <reference path="../assets/js/angular/angular.js" />
/// <reference path="../assets/js/angular/angular-route.js" />
/// <reference path="../assets/js/angular/angular-cookies.js" />
/// <reference path="../assets/js/angular/angular-resource.js" />

(function () {

    var application = angular.module('Trade4B', ['ngRoute', 'ngCookies', 'chieffancypants.loadingBar', 'ngAnimate']);

     application.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

        $routeProvider.when('/', { templateUrl: '/Login/Index', controller: 'AuthenticateController' });
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