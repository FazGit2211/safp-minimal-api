using Microsoft.EntityFrameworkCore;

public static class ClientRoutes
{
    public static void Map(WebApplication app)
    {
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
        app.MapGet("/api/client/{id}", async (SafpContext db, int id) => { return await db.Clients.FindAsync(id) is Client client ? Results.Ok(client) : Results.NotFound(); });
        app.MapPost("/api/client", async (SafpContext db, Client client) => { db.Add(client); await db.SaveChangesAsync(); return Results.Created($"Cliente creado:", client); });
    }
}