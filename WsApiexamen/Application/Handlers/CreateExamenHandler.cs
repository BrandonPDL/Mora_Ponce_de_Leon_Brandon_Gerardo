using MediatR;
using WsApiexamen.Application.BD;
using WsApiexamen.Application.DTOs;
using WsApiexamen.Domain;
using WsApiexamen.Infrastructure.Commands;

namespace WsApiexamen.Application.Handlers
{
    public class CreateExamenHandler: IRequestHandler<CreateExamenCommand, ExamenCreateDto>
    {
        private readonly IExamenRepository _examenRepository;
        public CreateExamenHandler(IExamenRepository examenRepository)
        {
            _examenRepository = examenRepository;
        }
        public async Task<ExamenCreateDto> Handle(CreateExamenCommand request, CancellationToken cancellationToken)
        {
            using (var transaction = await _examenRepository.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var examen = new tblExamen
                    {
                        idExamen = request.idExamen,
                        Nombre = request.Nombre,
                        Descripcion = request.Descripcion
                    };

                    await _examenRepository.AddExamenAsync(examen);

                    // Si llegas hasta aquí sin excepciones, confirmas la transacción
                    await transaction.CommitAsync(cancellationToken);

                    return new ExamenCreateDto
                    {
                        Respuesta = true,
                        Descripcion = "Examen Agregado de manera exitosa"
                    };
                }
                catch (Exception ex)
                {
                    // Si hay un error, deshaces la transacción
                    await transaction.RollbackAsync(cancellationToken);
                    Console.WriteLine($"Error: {ex.Message}");

                    // Puedes elegir lanzar la excepción nuevamente o manejarla de alguna manera
                    return new ExamenCreateDto
                    {
                        Respuesta = false,
                        Descripcion = "No se agrego el examen"
                    };
                }
            }
        }
    }
}
