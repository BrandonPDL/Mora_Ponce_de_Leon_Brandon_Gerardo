using MediatR;
using WsApiexamen.Infrastructure;
using WsApiexamen.Infrastructure.Commands;

namespace WsApiexamen.Application.Handlers
{
    public class DeleteExamenHandler :IRequestHandler<DeleteExamenCommand,bool>
    {
        private readonly ApplicationDbContext _dbContext;
        public DeleteExamenHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteExamenCommand request, CancellationToken cancellationToken)
        {
            var examen = await _dbContext.tblExamen.FindAsync(
                    new object[] { request.idExamen }, cancellationToken);
            if (examen == null)
            {
                return false;
            }

            _dbContext.tblExamen.Remove(examen);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
