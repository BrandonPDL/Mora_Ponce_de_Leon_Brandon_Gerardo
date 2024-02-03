using MediatR;
using WsApiexamen.Application.BD;
using WsApiexamen.Infrastructure.Commands;

namespace WsApiexamen.Application.Handlers
{
    public class DeleteExamenHandler : IRequestHandler<DeleteExamenCommand, bool>
    {
        private readonly IExamenRepository _examenRepository;

        public DeleteExamenHandler(IExamenRepository examenRepository)
        {
            _examenRepository = examenRepository;
        }

        public async Task<bool> Handle(DeleteExamenCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _examenRepository.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var result = await _examenRepository.DeleteExamenAsync(request.idExamen);

                    if (result)
                    {
                        await transaction.CommitAsync(cancellationToken);
                    }
                    else
                    {
                        await transaction.RollbackAsync(cancellationToken);
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync(cancellationToken);
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
