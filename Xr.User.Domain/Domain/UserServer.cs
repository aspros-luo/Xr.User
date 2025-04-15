using Aspros.Base.Framework.Domain;

namespace Xr.User.Domain
{
    public class UserServer : BasicEntity
    {
        public long Id { get; protected set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; protected set; }
        /// <summary>
        /// 是否认证
        /// </summary>
        public long HasAudit { get; protected set; }
        /// <summary>
        /// 评分
        /// </summary>
        public float RatePoint { get; protected set; } = 0;

        public virtual User? User { get; protected set; }
    }
}
