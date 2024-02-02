using Microsoft.EntityFrameworkCore.Storage;
using WsApiexamen.Domain;

namespace WsApiexamen.Application.BD
{
    public interface IExamenRepository
    {
        Task<tblExamen> AddExamenAsync(tblExamen examen);
        Task<bool> DeleteExamenAsync(int idExamen);
        Task<IEnumerable<tblExamen>> GetAllExamenesAsync();
        Task<tblExamen> GetExamenByIdAsync(int idExamen);
        Task<bool> UpdateExamenAsync(tblExamen examen);
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
