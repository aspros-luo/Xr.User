using Aspros.Base.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xr.User.Domain.Domain;

namespace Xr.User.Domain
{
    public class User : BasicEntity, IAggregateRoot
    {
        public long Id { get; protected set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; protected set; } = string.Empty;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; protected set; } = string.Empty;
        /// <summary>
        /// 用户类型
        /// </summary>
        public UserType Type { get; protected set; } = 0;
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; protected set; } = string.Empty;
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; protected set; } = string.Empty;
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNo { get; protected set; } = string.Empty;
        /// <summary>
        /// 是否实名认证
        /// </summary>
        public bool IsReal { get; protected set; } = false;
        /// <summary>
        /// 性别
        /// </summary>
        public SexType Sex { get; protected set; } = 0;
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime Birthday { get; protected set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; protected set; } = string.Empty;
        /// <summary>
        /// 手机号码
        /// </summary>
        public long Phone { get; protected set; }

        public virtual ICollection<UserFollow> UserFollows { get; protected set; }
        public virtual UserServer UserServer { get; protected set; }
        public virtual ICollection<UserOauth> UserOauths { get; protected set; }

        public User()
        {
            UserFollows = [];
            UserServer = new UserServer();
            UserOauths = [];
        }

    }
}
