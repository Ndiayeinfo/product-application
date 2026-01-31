using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApplication.Data;
using ProductApplication.Model;

namespace ProductApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("getAllProduct")]
        public IActionResult getAllProducts()
        {
            try
            {
                var product = _context.Products.ToList();
                if (product.Count == 0)
                {
                    return NotFound("No products available.");
                }
                return Ok(product);
            }   
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct(Product Products)
        { 
            _context.Products.Add(Products);
            _context.SaveChanges();
            return Ok("Product added successfully");
        }

        [HttpPut("UpdateProduct/{id}")]
        public IActionResult UpdateProduct(Product Products, int id)
        {
            try
            {
                var isRecordAvailable = _context.Products.SingleOrDefault(m => m.productId == id);
                if (isRecordAvailable == null)
                {
                    return NotFound("Product not found");
                }
                isRecordAvailable.productName = Products.productName;
                isRecordAvailable.productPrice = Products.productPrice;
                isRecordAvailable.productDescription = Products.productDescription;
                isRecordAvailable.productCategory = Products.productCategory;
                isRecordAvailable.IsExpire = Products.IsExpire;
                isRecordAvailable.DateTime = Products.DateTime;
                _context.SaveChanges();
                return Ok("Product updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                var singleRecord = _context.Products.SingleOrDefault(m => m.productId == id);
                if (singleRecord == null)
                {
                    return NotFound("Product not found.");
                }
                _context.Products.Remove(singleRecord);
                _context.SaveChanges(true);
                return Ok("Product delete successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
