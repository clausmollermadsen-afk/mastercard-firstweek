using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Firstweek.WebApp.Data
{
    /// <summary>
    /// Represents an application user with additional profile data and configuration.
    /// </summary>
    public class ApplicationUser : IdentityUser, IEntityTypeConfiguration<ApplicationUser>
    {
        /// <summary>
        /// Gets or sets the user's address.
        /// </summary>
        public required string Address { get; init; }

        /// <summary>
        /// Gets or sets the authentication token for the user.
        /// </summary>
        public required string Token { get; init; }

        /// <summary>
        /// Gets or sets the list of bills associated with the user.
        /// </summary>
        public required List<Bill> Bills { get; init; }

        /// <summary>
        /// Gets or sets a value indicating whether the user is active.
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// Configures the entity for EF Core, setting up indexes, table name, and string length.
        /// </summary>
        /// <param name="builder">The entity type builder.</param>
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasIndex(e => new { e.Address, e.Active }).IsUnique();
            builder.ToTable("ApplicationUsers");
            builder.Property(e => e.Address).HasMaxLength(256);
            builder.Property(e => e.Token).HasMaxLength(256);
        }
    }
}