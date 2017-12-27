/// <reference path="../Library/Jquery/toastr.min.js" />
/// <reference path="../Library/Angular/angular.js" />
/// <reference path="../Service/TimeSheetService.js" />



(function () {
    var injectParams = ['$scope', '$rootScope', '$compile', '$cookieStore', 'TimeSheetFactory'];
    var TimeSheetController = function ($scope, $rootScope, $compile, $cookieStore, TimeSheetFactory) {

        $scope.init = function () {

            $scope.SumMonth = 0;
            $scope.Model = {};


            // Initialize with options
            $('.daterange-predefined').daterangepicker(
                {
                    startDate: moment().subtract(29, 'days'),
                    endDate: moment(),
                    minDate: '01/01/2014',
                    maxDate: '12/31/2199',
                    dateLimit: { days: 60 },
                    ranges: {
                        'Hoje': [moment(), moment()],
                        'Ontem': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                        'Ultimos 7 Dias': [moment().subtract(6, 'days'), moment()],
                        'Ultimos 30 dias': [moment().subtract(29, 'days'), moment()],
                        'Mes Atual': [moment().startOf('month'), moment().endOf('month')],
                        'Mes Anterior': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                    },
                    opens: 'left',
                    applyClass: 'btn-small bg-slate',
                    cancelClass: 'btn-small btn-default'
                },
                function (start, end) {
                    $('.daterange-predefined span').html(start.format('MMMM D, YYYY') + ' &nbsp; - &nbsp; ' + end.format('MMMM D, YYYY'));
                    toastr["info"]("Novo range de data definido.");
                }
            );

            // Display date format
            $('.daterange-predefined span').html(moment().subtract(29, 'days').format('MMMM D, YYYY') + ' &nbsp; - &nbsp; ' + moment().format('MMMM D, YYYY'));


        }
        $scope.GetTimeSheet = function () {
            if ($scope.Data != undefined && $scope.Data.IniDate != undefined && $scope.Data.EndDate != undefined) {
                var data = {
                    IniDate: $scope.Data.IniDate.split('/')[2] + "/" + $scope.Data.IniDate.split('/')[1] + "/" + $scope.Data.IniDate.split('/')[0],
                    EndDate: $scope.Data.EndDate.split('/')[2] + "/" + $scope.Data.EndDate.split('/')[1] + "/" + $scope.Data.EndDate.split('/')[0] + " " + "23:59"
                }
                TimeSheetFactory.GetTimeSheet(data, function (result) {
                    $scope.result = result;
                    $scope.SumMonth = $scope.ToSum(result);
                }, function (error) {
                    toastr.error(error);
                });
            }
        }
        $scope.Save = function () {
            if ($scope.Model.Data != undefined) {
                var data = {
                    IniDay: $scope.Model.Data.split('/')[2] + "/" + $scope.Model.Data.split('/')[1] + "/" + $scope.Model.Data.split('/')[0] + " " + $scope.Model.HoraIncio,
                    EndDay: $scope.Model.Data.split('/')[2] + "/" + $scope.Model.Data.split('/')[1] + "/" + $scope.Model.Data.split('/')[0] + " " + $scope.Model.HoraFim,
                    BreakFestIni: $scope.Model.Data.split('/')[2] + "/" + $scope.Model.Data.split('/')[1] + "/" + $scope.Model.Data.split('/')[0] + " " + $scope.Model.HoraAlmocoInicio,
                    BreakFestEnd: $scope.Model.Data.split('/')[2] + "/" + $scope.Model.Data.split('/')[1] + "/" + $scope.Model.Data.split('/')[0] + " " + $scope.Model.HoraAlmocoFim,
                    ExtendInit: $scope.Model.Data.split('/')[2] + "/" + $scope.Model.Data.split('/')[1] + "/" + $scope.Model.Data.split('/')[0],
                    ExtendEnd: $scope.Model.Data.split('/')[2] + "/" + $scope.Model.Data.split('/')[1] + "/" + $scope.Model.Data.split('/')[0],
                    CliendId: 1,
                    UserId: $cookieStore.get('UserId'),
                    ProjectId: 1,
                    Status: 0
                };
                TimeSheetFactory.SaveOrUpDate(data,
                    function (result) {
                        toastr.success("Lançamento efetuado com sucesso.");
                        //     $scope.GetTimeSheet();
                    },
                    function (error) {
                        toastr.error(error);
                    })
            }
            else {
                toastr.error("Data Invalida");
            }
        }
        $scope.Remove = function (timesheetId) {
            var data = { timesheetId: timesheetId };
            TimeSheetFactory.Remove(data, function (result) {
                $scope.result = {};
                toastr.info("Removido com sucesso!");
                $scope.GetTimeSheet();
            }, function (error) { toastr.error(error); });
        }
        $scope.Edit = function (timesheetId) {
            var data = { timesheetId: timesheetId };
            TimeSheetFactory.Edit(data, function (result) {
                $scope.Model = {};
                $scope.Model.Data = result.IniDay;
                $scope.Model.HoraIncio = result.IniDay;
                $scope.Model.HoraAlmocoInicio = result.BreakFestIni;
                $scope.Model.HoraAlmocoFim = result.BreakFestEnd;
                $scope.Model.HoraFim = result.EndDay;
                $scope.Model.id = result.id;
                toastr.success(result.id + " -> Carregado com sucesso");
            }, function (error) {
                toastr.error(error);
            })
        }
        $scope.New = function () {
            $scope.Model = {};
        }
        $scope.timediff = function (/*Date*/ d1, /*Date*/ d2) {
            var date1 = new Date(d1);
            var date2 = new Date(d2);
            return $scope.ToFloat(date2) - $scope.ToFloat(date1);
        }

        $scope.ToFloat = function (/*Date*/ date) {
            return (((new Date(date)) % 86400000) / 3600000);
        }
        $scope.ToSum = function (result) {
            var Sum = 0;
            angular.forEach(result, function (value, key) {
                Sum += ($scope.timediff(value.IniDay, value.BreakFestIni) + $scope.timediff(value.BreakFestEnd, value.EndDay));
            });
            return Sum;
        }

        $scope.Export = function () {

            var t = 'Dia;Entrada;Saida Almoço;Retorno Almoço; Saida; Total Horas Dia;Observações\n';
            for (i = 0; i < $scope.result.length; i++) {
                t += $scope.result[i].IniDay.split('T')[0] + ';';
                t += $scope.result[i].IniDay.split('T')[1] + ';';
                t += $scope.result[i].BreakFestIni.split('T')[1] + ';';
                t += $scope.result[i].BreakFestEnd.split('T')[1] + ';';
                t += $scope.result[i].EndDay.split('T')[1] + ';';
                t += $scope.timediff($scope.result[i].IniDay, $scope.result[i].BreakFestIni) + $scope.timediff($scope.result[i].BreakFestEnd, $scope.result[i].EndDay) + ';';
                t += $scope.result[i].Message + '\n';

            }
            //t += '\n\n Total de Horas :;' + $scope.SumMonth;
        //    var blob = new Blob([t], { type: "text/txt;charset=utf-8" });
         //   saveAs(blob, 'RelatorioHoras_OpenSquare.csv');


        }

    }
    TimeSheetController.$inject = injectParams;

    angular.module('Trade4B').controller('TimeSheetController', TimeSheetController);

}());
