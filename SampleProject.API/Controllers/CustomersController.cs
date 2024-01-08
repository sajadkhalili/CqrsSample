using MediatR;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Application.Customers.RegisterCustomer;
using SampleProject.Contract.Customers;
using System.Net;

namespace SampleProject.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : Controller
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Register customer.
        /// </summary>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(CustomerDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterCustomer([FromBody] RegisterCustomerRequest request)
        {
            var customer = await _mediator.Send(new RegisterCustomerCommand(request.Email, request.Name));


            return Created(string.Empty, customer);
        }

        [HttpGet]

        public async Task<IActionResult> GetCustomers()
        {
            var customerDetails = await _mediator.Send(new GetCustomerDetailsQuery());

            return Ok(customerDetails);
        }
    }
}
