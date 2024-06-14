using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DevIO.Data.Context;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

        builder.UseSqlServer("Server=127.0.0.1,1433;Initial Catalog=DevIO;User id=sa; Password=1q2w3e4r@#$;TrustServerCertificate=true");

        return new ApplicationDbContext(builder.Options);
    }
}