using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeLogger.AppService.Contract;
using TimeLogger.AppService.Contract.User;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IJwtService _jwtService;

        public UserController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }
        [HttpGet("[action]")]
        public async Task<string> Token(string username, string password, CancellationToken cancellationToken)
        {
            var user = new UserView
                {
                    Id = 1,
                    UserName = "MehranLabour"
                };
            var jwt = _jwtService.Generate(user);
            return jwt;

        }
    }
}