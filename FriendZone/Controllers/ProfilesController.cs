using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FriendZone.Models;
using FriendZone.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FriendZone.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly FollowsService _fs;
        private readonly AccountService _as;

        public ProfilesController(FollowsService fs, AccountService @as)
        {
            _fs = fs;
            _as = @as;
        }

        [HttpGet("{id}/follows")]
        public ActionResult<List<FollowViewModel>> GetProfileFollows(string id)
        {
            try
            {
                List<FollowViewModel> follows = _fs.GetProfileFollows(id);
                return Ok(follows);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}