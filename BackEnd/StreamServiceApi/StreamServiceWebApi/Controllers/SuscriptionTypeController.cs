using Application.Features.SuscriptionTypes.Queries.GetSuscriptionTypes;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace StreamServiceWebApi.Controllers
{

    public class SuscriptionTypeController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult> Get() => Ok(await Mediator.Send(new GetSuscriptionTypesQuery()));
    }
}
