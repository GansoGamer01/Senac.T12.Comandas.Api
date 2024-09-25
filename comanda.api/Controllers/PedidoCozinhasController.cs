using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeComandas.BancoDeDados;
using SistemaDeComandas.Modelos;

namespace comanda.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoCozinhasController : ControllerBase
    {
        // variavel do banco de dados \\
        private readonly ComandaContexto _context;

        // o construtor do controlador \\
        public PedidoCozinhasController(ComandaContexto contexto)
        {
            _context = contexto;
        }

        // GET: api/PedidoCozinhas
        /// <summary>
        /// 
        /// </summary>
        /// <returns>[{id, ComandaId, SituacaoId},... ]</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoCozinha>>> GetPedidos([FromQuery] int? SituacaoId)
        {
            // SELECT * FROM PedidoCozinhas \\
            // INNER JOIN Comanda c on c.id = p.ComandaId
            var query = _context.PedidoCozinhas.Include(p => p.Comanda)
                .Include(p=>p.PedidoCozinhaItems)
                .AsQueryable();

            if (SituacaoId > 0)
                query = query.Where(w => w.SituacaoId == SituacaoId);

            return await query.ToListAsync();
        }

        // GET api/<PedidoCozinhasController>/
        //[HttpGet("{id}")]

    }
}
