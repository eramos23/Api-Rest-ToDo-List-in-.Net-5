using Application.Features.Commands.ListaCommand;
using Application.Features.Queries.Lista;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ServiceApp.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ListaController : BaseApiController
    {
        #region Queries
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleList(int id)
        {
            return Ok(await Mediator.Send(new GetSigleListaQuery { Id = id }));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllList()
        {
            return Ok(await Mediator.Send(new GetAllListaQuery { }));
        }

        [HttpGet("GetSearch")]
        public async Task<IActionResult> GetSearch(string texto)
        {
            return Ok(await Mediator.Send(new GetSearchQuery { Texto = texto }));
        }

        [HttpGet("GetPagination")]
        public async Task<IActionResult> GetPagination(int pagina, int tamanioPagina)
        {
            return Ok(await Mediator.Send(new GetPaginationQuery { Pagina = pagina, TamanioPagina = tamanioPagina }));
        }
        #endregion

        #region Commands
        [HttpPost]
        public async Task<IActionResult> CreateList(CreateListaCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateList(int id, UpdateListaCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteList(int id, int tipo)
        {
            return Ok(await Mediator.Send(new DeleteListaCommand { Id = id, Tipo = tipo}));
        }
        #endregion
    }
}
