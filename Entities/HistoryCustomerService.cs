public class HistoryCustomerService : BaseEntity
{
    public int HistoryCustomerServiceId { get; set; }
    
    public int CustomerServiceId { get; set; }
    public CustomerService CustomerService { get; set; }

    public string FromColumn { get; set; }
    public string ToColumn { get; set; }



}