(function () {

    var injectParams = ['$http'];

    var TimeSheetFactory = function ($http) {
        return {
            GetTimeSheet: function (data, sucesscallback, errorcallback) {
                $http.get(global.service + '/api/TimeSheet/GetTimeSheet?IniDate=' + data.IniDate + '&EndDate=' + data.EndDate)
                    .success(sucesscallback)
                    .error(errorcallback);
            },
            getProjectsByClientId: function (data, sucesscallback, errorcallback) {
                $http.get(global.service + '/api/Account/GetProjectsByClientId?clientId=' + data)
                    .success(sucesscallback)
                    .error(errorCallback);
            },
            Edit: function (data, sucesscallback, errorcallback) {
                $http.get(global.service + '/api/TimeSheet/GetTimeSheetById?timesheetId=' + data.timesheetId)
                    .success(sucesscallback)
                    .error(errorcallback);
            },

            SaveOrUpDate: function (data, sucesscallback, errorcallback) {
                $http.post(global.service + '/api/TimeSheet/SaveOrUpDate', data)
                    .success(sucesscallback)
                    .error(errorcallback);
            },
            Remove: function (data, sucesscallback, errorcallback) {
                $http.post(global.service + '/api/TimeSheet/Remove?timesheetId=' + data.timesheetId)
                    .success(sucesscallback)
                    .error(errorcallback);
            }
        }
    };

    TimeSheetFactory.$inject = injectParams;

    angular.module('Trade4B').factory('TimeSheetFactory', TimeSheetFactory);

}());

