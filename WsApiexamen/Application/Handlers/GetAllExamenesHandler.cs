using MediatR;
using Microsoft.EntityFrameworkCore;
using WsApiexamen.Application.DTOs;
using WsApiexamen.Infrastructure;
using WsApiexamen.Infrastructure.Commands;
using WsApiexamen.Infrastructure.Queries;

namespace WsApiexamen.Application.Handlers
{
    public class GetAllExamenesHandler : IRequestHandler<GetAllExamenesQuery, IEnumerable<ExamenDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetAllExamenesHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ExamenDto>> Handle(GetAllExamenesQuery request, CancellationToken cancellationToken)
        {
            var examenes = await _dbContext.tblExamen.ToListAsync(cancellationToken);

            return examenes.Select(examen => new ExamenDto
            {
                idExamen = examen.idExamen,
                Nombre = examen.Nombre,
                Descripcion = examen.Descripcion ?? "Sin descripción"
            });
        }
    }
}
