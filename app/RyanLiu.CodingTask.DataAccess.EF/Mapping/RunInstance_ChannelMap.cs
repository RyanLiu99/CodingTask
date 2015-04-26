using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RyanLiu.CodingTask.Models.Mapping
{
    public class RunInstance_ChannelMap : EntityTypeConfiguration<RunInstance_Channel>
    {
        public RunInstance_ChannelMap()
        {
            // Primary Key
            this.HasKey(t => new { t.run_instance_id, t.channel_code });

            // Properties
            this.Property(t => t.run_instance_id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.channel_code)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("RunInstance_Channel");
            this.Property(t => t.run_instance_id).HasColumnName("run_instance_id");
            this.Property(t => t.channel_code).HasColumnName("channel_code");
            this.Property(t => t.result).HasColumnName("result");

            // Relationships
            this.HasRequired(t => t.Channel)
                .WithMany(t => t.RunInstance_Channel)
                .HasForeignKey(d => d.channel_code);
            this.HasRequired(t => t.RunInstance)
                .WithMany(t => t.RunInstance_Channel)
                .HasForeignKey(d => d.run_instance_id);

        }
    }
}
