using CodingChallenge.Models;
using Gym.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMemberService _memberService;
        private readonly ILogger<MemberController> _logger;

        public MemberController(IUserService userService, IMemberService memberService, ILogger<MemberController> logger)
        {
            _userService = userService;
            _memberService = memberService;
            _logger = logger;

        }

        [HttpGet]
        public async Task<ActionResult<List<Member>>> GetAllMember()
        {
            try
            {
                var members = await _memberService.GetAllMember();
                return members;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Member>> UpdateMember(Member member)
        {
            try
            {
                return await _memberService.UpdateMember(member);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteMember(User user)
        {
            try
            {
                bool users = await _userService.RemoveUser(user);
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }
    }
}
