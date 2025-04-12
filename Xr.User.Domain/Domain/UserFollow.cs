using Aspros.Base.Framework.Domain;

namespace Xr.User.Domain
{
    public class UserFollow : BasicEntity, IAggregateRoot
    {
        public long Id { get; protected set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public long UserId { get; protected set; }
        /// <summary>
        /// 关注类型
        /// </summary>
        public FollowType Type { get; protected set; }
        /// <summary>
        /// 被关注Id
        /// </summary>
        public long ValueId { get; protected set; }
        /// <summary>
        /// 关注时间
        /// </summary>
        public DateTime FollowTime { get; protected set; } = DateTime.Now;
        
        public virtual User? User { get; protected set; }
    }
}
