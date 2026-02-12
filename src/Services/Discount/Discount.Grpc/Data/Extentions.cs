using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Discount.Grpc.Data
{
    public static class Extentions
    {
       public static async Task<IApplicationBuilder> UseMigration(this IApplicationBuilder app)
        {
            // Create a scope to get the DbContext instance
            using var scope= app.ApplicationServices.CreateScope();
            // Get the dbcontext from the service provider container
            using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountDbContext>();
            // Add db if not created, apply migration appended, if all is okay , do nothing.
             await dbContext.Database.MigrateAsync();

            return app;
        }
    }
}
