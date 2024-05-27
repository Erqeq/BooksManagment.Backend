using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Author)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.Year)
                .IsRequired();

            builder.Property(x => x.Genre)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
