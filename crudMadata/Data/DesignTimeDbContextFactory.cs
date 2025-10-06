using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using crudMadata.Data;
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

        optionsBuilder.UseNpgsql("Host=shinkansen.proxy.rlwy.net;Port=46789;Database=railway;Username=postgres;Password=ShegDpDVhVnQsFbBKzYBLvOICAhZaLqI");

        return new AppDbContext(optionsBuilder.Options);
    }
}
