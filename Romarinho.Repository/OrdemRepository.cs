using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Romarinho.Domain.Interfaces;
using Romarinho.Domain.Model;

namespace Romarinho.Repository;
public class OrdemRepository : IRepository<Ordem>
{
    private readonly IConfiguration _configuration;

    public OrdemRepository(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public void Cadastrar(Ordem ordem)
    {
        var connectionString = _configuration.GetConnectionString("RomarinhoConnection");

        using (var con = new MySqlConnection(connectionString))
        {
            try
            {
                con.Open();
                var query = "INSERT INTO " +
                                "Ordem(" +
                                "  Data           " +
                                ", Assessor       " +
                                ", Conta          " +
                                ", Ativo          " +
                                ", Tipo           " +
                                ", Quantidade     " +
                                ", QtdAparente    " +
                                ", QtdDisponivel  " +
                                ", QtdCancelada   " +
                                ", QtdExecutada   " +
                                ", Valor          " +
                                ", ValorDisponivel" +
                                ", Objetivo       " +
                                ", ObjDispon      " +
                                ", Reducao        " +
                                ", IdUsuario      " +
                                ") " +
                            "VALUES" +
                                "(" +
                                "  @Data           " +
                                ", @Assessor       " +
                                ", @Conta          " +
                                ", @Ativo          " +
                                ", @Tipo           " +
                                ", @Quantidade     " +
                                ", @QtdAparente    " +
                                ", @QtdDisponivel  " +
                                ", @QtdCancelada   " +
                                ", @QtdExecutada   " +
                                ", @Valor          " +
                                ", @ValorDisponivel" +
                                ", @Objetivo       " +
                                ", @ObjDispon      " +
                                ", @Reducao        " +
                                ", @IdUsuario      " +
                                "); ";
                con.Execute(query, ordem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }

    public void Editar(Ordem ordem)
    {
        var connectionString = _configuration.GetConnectionString("RomarinhoConnection");

        using (var con = new MySqlConnection(connectionString))
        {
            try
            {
                con.Open();
                var query = "UPDATE " +
                                "Ordem SET" +
                                "  Data = @Data          " +
                                ", Quantidade = @Quantidade    " +
                                ", Valor =  @Valor         " +
                                ",  QtdAparente = @QtdAparente          " +
                                ", QtdDisponivel = @QtdDisponivel    " +
                                ", QtdCancelada =  @QtdCancelada         " +
                                ", ValorDisponivel =  @ValorDisponivel         " +
                            "WHERE " +
                                "Id = " + ordem.Id;
                con.Execute(query, ordem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }

    public void Excluir(int id)
    {
        var connectionString = _configuration.GetConnectionString("RomarinhoConnection");

        using (var con = new MySqlConnection(connectionString))
        {
            try
            {
                con.Open();
                var query = "DELETE FROM " +
                                "Ordem " +
                            "WHERE " +
                                "Id = " + id;
                con.Execute(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }

    public Ordem PegarPorId(int id)
    {
        var connectionString = _configuration.GetConnectionString("RomarinhoConnection");

        using (var con = new MySqlConnection(connectionString))
        {
            try
            {
                con.Open();

                return con.QuerySingleOrDefault<Ordem>($"SELECT * FROM Ordem WHERE Id = { id }", commandType: System.Data.CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }

    public IEnumerable<Ordem> PegarPorIdUsuario(int idUsuario)
    {
        var connectionString = _configuration.GetConnectionString("RomarinhoConnection");

        using (var con = new MySqlConnection(connectionString))
        {
            try
            {
                con.Open();

                return con.Query<Ordem>($"SELECT * FROM Ordem WHERE IdUsuario = { idUsuario }", commandType: System.Data.CommandType.Text).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }

    public IEnumerable<Ordem> PegarTodas()
    {
        var connectionString = _configuration.GetConnectionString("RomarinhoConnection");

        using (var con = new MySqlConnection(connectionString))
        {
            try
            {
                con.Open();

                return con.Query<Ordem>($"SELECT * FROM Ordem", commandType: System.Data.CommandType.Text).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}

