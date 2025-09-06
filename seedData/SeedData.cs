using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new SafpContext(serviceProvider.GetRequiredService<DbContextOptions<SafpContext>>()))
        {
            if (context.Clients.Any())
            {
                return;
            }
            context.SaveChanges();
        }
    }
}