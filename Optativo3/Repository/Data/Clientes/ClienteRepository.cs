using Dapper;
using Optativo3.Repository.Data.Clientes;
using Optativo3.Repository.Data.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Clientes
{
    public class ClienteRepository : IClienteRepository
    {
        IDbConnection connection;

        public ClienteRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public bool add(ClienteModel clienteModel)
        {
            try
            {
                connection.Execute("INSERT INTO Cliente (Id_banco, Nombre, Apellido, Documento, Direccion, Email, Celular, Estado) " +
                    "VALUES (@Id_banco, @Nombre, @Apellido, @Documento, @Direccion, @Email, @Celular, @Estado)", clienteModel);
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al agregar cliente: {ex.Message}");
                return false;
            }
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            try
            {
                return connection.Query<ClienteModel>("SELECT * FROM Cliente");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener clientes: {ex.Message}");
                return new List<ClienteModel>();
            }
        }

        public bool delete(int id)
        {
            try
            {
                connection.Execute("DELETE FROM Cliente WHERE Id = @Id", new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar cliente: {ex.Message}");
                return false;
            }
        }

        public bool update(ClienteModel clienteModel)
        {
            try
            {
                connection.Execute("UPDATE Cliente SET " +
                    "id_banco = @Id_banco, " +
                    "nombre = @Nombre, " +
                    "apellido = @Apellido, " +
                    "documento = @Documento, " +
                    "direccion = @Direccion, " +
                    "dmail = @Email, " +
                    "celular = @Celular, " +
                    "estado = @Estado " +
                    "WHERE Id = @Id", clienteModel);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar cliente: {ex.Message}");
                return false;
            }
        }
    }
}
