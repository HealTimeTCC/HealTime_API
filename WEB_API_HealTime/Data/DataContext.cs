using Microsoft.EntityFrameworkCore;
using WEB_API_HealTime.Models;

namespace WEB_API_HealTime.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<Pessoas> Pessoas { get; set; }
}
