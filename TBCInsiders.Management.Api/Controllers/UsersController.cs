using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TBCInsiders.Management.ApplicationCore.Interfaces.Services;
using TBCInsiders.Management.ApplicationCore.Models.ConnectedUser;
using TBCInsiders.Management.ApplicationCore.Models.PhoneNumber;
using TBCInsiders.Management.ApplicationCore.Models.User;

namespace TBCInsiders.Management.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPhoneNumberService _phoneService;
        private readonly IUserConnectionService _userConnectionService;
        private readonly IImageService _imageService;
        public UsersController(IUserService service, IPhoneNumberService phoneService, IUserConnectionService userConnectionService, IImageService imageService)
        {
            _userService = service;
            _phoneService = phoneService;
            _userConnectionService = userConnectionService;
            _imageService = imageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userService.GetUserAsync(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }


        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetUserDetails(int id)
        {
            var result = await _userService.GetUserDetailsAsync(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }


        [HttpGet("UserList")]
        public async Task<IActionResult> Filter(string firstName, string lastName, string personalNumber, int? pageIndex, int pageSize)
        {
            var result = await _userService.Filter(firstName, lastName, personalNumber, pageIndex, pageSize);

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(EditUserDto request, int id)
        {
            await _userService.UpdateUserAsync(request);
            return Ok();

        }


        [HttpPut("updatePhone")]
        public async Task<IActionResult> UpdatePhoneNumber(PhoneNumberDto phoneNumber)
        {
            await _phoneService.UpdateUsersPhoneNumberAsync(phoneNumber);
            return Ok();
        }

        [HttpPost("AddPhoneNumber")]
        public async Task<IActionResult> AddPhoneNumber(int userId, PhoneNumberDto phoneNumber)
        {
            await _phoneService.AddPhoneNumber(userId, phoneNumber);
            return Ok();
        }

        [HttpGet("{id}/ConnectionRepot")]
        public async Task<IActionResult> UserConnectionReport(int id)
        {

            var result = await _userService.GetReportAsync(id);

            return Ok(result);
        }

        [HttpPost("{Id}/AddConnection")]
        public async Task<IActionResult> AddConnection(int Id, ConnectedUserDto connectedUser)
        {
            await _userConnectionService.AddConnectedUser(Id, connectedUser);
            return Ok();
        }

        [HttpDelete("connection/remove{userConnectionId}")]
        public async Task<IActionResult> RemoveUserConnection(int userConnectionId)
        {
            await _userConnectionService.RemoveConnectionAsync(userConnectionId);
            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromForm]CreateUserDto request)
        {
            
            await _userService.AddUserAsync(request,request.image);

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
