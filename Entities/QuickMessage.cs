using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class QuickMessage : BaseEntity
{

    public int QuickMessageId { get; set; }

    [Required]
    public string Text { get; set; }

    [ForeignKey("ApplicationUser")]
    public string ApplicationUserId { get; set; } = null;
    public ApplicationUser ApplicationUser { get; set; }
}