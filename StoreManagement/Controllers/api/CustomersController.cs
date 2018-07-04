using StoreManagement.Dal.Interfaces;
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
    public class CustomersController : ApiController
    {
        private ICustomerRepository _cusRepo;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _cusRepo = customerRepository;
        }

        // GET api/customers
        [ResponseType(typeof(IEnumerable<Customer>))]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _cusRepo.GetAll());
        }

        // GET api/customers/5
        [ResponseType(typeof(Customer))]
        public HttpResponseMessage Get(int id)
        {
            Customer toFind = _cusRepo.Get(c => c.ID == id);
            if(toFind == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Customer not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, toFind);
        }

        // POST api/customers
        [ResponseType(typeof(Customer))]
        public HttpResponseMessage Post([FromBody]Customer customer)
        {
            if(customer != null){
                _cusRepo.Create(customer);
            }
            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        // PUT api/customers/5
        public void Put(int id, [FromBody]Customer update)
        {
            Customer cusToUpdate = _cusRepo.Get(c => c.ID == id);
            if (cusToUpdate == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotModified, "Customer to update does not exits."));
            }
            cusToUpdate.ID = update.ID;
            cusToUpdate.Firstname = update.Firstname;
            cusToUpdate.Lastname = update.Lastname;
            cusToUpdate.Address = update.Address;
            cusToUpdate.Email = update.Email;
            cusToUpdate.Phone = update.Phone;
            cusToUpdate.CustomerCode = update.CustomerCode;
            _cusRepo.Update(cusToUpdate);
        }

        // DELETE api/customers/5
        public void Delete(int id)
        {
            Customer cusToDelete = _cusRepo.Get(c => c.ID == id);
            if(cusToDelete == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Customer to delete does not exits."));
            }
            _cusRepo.Delete(cusToDelete);
        }
    }
}