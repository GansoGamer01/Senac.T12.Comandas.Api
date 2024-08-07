using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeComandas.Modelos
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public int ComandaId { get; set; }
        public int SituacaoId { get; set; }
        public ICollection<PedidoCozinhaItem> pedidoCozinhaItems { get; set; }
    }
}
