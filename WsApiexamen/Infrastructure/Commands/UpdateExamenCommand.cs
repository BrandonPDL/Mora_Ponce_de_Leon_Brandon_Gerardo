using MediatR;
using WsApiexamen.Application.DTOs;

namespace WsApiexamen.Infrastructure.Commands
{
    public record UpdateExamenCommand(int idExamen, string Nombre, string Descripcion) : IRequest<bool>;
}
