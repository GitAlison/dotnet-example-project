
using System.ComponentModel.DataAnnotations;

namespace appflow.DTOs;
public class TagDto
{

    public int? Id { get; set; }

    [Required]
    public string Text { get; set; }

    [Required]
    public string Color { get; set; }
}