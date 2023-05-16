namespace API.Apps.AdminApi.DTOs.ProductDTOs
{
    public class ProductGetAllDTO
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountedPrice { get; set; }
    }

}
