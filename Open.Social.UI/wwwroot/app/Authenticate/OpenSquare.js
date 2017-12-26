/// <reference path="../assets/js/angular/angular.js" />
/// <reference path="../assets/js/angular/angular-route.js" />
/// <reference path="../assets/js/angular/angular-cookies.js" />
/// <reference path="../assets/js/angular/angular-resource.js" />

(function () {

    var application = angular.module('Trade4B', ['ngRoute', 'ngCookies', 'chieffancypants.loadingBar', 'ngAnimate']);

    application.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

        $routeProvider.when('/OAuth', { templateUrl: '/OAuth/Login/Login', controller: 'AuthenticateController' });
        $routeProvider.when('/Register', { templateUrl: '/OAuth//Login/Register', controller: 'AuthenticateController' });
        $routeProvider.otherwise({ redirectTo: '/OAuth' });

    //    $$locationProvider.hashPrefix('');
        $locationProvider.html5Mode({
            enabled: false,
            requireBase: false
        })
     //   $locationProvider.hashPrefix = '#';
    }]);
    application.config(function (cfpLoadingBarProvider) {
        cfpLoadingBarProvider.includeSpinner = true;
    })

}());

