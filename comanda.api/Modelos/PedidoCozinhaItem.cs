using SistemaDeComandas.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PedidoCozinhaItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int PedidoCozinhaId { get; set; }
    public virtual PedidoCozinha PedidoCozinha { get; set; }
    public int ComandaItemId { get; set; }
    public virtual ComandaItem ComandaItem { get; set; }
}
