public class Provider
{
    public int ID { get; set; }
    private string Name { get; set; }
    private string? Address { get; set; }
    private string? Email { get; set; }
    private string? Cuit { get; set; }
    private int? PhoneNumber { get; set; }
    private ICollection<Product> Products { get; set; }
}