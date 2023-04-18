using Dominio.Entidade;
using Dominio.Interface;
using Infra.Context;
using static Dominio.Enum.Enum;

namespace Infra.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly MeuContext _context;
        public CategoriaRepositorio(MeuContext bancoContext)
        {
            _context = bancoContext;
        }

        public Categoria Incluir(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public Categoria Alterar(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public Categoria BuscarPorId(int id)
        {
            var categorioaBd = _context.Categorias.Where(a => a.Id == id).FirstOrDefault();
            return categorioaBd;
        }

        public List<Categoria> BuscarPorNome(string nome)
        {
            var resultado =_context.Categorias.Where(a => a.Nome.Contains(nome)).ToList();
            return resultado;
        }

        public List<Categoria> BuscarPorSituacao(SituacaoEnum situacao)
        {
            short tipo = (short)situacao;
            var resultado = _context.Categorias.Where(a => a.Situacao == tipo).ToList();
            return resultado;
        }
    }
}
