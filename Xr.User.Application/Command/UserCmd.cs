using MediatR;

namespace Xr.Category.Application
{
    /// <summary>
    /// 新增用户
    /// </summary>
    public class UserAddCmd : IRequest<long>
    {
        
    }

    /// <summary>
    /// 修改用户
    /// </summary>
    public class UserModifyCmd : IRequest<bool>
    {
        
    }
}
