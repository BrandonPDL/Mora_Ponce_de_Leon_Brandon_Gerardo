using MediatR;
using Microsoft.EntityFrameworkCore;
using WsApiexamen.Application.BD;
using WsApiexamen.Application.DTOs;
using WsApiexamen.Infrastructure.Commands;
using WsApiexamen.Infrastructure.Queries;

namespace WsApiexamen.Application.Handlers
{
    public class GetAllExamenesHandler : IRequestHandler<GetAllExamenesQuery, IEnumerable<ExamenDto>>
    {
        private readonly IExamenRepository _examenRepository;

        public GetAllExamenesHandler(IExamenRepository examenRepository)
        {
            _examenRepository = examenRepository;
        }

        public async Task<IEnumerable<ExamenDto>> Handle(GetAllExamenesQuery request, CancellationToken cancellationToken)
        {
            var examenes = await _examenRepository.GetAllExamenesAsync();

            return examenes.Select(examen => new ExamenDto
            {
                idExamen = examen.idExamen,
                Nombre = examen.Nombre,
                Descripcion = examen.Descripcion ?? "Sin descripción"
            });
        }
    }
}
