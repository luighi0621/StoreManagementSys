using StoreManagement.Dal.Interfaces;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoreManagement.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ICustomerRepository _cusRepo;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _cusRepo = customerRepository;
        }

        // GET api/customers
        public IEnumerable<Customer> Get()
        {
            return _cusRepo.GetAll();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}