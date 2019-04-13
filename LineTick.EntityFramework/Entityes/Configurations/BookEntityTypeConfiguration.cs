using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LineTick.EntityFramework.Entities.Configurations
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book").HasKey(book => book.Id);
            builder.Property(book => book.Id).IsRequired();
            builder.Property(book => book.Title).IsRequired().HasMaxLength(25);
            builder.Property(book => book.Description).IsRequired().HasMaxLength(25);
        }
    }
}
