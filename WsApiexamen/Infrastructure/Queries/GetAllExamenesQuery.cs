using MediatR;
using WsApiexamen.Application.DTOs;

namespace WsApiexamen.Infrastructure.Queries
{
    public record GetAllExamenesQuery : IRequest<IEnumerable<ExamenDto>>;
}
