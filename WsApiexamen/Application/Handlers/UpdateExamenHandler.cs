using MediatR;
using WsApiexamen.Application.DTOs;
using WsApiexamen.Infrastructure.Commands;
using WsApiexamen.Application.BD;

namespace WsApiexamen.Application.Handlers
{
    public class UpdateExamenHandler : IRequestHandler<UpdateExamenCommand, bool>
    {
        private readonly IExamenRepository _examenRepository;

        public UpdateExamenHandler(IExamenRepository examenRepository)
        {
            _examenRepository = examenRepository;
        }

        public async Task<bool> Handle(UpdateExamenCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _examenRepository.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var examen = await _examenRepository.GetExamenByIdAsync(request.idExamen);

                    if (examen == null)
                    {
                        await transaction.RollbackAsync(cancellationToken);
                        return false;
                    }

                    examen.Nombre = request.Nombre;
                    examen.Descripcion = request.Descripcion;

                    await _examenRepository.UpdateExamenAsync(examen);
                    await transaction.CommitAsync(cancellationToken);

                    return true;
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
