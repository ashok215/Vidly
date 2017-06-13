using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/Customers
        public IHttpActionResult GetCustomers(string query=null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!string.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDto= customersQuery
                
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDto);
        }

        //GET /api/Customers/Id

        public IHttpActionResult GetCustomer(int id)
        {

           
            var customer = _context.Customers.SingleOrDefault(m => m.Id == id);


            if(customer==null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer,CustomerDto>(customer));

        }

        //POST /api/Customers
        [HttpPost]
        public IHttpActionResult  CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri +"/"+customer.Id),customerDto);
        }

        //Put /api/Customers/id
        [HttpPut]
     public void  UpdateCustomer(int id,CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(m => m.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {

            var customer = _context.Customers.SingleOrDefault(m => m.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customer);
            _context.SaveChanges();


        }
    }
}
