using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.CustomerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServiceNet5WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet(nameof(GetCustomer))]
        public IActionResult GetCustomer(int id)
        {
            var result = _customerService.GetCustomer(id);
            if (result is not null)
            {
                return Ok(result);
            }

            return BadRequest("No records found");
        }

        [HttpGet(nameof(GetAllCustomer))]
        public IActionResult GetAllCustomer()
        {
            var result = _customerService.GetAllCustomers();
            if (result is not null)
            {
                return Ok(result);
            }

            return BadRequest("No records found");
        }

        [HttpPost(nameof(InsertCustomer))]
        public IActionResult InsertCustomer(Customer customer)
        {
            _customerService.InsertCustomer(customer);
         
            return Ok("Data inserted");
        }
    }
}
