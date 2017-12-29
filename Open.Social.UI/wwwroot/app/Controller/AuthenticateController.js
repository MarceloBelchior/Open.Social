/// <reference path="../service/userservice.js" />

(function () {
    var injectParams = ['$scope','$rootScope', '$compile', '$cookies', '$window', '$location','$cookies','UserService' ];
    var AuthenticateController = function ($scope,$rootScope, $compile, $cookies, $window, $location, $cookies, UserService) {


        
        $scope.Submit = function () {
            var data = { login: $scope.login, password: $scope.password };
            UserService.Autenticacao(data, function (response) {
                $window.location = "./#/";
            }, function (err) { toastr.error("Erro na autenticação."); });
                    
               


        }
        $scope.Registrar = function () {
            toastr.warning("Função desabilitada.")
        }
        $scope.Register = function () {
            $window.location = "/#/Register";
        }

    }
    AuthenticateController.$inject = injectParams;

    angular.module('Trade4B').controller('AuthenticateController', AuthenticateController);

}());