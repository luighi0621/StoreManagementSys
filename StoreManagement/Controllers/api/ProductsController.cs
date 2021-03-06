﻿using StoreManagement.Dal.Interfaces;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace StoreManagement.Controllers.api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        private IProductRepository _prodRepo;

        public ProductsController(IProductRepository proRepo)
        {
            _prodRepo = proRepo;
        }

        // GET api/products
        [Route("api/products")]
        [HttpGet]
        [ResponseType(typeof(IEnumerable<Product>))]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _prodRepo.GetAll());
        }

        // GET api/products/5
        [Route("api/products/{id}")]
        [HttpGet]
        [ResponseType(typeof(Product))]
        public HttpResponseMessage Get(int id)
        {
            Product toFind = _prodRepo.Get(c => c.Id == id);
            if (toFind == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Product not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, toFind);
        }

        // POST api/products
        [Route("api/products")]
        [HttpPost]
        [ResponseType(typeof(Product))]
        public HttpResponseMessage Post([FromBody]Product prod)
        {
            if (prod != null)
            {
                prod.IdSupplier = prod.Supplier.ID;
                prod.Supplier = null;
                _prodRepo.Create(prod);
            }
            return Request.CreateResponse(HttpStatusCode.OK, prod);
        }

        // PUT api/products/5
        [Route("api/products/{id}")]
        [HttpPut]
        public void Put(int id, [FromBody]Product cus)
        {
            Product ToUpdate = _prodRepo.Get(c => c.Id == id);
            if (ToUpdate == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotModified, "Product to update does not exits."));
            }
            ToUpdate.Id = cus.Id;
            ToUpdate.Name = cus.Name;
            ToUpdate.Description = cus.Description;
            ToUpdate.Image = cus.Image;
            ToUpdate.ProductCode = cus.ProductCode;
            ToUpdate.IdSupplier = cus.Supplier.ID;
            _prodRepo.Update(ToUpdate);
        }

        // DELETE api/products/5
        [Route("api/products/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            Product cusToDelete = _prodRepo.Get(c => c.Id == id);
            if (cusToDelete == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product to delete does not exits."));
            }
            _prodRepo.Delete(cusToDelete);
        }
    }
}