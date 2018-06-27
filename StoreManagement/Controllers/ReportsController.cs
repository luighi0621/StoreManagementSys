using StoreManagement.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManagement.Controllers
{
    public class ReportsController : Controller
    {
        private IOperationRepository _operationRepository;

        public ReportsController(IOperationRepository opeRepo)
        {
            _operationRepository = opeRepo;
        }
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Operations()
        {
            return View(_operationRepository.GetAll());
        }
        public ActionResult ProductsBySupplier()
        {
            string query = "select s.Name, p.Name from product p, supplier s where p.IdSupplier = s.Id group by s.Name, p.Name order by s.Name, p.Name";
            DataTable data = _operationRepository.ExecuteQuery(query);
            return View(data);
        }

        public ActionResult CustomersByLastname()
        {
            string query = "select Lastname, Firstname, Address, Email, Phone, CustomerCode from Customer order by Lastname";
            DataTable data = _operationRepository.ExecuteQuery(query);
            return View(data);
        }

        public ActionResult UsersCustomers()
        {
            string query = "select distinct u.Firstname, u.Lastname, u.Username, u.Email, u.PhoneNumber from [User] u" +
                " inner join [Customer] c on u.Firstname = c.Firstname " +
                " inner join [Customer] cus on u.Lastname = cus.Lastname";
            DataTable data = _operationRepository.ExecuteQuery(query);
            return View(data);
        }

        public ActionResult CustomersAddress()
        {
            string query = "select Firstname, Lastname, Address, Email, Phone, CustomerCode from Customer";
            DataTable data = _operationRepository.ExecuteQuery(query);
            return View(data);
        }

        [HttpPost]
        public ActionResult FilterCustomersAjax(string filter)
        {
            string query = "select Firstname, Lastname, Address, Email, Phone, CustomerCode from Customer";
            if (!string.IsNullOrEmpty(filter))
            {
                query = string.Format("{0} where LOWER(Address) like LOWER('%{1}%')", query, filter);
            }
            DataTable filtering = _operationRepository.ExecuteQuery(query);
            return PartialView("AddressCustomerPartial", filtering);
        }
    }
}