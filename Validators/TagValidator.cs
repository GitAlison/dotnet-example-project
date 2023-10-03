using appflow.Contexts;
using appflow.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

public class TagValidator : AbstractValidator<TagDto>
{
    private readonly ApplicationDbContext _db;
    private readonly string _userId;
    private string strRegexColor = @"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$";


    public TagValidator(ApplicationDbContext db, string userId)
    {
        _db = db;
        _userId = userId;

        RuleFor(x => x).MustAsync(UniqueTextByUser).OverridePropertyName("text").WithMessage("Voce já possui uma tag com este nome.");
        RuleFor(x => x.Color).NotEmpty().Matches(strRegexColor).WithMessage("Deve ser uma cor em Hexadecimal.");

    }

    private async Task<bool> UniqueTextByUser(TagDto tagObj, CancellationToken token)
    {
        bool hasError = false;
        if (tagObj.Id is not null)
        {
            var tag = await _db.Tags.FirstOrDefaultAsync(x => x.Text.ToLower() == tagObj.Text.ToLower() && x.ApplicationUser.Id == _userId && x.TagId != tagObj.Id);
            if (tag is null) hasError = true;
        }
        else
        {
            var tag = await _db.Tags.FirstOrDefaultAsync(x => x.Text.ToLower() == tagObj.Text.ToLower() && x.ApplicationUser.Id == _userId);

            if (tag is null) hasError = true;
            return false;
        }

        return hasError;

    }


}