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
    public class UsersController : ApiController
    {
        private IUserRepository _userRepository;
        public UsersController(IUserRepository repo)
        {
            _userRepository = repo;
        }
        // GET api/<controller>
        [Route("api/users")]
        [ResponseType(typeof(IEnumerable<User>))]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _userRepository.GetAll());
        }

        // GET api/<controller>/5
        [Route("api/users/{id}")]
        [ResponseType(typeof(User))]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            User toFind = _userRepository.Get(c => c.ID == id);
            if (toFind == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "User not found");
            }
            return Request.CreateResponse(HttpStatusCode.OK, toFind);
        }

        // POST api/<controller>
        [Route("api/users)]
        [ResponseType(typeof(User))]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]User user)
        {
            if (user != null)
            {
                _userRepository.Create(user);
            }
            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        // PUT api/<controller>/5
        [Route("api/users/{id}")]
        [HttpPut]
        public void Put(int id, [FromBody]User user)
        {
            User ToUpdate = _userRepository.Get(c => c.ID == id);
            if (ToUpdate == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotModified, "User to update does not exits."));
            }

            ToUpdate.ID = user.ID;
            ToUpdate.Firstname = user.Firstname;
            ToUpdate.Lastname = user.Lastname;
            ToUpdate.Login = user.Login;
            ToUpdate.Email = user.Email;
            ToUpdate.Phone = user.Phone;
            _userRepository.Update(ToUpdate);
        }

        // DELETE api/<controller>/5
        [Route("api/users/{id}")]
        [HttpDelete]
        public void Delete(int id)
        {
            User ToDelete = _userRepository.Get(c => c.ID == id);
            if (ToDelete == null)
            {
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound, "User to delete does not exits."));
            }
            _userRepository.Delete(ToDelete);
        }
    }
}