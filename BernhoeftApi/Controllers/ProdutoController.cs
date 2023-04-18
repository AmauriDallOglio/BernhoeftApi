using Aplicacao.Aplicacao;
using Dominio.Entidade;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;
using static Dominio.Enum.Enum;

namespace BernhoeftApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio iProduto;
        private readonly ProdutoAplicacao aplicacaoProduto;
        public ProdutoController(IProdutoRepositorio iProdutoRepositorio)
        {
            iProduto = iProdutoRepositorio;
            aplicacaoProduto = new ProdutoAplicacao(iProduto);

        }


        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Produto produto)
        {
            try
            {
                Produto produtoRetorno = aplicacaoProduto.Cadastrar(produto);
                return Ok(produtoRetorno);
            }
            catch (Exception erro)
            {
                return NotFound("Controller:" + erro.Message);
            }
        }

        [HttpPut("Alterar")]
        public IActionResult Alterar(int id, Produto produto)
        {
            try
            {
                produto.Id = id;
                Produto produtoRetorno = aplicacaoProduto.Alterar(produto);
                return Ok(produtoRetorno); 
            }
            catch (Exception erro)
            {
                return NotFound("Controller:" + erro.Message);
            }
        }


        [HttpGet("ObterPorNomeDaCategoria")]
        public IActionResult ListarPorCategoria(string nome)
        {
            try
            {
                List<Produto> listaDeProdutos = aplicacaoProduto.ListarProdutosPorCategoriaPeloNome(nome);
                return Ok(listaDeProdutos); 
            }
            catch (Exception erro)
            {
                return NotFound("Controller:" + erro.Message);
            }
        }

        [HttpGet("ObterPorDescricao")]
        public IActionResult ObterPorDescricao(string descricao)
        {
            try
            {
                List<Produto> listaDeProdutos = aplicacaoProduto.ListarProdutosPelaDescricao(descricao);
                return Ok(listaDeProdutos); 
            }
            catch (Exception erro)
            {
                return NotFound("Controller:" + erro.Message);
            }
        }


        [HttpGet("ObterPelaSituacao")]
        public IActionResult ObterPelaSituacao(SituacaoEnum situacao)
        {
            try
            {
                List<Produto> listaDeProdutos = aplicacaoProduto.ListarProdutoPelaSituacao(situacao);
                return Ok(listaDeProdutos); 
            }
            catch (Exception erro)
            {
                return NotFound("Controller:" + erro.Message);
            }
        }


    }
}
