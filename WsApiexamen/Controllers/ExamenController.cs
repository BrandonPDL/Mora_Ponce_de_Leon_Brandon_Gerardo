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
        public async Task<ActionResult<ExamenDto>> Create(CreateExamenCommand command)
        {
            var examen = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById),new { idExamen = examen.idExamen },examen);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> update(int id, UpdateExamenCommand command)
        {
            if(id!= command.idExamen)
            {
                return BadRequest();
            }
            var result = await _mediator.Send(command);
            if(result == false)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteExamenCommand(id));
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
