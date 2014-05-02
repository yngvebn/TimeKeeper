angular.module('app').controller('Home', [
    '$scope', 'CalendarEntries', 'Mapper', 'Entry', function($scope, calendarEntries, mapper, Entry) {
        'use strict';

        $scope.entries = [];

        calendarEntries.get().success(function(data) {
            $scope.entries = mapper.map(data.entries, Entry);
        })
    }
]);