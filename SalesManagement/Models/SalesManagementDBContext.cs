using Microsoft.EntityFrameworkCore;

namespace SalesManagement.Models
{
    public class SalesManagementDBContext :DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public SalesManagementDBContext(DbContextOptions<SalesManagementDBContext> options) :base(options)
        {
            
        }
    }

}
