using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Customers.Commands.CreateCustomerCommand;
using Application.Features.Customers.Commands.DeleteCustomerCommand;
using Application.Features.Customers.Commands.UpdateCustomerCommand;
using Application.Features.Customers.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using WebApi.Controllers;
using Application.Features.Customers.Queries.GetCustomers;


namespace StreamServiceWebApi.Controllers
{
    public class CustomerController : BaseApiController
    {
        //[Authorize(Roles = "Administrator,Manager")]// personaliza que perfil puede realziar ejecuciones del endpoint
        [HttpPost]
        public async Task<ActionResult> Post(CreateCustomerCommand command) => Ok(await Mediator.Send(command));

        //[Authorize(Roles = "Administrator,Manager")]// personaliza que perfil puede realziar ejecuciones del endpoint
        [HttpPut]
        public async Task<ActionResult> Put(UpdateCustomerCommand command) => Ok(await Mediator.Send(command));

        //[Authorize(Roles = "Administrator,Manager")]// personaliza que perfil puede realziar ejecuciones del endpoint
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) => Ok(await Mediator.Send(new DeleteCustomerCommand() { Id = id }));

        ///[Authorize(Roles = "Administrator,Manager")]// personaliza que perfil puede realziar ejecuciones del endpoint
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id) => Ok(await Mediator.Send(new GetCustomerByIdQuery() { Id = id }));

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] GetCustomersParameters query) => Ok(await Mediator.Send
            (new GetCustomersByEmailQuery()
            {
                //IdenticacionCode = null,
                //Name = null,
                //Lastnames = null,
                Mail = query.Mail
            }
            ));


    }
}
