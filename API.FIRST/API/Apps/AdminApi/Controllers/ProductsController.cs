using API.Apps.AdminApi.DTOs.ProductDTOs;
using AutoMapper;
using Core.Entites;
using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Apps.AdminApi.Controllers
{
    [ApiExplorerSettings(GroupName = "admin_v1")]
    [Route("admin/api/[controller]")]
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
        public IActionResult GetAll()
        {
            var datas = _context.Products.ToList();
            List<ProductGetAllDTO> products = _mapper.Map<List<ProductGetAllDTO>>(datas);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _context.Products.Find(id);

            if (data == null) return NotFound();

            ProductGetDTO getDTO = _mapper.Map<ProductGetDTO>(data);

            return Ok(getDTO);
        }

        [HttpPost("")]
        public IActionResult Create(ProductDTO productDTO)
        {
            if(!_context.Brands.Any(x=>x.Id==productDTO.BrandId))
            {
                ModelState.AddModelError("BrandId", "This brand is not exist");
                return BadRequest(ModelState);
            }
            Product product = _mapper.Map<Product>(productDTO);
            _context.Products.Add(product);
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductDTO productDTO)
        {
            var existPr = _context.Products.Find(id);

            if (existPr == null) return NotFound();

            if ( existPr.BrandId!=productDTO.BrandId && !_context.Brands.Any(x => x.Id == productDTO.BrandId))
            {
                ModelState.AddModelError("BrandId", "This brand is not exist");
                return BadRequest(ModelState);
            }

            existPr.BrandId = productDTO.BrandId;
            existPr.Name = productDTO.Name;
            existPr.SalePrice = productDTO.SalePrice;
            existPr.CostPrice = productDTO.CostPrice;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existPr = _context.Products.Find(id);

            if (existPr == null) return NotFound();

            _context.Products.Remove(existPr);
            _context.SaveChanges();

            return NoContent();
        }
    }


}
