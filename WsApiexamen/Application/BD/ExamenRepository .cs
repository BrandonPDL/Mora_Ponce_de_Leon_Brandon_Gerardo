using Microsoft.EntityFrameworkCore.Storage;
using WsApiexamen.Domain;

namespace WsApiexamen.Application.BD
{
    // ExamenRepository.cs
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage;

    public class ExamenRepository : IExamenRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private IDbContextTransaction _transaction;

        public ExamenRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<tblExamen> AddExamenAsync(tblExamen examen)
        {
            _dbContext.tblExamen.Add(examen);
            await _dbContext.SaveChangesAsync();
            return examen;
        }

        public async Task<bool> DeleteExamenAsync(int idExamen)
        {
            var examen = await _dbContext.tblExamen.FindAsync(idExamen);
            if (examen == null)
            {
                return false;
            }

            _dbContext.tblExamen.Remove(examen);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<tblExamen>> GetAllExamenesAsync()
        {
            return await _dbContext.tblExamen.ToListAsync();
        }

        public async Task<tblExamen> GetExamenByIdAsync(int idExamen)
        {
            return await _dbContext.tblExamen.FindAsync(idExamen);
        }

        public async Task<bool> UpdateExamenAsync(tblExamen examen)
        {
            // Puedes validar aquí si el examen existe antes de intentar actualizarlo
            _dbContext.Entry(examen).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync();
            return _transaction;
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            return _transaction;
        }
        public async Task CommitTransactionAsync()
        {
            await _transaction.CommitAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction.RollbackAsync();
        }
    }
}
