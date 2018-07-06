using StoreManagement.Dal.Interfaces;
using StoreManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;

namespace StoreManagement.Controllers.api
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReportsController : ApiController
    {
        private IOperationRepository _repository;

        public ReportsController(IOperationRepository repo)
        {
            _repository = repo;
        }

        struct ActionReport
        {
            string Name;
            string Link;
            public ActionReport(string l, string n)
            {
                Name = n; 
                Link = l;
            }
        }

        // GET api/<controller>
        [Route("api/reports")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            Dictionary<string, string> actions = new Dictionary<string, string>();
            actions["ProductsBySupplier"] = "Products By Supplier";
            actions["CustomersByLastname"] = "Customers By Lastname";
            actions["UsersCustomers"] = "Users and Customers with same name and lastname";
            actions["CustomersAddress"] = "Customers with Address";
            actions["Operations"] = "Operations report";
            return Request.CreateResponse(HttpStatusCode.OK, actions.ToArray());
        }

        [Route("api/reports/CustomersByLastname")]
        [HttpGet]
        public HttpResponseMessage CustomersByLastname()
        {
            string query = "select Lastname, Firstname, Address, Email, Phone, CustomerCode from Customer order by Lastname";
            DataTable data = _repository.ExecuteQuery(query);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/reports/ProductsBySupplier")]
        [HttpGet]
        public HttpResponseMessage ProductsBySupplier()
        {
            string query = "select s.Name, p.Name from product p, supplier s where p.IdSupplier = s.Id group by s.Name, p.Name order by s.Name, p.Name";
            DataTable data = _repository.ExecuteQuery(query);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/reports/UsersCustomers")]
        [HttpGet]
        public HttpResponseMessage UsersCustomers()
        {
            string query = "select distinct u.Firstname, u.Lastname, u.Login, u.Email, u.Phone from [User] u" +
                " inner join [Customer] c on u.Firstname = c.Firstname " +
                " inner join [Customer] cus on u.Lastname = cus.Lastname";
            DataTable data = _repository.ExecuteQuery(query);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/reports/CustomersAddress/{address?}")]
        [HttpGet]
        public HttpResponseMessage CustomersAddress(string address)
        {
            string query = string.Format("select Firstname, Lastname, Address, Email, Phone, CustomerCode from Customer where LOWER(Address) like LOWER('%{0}%')", address);
            DataTable data = _repository.ExecuteQuery(query);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/reports/CustomersAddress")]
        [HttpGet]
        public HttpResponseMessage CustomersAddress()
        {
            string query = "select Firstname, Lastname, Address, Email, Phone, CustomerCode from Customer";
            DataTable data = _repository.ExecuteQuery(query);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [Route("api/reports/Operations")]
        [HttpGet]
        public HttpResponseMessage Operations()
        {
            IEnumerable<Operation> data = _repository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}