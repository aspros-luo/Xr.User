using Aspros.Base.Framework.Infrastructure;
using MediatR;
using Xr.User.Domain;

namespace Xr.Category.Application.Command
{
    public class UserAddCmdHandler(IUserRepository userReporistory, IUnitOfWork unitOfWork) : IRequestHandler<UserAddCmd, long>
    {
        private readonly IUserRepository _userRepository = userReporistory;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<long> Handle(UserAddCmd request, CancellationToken cancellationToken)
        {
            
            return 0L;
        }
    }
}
