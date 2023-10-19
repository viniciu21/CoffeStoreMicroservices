
using Products.Infra.Data.UoW.Interfaces;

namespace Products.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ProductsDbContext _context;

        public UnitOfWork(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            int _changesNumber = await _context.SaveChangesAsync();
            return _changesNumber > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

