using System.Collections.Generic;

namespace OnlineRoulette.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void SetObjectAsync(string id, TEntity objectToCache);
        TEntity GetObjectAsync(string id);
        List<TEntity> GetAllObjects();
    }
}
