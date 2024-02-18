namespace ECommerceWebUi.Models
{
    public class OrderConfirmationModel
    {
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
