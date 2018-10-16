(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider', '$qProvider',
        function ($stateProvider, $urlRouterProvider, $qProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('tasklist', {
                    url: '/',
                    templateUrl: '/App/Main/views/task/list.cshtml',
                    menu: 'TaskList' //Matches to name of 'TaskList' menu in SvcNavigationProvider
                })
                .state('processlist', {
                    url: '/',
                    templateUrl: '/App/Main/views/prcess/list.cshtml',
                    menu: 'ProcessList' //Matches to name of 'ProcessList' menu in SvcNavigationProvider
                });

            //$qProvider settings
            $qProvider.errorOnUnhandledRejections(false);
        }
    ]);
})();