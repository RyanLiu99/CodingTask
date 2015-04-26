using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RyanLiu.CodingTask.Models.Mapping
{
    public class RunInstance_Product_ChartMap : EntityTypeConfiguration<RunInstance_Product_Chart>
    {
        public RunInstance_Product_ChartMap()
        {
            // Primary Key
            this.HasKey(t => new { t.run_instance_id, t.product_code, t.year, t.month });

            // Properties
            this.Property(t => t.run_instance_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.product_code)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.year)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("RunInstance_Product_Chart");
            this.Property(t => t.run_instance_id).HasColumnName("run_instance_id");
            this.Property(t => t.product_code).HasColumnName("product_code");
            this.Property(t => t.year).HasColumnName("year");
            this.Property(t => t.month).HasColumnName("month");
            this.Property(t => t.result).HasColumnName("result");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.RunInstance_Product_Chart)
                .HasForeignKey(d => d.product_code);
            this.HasRequired(t => t.RunInstance)
                .WithMany(t => t.RunInstance_Product_Chart)
                .HasForeignKey(d => d.run_instance_id);

        }
    }
}
