using System.Data.Common;
using System.Security.Claims;
using appflow.Contexts;
using appflow.DTOs;
using appflow.Formatters;
using appflow.Repository;
using appflow.Repository.interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace appflow.Controllers;



[ApiController]
[Authorize]
[Route("api/[controller]")]
public class TagsController : ControllerBase
{
    private ApplicationDbContext _db;
    private UserManager<ApplicationUser> _userManager;
    private readonly ITagRepository _tagRepository;

    public TagsController(
        ApplicationDbContext dbContext,
        UserManager<ApplicationUser> userManager,
        ITagRepository tagRepository
        )
    {
        _db = dbContext;
        _userManager = userManager;
        _tagRepository = tagRepository;
    }

    [HttpGet]

    public Task<IActionResult> List()
    {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

        var tags = _tagRepository.GetUserTags(userId);

        return Task.FromResult<IActionResult>(Ok(tags));

    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TagDto body)
    {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

        ApplicationUser user = await _db.ApplicationUsers.FirstOrDefaultAsync(e => e.Id == userId);

        TagValidator tagValidator = new TagValidator(_db, userId);

        ValidationResult result = await tagValidator.ValidateAsync(body);


        if (!result.IsValid)
        {
            var errorsValidation = ResponseErrorValidator.createResponseObject(result);

            return BadRequest(new
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Bad Request",
                Errors = errorsValidation
            });
        }
        else
        {
            if (user is not null)
            {
                var tag = new Tag
                {
                    Text = body.Text,
                    Color = body.Color,
                };

                tag.ApplicationUser = user;
                _db.Add(tag);
                await _db.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, new
                {
                    tag.TagId,
                    tag.Text,
                    tag.Color
                });
            }

        }
        return BadRequest();

    }

    [HttpPut("{TagId}")]
    public async Task<IActionResult> Update([FromRoute] int TagId, [FromBody] TagDto body)
    {

        string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        TagValidator validator = new TagValidator(_db, userId);
        body.Id = TagId;

        ValidationResult result = await validator.ValidateAsync(body);

        if (result.IsValid)
        {
            _tagRepository.Update(TagId, body);

            return Ok(body);
        }
        else
        {
            var errorsValidation = ResponseErrorValidator.createResponseObject(result);

            return BadRequest(new
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Bad Request",
                Errors = errorsValidation
            });
        }


    }
}