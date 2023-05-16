using API.Apps.AdminApi.DTOs.ProductDTOs;
using API.Apps.ClientApi.DTOs.ProductDTOs;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Apps.ClientApi.Controllers
{
    [ApiExplorerSettings(GroupName = "user_v1")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public ProductsController(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult GetAll(ProductGetAllDTO prAll)
        {
            var datas = _context.Products.Include(x=>x.Brand).ToList();

            var dtos = _mapper.Map<List<CProductGetAllDTO>>(datas);

            //List<CProductGetAllDTO> products = datas.Select(x => new CProductGetAllDTO
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    BrandName = x.Brand.Name,
            //    SalePrice = x.SalePrice,
            //    DiscountedPrice = (x.SalePrice - (x.SalePrice * x.DiscountPercent) / 100),

            //}).ToList();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.Products.Include(x=>x.Brand).FirstOrDefault(x=>x.Id==id);

            if (data == null) return NotFound();

            var dto = _mapper.Map<CProductGetDTO>(data);
            //CProductGetDTO getDTO = new()
            //{
            //    Name = data.Name,
            //    SalePrice = data.SalePrice,
            //    DiscountPercent=data.DiscountPercent,
            //    DiscountedPrice= (data.SalePrice - (data.SalePrice * data.DiscountPercent) / 100),
            //    Brand=new BrandInProductGetDto
            //    {
            //        Id=data.Brand.Id,
            //        Name=data.Brand.Name
            //    }

            //};

            return Ok(dto);
        }
    }
}
