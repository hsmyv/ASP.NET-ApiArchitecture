using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Customer;
using ServiceLayer.Services.Interfaces;

namespace Api.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _service;
        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CustomerCreateDto customer)
        {
            await _service.InsertAsync(customer);
            return Ok(customer);
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] CustomerEditDto customer)
        {
            await _service.UpdateAsync(id, customer);
            return Ok();
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> GetByName([FromQuery] string search)
        {
            return Ok(await _service.GetAllByConditionAsync(search));
        }
    }
}
