public class Client
{
    public int ID { get; set; }
    internal string Name { get; set; }
    internal string Surname { get; set; }
    internal int DocumentNumber { get; set; }
    internal string? Birthdate { get; set; }
    internal string? Address { get; set; }
    internal string? Email { get; set; }
    internal string? Cuit { get; set; }
    internal int? PhoneNumber { get; set; }
    
    public ICollection<Product> Products { get; set; }

}