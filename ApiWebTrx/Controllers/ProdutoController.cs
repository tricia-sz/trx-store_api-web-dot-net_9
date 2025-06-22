using ApiWebTrx.Data;
using ApiWebTrx.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiWebTrx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProdutoController(AppDbContext context)
        {
            _context = context;   
        }

        [HttpGet]
        public ActionResult<List<ProdutoModel>> BuscarProduto()
        {
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProdutoModel> BuscarProdutoPorId(int id)
        {
            var produto = _context.Produtos.Find(id);
            if(produto == null)
            {
                return NotFound("Produto nao encontrado");
            }

            return Ok(produto);
        }
    }
}
