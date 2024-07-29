using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ColumnFlow : BaseEntity
{

    public int ColumnFlowId { get; set; }

    public int Order { get; set; }

    [Required]
    public string Title { get; set; }


    [ForeignKey("ApplicationUser")]
    public string ApplicationUserId { get; set; } = null;
    public ApplicationUser User { get; set; }

    public ICollection<CustomerService> customerServices{ get; set; } = new List<CustomerService>();

}