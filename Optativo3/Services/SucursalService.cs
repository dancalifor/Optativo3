using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Optativo3.Modelos;

public class SucursalRepository
{
    private readonly IDbConnection _connection;

    public SucursalRepository(IDbConnection connection)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
    }

    public void InsertarSucursal(Sucursal sucursal)
    {
        string query = "INSERT INTO Sucursal (Descripcion, Direccion, Telefono, Whatsapp, Mail, Estado) VALUES (@Descripcion, @Direccion, @Telefono, @Whatsapp, @Mail, @Estado)";
        _connection.Execute(query, sucursal);
    }

    public Sucursal ObtenerSucursalPorId(int id)
    {
        string query = "SELECT * FROM Sucursal WHERE Id = @Id";
        return _connection.QuerySingleOrDefault<Sucursal>(query, new { Id = id });
    }

    public IEnumerable<Sucursal> ObtenerTodasLasSucursales()
    {
        string query = "SELECT * FROM Sucursal";
        return _connection.Query<Sucursal>(query);
    }

    public void ActualizarSucursal(Sucursal sucursal)
    {
        string query = "UPDATE Sucursal SET Descripcion = @Descripcion, Direccion = @Direccion, Telefono = @Telefono, Whatsapp = @Whatsapp, Mail = @Mail, Estado = @Estado WHERE Id = @Id";
        _connection.Execute(query, sucursal);
    }

