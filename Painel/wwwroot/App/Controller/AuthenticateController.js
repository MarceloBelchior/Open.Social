
(function () {
    var injectParams = ['$scope', '$compile', '$cookies', '$window', '$location', ];
    var AuthenticateController = function ($scope, $compile, $cookies, $window, $location) {


        
        $scope.Submit = function () {
        
                    toastr.error("Erro na autenticação.");
               


        }
        $scope.Registrar = function () {
            toastr.warning("Função desabilitada.")
        }
        $scope.Register = function () {
            $window.location = "/Register";
        }

    }
    AuthenticateController.$inject = injectParams;

    angular.module('Trade4B').controller('AuthenticateController', AuthenticateController);

}());