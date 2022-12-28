using KatmanliBlogSitesi.Data.Abstract;
using KatmanliBlogSitesi.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KatmanliBlogSitesi.Data.Concrete
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected DatabaseContext context;
        protected DbSet<T> dbSet; // veritabanı için boş generic dbset oluşturduk
        public Repository(DatabaseContext _context)
        {
            context = _context;
            dbSet = context.Set<T>(); // boş dbset i context içindeki ilgili class ın db seti için ayarladık
        }
        public int Add(T entity)
        {
            dbSet.Add(entity);
            return SaveChanges();
        }

        public async Task AddAsync(T entity)
        {
            //await context.AddAsync(entity);
            await dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
        }

        public T Find(int id)
        {
            return dbSet.Find(id);
        }

        public IQueryable<T> FindAllAsync(Expression<Func<T, bool>> expression)
        {
            return dbSet.Include(expression);
        }

        public async Task<T> FindAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await dbSet.FirstOrDefaultAsync(expression);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return dbSet.FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
            return dbSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return dbSet.Where(expression).ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await dbSet.Where(expression).ToListAsync();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            context.Update(entity);
        }
    }
}
