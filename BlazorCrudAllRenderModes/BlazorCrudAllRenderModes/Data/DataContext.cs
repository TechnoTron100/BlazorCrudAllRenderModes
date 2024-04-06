using BlazorCrudAllRenderModes.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudAllRenderModes.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Game> Games { get; set; }
    }
}
