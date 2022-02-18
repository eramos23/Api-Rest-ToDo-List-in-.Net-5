using Application.Features.Commands.ItemCommand;
using Application.Features.Queries.Items;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServiceApp.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ItemController : BaseApiController
    {
        #region Queries
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleItem(int id)
        {
            return Ok(await Mediator.Send(new GetSigleItemQuery { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItem()
        {
            return Ok(await Mediator.Send(new GetAllItemQuery { }));
        }
        #endregion

        #region Commands
        [HttpPost]
        public async Task<IActionResult> CreateItem(CreateItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, UpdateItemCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(int id, int tipo)
        {
            return Ok(await Mediator.Send(new DeleteItemCommand { Id = id, Tipo = tipo }));
        }
        #endregion
    }
}
