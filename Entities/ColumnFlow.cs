using System.ComponentModel.DataAnnotations;

public class ColumnFlow : BaseEntity
{

    public int ColumnFlowId { get; set; }

    public int Order { get; set; }

    [Required]
    public string Title { get; set; }

    public ApplicationUser User { get; set; }

    public ICollection<CustomerService> customerServices{ get; set; } = new List<CustomerService>();

}