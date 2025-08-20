using Aspros.Base.Framework.Domain;
using Xr.User.Domain.ValueObjects;

namespace Xr.User.Domain.Domain
{
    public class UserOauth : BasicEntity
    {
        public long Id { get; set; }
        public long UserId { get; private set; }
        public PlatformType Plateform { get; private set; } = 0;
        public string ValueId { get; private set; } = string.Empty;

        public virtual User User { get; private set; }

        public UserOauth()
        {

        }

        public UserOauth(long userId, PlatformType plateform, string valueId)
        {
            UserId = userId;
            Plateform = plateform;
            ValueId = valueId;
        }
    }
}
