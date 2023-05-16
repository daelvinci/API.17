namespace API.Apps.AdminApi.DTOs.ProductDTOs
{
    public class ProductGetDTO
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountedPrice { get; set; }




    }
}
