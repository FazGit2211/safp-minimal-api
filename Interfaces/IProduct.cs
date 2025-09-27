public interface IProduct
{
    Task<List<Product>> GetProductsAsync();
    Task<Product> GetProductAsync(int id);
    Task<Product> PostProductAsync(Product product);
}