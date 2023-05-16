using FluentValidation;

namespace API.Apps.AdminApi.DTOs.BrandDTOs
{
    public class BrandDTO
    {
        public string Name { get; set; }
    }

    public class BrandDTOValidator : AbstractValidator<BrandDTO>
    {
        public BrandDTOValidator()
        {
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Name can not be less than 5");

        }
    }
}

