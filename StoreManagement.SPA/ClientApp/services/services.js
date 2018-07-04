app.factory('CustomerService', function ($resource) {
    return $resource('http://localhost:57826/api/customers/:id', { id: '@id' }, {
        update: {
            method: 'PUT'
        }
    })
});

app.factory('SupplierService', function ($resource) {
    return $resource('http://localhost:57826/api/suppliers/:id', { id: '@id' }, {
        update: {
            method: 'PUT'
        }
    })
});

app.factory('ProductService', function ($resource) {
    return $resource('http://localhost:57826/api/products/:id', { id: '@id' }, {
        update: {
            method: 'PUT'
        }
    })
});