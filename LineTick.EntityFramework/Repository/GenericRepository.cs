using LineTick.EntityFramework.Entityes;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LineTick.EntityFramework
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public IQueryable<TEntity> All { get; }

        private DbSet<TEntity> Table => _applicationDbContext.Set<TEntity>();
        private readonly ApplicationDbContext _applicationDbContext;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            All = Table;
        }

        public TEntity GetItem(int id) => Table.Find(id);

        public TEntity Save(TEntity item)
        {
            TEntity savedEntity = item.Id == 0
                ? Table.Add(item).Entity
                : Table.Update(item).Entity;

            _applicationDbContext.SaveChanges();

            return savedEntity;
        }

        public void Delete(TEntity item)
        {
            var entity = Table.Find(item);
            if (entity != null)
            {
                Table.Remove(entity);
                _applicationDbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var entity = Table.Find(id);
            if (entity != null)
            {
                Table.Remove(entity);
                _applicationDbContext.SaveChanges();
            }
        }
    }
}
