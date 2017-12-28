/// <reference path="../Library/Jquery/toastr.min.js" />
/// <reference path="../Library/Angular/angular.js" />
/// <reference path="../Service/TimeSheetService.js" />



(function () {
    var injectParams = ['$scope', '$rootScope', '$compile', '$cookieStore', 'TimeSheetFactory'];
    var TimeSheetController = function ($scope, $rootScope, $compile, $cookieStore, TimeSheetFactory) {

        $scope.init = function () {

            $scope.SumMonth = 0;
            $scope.model = {};
            


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
                    IniDate: $scope.data.IniDate.split('/')[2] + "/" + $scope.Data.IniDate.split('/')[1] + "/" + $scope.Data.IniDate.split('/')[0],
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
        $scope.SaveTimeSheet = function () {
            if ($scope.model.data != undefined) {
                var lk = $scope.model.data.split('/')[2] + "/" + $scope.model.data.split('/')[1] + "/" + $scope.model.data.split('/')[0] ;
                var data = { TimeSheet : {
                    id : $scope.model.id,
                    IniDay: lk + " " + $scope.model.horainicio,
                    EndDay:  lk + " " + $scope.model.saida,
                    BreakFestIni: lk+ " " + $scope.model.horainicioalmoco,
                    BreakFestEnd: lk+ " " + $scope.model.horafimalmoco,
                    ExtendInit: lk,
                    ExtendEnd:lk,
                    CliendId: $.cookie('UserId'),
                    UserId: $.cookie('UserId'),
                    ProjectId: 1,
                    Status: 0
                }, User : { id : $.cookie('UserId'), name: $.cookie('name')  }};
                TimeSheetFactory.AddOrUpdate(data,
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
                $scope.model = {};
                $scope.model.Data = result.IniDay;
                $scope.model.HoraIncio = result.IniDay;
                $scope.model.HoraAlmocoInicio = result.BreakFestIni;
                $scope.model.HoraAlmocoFim = result.BreakFestEnd;
                $scope.model.HoraFim = result.EndDay;
                $scope.model.id = result.id;
                toastr.success(result.id + " -> Carregado com sucesso");
            }, function (error) {
                toastr.error(error);
            })
        }
        $scope.New = function () {
            $scope.model = {};
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
