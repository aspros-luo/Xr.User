using Aspros.Base.Framework.Infrastructure;
using MediatR;
using Xr.User.Domain;

namespace Xr.Category.Application.Command
{
    public class UserModifyCmdHandler(IUserRepository userReporistory, IUnitOfWork unitOfWork) : IRequestHandler<UserModifyCmd, bool>
    {
        private readonly IUserRepository _userReporistory = userReporistory;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> Handle(UserModifyCmd request, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}
