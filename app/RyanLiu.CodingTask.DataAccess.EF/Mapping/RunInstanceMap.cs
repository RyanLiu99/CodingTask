using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RyanLiu.CodingTask.Models.Mapping
{
    public class RunInstanceMap : EntityTypeConfiguration<RunInstance>
    {
        public RunInstanceMap()
        {
            // Primary Key
            this.HasKey(t => t.run_instance_id);

            // Properties
            this.Property(t => t.path)
                .HasMaxLength(500);

            this.Property(t => t.note)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("RunInstance");
            this.Property(t => t.run_instance_id).HasColumnName("run_instance_id");
            this.Property(t => t.setup_id).HasColumnName("setup_id");
            this.Property(t => t.run_start).HasColumnName("run_start");
            this.Property(t => t.run_end).HasColumnName("run_end");
            this.Property(t => t.path).HasColumnName("path");
            this.Property(t => t.note).HasColumnName("note");

            // Relationships
            this.HasRequired(t => t.Setup)
                .WithMany(t => t.RunInstances)
                .HasForeignKey(d => d.setup_id);

        }
    }
}
