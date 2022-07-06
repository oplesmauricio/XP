using Romarinho.Domain.Interfaces;
using Romarinho.Domain.Model;

namespace Romarinho.Repository;
public class OrdemRepository : IRepository<Ordem>
{
    public void Cadastrar(Ordem entity)
    {
        //throw new NotImplementedException();
    }

    public void Editar(Ordem entity)
    {
        //throw new NotImplementedException();
    }

    public void Excluir(int id)
    {
        //throw new NotImplementedException();
    }

    public Ordem PegarPorId(int id)
    {
        return new Ordem();
    }

    public IEnumerable<Ordem> PegarPorIdUsuario(int idUsuario)
    {
        return new List<Ordem>
        {
            new Ordem()
        };
    }
}

