namespace NLayerArchitecture.DTO
{
    public class SaleDetail : IEntity
    {
        public Guid Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
