using System.ComponentModel.DataAnnotations;

public class QuickMessage : BaseEntity
{

    public int QuickMessageId { get; set; }

    [Required]
    public string Text { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
}