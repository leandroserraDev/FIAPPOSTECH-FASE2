using FIAPPOSTECH_FASE2.DOMAIN.Entities;
using FIAPPOSTECH_FASE2.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPPOSTECH_FASE2.DTO.AppServices
{
    public class AppServicoNoticia : AppServicoGenerico<Noticia>, IAppServicoNoticia
    {
        public AppServicoNoticia(ServicoGenerico<Noticia> servicoGenerico) : base(servicoGenerico)
        {
        }
    }
}
