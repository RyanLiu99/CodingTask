using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RyanLiu.CodingTask.Models.Mapping
{
    public class RegionMap : EntityTypeConfiguration<Region>
    {
        public RegionMap()
        {
            // Primary Key
            this.HasKey(t => t.region_code);

            // Properties
            this.Property(t => t.region_code)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.region_name)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("Region");
            this.Property(t => t.region_code).HasColumnName("region_code");
            this.Property(t => t.region_name).HasColumnName("region_name");
            this.Property(t => t.stat_code).HasColumnName("stat_code");

            // Relationships
            this.HasRequired(t => t.State)
                .WithMany(t => t.Regions)
                .HasForeignKey(d => d.stat_code);

        }
    }
}
