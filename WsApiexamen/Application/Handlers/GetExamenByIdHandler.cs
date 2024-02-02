using MediatR;
using WsApiexamen.Application.DTOs;
using WsApiexamen.Infrastructure;
using WsApiexamen.Infrastructure.Queries;

namespace WsApiexamen.Application.Handlers
{
    public class GetExamenByIdHandler : IRequestHandler<GetExamenByIdQuery, ExamenDto>
    {
        private readonly ApplicationDbContext _dbContext;
        public GetExamenByIdHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ExamenDto> Handle(GetExamenByIdQuery request, CancellationToken cancellationToken)
        {
            var examen = await _dbContext.tblExamen.FindAsync(
             new object[] { request.idExamen }, cancellationToken);
            if (examen == null)
            {
                return null;
            }

            return new ExamenDto
            {
                idExamen = examen.idExamen,
                Nombre = examen.Nombre,
                Descripcion = examen.Descripcion
            };
        }
    }
}
