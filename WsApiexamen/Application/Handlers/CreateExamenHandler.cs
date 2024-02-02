using MediatR;
using WsApiexamen.Application.DTOs;
using WsApiexamen.Domain;
using WsApiexamen.Infrastructure;
using WsApiexamen.Infrastructure.Commands;

namespace WsApiexamen.Application.Handlers
{
    public class CreateExamenHandler
        : IRequestHandler<CreateExamenCommand, ExamenDto>
    {
        private readonly ApplicationDbContext _dbContext;
        public CreateExamenHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ExamenDto> Handle(CreateExamenCommand request, CancellationToken cancellationToken)
        {
            var examen = new tblExamen
            {
                idExamen = request.idExamen,
                Nombre = request.Nombre,
                Descripcion = request.Descripcion
            };
            _dbContext.tblExamen.Add(examen);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new ExamenDto
            {
                idExamen = examen.idExamen,
                Nombre = examen.Nombre,
                Descripcion = examen.Descripcion
            };
        }
    }
}
