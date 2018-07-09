app.factory('CustomerService', function ($resource, config) {
    return $resource(config.url +'/api/customers/:id', { id: '@id' }, {
        update: {
            method: 'PUT'
        }
    });
});

app.factory('SupplierService', function ($resource, config) {
    return $resource(config.url +'/api/suppliers/:id', { id: '@id' }, {
        update: {
            method: 'PUT'
        }
    });
});

app.factory('ProductService', function ($resource, config) {
    return $resource(config.url +'/api/products/:id', { id: '@id' }, {
        update: {
            method: 'PUT'
        }
    });
});

app.factory('UserService', function ($resource, config) {
    return $resource(config.url + '/api/users/:id', { id: '@id' }, {
        update: {
            method: 'PUT'
        }
    });
});

app.factory('RepService', function ($resource, config) {
    return $resource(config.url +'/api/reports', { address: '@address' }, {
        'getReports': {
            url: config.url +'/api/reports/',
            method: 'GET',
            isArray: true
        },
        'getProductsBySupplier': {
            url: config.url +'/api/reports/ProductsBySupplier',
            method: 'GET',
            isArray: true
        },
        'getUsersCustomers': {
            url: config.url +'/api/reports/UsersCustomers',
            method: 'GeT',
            isArray: true
        },
        'getCustomersByLastname': {
            url: config.url +'/api/reports/CustomersByLastname',
            method: 'GeT',
            isArray: true
        },
        'getCustomersAddress': {
            url: config.url +'/api/reports/CustomersAddress',
            method: 'GeT',
            isArray: true
        },
        'getCustomersAddressWithAddress': {
            url: config.url +'/api/reports/CustomersAddress/:address',
            method: 'GeT',
            isArray: true
        },
        'getOperations': {
            url: config.url +'/api/reports/Operations',
            method: 'GeT',
            isArray: true
        }
    });
});

app.factory('ReportService', function ($http, config) {
    var urlBalse = config + '/api/reports';
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