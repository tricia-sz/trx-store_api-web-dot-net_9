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

        [HttpPost]
        public ActionResult<ProdutoModel> CriarProduto(ProdutoModel produtoModel)
        {
            if(produtoModel == null)
            {
                return BadRequest("Ocorreu um erro na Solicitacao!");
            }

            _context.Produtos.Add(produtoModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(BuscarProdutoPorId), new { id = produtoModel.Id }, produtoModel);
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<ProdutoModel> EditarProduto(ProdutoModel produtoModel, int id)
        {
            var produto = _context.Produtos.Find(id);

            if(produto == null)
            {
                return NotFound("Registro nao localizado!");
            }

            produto.Nome = produtoModel.Nome;
            produto.Descricao = produtoModel.Descricao;
            produto.Marca = produtoModel.Marca;
            produto.QuantidadeEstoque = produtoModel.QuantidadeEstoque;
            produto.CodigoDeBarras = produtoModel.CodigoDeBarras;

            _context.Produtos.Update(produto);
            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<ProdutoModel> DeletarProduto(int id) {

            var produto = _context.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound("REgistro nao lozalizado");
            }

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
