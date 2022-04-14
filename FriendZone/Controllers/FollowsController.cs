using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using FriendZone.Models;
using FriendZone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriendZone.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class FollowsController : ControllerBase
    {
        private readonly FollowsService _fs;
        private readonly AccountService _as;

        public FollowsController(FollowsService fs, AccountService @as)
        {
            _fs = fs;
            _as = @as;
        }

        [HttpPost]
        public async Task<ActionResult<Follow>> Create([FromBody] Follow followData)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                followData.FollowerId = userInfo.Id;
                Follow created = _fs.Create(followData);
                return Ok(created);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}