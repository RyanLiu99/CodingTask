using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RyanLiu.CodingTask.Models.Mapping
{
    public class RunInstance_RegionMap : EntityTypeConfiguration<RunInstance_Region>
    {
        public RunInstance_RegionMap()
        {
            // Primary Key
            this.HasKey(t => new { t.run_instance_id, t.region_code });

            // Properties
            this.Property(t => t.run_instance_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.region_code)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("RunInstance_Region");
            this.Property(t => t.run_instance_id).HasColumnName("run_instance_id");
            this.Property(t => t.region_code).HasColumnName("region_code");
            this.Property(t => t.result).HasColumnName("result");

            // Relationships
            this.HasRequired(t => t.Region)
                .WithMany(t => t.RunInstance_Region)
                .HasForeignKey(d => d.region_code);
            this.HasRequired(t => t.RunInstance)
                .WithMany(t => t.RunInstance_Region)
                .HasForeignKey(d => d.run_instance_id);

        }
    }
}
