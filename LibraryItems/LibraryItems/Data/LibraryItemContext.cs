using LibraryItems.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryItems.Data
{
    public class LibraryItemContext : DbContext
    {
        public LibraryItemContext(DbContextOptions<LibraryItemContext> options) : base(options)
        {
        }
        public DbSet<LibraryItem> LibraryItems { get; set; }
    }
}
