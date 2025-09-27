using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[Authorize]
[ApiController]
[Route("/api/product")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }

    //Endpoints
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        try
        {
            List<Product> products = await _productService.GetProductsAsync();
            if (products.Count <= 0)
            {
                return NoContent();
            }
            return Ok(products);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Error Servidor {ex}");
        }
    }

    [HttpPost]
    public async Task<ActionResult> PostProduct([FromBody] Product product)
    {
        try
        {
            Product productExist = await _productService.PostProductAsync(product);
            if (productExist is null)
            {
                return NoContent();
            }
            return Ok(productExist);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Error Servidor {ex}");
        }
    }

    [HttpGet]
    [Route("/api/product/{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        try
        {
            Product productExist = await _productService.GetProductAsync(id);
            if (productExist is null)
            {
                return NoContent();
            }
            return Ok(productExist);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Error Servidor {ex}");
        }
    }

}