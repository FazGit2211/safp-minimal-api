using Microsoft.EntityFrameworkCore;

public class ClientService : IClient
{
    //Inyectar el contexto de la base de dato
    private readonly SafpContext _context;
    public ClientService(SafpContext context)
    {
        _context = context;
    }
    //Método para obtener a todos
    public async Task<List<Client>> GetClients()
    {
        try
        {
            List<Client> clients = new List<Client>();
            var clientsList = await _context.Clients.Include(products => products.Products).FirstAsync();
            clients.Add(clientsList);
            return clients;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
    //Método para obtener por id
    public async Task<Client> GetClient(int id)
    {
        try
        {
            return await _context.Clients.FindAsync(id);
        }
        catch (System.Exception)
        {

            throw;
        }
    }
    //Método para crear nuevo cliente
    public async Task<Client> PostClient(Client client)
    {
        try
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }
        catch (System.Exception)
        {

            throw;
        }
    }
    //Método para actualizar
    public async Task<Client> PutClient(Client client, int id)
    {
        try
        {
            Client? userExist = await _context.Clients.FindAsync(id);
            if (userExist is null)
            {
                return null;
            }
            userExist.Name = client.Name;
            userExist.Surname = client.Surname;
            await _context.SaveChangesAsync();
            return userExist;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

}