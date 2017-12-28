(function () {
    // use this directive to delay assigning user input to the underlying 
    // view model field until focus leaves the dom element. Useful for 
    // delaying breeze validation until user enters all data (like when 
    // entering dates)
    var mask = function () {
        return {
            restrict: 'A', //E = element, A = attribute, C = class, M = comment         
            link: function (scope, el, attrs) {
                if (attrs.mask != '') {
                    $(el).mask(attrs.mask);
                }
            }
        };
    };

    angular.module('Trade4B').directive('mask', mask);

}());

(function () {
    // use this directive to delay assigning user input to the underlying 
    // view model field until focus leaves the dom element. Useful for 
    // delaying breeze validation until user enters all data (like when 
    // entering dates)
    var maskCpfcnpj = function () {
        return {
            require: 'ngModel',
            link: function (scope, el, attrs, modelCtrl) {
                modelCtrl.$parsers.push(function (inputValue) {
                    if (inputValue == undefined) return ''
                    var returnvalue = ''

                    returnvalue = inputValue.replace(/\D/g, "");

                    if (returnvalue.length <= 13) {
                        returnvalue = returnvalue.replace(/(\d{3})(\d)/, "$1.$2");
                        returnvalue = returnvalue.replace(/(\d{3})(\d)/, "$1.$2");
                        returnvalue = returnvalue.replace(/(\d{3})(\d{1,2})$/, "$1-$2");
                    }
                    else {
                        returnvalue = returnvalue.replace(/^(\d{2})(\d)/, "$1.$2");
                        returnvalue = returnvalue.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3");
                        returnvalue = returnvalue.replace(/\.(\d{3})(\d)/, ".$1/$2");
                        returnvalue = returnvalue.replace(/(\d{4})(\d)/, "$1-$2");
                    }
                    if (returnvalue != inputValue) {
                        modelCtrl.$setViewValue(returnvalue);
                        modelCtrl.$render();
                    }
                    return returnvalue;
                });
            }
        };
    };

    angular.module('Trade4B').directive('maskCpfcnpj', maskCpfcnpj);

}());

(function () {
    // use this directive to delay assigning user input to the underlying 
    // view model field until focus leaves the dom element. Useful for 
    // delaying breeze validation until user enters all data (like when 
    // entering dates)
    var maskCnpj = function () {
        return {
            require: 'ngModel',
            link: function (scope, el, attrs, modelCtrl) {
                modelCtrl.$parsers.push(function (inputValue) {
                    if (inputValue == undefined) return ''
                    var returnvalue = ''
                    returnvalue = inputValue.replace(/\D/g, "")
                    returnvalue = returnvalue.replace(/^(\d{2})(\d)/, "$1.$2")
                    returnvalue = returnvalue.replace(/^(\d{2})\.(\d{3})(\d)/, "$1.$2.$3")
                    returnvalue = returnvalue.replace(/\.(\d{3})(\d)/, ".$1/$2")
                    returnvalue = returnvalue.replace(/(\d{4})(\d)/, "$1-$2");
                    if (returnvalue != inputValue) {
                        modelCtrl.$setViewValue(returnvalue);
                        modelCtrl.$render();
                    }
                    return returnvalue;
                });
            }
        };
    };

    angular.module('Trade4B').directive('maskCnpj', maskCnpj);

}());

(function () {
    // use this directive to delay assigning user input to the underlying 
    // view model field until focus leaves the dom element. Useful for 
    // delaying breeze validation until user enters all data (like when 
    // entering dates)
    var maskdate = function () {
        return {
            require: 'ngModel',
            link: function (scope, el, attrs, modelCtrl) {
                modelCtrl.$parsers.push(function (inputValue) {
                    if (inputValue == undefined) return ''
                    var returnvalue = inputValue.replace(/\D/g, '');
                    returnvalue = returnvalue.replace(/^(\d\d)(\d)/, "$1/$2");
                    returnvalue = returnvalue.replace(/^(\d{2}\/\d{2})(\d)/, "$1/$2");
                    if (returnvalue != inputValue) {
                        modelCtrl.$setViewValue(returnvalue);
                        modelCtrl.$render();
                    }

                    return returnvalue;
                });
            }
        };
    };

    angular.module('Trade4B').directive('maskdate', maskdate);

}());

(function () {
    // use this directive to delay assigning user input to the underlying 
    // view model field until focus leaves the dom element. Useful for 
    // delaying breeze validation until user enters all data (like when 
    // entering dates)
    var datepicker = function () {
        return {
            restrict: 'A',
            require: 'ngModel',
            link: function (scope, element, attrs, ngModelCtrl) {
                $(function () {
                    element.datepicker({
                        format: "dd/mm/yyyy",
                        language: "pt-BR",
                        todayHighlight: true,
                        onSelect: function (date) {
                            scope.$apply(function () {
                                ngModelCtrl.$setViewValue(date);
                            });
                        }
                    });
                });
            }
        }
    };

    angular.module('Trade4B').directive('datepicker', datepicker);

}());

