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
            using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountDbContext>();

             await dbContext.Database.MigrateAsync();

            return app;
        }
    }
}
