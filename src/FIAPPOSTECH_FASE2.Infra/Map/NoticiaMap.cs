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
    public class NoticiaMap : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia> builder)
        {
            builder.ToTable("Noticia");
            builder.HasKey(x => x.Id);
            builder.Property(nt => nt.Titulo)
                .HasColumnType("nvarchar(255)")
                .IsRequired();

            builder.Property(nt => nt.Titulo)
             .HasColumnType("text")
             .IsRequired();

            builder.HasOne(nt => nt.Autor)
                .WithMany(obj => obj.Noticias)
                .HasForeignKey(nt => nt.AutorId);

        }
    }
}
