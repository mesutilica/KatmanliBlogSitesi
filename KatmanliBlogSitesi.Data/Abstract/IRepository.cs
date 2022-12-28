using System.Linq.Expressions;

namespace KatmanliBlogSitesi.Data.Abstract
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll(); // veritabanındaki tüm kayıtları listeleyecek metot imzası
        List<T> GetAll(Expression<Func<T, bool>> expression); // GetAll metodunda entity frameworkteki x=>x. şeklinde yazdığımız lambda expression larınıkullanabilmek için
        T Get(Expression<Func<T, bool>> expression); // özel sorgu kullanarak 1 tane kayıt getiren metot imzası
        T Find(int id);
        int Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int SaveChanges();
        // Asenkron metotlar
        Task<T> FindAsync(int id);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> FindAllAsync(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
