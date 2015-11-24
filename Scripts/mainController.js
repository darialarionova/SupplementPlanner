var mainApp = angular.module('mainApp', []);

mainApp.controller('mainController', ['$scope', 'gridService', function ($scope, gridService) {
    
    $scope.types = {
        vitamin: 'Vitamin',
        mineral: 'Mineral'
    }

    $scope.initialize = function () {
        $scope.currentSupplement = {
            vitaminCellsStyle: [],
            mineralCellsStyle: [],
            relatedVitamins: [],
            relatedMinerals: []
        };

        gridService.getSupplementsByType($scope.types.vitamin).success(function (data, status) {
            $scope.vitamins = data;
            $scope.currentSupplement.vitaminCellsStyle = $scope.chooseCellsStyle(0, data, []);
        });
        gridService.getSupplementsByType($scope.types.mineral).success(function (data, status) {
            $scope.minerals = data;
            $scope.currentSupplement.mineralCellsStyle = $scope.chooseCellsStyle(0, data, []);
        });
    }
    $scope.onSupplementClick = function (id) {
        gridService.getSupplement(id, $scope.types.vitamin).success(function (data, status) {
            $scope.currentSupplement.id = id;
            $scope.currentSupplementrelatedVitamins = data;
            $scope.currentSupplement.vitaminCellsStyle = $scope.chooseCellsStyle(id, $scope.vitamins, data);
        });
        gridService.getSupplement(id, $scope.types.mineral).success(function (data, status) {
            $scope.currentSupplement.relatedMinerals = data,
            $scope.currentSupplement.mineralCellsStyle = $scope.chooseCellsStyle(id, $scope.minerals, data);
        });
    }
    $scope.chooseCellsStyle = function(currentSupplementId, supplements, relatedSupplements) {
        var cellStyles = [];
        for (var i = 0, j = 0; i < supplements.length; i++) {
            if (currentSupplementId == supplements[i].Id) {
                cellStyles.push("Current");
                continue;
            }
            if (typeof (relatedSupplements[j]) == "undefined" || supplements[i].Id != relatedSupplements[j].Id) {
                cellStyles.push("Neutral");
            } else {
                cellStyles.push(relatedSupplements[j].RelationType);
                j++;
            }
        }
        return cellStyles;
    }
}]);

mainApp.service('gridService', ['gridRepository', function (gridRepository) {
    this.getSupplement = function (id, type) {
        return gridRepository.getSupplement(id, type);
    }
    this.getSupplementsByType = function (type) {
        return gridRepository.getSupplementsByType(type);
    }
}]);

mainApp.service('gridRepository', ['$http', function ($http) {
    this.getSupplementsByType = function (type) {
        return $http.post("SupplementsPlanner/GetSupplements/" + type);
    }
    this.getSupplement = function (id, type) {
        return $http.post("SupplementsPlanner/GetSupplementRelations/" + id + "/" + type);
    }
}]);