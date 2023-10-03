using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Tag : BaseEntity
{
    public int TagId { get; set; }

    [Required]
    public string Text { get; set; }

    [Required]
    public string Color { get; set; }


    [ForeignKey("ApplicationUser")]
    public string ApplicationUserId { get; set; } = null;
    public ApplicationUser ApplicationUser { get; set; } = null;

}