using Dapper;
using Optativo3.Repository.Data.Connection;
using System.Data;

namespace Repository.Data.Facturas
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly IDbConnection connection;

        public FacturaRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public bool add(FacturaModel facturaModel)
        {
            try
            {
                connection.Execute("INSERT INTO Factura (Id, Id_cliente,Nro_factura, Total, Fecha_hora, Total_iva5, Total_iva10, Total_iva, Total_letras, Sucursal) " +
                    "VALUES (@Id, @Id_cliente, @Nro_factura,@Total, @Fecha_hora, @Total_iva5, @Total_iva10, @Total_iva, @Total_letras, @Sucursal)", facturaModel);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<FacturaModel> GetAll()
        {
            return connection.Query<FacturaModel>("SELECT * FROM factura");
        }

        public bool delete(int id)
        {
            try
            {
                connection.Execute($"DELETE FROM Factura WHERE Id = {id}");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(FacturaModel facturaModel)
        {
            try
            {
                connection.Execute("UPDATE Factura SET " +
                    "Id_cliente = @Id_cliente, " +
                    "Total = @Total, " +
                    "Fecha_hora = @Fecha_hora " +
                    "WHERE Id = @Id", facturaModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
