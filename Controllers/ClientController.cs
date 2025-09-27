using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("/api/client")]
public class ClientController : ControllerBase
{
    //Inyectar el servicio
    private readonly ClientService _clientService;
    public ClientController(ClientService clientService)
    {
        _clientService = clientService;
    }
    //Endpoint Get Clients
    [HttpGet]
    public async Task<ActionResult<List<Client>>> GetAllClient()
    {
        try
        {
            var clients = await _clientService.GetClients();
            if (clients is null)
            {
                return NoContent();
            }
            return Ok(clients);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Error Servidor {ex}");
        }
    }
    //Endpoint Get Client By Id
    [HttpGet]
    [Route("/api/client/{id}")]
    public async Task<ActionResult<Client>> GetClientById(int id)
    {
        try
        {
            var client = await _clientService.GetClient(id);
            if (client is null)
            {
                return NoContent();
            }
            return Ok(client);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Error Servidor {ex}");
        }
    }
    //Endpoint Post New Client
    [HttpPost]
    public async Task<ActionResult> PostClient([FromBody] Client client)
    {
        try
        {
            var clientCreated = await _clientService.PostClient(client);
            if (client is null)
            {
                return BadRequest();
            }
            return Ok(clientCreated);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"Error Servidor {ex}");
        }
    }
    //Endpoint Update
    [HttpPut]
    [Route("/api/client/{id}")]
    public async Task<ActionResult> PutClient([FromBody] Client client, int id)
    {
        try
        {
            Client? clientUpdated = await _clientService.PutClient(client, id);
            if (clientUpdated is null)
            {
                return BadRequest();
            }
            return Ok(clientUpdated);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

}