using MediatR;
using WsApiexamen.Application.BD;
using WsApiexamen.Application.DTOs;
using WsApiexamen.Infrastructure.Queries;

namespace WsApiexamen.Application.Handlers
{
    public class GetExamenByIdHandler : IRequestHandler<GetExamenByIdQuery, ExamenDto>
    {
        private readonly IExamenRepository _examenRepository;

        public GetExamenByIdHandler(IExamenRepository examenRepository)
        {
            _examenRepository = examenRepository;
        }

        public async Task<ExamenDto> Handle(GetExamenByIdQuery request, CancellationToken cancellationToken)
        {
            var examen = await _examenRepository.GetExamenByIdAsync(request.idExamen);

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
