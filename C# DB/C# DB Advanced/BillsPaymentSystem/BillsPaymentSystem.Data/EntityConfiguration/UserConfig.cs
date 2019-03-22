namespace BillsPaymentSystem.Data.EntityConfiguration
{
    using BillsPaymentSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                 .HasKey(u => u.UserId);

            builder
                .Property(f => f.FirstName)
                .HasMaxLength(50)                
                .IsRequired();

            builder
                .Property(l => l.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false)
                .IsRequired();

            builder
                .Property(p => p.Password)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();
        }
    }
}
