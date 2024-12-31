using Microsoft.EntityFrameworkCore;

namespace DenemeApi.DataAccessLayer
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql(
                "server=localhost;database=NetCoreDataApi;user=root;password='';",
                new MySqlServerVersion(new Version(8, 0, 2))
            );
        }
        public DbSet<Employee> Employees{ get; set; }
    }
}
