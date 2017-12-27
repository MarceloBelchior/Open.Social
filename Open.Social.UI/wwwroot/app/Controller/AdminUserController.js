/// <reference path="../service/userservice.js" />

(function () {
    var injectParams = ['$scope', '$compile', '$cookies', '$window', '$location','adminuserservice' ];
    var AdminUserController = function ($scope, $compile, $cookies, $window, $location, adminuserservice) {
        $scope.init = function () {
            $scope.model = {};
            $scope.GetUser();
            
        }

        
        $scope.SaveUser = function () {
            var data = $scope.model;
            adminuserservice.Save(data, function (result) {
                $('#modal_form_vertical').modal('close'); 
                $scope.model = {};
                $scope.GetUser();
            }, function (err) { toastr.error("Erro na autenticação."); }
                );
                    
               


        }
        $scope.Edit = function (data) {
            $scope.model = data;
            $('#modal_form_vertical').modal('show'); 
            
        }
        $scope.Remove = function (data) {
            adminuserservice.Remove(data, function (result) {
                toastr["success"]("Removido o usuario da base de dados");
                $scope.init();
            }, function (error) {
                toastr["warning"]("Não foi possivel remover o usuario do sistema");
            }
            );
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