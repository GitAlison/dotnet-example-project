using System.Net;
using appflow.Contexts;
using appflow.DTOs;
using appflow.Formatters;
using appflow.Repository.interfaces;
using appflow.Services;
using appflow.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appflow.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ApplicationDbContext _db;

    private readonly IAccountService _accountService;
    private readonly ITagRepository _tagRepository;
    public AuthController(
        UserManager<ApplicationUser> userManager,
        ApplicationDbContext dbContext,
        IAccountService accountService,
        ITagRepository tagRepository
        )
    {
        _userManager = userManager;
        _db = dbContext;
        _accountService = accountService;
        _tagRepository = tagRepository;
    }


    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterDto register)
    {

        RegisterValidator registerValidator = new RegisterValidator();

        ValidationResult result = registerValidator.Validate(register);

        if (!result.IsValid)
        {
            return BadRequest(result);
        }

        ApplicationUser user = new ApplicationUser
        {
            UserName = register.Name,
            Email = register.Email
        };
        var userCreated = await _userManager.CreateAsync(user, register.Password);
        if (user == null)
        {
            return BadRequest(userCreated);
        }

        object token = _accountService.GenerateToken(user);
        return Ok(token);

    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginDto login)
    {

        LoginValidator loginValidator = new LoginValidator();
        ValidationResult result = loginValidator.Validate(login);

        var errorsValidation = ResponseErrorValidator.createResponseObject(result);

        if (!result.IsValid)
        {
            return BadRequest(new
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = "Bad Request",
                Errors = errorsValidation
            });
        }


        ApplicationUser user = await _db.ApplicationUsers.SingleOrDefaultAsync(i => i.Email == login.Email);

        var passwordOk = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, login.Password);

        if (passwordOk != PasswordVerificationResult.Success)
        {
            List<string> errors = new List<string>(){
                "Usuario ou senhas invalidas."
            };

            return BadRequest(new
            {
                Errors = errors
            });
        }
        else
        {
            object token = _accountService.GenerateToken(user);

            _tagRepository.CreateUserDefaultTags(user.Id);

            return Ok(token);
        }


    }
}
