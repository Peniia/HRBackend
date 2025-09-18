using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HRManagementSystem.Infrastructure.Persistence
{
    public class HRDbContextFactory : IDesignTimeDbContextFactory<HRDbContext>
    {
        public HRDbContext CreateDbContext(string[] args)
        {
            // DbContext seçeneklerini oluştur
            var optionsBuilder = new DbContextOptionsBuilder<HRDbContext>();

            // Windows Authentication ile SQL Server bağlantısı
            optionsBuilder.UseSqlServer(
                "Server=localhost;Database=HRManagementSystemDB;Trusted_Connection=True;TrustServerCertificate=True;"
            );

            // Her zaman DbContext döndür
            return new HRDbContext(optionsBuilder.Options);
        }
    }
}
