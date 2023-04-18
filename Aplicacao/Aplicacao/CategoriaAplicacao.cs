using Dominio.Entidade;
using Dominio.Interface;
using Microsoft.IdentityModel.Tokens;

using static Dominio.Enum.Enum;

namespace Aplicacao.Aplicacao
{
    public class CategoriaAplicacao
    {

        private readonly ICategoriaRepositorio iCategoria;
        public CategoriaAplicacao(ICategoriaRepositorio iCategoriaRepositorio)
        {
            iCategoria = iCategoriaRepositorio;
        }

        public Categoria Cadastrar(Categoria categoria)
        {
            try
            {
                ValidadorIncluir(categoria);
                Categoria resultado = iCategoria.Incluir(categoria);
                return resultado;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Cadastrar: {erro.Message}");
            }
        }

        public void ValidadorIncluir(Categoria categoria)
        {
            if (categoria.Nome.IsNullOrEmpty())
                throw new NotImplementedException("Nome não pode estar em branco!");

        }

        public Categoria Alterar(Categoria categoria)
        {

            try
            {
                if (categoria.Nome.IsNullOrEmpty())
                    throw new NotImplementedException("Nome não pode estar em branco!");

                Categoria categoriaBD = iCategoria.BuscarPorId(categoria.Id);
                if (categoriaBD == null)
                    throw new System.Exception("ValidadorAlterar: Erro na atualização, categoria não localizada!");

                categoriaBD.Alteracao(categoria.Nome, categoria.Situacao);

                Categoria resultado = iCategoria.Alterar(categoriaBD);
                return categoria;
            }
            catch (Exception erro)
            {
                throw new NotImplementedException($"Alterar: {erro.Message}");
            }
        }

        public List<Categoria> BuscarPorNome(string nome)
        {
            List<Categoria> categorias = iCategoria.BuscarPorNome(nome);
            return categorias;
        }
        public List<Categoria> BuscarPorSituacao(SituacaoEnum situacao)
        {
            List<Categoria> categorias = iCategoria.BuscarPorSituacao(situacao);
            return categorias;
        }
    }
}
