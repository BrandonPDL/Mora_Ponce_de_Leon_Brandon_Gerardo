using MediatR;
using WsApiexamen.Application.DTOs;
using WsApiexamen.Infrastructure.Commands;
using WsApiexamen.Infrastructure;

namespace WsApiexamen.Application.Handlers
{
    public class UpdateExamenHandler
     : IRequestHandler<UpdateExamenCommand, bool>
    {
        private readonly ApplicationDbContext _dbContext;
        public UpdateExamenHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateExamenCommand request, CancellationToken cancellationToken)
        {
            var examen = await _dbContext.tblExamen.FindAsync(
                    new object[] { request.idExamen }, cancellationToken);
            if (examen == null)
            {
                return false;
            }
            examen.Nombre = request.Nombre;
            examen.Descripcion = request.Descripcion;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
