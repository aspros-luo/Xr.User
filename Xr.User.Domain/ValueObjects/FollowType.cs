using System.ComponentModel;

namespace Xr.User.Domain
{
    public enum FollowType
    {
        /// <summary>
        /// 文章
        /// </summary>
        [Description("文章")]
        Article = 1,
        /// <summary>
        /// 商品
        /// </summary>
        [Description("商品")]
        Item = 2,
        /// <summary>
        /// 人
        /// </summary>
        [Description("人")]
        Person = 3,
    }
}
