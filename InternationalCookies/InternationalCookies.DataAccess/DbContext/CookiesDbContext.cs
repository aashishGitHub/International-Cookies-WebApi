using System.Data.Entity;
using Unity.Attributes;

namespace InternationalCookies.DataAccess.DbContext
{
    public class CookiesDbContext : System.Data.Entity.DbContext
    {
        public CookiesDbContext([Dependency("CookiesDbContext")] string connectionString)
            : base(connectionString)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Customer);


            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithRequired(detail => detail.Order)
                .HasForeignKey(od => od.OrderId);
                

            modelBuilder.Entity<Order>()
              .Property(e => e.TotalCost)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasRequired<Stock>(p => p.Stock)
                .WithRequiredPrincipal(s => s.Product);

            //modelBuilder.Entity<Product>()
            //    .HasOptional(e => e.Stock)
            //    .WithRequired(e => e.Product);

            modelBuilder.Entity<OrderDetail>()
                .HasRequired(od => od.Product);

        }
    }
}
