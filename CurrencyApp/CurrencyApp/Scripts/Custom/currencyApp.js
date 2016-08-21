var currencyApp = angular.module('currencyApp', []);

currencyApp.controller('currencyController', function ($scope, $http) {
    $http.get("Home/GetResult").then(function (response) {
        $scope.result = response.data;
    });
});