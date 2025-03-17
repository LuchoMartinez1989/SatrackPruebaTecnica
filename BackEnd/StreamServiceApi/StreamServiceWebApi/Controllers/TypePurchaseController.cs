using Application.Features.TypePurchases.Queries.GetTypePurchases;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace StreamServiceWebApi.Controllers
{
    public class TypePurchaseController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult> Get() => Ok(await Mediator.Send(new GetTypePurchaseQuery()));
    }
}