(function () {
    // use this directive to delay assigning user input to the underlying 
    // view model field until focus leaves the dom element. Useful for 
    // delaying breeze validation until user enters all data (like when 
    // entering dates)
    var maskhour = function () {
        return {
            require: 'ngModel',
            link: function (scope, el, attrs, modelCtrl) {
                modelCtrl.$parsers.push(function (inputValue) {
                    if (inputValue == undefined) return ''
                    var returnvalue = inputValue.replace(/\D/g, '').replace(/(\d{2})(\d)/, '$1:$2');

                    if (returnvalue != inputValue) {
                        modelCtrl.$setViewValue(returnvalue);
                        modelCtrl.$render();
                    }
                    return returnvalue;
                });
            }
        };
    };

    angular.module('Trade4B').directive('maskhour', maskhour);

}());


//(function () {
//    // use this directive to delay assigning user input to the underlying 
//    // view model field until focus leaves the dom element. Useful for 
//    // delaying breeze validation until user enters all data (like when 
//    // entering dates)
//    var maskcurrency = function () {
//        return {
//            require: 'ngModel',
//            link: function (scope, el, attrs, modelCtrl) {
//                scope.$watch(el.val(), function () {
//                    $(el).maskMoney({ symbol: '', thousands: '.', decimal: ',' });
//                });
//            }
//        };
//    };

//    angular.module('Trade4B').directive('maskcurrency', maskcurrency);

//}());



//application.directive('maskPhone', function () {
//    return {
//        require: 'ngModel',
//        link: function (scope, el, attrs, modelCtrl) {
//            modelCtrl.$parsers.push(function (inputValue) {
//                if (inputValue == undefined) return ''

//                var returnvalue = ''
//                if (inputValue != null) {
//                    returnvalue = inputValue.replace(/\D/g, "");                     //Remove tudo o que não é dígito
//                    returnvalue = returnvalue.replace(/(\d{2})(\d)/, "($1) $2");      //Coloca parênteses em volta dos dois primeiros dígitos
//                    if (inputValue.length < 15)
//                        returnvalue = returnvalue.replace(/(\d{4})(\d)/, "$1-$2");    //Coloca hífen entre o quarto e o quinto dígitos
//                    else
//                        returnvalue = returnvalue.replace(/(\d{5})(\d)/, "$1-$2");    //Coloca hífen entre o quarto e o quinto dígitos
//                }

//                if (returnvalue != inputValue) {
//                    modelCtrl.$setViewValue(returnvalue);
//                    modelCtrl.$render();
//                }
//                return returnvalue;
//            });
//        }
//    };
//    //return {
//    //    restrict: 'A',
//    //    link: function (scope, el, attrs) {
//    //        scope.$watch(attrs.ngModel, function () {

//    //            if (el.val() != null) {
//    //                el.val(el.val().replace(/\D/g, ""));                     //Remove tudo o que não é dígito
//    //                el.val(el.val().replace(/(\d{2})(\d)/, "($1) $2"));      //Coloca parênteses em volta dos dois primeiros dígitos
//    //                if (el.val().length < 14)
//    //                    el.val(el.val().replace(/(\d{4})(\d)/, "$1-$2"));    //Coloca hífen entre o quarto e o quinto dígitos
//    //                else
//    //                    el.val(el.val().replace(/(\d{5})(\d)/, "$1-$2"));    //Coloca hífen entre o quarto e o quinto dígitos
//    //            }
//    //        });
//    //    }
//    //};
//});

//application.directive('maskCep', function () {
//    return {
//        require: 'ngModel',
//        link: function (scope, el, attrs, modelCtrl) {
//            modelCtrl.$parsers.push(function (inputValue) {
//                if (inputValue == undefined) return ''
//                var returnvalue = inputValue.replace(/\D/g, '').replace(/(\d{5})(\d)/, '$1-$2');
//                if (returnvalue != inputValue) {
//                    modelCtrl.$setViewValue(returnvalue);
//                    modelCtrl.$render();
//                }
//                return returnvalue;
//            });
//        }
//    };
//    //return {
//    //    restrict: 'A',
//    //    link: function (scope, el, attrs) {
//    //        scope.$watch(attrs.ngModel, function () {

//    //            if (el.val() != null) {
//    //                el.val(el.val().replace(/\D/g, ''));
//    //                el.val(el.val().replace(/(\d{5})(\d)/, '$1-$2'));
//    //            }
//    //        });
//    //    }
//    //};
//});

