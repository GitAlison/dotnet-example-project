

public class CustomerService : BaseEntity
{

    public int CustomerServiceId { get; set; }

    public string Phone { get; set; }
    public string Protocol { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }



    public int ColumnFlowId { get; set; }
    public ColumnFlow ColumnFlow { get; set; }


    public ICollection<HistoryCustomerService> HistoryCustomerServices { get; } = new List<HistoryCustomerService>();

}