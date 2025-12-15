using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Master.Firstweek.WebApp.Data
{
    /// <summary>
    /// Abstract base class for entities, providing an Id and configuration for EF Core.
    /// </summary>
    /// <typeparam name="T">The entity type inheriting from this base.</typeparam>
    public abstract class EntityBase<T> : Auditable where T : EntityBase<T>
    {
        /// <summary>
        /// Gets or sets the primary key for the entity.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Configures the entity for EF Core, setting Id as the primary key and auto-generated.
        /// </summary>
        /// <param name="builder">The entity type builder.</param>
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
        }
    }
}