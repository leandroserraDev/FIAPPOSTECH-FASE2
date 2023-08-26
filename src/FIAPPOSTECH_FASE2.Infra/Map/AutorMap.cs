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

            builder.Property(us =>
            us.Nome
            )
                .IsRequired();
            builder.Property(us =>
           us.Sobrenome
           )
               .IsRequired();
            builder.Property(us =>
           us.Email
           )
               .IsRequired();
        }
    }
}
