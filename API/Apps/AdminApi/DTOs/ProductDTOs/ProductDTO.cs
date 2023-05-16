using FluentValidation;

namespace API.Apps.AdminApi.DTOs.ProductDTOs
{
    public class ProductDTO
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }

        
    }

    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(x => x.Name).MinimumLength(5).MaximumLength(20);
            RuleFor(x => x.CostPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.SalePrice).GreaterThan(x => x.CostPrice);
            RuleFor(x => x.DiscountPercent).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
            RuleFor(x => x).Custom((x, context) =>
            {
                if ((x.SalePrice * (100 - x.DiscountPercent) / 100) < x.CostPrice)
                {
                    context.AddFailure(nameof(ProductDTO.DiscountPercent), "Discount percent must be less than this");
                }
            });
        }
    }
}
