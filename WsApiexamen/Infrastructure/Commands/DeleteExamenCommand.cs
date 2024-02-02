using MediatR;

namespace WsApiexamen.Infrastructure.Commands
{
    public record DeleteExamenCommand(int idExamen):IRequest<bool>;
}
