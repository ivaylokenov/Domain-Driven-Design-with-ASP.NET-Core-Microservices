namespace CarRentalSystem.Web.Features
{
    using System.Threading.Tasks;
    using Application.Common;
    using Application.Dealerships.Dealers.Commands.Create;
    using Application.Dealerships.Dealers.Commands.Edit;
    using Application.Dealerships.Dealers.Queries.Details;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class DealersController : ApiController
    {
        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<DealerDetailsOutputModel>> Details(
            [FromRoute] DealerDetailsQuery query)
            => await this.Send(query);

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<CreateDealerOutputModel>> Create(
            CreateDealerCommand command)
            => await this.Send(command);

        [HttpPut]
        [Route(Id)]
        public async Task<ActionResult> Edit(
            int id, EditDealerCommand command)
            => await this.Send(command.SetId(id));
    }
}
