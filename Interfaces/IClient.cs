public interface IClient
{
    Task<List<Client>> GetClients();
    Task<Client> GetClient(int id);
    Task<Client> PostClient(Client client);
    Task<Client> PutClient(Client client, int id);
}