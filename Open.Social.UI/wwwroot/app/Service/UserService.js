﻿

(function () {

    var injectParams = ['$http', '$rootScope'];

    var UserService = function ($http, $rootScope) {
        return {
            CheckEmail: function (data, successCallback, errorCallback) {
                $http.post(global.service + '/api/User/CheckEmail?email=' + data.email)
                    .success(successCallback).error(errorCallback);
            },

            Save: function (data, successCallback, errorCallback) {
                $http.post('/api/Users/Create', data)
                    .then(successCallback).catch(errorCallback);
            },
            Autenticacao: function (data, successCallBack, errorCallBack) {
                $http.post("/API/Users/Autenticacao?login=" + data.login + "&password=" + data.password).then(successCallBack).catch(errorCallBack);
            },
            AuthenticateSocialMedia: function (data, successCallBack, errorCallBack) {
                $http.post("/Home/AuthenticateSocialMedia", data).success(successCallBack).error(errorCallBack);
            },
            UsuarioList: function (top, skip, sucessCallBack, errorCallback) {
                $http.get(global.service + '/api/User/UsuarioList?top=' + top + '&skip=' + skip).success(sucessCallBack).error(errorCallback);
            },
            UsuarioExcluir: function (data, sucessCallback, errorCallback) {
                $http.post(global.service + '/api/User/UsuarioExcluir?UsuarioId=' + data).success(sucessCallback).error(errorCallback);
            }
        }
    };

    UserService.$inject = injectParams;

    angular.module('Trade4B').service('UserService', UserService);

}());

