using Microsoft.EntityFrameworkCore;

public static class ProviderRoutes
{
    public static void MapProvider(WebApplication app)
    {
        //Endpoint Get Providers
        app.MapGet("/api/provider", async (SafpContext db) =>
        {
            try
            {
                return await db.Providers.ToListAsync();
            }
            catch (System.Exception)
            {
                throw;
            }
        });
        //Endpoint Get Provider By Id
        app.MapGet("/api/provider/{id}", async (SafpContext db, int id) =>
        {
            try
            {
                return await db.Providers.FindAsync(id) is Provider provider ? Results.Ok(provider) : Results.NotFound();
            }
            catch (System.Exception)
            {
                throw;
            }
        });
        //Endpoint Post New Provider
        app.MapPost("/api/provider", async (SafpContext db, Provider provider) =>
        {
            try
            {
                db.Add(provider);
                await db.SaveChangesAsync();
                return Results.Created("Created", provider);
            }
            catch (System.Exception)
            {
                throw;
            }
        });
        //Endpoint Put Provider
        app.MapPut("/api/provider/{id}", async (SafpContext db, int id, Provider provider) =>
        {
            try
            {
                var providerExist = await db.Providers.FindAsync(id);
                if (providerExist is null)
                {
                    return Results.NotFound();
                }
                providerExist.Name = provider.Name;
                providerExist.Address = provider.Address;
                providerExist.Email = provider.Email;
                providerExist.Cuit = provider.Cuit;
                providerExist.PhoneNumber = provider.PhoneNumber;
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            catch (System.Exception)
            {
                throw;
            }
        });
        //Endpoint Delete Provider
        app.MapDelete("/api/provider/{id}", async (SafpContext db, int id) =>
        {
            try
            {
                var providerExist = await db.Providers.FindAsync(id);
                if (providerExist is null)
                {
                    return Results.NotFound();
                }
                db.Providers.Remove(providerExist);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            catch (System.Exception)
            {
                throw;
            }
        });
    }
}