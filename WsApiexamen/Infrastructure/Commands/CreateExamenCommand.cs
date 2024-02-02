using MediatR;
using WsApiexamen.Application.DTOs;

namespace WsApiexamen.Infrastructure.Commands
{
    public record CreateExamenCommand(int idExamen, string Nombre, string Descripcion) :IRequest<ExamenDto>;
}
