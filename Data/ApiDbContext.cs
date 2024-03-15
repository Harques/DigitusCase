using Microsoft.EntityFrameworkCore;

namespace DigitusCase.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
    }
}
