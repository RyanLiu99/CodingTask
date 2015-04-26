using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RyanLiu.CodingTask.Models.Mapping
{
    public class optimization_goalMap : EntityTypeConfiguration<optimization_goal>
    {
        public optimization_goalMap()
        {
            // Primary Key
            this.HasKey(t => t.optimization_goal_id);

            // Properties
            this.Property(t => t.optimization_goal1)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("optimization_goal");
            this.Property(t => t.optimization_goal_id).HasColumnName("optimization_goal_id");
            this.Property(t => t.optimization_goal1).HasColumnName("optimization_goal");
        }
    }
}
