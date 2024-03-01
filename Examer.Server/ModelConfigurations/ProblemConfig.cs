using Examer.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace Examer.Server.ModelConfigurations
{
    public class ProblemConfig : IEntityTypeConfiguration<Problem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Problem> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasKey(x => x.Id);
        }
    }
}
