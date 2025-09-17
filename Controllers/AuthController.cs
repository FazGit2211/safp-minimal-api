using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserService userService;
    private readonly AuthService authService;
    public AuthController(UserService service, AuthService auth)
    {
        userService = service;
        authService = auth;
    }
    [HttpPost("api/login")]
    [EnableCors]
    public async Task<ActionResult> Login([FromBody] User user)
    {
        try
        {
            var userExist = await userService.GetUser(user);
            if (userExist is null)
            {
                return NotFound();
            }
            var token = authService.GenerateJwtTokens(user.username);
            return Ok(token);
        }
        catch (System.Exception)
        {

            throw;
        }
    }
    [HttpPost("api/signin")]
    [EnableCors]
    public async Task<ActionResult> SignIn([FromBody] User user)
    {
        try
        {
            var userCreated = await userService.PostUser(user);
            if (userCreated is null)
            {
                return BadRequest();
            }
            return Ok();
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}