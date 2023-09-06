

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

public class HistoryCustomerService : BaseEntity
{
    public int HistoryCustomerServiceId { get; set; }
    
    public int CustomerServiceId { get; set; }
    public CustomerService CustomerService { get; set; }

    public string FromColumn { get; set; }
    public string ToColumn { get; set; }



}