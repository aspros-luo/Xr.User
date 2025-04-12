using System.ComponentModel;

namespace Xr.User.Domain
{
    public enum UserType
    {
        /// <summary>
        /// 管理员
        /// </summary>
        [Description("管理员")]
        Admin = 1,
        /// <summary>
        /// 客户
        /// </summary>
        [Description("客户")]
        Customer = 2,
        /// <summary>
        /// 摄影师
        /// </summary>
        [Description("摄影师")]
        Photographer = 3,
        /// <summary>
        /// 化妆师
        /// </summary>
        [Description("化妆师")]
        Makeuper = 4,
    }
}
