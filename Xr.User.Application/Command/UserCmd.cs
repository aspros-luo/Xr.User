using MediatR;
using Xr.User.Domain;

namespace Xr.Category.Application
{
    /// <summary>
    /// 用户名密码注册用户
    /// </summary>
    public class UserRegisterByPasswordCmd : IRequest<long>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public required string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public required string Password { get; set; }
    }

    /// <summary>
    /// 手机号注册用户
    /// </summary>
    public class UserRegisterByPhoneCmd : IRequest<long>
    {
        /// <summary>
        /// 手机号
        /// </summary>
        public required string Phone { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public required string Code { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType Type { get; set; }
    }

    /// <summary>
    /// 修改用户
    /// </summary>
    public class UserModifyCmd : IRequest<bool>
    {
        
    }
}
