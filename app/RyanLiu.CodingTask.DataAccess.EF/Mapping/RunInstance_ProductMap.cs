using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RyanLiu.CodingTask.Models.Mapping
{
    public class RunInstance_ProductMap : EntityTypeConfiguration<RunInstance_Product>
    {
        public RunInstance_ProductMap()
        {
            // Primary Key
            this.HasKey(t => new { t.run_instance_id, t.product_code });

            // Properties
            this.Property(t => t.run_instance_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.product_code)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("RunInstance_Product");
            this.Property(t => t.run_instance_id).HasColumnName("run_instance_id");
            this.Property(t => t.product_code).HasColumnName("product_code");
            this.Property(t => t.result).HasColumnName("result");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.RunInstance_Product)
                .HasForeignKey(d => d.product_code);
            this.HasRequired(t => t.RunInstance)
                .WithMany(t => t.RunInstance_Product)
                .HasForeignKey(d => d.run_instance_id);

        }
    }
}
