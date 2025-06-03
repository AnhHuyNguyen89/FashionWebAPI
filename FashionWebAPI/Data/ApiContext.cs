using Microsoft.EntityFrameworkCore;
using FashionWebAPI.Models;

namespace FashionWebAPI.Data
{
    public class ApiContext: DbContext
    {
        public DbSet<NewFashionItems> NewItem {get; set;}

        public ApiContext(DbContextOptions<ApiContext> opts) : base(opts)
        {
            
        }
    }
}
