using Dominio.Entidade;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dominio.Enum.Enum;

namespace Dominio.Interface
{
    public interface ICategoriaRepositorio
    {
        Categoria Incluir(Categoria categoria);
        Categoria Alterar(Categoria categoria);
 

        Categoria BuscarPorId(int id);
        List<Categoria> BuscarPorNome(string nome);
        List<Categoria> BuscarPorSituacao(SituacaoEnum situacao);


    }

}
