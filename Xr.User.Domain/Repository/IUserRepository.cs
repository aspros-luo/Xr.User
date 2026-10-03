using Aspros.Base.Framework.Domain;

namespace Xr.User.Domain
{
    public interface IUserRepository: IRepository<User>
    {
        IQueryable<User> QueryDetail(long id);
    }
}
