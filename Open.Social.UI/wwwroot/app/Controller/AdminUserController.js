/// <reference path="../service/userservice.js" />

(function () {
    var injectParams = ['$scope', '$compile', '$cookies', '$window', '$location','adminuserservice' ];
    var AdminUserController = function ($scope, $compile, $cookies, $window, $location, adminuserservice) {
        $scope.init = function () {
            $scope.GetUser();
        }

        
        $scope.SaveUser = function () {
            var data = { name: $scope.model.nome, password: $scope.model.password, email: $scope.model.email };
            adminuserservice.Save(data, function (result) {
                $scope.GetUser();
                toastr["info"]("Cadastro efetuado");
                toastr["success"]("Cadastro efetuado");
                toastr["error"]("Cadastro efetuado");
                toastr["warning"]("Cadastro efetuado");
                $('#modal_form_vertical').modal('toggle'); 
            }, function (err) { toastr.error("Erro na autenticação."); });
                    
               


        }
        $scope.GetUser = function () {
            adminuserservice.getUser(function (result) {
                toastr["info"]("Carregando informações");
                $scope.listUser = result.data;
            }, function (error) { });
        }
        $scope.Registrar = function () {
            toastr.warning("Função desabilitada.")
        }
        $scope.Register = function () {
            $window.location = "/#/Register";
        }

    }
    AdminUserController.$inject = injectParams;

    angular.module('Trade4B').controller('AdminUserController', AdminUserController);

}());