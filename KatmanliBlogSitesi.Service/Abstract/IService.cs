using KatmanliBlogSitesi.Data.Abstract;
using KatmanliBlogSitesi.Entites;

namespace KatmanliBlogSitesi.Service.Abstract
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()
    {
    }
}
