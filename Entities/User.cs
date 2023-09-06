using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


// public class AppFlowDbContext : DbContext
// {
//     public DbSet<>
// }




public class User : BaseEntity
{
    public int UserId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Phone { get; set; }

    [Required]
    public string Password { get; set; }

    [DefaultValue(false)]
    public bool isOwner { get; set; }

    public ICollection<Tag> Tags { get; } = new List<Tag>();

    public ICollection<QuickMessage> QuickMessages { get; } = new List<QuickMessage>();

}
