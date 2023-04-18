using Dominio.Entidade;
using Dominio.Interface;
using static Dominio.Enum.Enum;

namespace Aplicacao.Aplicacao
{
    public class ProdutoAplicacao
    {

        private readonly IProdutoRepositorio iProduto;
        public ProdutoAplicacao(IProdutoRepositorio iProdutoRepositorio)
        {
            iProduto = iProdutoRepositorio;
        }

        public Produto Cadastrar(Produto produto)
        {
            try
            {
                produto = iProduto.CarregaCategoriaSeExistir(produto);
                Produto resultado = iProduto.Incluir(produto);
                return produto;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Cadastrar: {erro.Message}");
            }
        }

        public Produto Alterar(Produto produto)
        {
            try
            {
                produto = iProduto.CarregaCategoriaSeExistir(produto);
                Produto resultado = iProduto.Alterar(produto);
                return produto;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Alterar: {erro.Message}");
            }
        }

        public List<Produto> ListarProdutosPorCategoriaPeloNome(string nomeCategoria)
        {
            try
            {
                List<Produto> listadeProdutoPorCategoria = iProduto.ListarProdutosPorCategoriaPeloNome(nomeCategoria);
                if (listadeProdutoPorCategoria.Count == 0)
                    throw new NotImplementedException($"categoria pesquisa não possuí produtos cadastrados!");

                return listadeProdutoPorCategoria;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Aplicacao: {erro.Message}");
            }
        }


        public List<Produto> ListarProdutosPelaDescricao(string descricao)
        {
            try
            {
                List<Produto> listadeProdutoPorCategoria = iProduto.ListarProdutosPelaDescricao(descricao);
                if (listadeProdutoPorCategoria.Count == 0)
                    throw new NotImplementedException($"não existe produtos com esta descrição!");

                return listadeProdutoPorCategoria;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Aplicacao: {erro.Message}");
            }
        }

        public List<Produto> ListarProdutoPelaSituacao(SituacaoEnum situacao)
        {
            try
            {
                List<Produto> listadeProdutoPorCategoria = iProduto.ListarProdutosPelaSituacao(situacao);
                if (listadeProdutoPorCategoria.Count == 0)
                    throw new NotImplementedException($"não existe produtos com esta situação!");

                return listadeProdutoPorCategoria;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Aplicacao: {erro.Message}");
            }
        }


    }
}
