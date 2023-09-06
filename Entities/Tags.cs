using System.ComponentModel.DataAnnotations;

public class Tag : BaseEntity
{
    public int TagId { get; set; }

    [Required]
    public string Text { get; set; }

    [Required]
    public string Color { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null;

}