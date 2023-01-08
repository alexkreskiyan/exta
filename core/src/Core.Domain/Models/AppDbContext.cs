// using System;
// using System.Linq;
// using Core.Domain.Interfaces;
//
// namespace Core.Domain.Models;
//
// public sealed record AppDbContext : IIdEntity
// {
//     public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
//
//     protected DbSet<Accrual> Accruals { get; set; }
//
//     public IQueryable<Accrual> AccrualsQuery => Accruals
//         .Include(e => e.Reason)
//         .Include(e => e.DriverContract).ThenInclude(e => e.Driver).ThenInclude(e => e.User)
//         .Include(e => e.DriverContract).ThenInclude(e => e.Car).ThenInclude(e => e.Brand)
//         .AsQueryable();
//
//     protected DbSet<AccrualReason> AccrualReasons { get; set; }
//
//     public IQueryable<AccrualReason> AccrualReasonsQuery => AccrualReasons
//         .AsQueryable();
//
//     protected DbSet<Car> Cars { get; set; }
//
//     public IQueryable<Car> CarsQuery => Cars
//         .Include(e => e.Brand)
//         .AsQueryable();
//
//     public IQueryable<CarDriver> CarDriversQuery(DateTime date) => CarsQuery
//         .GroupJoin(
//             DriverContractsQuery.Where(e => e.SignDate <= date && (e.TerminationDate == null || e.TerminationDate >= date)).OrderBy(e => e.SignDate),
//             e => e.Id,
//             e => e.CarId,
//             (car, contracts) => new CarDriver() { Car = car, Driver = contracts.Count() > 0 ? contracts.First().Driver : null }
//         )
//         .AsQueryable();
//
//     protected DbSet<CarBrand> CarBrands { get; set; }
//
//     public IQueryable<CarBrand> CarBrandsQuery => CarBrands
//         .AsQueryable();
//
//     protected DbSet<DayOff> DaysOff { get; set; }
//
//     public IQueryable<DayOff> DaysOffQuery => DaysOff
//         .Include(e => e.Reason)
//         .Include(e => e.DriverContract).ThenInclude(e => e.Driver).ThenInclude(e => e.User)
//         .Include(e => e.DriverContract).ThenInclude(e => e.Car).ThenInclude(e => e.Brand)
//         .AsQueryable();
//
//     protected DbSet<Driver> Drivers { get; set; }
//
//     public IQueryable<Driver> DriversQuery => Drivers
//         .Include(e => e.User)
//         .AsQueryable();
//
//     protected DbSet<DriverContract> DriverContracts { get; set; }
//
//     public IQueryable<DriverContract> DriverContractsQuery => DriverContracts
//         .Include(e => e.Driver).ThenInclude(e => e.User)
//         .Include(e => e.Car).ThenInclude(e => e.Brand)
//         .AsQueryable();
//
//     protected DbSet<Payment> Payments { get; set; }
//
//     public IQueryable<Payment> PaymentsQuery => Payments
//         .Include(e => e.Category)
//         .Include(e => e.Account)
//         .Include(e => e.Car).ThenInclude(e => e.Brand)
//         .AsQueryable();
//
//     protected DbSet<Account> Accounts { get; set; }
//
//     public IQueryable<Account> AccountsQuery => Accounts
//         .AsQueryable();
//
//     protected DbSet<Category> Categories { get; set; }
//
//     public IQueryable<Category> CategoriesQuery => Categories
//         .AsQueryable();
//
//     protected DbSet<Transfer> Transfers { get; set; }
//
//     public IQueryable<Transfer> TransfersQuery => Transfers
//         .Include(e => e.FromAccount)
//         .Include(e => e.ToAccount)
//         .AsQueryable();
//
//     protected DbSet<User> Users { get; set; }
//
//     public IQueryable<User> UsersQuery => Users
//         .AsQueryable();
//
//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         modelBuilder.Entity<Accrual>().HasIndex(e => e.Id).IsUnique();
//         modelBuilder.Entity<Accrual>().HasOne(e => e.DriverContract).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
//         modelBuilder.Entity<Accrual>().HasOne(e => e.Reason).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
//
//         modelBuilder.Entity<AccrualReason>().HasIndex(e => e.Id).IsUnique();
//
//         modelBuilder.Entity<Car>().HasIndex(e => e.Id).IsUnique();
//         modelBuilder.Entity<Car>().HasIndex(e => e.GovernmentNumber).IsUnique();
//         modelBuilder.Entity<Car>().HasIndex(e => e.VIN).IsUnique();
//         modelBuilder.Entity<Car>().HasIndex(e => e.EngineNumber).IsUnique();
//         modelBuilder.Entity<Car>().HasIndex(e => e.BodyNumber).IsUnique();
//         modelBuilder.Entity<Car>().HasIndex(e => e.PassportNumber).IsUnique();
//         modelBuilder.Entity<Car>().HasIndex(e => e.RegistrationNumber).IsUnique();
//         modelBuilder.Entity<Car>().HasOne(e => e.Brand).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
//
//         modelBuilder.Entity<CarBrand>().HasIndex(e => e.Id).IsUnique();
//
//         modelBuilder.Entity<DayOff>().HasIndex(e => e.Id).IsUnique();
//         modelBuilder.Entity<DayOff>().HasOne(e => e.DriverContract).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
//         modelBuilder.Entity<DayOff>().HasOne(e => e.Reason).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
//
//         modelBuilder.Entity<Driver>().HasIndex(e => e.Id).IsUnique();
//         modelBuilder.Entity<Driver>().HasIndex(e => e.PassportNumber).IsUnique();
//         modelBuilder.Entity<Driver>().HasIndex(e => e.LicenseNumber).IsUnique();
//         modelBuilder.Entity<Driver>().HasOne(e => e.User).WithOne().OnDelete(DeleteBehavior.Restrict);
//
//         modelBuilder.Entity<DriverContract>().HasIndex(e => e.Id).IsUnique();
//         modelBuilder.Entity<DriverContract>().HasOne(e => e.Driver).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
//         modelBuilder.Entity<DriverContract>().HasOne(e => e.Car).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
//
//         modelBuilder.Entity<Payment>().HasIndex(e => e.Id).IsUnique();
//         modelBuilder.Entity<Payment>().HasOne(e => e.Account).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
//         modelBuilder.Entity<Payment>().HasOne(e => e.Category).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
//         modelBuilder.Entity<Payment>().HasOne(e => e.Car).WithMany().OnDelete(DeleteBehavior.Restrict);
//
//         modelBuilder.Entity<Account>().HasIndex(e => e.Id).IsUnique();
//         modelBuilder.Entity<Account>().HasIndex(e => e.Name).IsUnique();
//
//         modelBuilder.Entity<Category>().HasIndex(e => e.Id).IsUnique();
//
//         modelBuilder.Entity<Transfer>().HasIndex(e => e.Id).IsUnique();
//         modelBuilder.Entity<Transfer>().HasOne(e => e.FromAccount).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
//         modelBuilder.Entity<Transfer>().HasOne(e => e.ToAccount).WithMany().IsRequired().OnDelete(DeleteBehavior.Restrict);
//
//         modelBuilder.Entity<User>().HasIndex(e => e.Id).IsUnique();
//         modelBuilder.Entity<User>().HasIndex(e => e.UserId).IsUnique();
//     }
// }
