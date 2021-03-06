(function(angular, console) {
    'use strict';
    var app = angular.module('app', []);

    app.controller('tryCors', ['$scope', '$http', function($scope, $http) {
        function successResult(data, method) {
            console.log(data, method);
        }

        function errResult(method) {
            console.log('Err ' + method);
        }

        $scope.baseUrl = 'http://localhost:49158/api/file';

        $scope.init = function() {
            // $http.get($scope.baseUrl).then(function(res) {
            //     successResult(res.data, 'Get')
            // }, function() {
            //     errResult('Get')
            // });
            $http.post($scope.baseUrl,{value:'Hello I\'m POST method'}).then(function(res) {
                successResult(res.data, 'post');
                window.location.href = $scope.baseUrl+'/?fileName='+res.data.fileName;
            }, function() {
                errResult('post');
            });
            // $http.put($scope.baseUrl, {value:"Hello I'm PUT method"}).then(function(res) {
            //     successResult(res.data, 'put')
            // }, function() {
            //     errResult('put')
            // });
            // $http['delete']($scope.baseUrl,{value:"Hello I'm DELETE method"}).then(function(res) {
            //     successResult(res.data, 'delete')
            // }, function() {
            //     errResult('delete')
            // });
        };
    }]);
})(angular, console);
