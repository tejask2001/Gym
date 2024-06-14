using CodingChallenge.Models;
using Gym.Interfaces;
using Gym.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMemberService _memberService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService,IMemberService memberService, ILogger<UserController> logger)
        {
            _userService = userService;
            _memberService = memberService;
            _logger = logger;

        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUser()
        {
            try
            {
                var users = await _userService.GetAllUser();
                return users;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<ActionResult<User>> AddUser(User user)
        {
            try
            {
                return await _userService.AddUser(user);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddMember")]
        public async Task<ActionResult<Member>> AddMember(AddMemberDTO memberDTO)
        {
            try
            {
                User user = new User();
                user.UserName = memberDTO.UserName;
                user.Email = memberDTO.Email;
                user.Password = memberDTO.Password;
                user.isAdmin=memberDTO.isAdmin;

                var users = await _userService.AddUser(user);

                Member member = new Member();
                member.Name = memberDTO.Name;
                member.Email = memberDTO.Email;
                member.Phone = memberDTO.Phone;
                member.MembershipExpiry = memberDTO.MembershipExpiry;
                member.DateOfJoining = memberDTO.DateOfJoining;
                member.UserId = users.UserId;

                return await _memberService.AddMember(member);

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            try
            {
                return await _userService.UpdateUser(user);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteUser(User user)
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
