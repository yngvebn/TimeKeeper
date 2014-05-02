(function() {
    function entry() {
        this.checkIn = '';
        this.checkOut = '';
        this.date = '';
        
    }

    entry.prototype = {
        get duration(){
            return moment.duration(moment(this.checkOut, "HH:mm:ss.ms") - moment(this.checkIn, "HH:mm:ss.ms"))._data;
        }
    }
    angular.module('app').constant('Entry', entry);
}());

