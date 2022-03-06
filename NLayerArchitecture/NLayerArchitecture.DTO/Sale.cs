namespace NLayerArchitecture.DTO
{
    public class Sale : IEntity
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string Country { get; set; }
        public DateTime DateSale { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public List<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    }
}