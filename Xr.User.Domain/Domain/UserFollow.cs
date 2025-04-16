using Aspros.Base.Framework.Domain;

namespace Xr.User.Domain
{
    public class UserFollow : BasicEntity
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

        public UserFollow() { }

        public UserFollow(long userId, FollowType type, long valueId)
        {
            UserId = userId;
            Type = type;
            ValueId = valueId;
        }

        /// <summary>
        /// 取消关注
        /// </summary>
        public void UnFollow()
        {
            // 取消关注
            Status = Status.Deleted;
        }

        /// <summary>
        /// 关注
        /// </summary>
        public void Follow()
        {
            // 关注
            Status = Status.Normal;
            FollowTime = DateTime.Now;
        }
    }
}
