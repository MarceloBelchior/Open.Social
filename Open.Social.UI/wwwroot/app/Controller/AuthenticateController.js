/// <reference path="../service/userservice.js" />

(function () {
    var injectParams = ['$scope', '$compile', '$cookies', '$window', '$location','UserService' ];
    var AuthenticateController = function ($scope, $compile, $cookies, $window, $location, UserService) {


        
        $scope.Submit = function () {
            var data = { login: $scope.login, password: $scope.password };
            UserService.Autenticacao(data, function (err) { }, function (err) { toastr.error("Erro na autenticação."); });
                    
               


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