namespace DataLayer;
public class ApplicationDbContext : DbContext 
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Driver>().HasData(
            new Driver { Id = 1 , DriverName = "driver1" } ,
            new Driver { Id = 2 , DriverName = "driver2" } ,
            new Driver { Id = 3 , DriverName = "driver3" }
        );
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1 , CustomerName = "Customer1" } ,
            new Customer { Id = 2 , CustomerName = "Customer2" } ,
            new Customer { Id = 3 , CustomerName = "Customer3" }
        );
    }
    public virtual DbSet<Car> Cars {get; set;}
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Driver> Drivers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseLazyLoadingProxies();
}