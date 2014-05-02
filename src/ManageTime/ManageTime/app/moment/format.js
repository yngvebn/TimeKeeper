angular.module('app').filter('format', 
    function() {
        'use strict';
        
        return function (input, format) {
            console.log(input, format);
            return input.format(format);
        }
    }
);