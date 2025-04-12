using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Xr.User.Domain;

namespace Xr.User.Application
{
    public class UserDetailQueryHandler(IUserRepository userReporistory) : IRequestHandler<UserDetailQuery, UserDetailViewModel>
    {
        private readonly IUserRepository _userReporistory = userReporistory;

        public async Task<UserDetailViewModel> Handle(UserDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _userReporistory.QueryDetail(request.Id).FirstOrDefaultAsync();
            if (entity == null)  return new UserDetailViewModel();

            TypeAdapterConfig<User.Domain.User, UserDetailViewModel>.NewConfig().Map(d => d.Name, s => s.UserName + "maper");

            return entity.Adapt<UserDetailViewModel>();
        }
    }
}
