using AuctionAPI.Services;
using AuctionAPI.WebInterface;
using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GetUserResponse>> GetAll()
        {
            var users = _userService.GetAll()
                .Select(e => e.ToGetUserResponse())
                .ToList();
            
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<GetUserResponse> GetById(int id)
        {
            var user = _userService.GetById(id);
            
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user.ToGetUserResponse());
        }

        [HttpPost]
        public CreateUserResponse Create([FromBody] CreateUserRequest request)
        {
            var user = _userService.Create(request.ToUser());
            return user.ToCreateUserResponse();
        }

        [HttpPut("{id}")]
        public UpdateUserResponse Update(int id, [FromBody] UpdateUserRequest request)
        {
            var user = _userService.Update(request.ToUser(id));
            return user.ToUpdateUserResponse();
        }

        [HttpDelete("{id}")]
        public DeleteUserResponse Delete(int id)
        {
            _userService.Delete(id);
            return DeleteUserResponse.SuccessResponse();
        }
    }
}
