using Optativo3.Modelos;

public class SucursalService
{
    private readonly SucursalRepository _sucursalRepository;

    public SucursalService(SucursalRepository sucursalRepository)
    {
        _sucursalRepository = sucursalRepository ?? throw new ArgumentNullException(nameof(sucursalRepository));
    }

    public void InsertarSucursal(Sucursal sucursal)
    {
        if (ValidarSucursal(sucursal))
        {
            _sucursalRepository.InsertarSucursal(sucursal);
        }
    }

    public Sucursal ObtenerSucursalPorId(int id)
    {
        return _sucursalRepository.ObtenerSucursalPorId(id);
    }

    public IEnumerable<Sucursal> ObtenerTodasLasSucursales()
    {
        return _sucursalRepository.ObtenerTodasLasSucursales();
    }

    public void ActualizarSucursal(Sucursal sucursal)
    {
        if (ValidarSucursal(sucursal))
        {
            _sucursalRepository.ActualizarSucursal(sucursal);
        }
    }


    private bool ValidarSucursal(Sucursal sucursal)
    {
        if (string.IsNullOrEmpty(sucursal.Direccion) || sucursal.Direccion.Length < 10)
        {
            Console.WriteLine("La dirección debe tener al menos 10 caracteres.");
            return false;
        }

        if (!IsValidEmail(sucursal.Mail))
        {
            Console.WriteLine("El correo electrónico no es válido.");
            return false;
        }

        return true;
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
