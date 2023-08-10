using PrimeTechApp.Interfaces.Base;

namespace PrimeTechApp.Repositories.Base
{
    public class BaseRepository<TEntity>:IBaseService<TEntity> where TEntity : class
    {
    }
}