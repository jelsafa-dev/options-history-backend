using Microsoft.EntityFrameworkCore;
using OptionsHistory.API.Models;

namespace OptionsHistory.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<Stock> Stocks => Set<Stock>();
        public DbSet<Option> Options => Set<Option>();
    }
}
