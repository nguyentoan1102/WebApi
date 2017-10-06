using PingYourPackage.Domain.Entities.Extensions;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace PingYourPackage.Domain.Entities.Core
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class, IEntity, new()
    {
        readonly DbContext _entitiesContext;
        public EntityRepository(DbContext entitiesContext)
        {
            if (entitiesContext == null)
            {
                throw new ArgumentNullException(nameof(entitiesContext));
            }
            _entitiesContext = entitiesContext;

        }

        public virtual IQueryable<T> GetAll() => _entitiesContext.Set<T>();
        public virtual IQueryable<T> All => GetAll();

        public IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _entitiesContext.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) => _entitiesContext.Set<T>().Where(predicate);

        public T GetSingle(Guid key) => GetAll().FirstOrDefault(x => x.Key == key);

        public PaginatedList<T> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector) => Paginate(pageIndex, pageSize, keySelector, null);

        public PaginatedList<T> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AllIncluding(includeProperties).OrderBy(keySelector);
            query = (predicate == null)
            ? query
            : query.Where(predicate);
            return query.ToPaginatedList(pageIndex, pageSize);
        }

        public void Add(T entity)
        {
            DbEntityEntry dbentityentry = _entitiesContext.Entry<T>(entity);
            _entitiesContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = _entitiesContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public void Edit(T entity)
        {
            DbEntityEntry dbEntityEntry = _entitiesContext.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public void Save()
        {
            _entitiesContext.SaveChanges();
        }
    }
}