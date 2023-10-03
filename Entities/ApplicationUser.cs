using Microsoft.AspNetCore.Identity;


public class ApplicationUser : IdentityUser
{
    public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
    public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    public virtual ICollection<IdentityUserToken<string>> Tokens { get; set; }
    public virtual ICollection<IdentityUserRole<string>> UserRoles { get; set; }

    public virtual ICollection<Tag> Tags { get; } = new List<Tag>();

    public virtual ICollection<QuickMessage> QuickMessages { get; } = new List<QuickMessage>();

}
