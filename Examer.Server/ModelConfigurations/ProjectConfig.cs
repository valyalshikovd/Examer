using Examer.Server.Models;
using Microsoft.EntityFrameworkCore;
namespace Examer.Server.ModelConfigurations
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Project> builder)
        {

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.HasIndex(e => e.token).IsUnique();
        }
    }
}
