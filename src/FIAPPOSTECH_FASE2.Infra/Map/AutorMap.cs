using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.Infra.Map
{
    public class AutorMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasIndex(us => us.Email )
                .IsUnique();

            builder.Property(us =>
            us.Nome
            )
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            builder.Property(us =>
           us.Sobrenome
           )
                .HasColumnType("nvarchar(50)")
               .IsRequired();
            builder.Property(us =>
           us.Email
           )
                .HasColumnType("nvarchar(50)")
               .IsRequired();

            builder.Property(us => us.Password)
                .HasColumnType("nvarchar(255)")
                .IsRequired();


            builder.HasMany(us => us.Noticias)
                .WithOne(us => us.Autor)
                .HasPrincipalKey(us => us.Id)
                .HasForeignKey(us => us.AutorId)
                .IsRequired();
        }
    }
}
