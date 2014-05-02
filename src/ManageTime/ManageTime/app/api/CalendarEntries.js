angular.module('app').factory('CalendarEntries', ['$http',
    function($http) {
        'use strict';
        
        function get() {
            return $http.get('/api/v1/calendar');
        }

        return {
            get: get
        }
    }
]);