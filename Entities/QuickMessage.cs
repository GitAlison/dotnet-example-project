using System.ComponentModel.DataAnnotations;

public class QuickMessage : BaseEntity
{

    public int QuickMessageId { get; set; }

    [Required]
    public string Text { get; set; }

    public int UserId { get; set; }

    public User User { get; set; }
}