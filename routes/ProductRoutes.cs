using Microsoft.EntityFrameworkCore;

public static class ProductRoutes
{
    public static void MapProduct(WebApplication app)
    {
        //Endpoint Get Products
        app.MapGet("/api/product", async (SafpContext db) =>
        {
            try
            {
                List<Product> productList = await db.Products.ToListAsync();
                return productList.Count > 0 ? Results.Ok(productList) : Results.NoContent();
            }
            catch (System.Exception)
            {
                throw;
            }
        });
        ////Endpoint Get Product by Id
        app.MapGet("/api/product/{id}", async (SafpContext db, int id) =>
        {
            try
            {
                return await db.Products.FindAsync(id) is Product product ? Results.Ok(product) : Results.NotFound();
            }
            catch (System.Exception)
            {
                throw;
            }
        });
        //Endpoint Post New Product
        app.MapPost("/api/product", async (SafpContext db, Product product) =>
        {
            try
            {
                db.Add(product);
                await db.SaveChangesAsync();
                return Results.Created("Created", product);
            }
            catch (System.Exception)
            {
                throw;
            }
        });
        //Endpoint Put Product
        app.MapPut("/api/product/{id}", async (SafpContext db, int id, Product product) =>
        {
            try
            {
                var productExist = await db.Products.FindAsync(id);
                if (productExist is null)
                {
                    return Results.NotFound();
                }
                productExist.Name = product.Name;
                productExist.Details = product.Details;
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            catch (System.Exception)
            {
                throw;
            }
        });
        //Endpoint Delete Product
        app.MapDelete("/api/product/{id}", async (SafpContext db, int id) =>
        {
            try
            {
                var productExist = await db.Products.FindAsync(id);
                if (productExist is null)
                {
                    return Results.NotFound();
                }
                db.Remove(productExist);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            catch (System.Exception)
            {
                throw;
            }
        });
        //Endpoint Add Products of Client
        app.MapPost("/api/product/client/{id}", async (SafpContext db, int id, IList<Product> products) =>
        {
            try
            {
                Client? clientExist = await db.Clients.FindAsync(id);
                List<Product> productList = new List<Product>();
                if (clientExist is null)
                {
                    return Results.NotFound();
                }
                foreach (var item in products)
                {
                    productList.Add(item);
                }
                clientExist.Products = productList;
                await db.SaveChangesAsync();
                return Results.NoContent();
            }
            catch (System.Exception)
            {
                throw;
            }
        });
        //Endpoint Add Products of Provider
        app.MapPost("/api/product/provider/{id}", async (SafpContext db, int id, List<Product> products) =>
        {
            try
            {
                Provider? providerExist = await db.Providers.FindAsync(id);
                List<Product> productList = new List<Product>();
                if (providerExist is null)
                {
                    return Results.NotFound();
                }
                foreach (var item in products)
                {
                    productList.Add(item);
                }
                providerExist.Products = productList;
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