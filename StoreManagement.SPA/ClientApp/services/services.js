app.factory('CustomerService', function ($resource) {
    return $resource('http://localhost:57826/api/customers/:id', { id: '@id' }, {
        update: {
            method: 'PUT'
        }
    });
});

app.factory('SupplierService', function ($resource) {
    return $resource('http://localhost:57826/api/suppliers/:id', { id: '@id' }, {
        update: {
            method: 'PUT'
        }
    });
});

app.factory('ProductService', function ($resource) {
    return $resource('http://localhost:57826/api/products/:id', { id: '@id' }, {
        update: {
            method: 'PUT'
        }
    });
});

app.factory('RepService', function ($resource) {
    return $resource('http://localhost:57826/api/reports', { address: '@address' }, {
        'getReports': {
            url: 'http://localhost:57826/api/reports/',
            method: 'GET',
            isArray: true
        },
        'getProductsBySupplier': {
            url: 'http://localhost:57826/api/reports/ProductsBySupplier',
            method: 'GET',
            isArray: true
        },
        'getUsersCustomers': {
            url: 'http://localhost:57826/api/reports/UsersCustomers',
            method: 'GeT',
            isArray: true
        },
        'getCustomersByLastname': {
            url: 'http://localhost:57826/api/reports/CustomersByLastname',
            method: 'GeT',
            isArray: true
        },
        'getCustomersAddress': {
            url: 'http://localhost:57826/api/reports/CustomersAddress',
            method: 'GeT',
            isArray: true
        },
        'getCustomersAddressWithAddress': {
            url: 'http://localhost:57826/api/reports/CustomersAddress/:address',
            method: 'GeT',
            isArray: true
        },
        'getOperations': {
            url: 'http://localhost:57826/api/reports/Operations',
            method: 'GeT',
            isArray: true
        }
    });
});

app.factory('ReportService', function ($http) {
    var urlBalse = 'http://localhost:57826/api/reports';
    var service = {};

    service.get = function () {
        return $http.get(urlBalse);
    };

    service.getCustomersByLastname = function () {
        return $http.get(urlBalse + '/CustomersByLastname');
    };

    service.getProductsBySupplier = function () {
        return $http.get(urlBalse + '/ProductsBySupplier');
    };

    service.getUsersCustomers = function () {
        return $http.get(urlBalse + '/UsersCustomers');
    };

    service.getCustomersAddress = function () {
        return $http.get(urlBalse + '/CustomersAddress');
    };

    service.getCustomersWithAddress = function (address) {
        return $http.get(urlBalse + '/CustomersAddress/' + address);
    };

    return service;
});