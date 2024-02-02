using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WsApiexamen.Application.DTOs;
using WsApiexamen.Infrastructure.Commands;
using WsApiexamen.Infrastructure.Queries;

namespace WsApiexamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExamenController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<ExamenDto>> GetAll()
        {
            return await _mediator.Send(new GetAllExamenesQuery());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ExamenDto>> GetById(int id)
        {
            var query = new GetExamenByIdQuery(id);
            var examen = await _mediator.Send(query);
            if(examen == null){
                return NotFound();
            }
            return examen;
        }
        [HttpPost]
        public async Task<ActionResult<ExamenCreateDto>> Create(CreateExamenCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> update(int id, UpdateExamenCommand command)
        {
            if(id!= command.idExamen)
            {
                return BadRequest(false);
            }
            var result = await _mediator.Send(command);
            if(result == false)
            {
                return NotFound(false);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteExamenCommand(id));
            if (!result)
            {
                return NotFound(false);
            }
            return result;
        }
    }
}
