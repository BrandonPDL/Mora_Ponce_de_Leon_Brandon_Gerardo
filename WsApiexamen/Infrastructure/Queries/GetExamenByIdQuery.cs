using MediatR;
using WsApiexamen.Application.DTOs;

namespace WsApiexamen.Infrastructure.Queries
{
    public record GetExamenByIdQuery (int idExamen) :IRequest<ExamenDto>;
}
