namespace Mortgage.Domain.Infrastructure.Utilities
{
    using Microsoft.EntityFrameworkCore;

    public class StartupConfiguration
    {
        public static void Migrate()
        {
            using (var context = new MortgageDbContext())
            {
                context.Database.Migrate();
            }
        }
    }
}
