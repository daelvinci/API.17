namespace API.Apps.ClientApi.DTOs.ProductDTOs
{
    public class CProductGetAllDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountedPrice { get; set; }
    }
}
