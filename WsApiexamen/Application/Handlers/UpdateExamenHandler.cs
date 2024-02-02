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
                        // Si no se encuentra el examen, revertir la transacción
                        await transaction.RollbackAsync(cancellationToken);
                        return false;
                    }

                    examen.Nombre = request.Nombre;
                    examen.Descripcion = request.Descripcion;

                    await _examenRepository.UpdateExamenAsync(examen);

                    // Confirmar la transacción si la actualización se realizó correctamente
                    await transaction.CommitAsync(cancellationToken);

                    return true;
                }
                catch (Exception ex)
                {
                    // Si hay un error, deshacer la transacción y manejar la excepción
                    await transaction.RollbackAsync(cancellationToken);
                    Console.WriteLine($"Error: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
