using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RyanLiu.CodingTask.Models.Mapping
{
    public class SetupMap : EntityTypeConfiguration<Setup>
    {
        public SetupMap()
        {
            // Primary Key
            this.HasKey(t => t.setup_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Setup");
            this.Property(t => t.setup_id).HasColumnName("setup_id");
            this.Property(t => t.optimization_goal_id).HasColumnName("optimization_goal_id");
            this.Property(t => t.optimization_goal_value).HasColumnName("optimization_goal_value");
            this.Property(t => t.date_start).HasColumnName("date_start");
            this.Property(t => t.date_end).HasColumnName("date_end");
            this.Property(t => t.input_increment).HasColumnName("input_increment");

            // Relationships
            this.HasRequired(t => t.optimization_goal)
                .WithMany(t => t.Setups)
                .HasForeignKey(d => d.optimization_goal_id);

        }
    }
}
