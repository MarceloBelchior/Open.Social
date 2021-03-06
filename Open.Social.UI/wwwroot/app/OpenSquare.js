﻿
(function () {

    var application = angular.module('Trade4B', ['ngRoute', 'ngCookies', 'chieffancypants.loadingBar', 'ngAnimate']);



    application.config(['$routeProvider', '$locationProvider','$httpProvider', function ($routeProvider, $locationProvider,$httpProvider) {
        $routeProvider.when('/', { templateUrl: '/Home/Index' });
        $routeProvider.when('/TimeSheet', { templateUrl: '/TimeSheet/Index' });
        $routeProvider.when('/User', { templateUrl: '/Login/Login' });
        $routeProvider.when('/Admin', { templateUrl: '/Admin/Index' });
        
        //$routeProvider.when('/User', { templateUrl: '/User/Index', controller: 'UserController' });
        //$routeProvider.when('/ProfileUser', { templateUrl: '/User/ProfileUser', controller: 'UserController' });
        //$routeProvider.when('/Profile', { templateUrl: '/Profile/Index', controller: 'ProfileController' });
        //$routeProvider.when('/Account', { templateUrl: '/Account/Index', controller: 'AccountController' });
        //$routeProvider.when('/CustomSetup', { templateUrl: '/Account/CustomSetup', controller: 'AccountCustomController' });
        //$routeProvider.when('/Site', { templateUrl: '/WebSite/Index', controller: 'WebSiteController' });
        //$routeProvider.when('/File', { templateUrl: '/File/Index', controller: 'FileController' });
        //$routeProvider.when('/404', { templateUrl: '/Home/NotFound', controller: 'homeController' });
        $routeProvider.otherwise({ redirectTo: '/' });

        $locationProvider.hashPrefix('');
        $locationProvider.html5Mode({
            enabled: false,
            requireBase: false
        })
        $locationProvider.hashPrefix = '#';
       $httpProvider.interceptors.push(function($q, $location) {
            return {
                    'responseError': function(response) {
                if(response.status === 401 || response.status === 403) {
                    window.location = "/OAuth/Login/Index";
                   // $window.location = "./OAuth/Login/Index";
                   //$location.path('../OAuth/Login/Index');
                }
                return $q.reject(response);
            }
        };
    });
    }]);

    application.config(function ($httpProvider) {
        $httpProvider.defaults.useXDomain = true;
        delete $httpProvider.defaults.headers.common['X-Requested-With'];
        delete $httpProvider.defaults.headers.common['Cookie'];
        $httpProvider.defaults.headers.common['Authorization'] = 'Bearer ' + $.cookie('token');
        //$httpProvider.defaults.withCredentials = true;
    });

    


    application.run(['$rootScope', '$location', function ($rootScope, $location) {
        
        $rootScope.$on('$routeChangeStart', function (evt, to, from) {
            if (to.authorize === true) {
                to.resolve = to.resolve || {};
                if (!to.resolve.authorizationResolver) {
                    to.resolve.authorizationResolver = ["authservice", function (authservice) {
                        return authservice.authorize();
                    }];
                }
            }
        });
        $rootScope.$on('$rootChangeError', function (evt, to, from, error) {
            if (error instanceof AuthorizationError) {
                $location.path('/OAuth').search('returnTo', to.originalPath);
            }
        });
    }
    ]);

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
                    //    window.location = "/OAuth/Login/Index";
                    }
                    // Return the promise rejection.
                    return $q.reject(rejection);
                }
            };
        });
    });

    function AuthInterceptor($location, AuthService, $q) {
        return {
            request: function (config) {
                config.headers = config.headers || {};

                if (AuthService.getToken()) {
                    config.headers['Authorization'] = 'Bearer ' + AuthService.getToken();
                }

                return config;
            },

            responseError: function (response) {
                if (response.status === 401 || response.status === 403) {
                    $location.path('/signin');
                }

                return $q.reject(response);
            }
        }
    }


}());