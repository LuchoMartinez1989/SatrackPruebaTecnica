using Application.Features.Customers.Queries.GetCustomers;
using Application.Features.CustomerSuscriptions.Commands.CreateCustomerSuscriptionCommand;
using Application.Features.CustomerSuscriptions.Commands.UpdateCustomerSuscriptionCommand;
using Application.Features.CustomerSuscriptions.Queries.GetCustomerActiveSuscriptionsByIdCustomer;
using Application.Features.CustomerSuscriptions.Queries.GetCustomerSuscriptionByIdCustomer;
using Application.Features.CustomerSuscriptions.Queries.GetCustomerSuscriptionListById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace StreamServiceWebApi.Controllers
{

    public class CustomerSuscriptionController : BaseApiController
    {
        [HttpPost]
        public async Task<ActionResult> Post(CreateCustomerSuscriptionCommand command) => Ok(await Mediator.Send(command));

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id) => Ok(await Mediator.Send(new GetCustomerSuscriptionByIdCustomerQuery() { Id = id }));

        [HttpPut]
        public async Task<ActionResult> Put(UpdateCustomerSuscriptionCommand command) => Ok(await Mediator.Send(command));

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] GetCustomerSuscriptionParameters query) => Ok(await Mediator.Send
            (new GetCustomerSuscriptionListByIdQuery()
            {
                IdCustomer = query.IdCustomer
            }
        ));

        [HttpGet("GetActiveSuscription")]
        public async Task<ActionResult> GetActiveSuscription([FromQuery] GetCustomerSuscriptionParameters query) => Ok(await Mediator.Send
            (new GetCustomerActiveSuscriptionsByIdCustomerQuery()
            {
                IdCustomer = query.IdCustomer
            }
        ));
    }
}
