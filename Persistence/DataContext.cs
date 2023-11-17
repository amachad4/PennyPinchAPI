using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Expense> Expenses { get; set; }
    public DbSet<LkpCategory> LkpCategories { get; set; }
}
