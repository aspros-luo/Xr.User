using Aspros.Base.Framework.Domain;
using Aspros.Base.Framework.Infrastructure;

namespace Xr.User.Domain
{
    public interface IUserRepository: IRepository<User>, ITransient
    {
        IQueryable<User> QueryDetail(long id);
    }
}
