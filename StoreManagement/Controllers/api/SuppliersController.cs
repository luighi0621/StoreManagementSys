﻿using StoreManagement.Dal.Interfaces;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace StoreManagement.Controllers.api
{
    public class SuppliersController : ApiController
    {
        private ISupplierRepository _supRepository;

        public SuppliersController(ISupplierRepository suprepo)
        {
            _supRepository = suprepo;
        }
        // GET api/<controller>
        [ResponseType(typeof(IEnumerable<Supplier>))]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _supRepository.GetAll());
        }

        // GET api/<controller>/5
        [ResponseType(typeof(Supplier))]
        public HttpResponseMessage Get(int id)
        {
            Supplier toFind = _supRepository.Get(c => c.ID == id);
            if (toFind == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Supplier not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, toFind);
        }

        // POST api/<controller>
        public int Post([FromBody]Supplier supplier)
        {
            if (supplier != null)
            {
                _supRepository.Create(supplier);
            }
            return supplier.ID;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Supplier cus)
        {
            Supplier ToUpdate = _supRepository.Get(c => c.ID == id);
            if (ToUpdate == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotModified, "Supplier to update does not exits."));
            }
            _supRepository.Update(cus);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            Supplier cusToDelete = _supRepository.Get(c => c.ID == id);
            if (cusToDelete == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Supplier to delete does not exits."));
            }
            _supRepository.Delete(cusToDelete);
        }
    }
}