using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RyanLiu.CodingTask.Models.Mapping
{
    public class ChannelMap : EntityTypeConfiguration<Channel>
    {
        public ChannelMap()
        {
            // Primary Key
            this.HasKey(t => t.channel_code);

            // Properties
            this.Property(t => t.channel_code)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.channel_name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Channel");
            this.Property(t => t.channel_code).HasColumnName("channel_code");
            this.Property(t => t.channel_name).HasColumnName("channel_name");
        }
    }
}
