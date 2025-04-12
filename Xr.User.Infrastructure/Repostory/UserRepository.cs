using Aspros.Base.Framework.Domain;
using Aspros.Base.Framework.Infrastructure;
using Xr.User.Domain;

namespace Xr.User.Infrastructure.Repostory
{
    public class UserRepository : BaseRepository<User.Domain.User>, IUserRepository
    {
        private readonly IQueryable<User.Domain.User> _users;
        public UserRepository(IDbContext dbContext) : base(dbContext)
        {
            _users = Entities;
        }

        public IQueryable<Domain.User> QueryDetail(long id)
        {
            return _users.Where(x => x.Id == id);
        }
    }
}
