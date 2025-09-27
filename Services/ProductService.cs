
using Microsoft.EntityFrameworkCore;

public class ProductService : IProduct
{
    //Inyectar el contexto de la base de dato
    private readonly SafpContext _context;

    public ProductService(SafpContext safpContext)
    {
        this._context = safpContext;
    }
    public async Task<Product> GetProductAsync(int id)
    {
        try
        {
            Product? products = await _context.Products.FindAsync(id);
            return products;
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public async Task<List<Product>> GetProductsAsync()
    {
        try
        {
            return await _context.Products.ToListAsync();            
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public async Task<Product> PostProductAsync(Product product)
    {
        try
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}