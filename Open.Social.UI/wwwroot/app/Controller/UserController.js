/// <reference path="../service/userservice.js" />

(function () {
    var injectParams = ['$scope', '$compile', '$cookies', '$window', '$location','UserService' ];
    var UserController = function ($scope, $compile, $cookies, $window, $location, UserService) {

        
        
        $scope.Save = function () {    
            var data = $scope.model;
            UserService.Save(data, function (result) {
               // toastr.sucess("Cadastro efetuado com sucesso");
            }, function (e) {
               //toastr.error(e);
            });
        
        }
        $scope.Registrar = function () {
            toastr.warning("Função desabilitada.")
        }
        $scope.Register = function () {
            $window.location = "/#/Register";
        }

    }
    UserController.$inject = injectParams;

    angular.module('Trade4B').controller('UserController', UserController);

}());