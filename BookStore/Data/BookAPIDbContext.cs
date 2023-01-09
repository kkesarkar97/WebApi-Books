using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookAPIDbContext : DbContext
    {
        public BookAPIDbContext(DbContextOptions options): base(options) { } //Constructor


        public DbSet<Book> Books { get; set; } // Property which Act as Tables for Entity Table Core  
    }
}
