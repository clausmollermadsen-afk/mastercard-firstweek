using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Master.Firstweek.WebApp.Data
{
    /// <summary>
    /// The application's Entity Framework Core database context.
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options to be used by a <see cref="DbContext"/>.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the bills in the database.
        /// </summary>
        public DbSet<Bill> Bills { get; set; }
        
        public DbSet<Payment> Payments { get; set; }
        
        public DbSet<RequestResponseLog> RequestResponseLogs { get; set; }

        /// <inheritdoc />
        public override int SaveChanges()
        {
            UpdatesOnSave();
            return base.SaveChanges();
        }

        /// <inheritdoc />
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdatesOnSave();
            return await base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// Updates audit fields before saving changes.
        /// </summary>
        private void UpdatesOnSave()
        {
            var entries = ChangeTracker.Entries<Auditable>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.Created = DateTime.UtcNow;
                    entry.Entity.Modified = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.Modified = DateTime.UtcNow;
                }
            }
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
