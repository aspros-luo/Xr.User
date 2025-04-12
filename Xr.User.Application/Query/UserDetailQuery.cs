using MediatR;

namespace Xr.User.Application
{
    /// <summary>
    /// 用户查询
    /// </summary>
    public class UserDetailQuery : IRequest<UserDetailViewModel>
    {
        /// <summary>
        /// 用户查询
        /// </summary>
        public required long Id { get; set; }
    }
}
