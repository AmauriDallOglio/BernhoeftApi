using Aplicacao.Aplicacao;
using Dominio.Entidade;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;
 
using static Dominio.Enum.Enum;

namespace BernhoeftApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio iRepositorioCategoria;
        private readonly CategoriaAplicacao aplicacaoCategoria;
        public CategoriaController(ICategoriaRepositorio iCategoriaRepositorio)
        {
            iRepositorioCategoria = iCategoriaRepositorio;
            aplicacaoCategoria = new CategoriaAplicacao(iRepositorioCategoria);
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Categoria categoria)
        {
            try
            {
                Categoria resultado = aplicacaoCategoria.Cadastrar(categoria);
                return CreatedAtAction(nameof(ObterPorNome), new { nome = resultado.Nome }, resultado);
            }
            catch (Exception erro)
            {
                return NotFound("Erro:" + erro.Message);
            }
        }

        [HttpPut("Alterar")]
        public IActionResult Alterar(int id, Categoria categoria)
        {
            try
            {
                categoria.Id = id;
                Categoria resultado = aplicacaoCategoria.Alterar(categoria);
                return CreatedAtAction(nameof(ObterPorNome), new { nome = resultado.Nome }, resultado);

            }
            catch (Exception erro)
            {
                return NotFound("Controller:" + erro.Message);
            }
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            try
            {
                List<Categoria> resultado = aplicacaoCategoria.BuscarPorNome(nome);
                return Ok(resultado);
            }
            catch (Exception erro)
            {
                return NotFound("Controller:" + erro.Message);
            }
        }

        [HttpGet("ObterPorSituacao")]
        public IActionResult ObterPorSituacao(SituacaoEnum situacao)
        {
            try
            {
                List<Categoria> resultado = aplicacaoCategoria.BuscarPorSituacao(situacao);
                return Ok(resultado);
            }
            catch (Exception erro)
            {
                return NotFound("Controller:" + erro.Message);
            }
        }

    }
}
