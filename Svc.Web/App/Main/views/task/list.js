(function () {
    var app = angular.module('app');

    var controllerId = 'sts.views.task.list';
    app.controller(controllerId, [
        '$scope', 'abp.services.taskmanager.task',
        function ($scope, taskService) {
            var vm = this;

            vm.localize = abp.localization.getSource('Svc');

            vm.tasks = [];

            $scope.selectedTaskState = 0;

            $scope.$watch('selectedTaskState', function (value) {
                vm.refreshTasks();
            });

            vm.refreshTasks = function () {
                abp.ui.setBusy(
                    null,
                    taskService.getTasks({
                        state: $scope.selectedTaskState > 0 ? $scope.selectedTaskState : null
                    }).then(function (data) {
                        vm.tasks = data.data.tasks;
                    })
                );
            };

            vm.changeTaskState = function (task) {
                var newState;
                if (task.state == 1) {
                    newState = 2; //Stopped
                } else {
                    newState = 1; //Active
                }

                taskService.updateTask({
                    taskId: task.id,
                    state: newState
                }).then(function () {
                    task.state = newState;
                    abp.notify.info(vm.localize('TaskUpdatedMessage'));
                });
            };

            vm.getTaskCountText = function () {
                return abp.utils.formatString(vm.localize('Xtasks'), vm.tasks.length);
            };
        }
    ]);
})();