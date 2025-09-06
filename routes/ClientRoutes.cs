using Microsoft.EntityFrameworkCore;

public static class ClientRoutes
{
    public static void Map(WebApplication app)
    {
        //Endpoint Get Clients
        app.MapGet("/api/client", async (SafpContext db) =>
        {
            try
            {
                var clients = await db.Clients.ToListAsync();
                return clients.Count != 0 ? Results.Ok(clients) : Results.NotFound();
            }
            catch (System.Exception)
            {
                throw;
            }
        });
        //Endpoint Get Client By Id
        app.MapGet("/api/client/{id}", async (SafpContext db, int id) =>
        {
            try
            {
                return await db.Clients.FindAsync(id) is Client client ? Results.Ok(client) : Results.NotFound();
            }
            catch (System.Exception)
            {
                throw;
            }
        });
        //Endpoint Post New Client
        app.MapPost("/api/client", async (SafpContext db, Client client) =>
        {
            try
            {
                db.Add(client); await db.SaveChangesAsync(); return Results.Created($"Cliente creado:", client);
            }
            catch (System.Exception)
            {
                throw;
            }
        });
        //Endpoint Put Client
        app.MapPut("/api/client/{id}", async (SafpContext db, int id, Client client) =>
        {
            try
            {
                var clientExist = await db.Clients.FindAsync(id);
                if (clientExist is null)
                {
                    return Results.NotFound();
                }
                clientExist.Name = client.Name;
                clientExist.Surname = client.Surname;
                clientExist.DocumentNumber = client.DocumentNumber;
                clientExist.Birthdate = client.Birthdate;
                clientExist.Address = client.Address;
                clientExist.Email = client.Email;
                clientExist.Cuit = client.Cuit;
                clientExist.PhoneNumber = client.PhoneNumber;
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            catch (System.Exception)
            {
                throw;
            }
        });
        //Endpoint Delete Client
        app.MapDelete("/api/client/{id}", async (SafpContext db, int id) => { try
            {
                var clientExist = await db.Clients.FindAsync(id);
                if (clientExist is null)
                {
                    return Results.NotFound();
                }
                db.Remove(clientExist);
                await db.SaveChangesAsync();
                return Results.NoContent();
        }
            catch (System.Exception)
            {
                throw;
            } });
    }
}