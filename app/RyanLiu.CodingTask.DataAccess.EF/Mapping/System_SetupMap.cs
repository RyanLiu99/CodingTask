using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RyanLiu.CodingTask.Models.Mapping
{
    public class System_SetupMap : EntityTypeConfiguration<System_Setup>
    {
        public System_SetupMap()
        {
            // Primary Key
            this.HasKey(t => new { t.input_increment, t.db_version });

            // Properties
            this.Property(t => t.input_increment)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.db_version)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("System_Setup");
            this.Property(t => t.input_increment).HasColumnName("input_increment");
            this.Property(t => t.db_version).HasColumnName("db_version");
        }
    }
}
