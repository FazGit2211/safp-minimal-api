public class Client
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int DocumentNumber { get; set; }
    public string? Birthdate { get; set; }
    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Cuit { get; set; }
    public int? PhoneNumber { get; set; }
    
    public ICollection<Product> Products { get; set; }

}