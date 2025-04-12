
using Aspros.Base.Framework.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xr.Category.Application;
using Xr.User.Application;

namespace Xr.User.WebApi.Controllers
{
    /// <summary>
    /// 用户
    /// </summary>
    /// <param name="mediator"></param>
    [Tags("用户")]
    [ApiController]
    [Route("user")]
    public class UserController(IMediator mediator) : WebApiController
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("user.add")]
        public async Task<IActionResult> ActionCategoryAdd([FromBody] UserAddCmd cmd)
        {
            var result = await _mediator.Send(cmd);
            return Success(result);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut("user.modify")]
        public async Task<IActionResult> ActionCategoryModify([FromBody] UserModifyCmd cmd)
        {
            var result = await _mediator.Send(cmd);
            return Success(result);
        }

        /// <summary>
        /// 查看用户详情
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("user.detail.query")]
        public async Task<IActionResult> ActionCategoryDetailQuery([FromQuery] UserDetailQuery query)
        {
            var data = await _mediator.Send(query);
            return Success(data);
        }
    }
}