//application.directive('formatPoint', function () {
//    return {
//        restrict: 'A',
//        link: function (scope, elm, attrs) {
//            if (attrs.ngModel) {
//                scope.$watch(attrs.ngModel, function () {
//                    $(elm).formatCurrency($.parseJSON(scope.FormatPoint));
//                });
//            }
//            else if (attrs.ngBind) {
//                scope.$watch(attrs.ngBind, function () {
//                    $(elm).formatCurrency($.parseJSON(scope.FormatPoint));
//                });
//            }
//        }
//    };
//});

//application.directive('formatCurrency', function () {
//    return {
//        restrict: 'AC',
//        link: function (scope, el, attrs) {
//            scope.$watch(el.val(), function () {
//                $(el).maskMoney({ symbol: '', thousands: '.', decimal: ',' });
//            });
//        }
//    };
//});

//application.directive('formatcurrencyrefund', function () {
//    return {
//        restrict: 'AC',
//        link: function (scope, el, attrs) {
//            scope.$watch(el.val(), function () {
//                $(el).maskMoney({ symbol: '', thousands: '', decimal: ',' });
//            });
//        }
//    };
//});

//application.directive('number', function () {
//    return {
//        require: 'ngModel',
//        link: function (scope, el, attrs, modelCtrl) {
//            modelCtrl.$parsers.push(function (inputValue) {
//                if (inputValue == undefined) return ''
//                var returnvalue = inputValue.replace(/\D/g, "");
//                if (returnvalue != inputValue) {
//                    modelCtrl.$setViewValue(returnvalue);
//                    modelCtrl.$render();
//                }
//                return returnvalue;
//            });
//        }
//    };
//    //return {
//    //    restrict: 'AC',
//    //    link: function (scope, el, attrs) {
//    //        scope.$watch(attrs.ngModel, function () {
//    //            el.val(el.val().replace(/\D/g, ""));
//    //        });
//    //    }
//    //};
//});

//application.directive('numberletter', function () {
//    return {
//        require: 'ngModel',
//        link: function (scope, el, attrs, modelCtrl) {
//            modelCtrl.$parsers.push(function (inputValue) {
//                if (inputValue == undefined) return ''
//                var returnvalue = inputValue.replace(/[^a-zA-Z0-9]/g, "");
//                if (returnvalue != inputValue) {
//                    modelCtrl.$setViewValue(returnvalue);
//                    modelCtrl.$render();
//                }
//                return returnvalue;
//            });
//        }
//    };
//    //return {
//    //    restrict: 'A',
//    //    link: function (scope, el, attrs) {
//    //        scope.$watch(attrs.ngModel, function () {
//    //            el.val(el.val().replace(/[^a-zA-Z0-9]/g, ""));
//    //        });
//    //    }
//    //};
//});

//application.directive('numberletterspace', function () {
//    return {
//        require: 'ngModel',
//        link: function (scope, el, attrs, modelCtrl) {
//            modelCtrl.$parsers.push(function (inputValue) {
//                if (inputValue == undefined) return ''
//                var returnvalue = inputValue.replace(/[^a-zA-Z0-9 ]/g, "");
//                if (returnvalue != inputValue) {
//                    modelCtrl.$setViewValue(returnvalue);
//                    modelCtrl.$render();
//                }
//                return returnvalue;
//            });
//        }
//    };
//    //return {
//    //    restrict: 'A',
//    //    link: function (scope, el, attrs) {
//    //        scope.$watch(attrs.ngModel, function () {
//    //            el.val(el.val().replace(/[^a-zA-Z0-9 ]/g, ""));
//    //        });
//    //    }
//    //};
//});

//application.directive('letter', function () {
//    return {
//        require: 'ngModel',
//        link: function (scope, el, attrs, modelCtrl) {
//            modelCtrl.$parsers.push(function (inputValue) {
//                if (inputValue == undefined) return ''
//                var returnvalue = inputValue.replace(/[^a-zA-Z ]/g, "");
//                if (returnvalue != inputValue) {
//                    modelCtrl.$setViewValue(returnvalue);
//                    modelCtrl.$render();
//                }
//                return returnvalue;
//            });
//        }
//    };
//});


//application.directive('dateTimePicker', ['$timeout', function ($timeout) {
//    return {
//        link: function (scope, element, attrs, ctrl) {
//            $timeout(function () {
//                element.datetimepicker({
//                    //      language:  'pt-BR',
//                    weekStart: 1,
//                    todayBtn: 1,
//                    autoclose: 1,
//                    todayHighlight: 1,
//                    startView: 2,
//                    forceParse: 0,
//                    showMeridian: 1
//                });
//            }, 10);
//            scope.$apply();
//        }
//    }
//}]);
