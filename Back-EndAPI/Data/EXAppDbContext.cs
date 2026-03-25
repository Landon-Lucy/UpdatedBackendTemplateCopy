//
// DB CONTEXT ROLE
// ----------------
// AppDbContext represents the DATABASE.
// Each DbSet<T> represents a TABLE.
//
// EF Core uses this class to:
// - Generate SQL
// - Track changes
// - Execute queries safely
//
// This class should contain NO business logic.
//

//public class AppDbContext : DbContext
//{
//    // DbSet = a database table
//    // This tells EF Core there is a "character" table
//    public DbSet<Character> Characters => Set<Character>();

//    // Constructor receives configuration options
//    // (connection string, provider, logging, etc.)
//    public AppDbContext(DbContextOptions<AppDbContext> options)
//        : base(options)
//    {
//    }
//}
