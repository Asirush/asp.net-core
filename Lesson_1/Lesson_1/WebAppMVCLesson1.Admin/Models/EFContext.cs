using Microsoft.EntityFrameworkCore;

namespace WebAppMVCLesson1.Admin.Models
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions options) : base(options)
        {

        }
    }
}
