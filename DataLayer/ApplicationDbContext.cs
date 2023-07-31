namespace DataLayer;
public class ApplicationDbContext : DbContext 
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerCar>()
            .HasKey(cc => new { cc.CarNumber , cc.CustomerId });

        modelBuilder.Entity<CustomerCar>()
            .HasOne(cc => cc.Car)
            .WithMany(cc => cc.CustomerCars)
            .HasForeignKey(cc => cc.CarNumber);

        modelBuilder.Entity<CustomerCar>()
            .HasOne(cc => cc.Customer)
            .WithMany(c => c.CustomerCars)
            .HasForeignKey(cc => cc.CustomerId);

        modelBuilder.Entity<DriverCar>()
            .HasKey(dc => new { dc.CarNumber, dc.DriverId });

        modelBuilder.Entity<DriverCar>()
            .HasOne(d => d.Car)
            .WithMany(c => c.DriverCars)
            .HasForeignKey(d => d.CarNumber);

        modelBuilder.Entity<DriverCar>()
            .HasOne(d => d.Driver)
            .WithMany(c => c.DriverCars)
            .HasForeignKey(d => d.DriverId);

        modelBuilder.Entity<Driver>()
            .HasOne(d => d.substitute)
            .WithOne()
            .HasForeignKey<Driver>(d => d.substitDriverId)
            .OnDelete(DeleteBehavior.Restrict);

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
    public virtual DbSet<CustomerCar> CustomerCars { get; set; }
    public virtual DbSet<DriverCar> DriverCars { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
        optionsBuilder.UseLazyLoadingProxies();
}