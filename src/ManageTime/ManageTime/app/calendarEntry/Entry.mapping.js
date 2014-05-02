angular.module('app').config(['MappingProvider', 'Entry', function (mapping, entry) {
    mapping.for(entry, {
        checkIn: function () {
            return moment(this.checkIn, "HH:mm:ss.ms");
        },
        checkOut: function () {
            return moment(this.checkOut, "HH:mm:ss.ms");
        },
        date: function() {
            return moment(this.date)
        }
    });
}]);