public record Solicitud
{
    public int Id { get; set; }
    public string? IdentificacionCliente { get; set; }
    public string? NombreCompletoCliente { get; set; }
    public int Plazo { get; set; }
    public long Monto { get; set; }
    public long MontoAprobado { get; set; }
    public DateTime FechaAprobacion { get; set; }
    public int  EstadoId { get; set; }
    public string? PrimerNombre { get; set; }
    public string? PrimerApellidoCliente { get; set; }
    public string? SegundoApellidoCliente { get; set; }
}

public class SolicitudesDB
{
    private static List<Solicitud> _solicitudes = new List<Solicitud>()
   {
     new Solicitud{ Id=1, NombreCompletoCliente="Cristian Correa", Monto = 15000000, Plazo=15 },
     new Solicitud{ Id=2, NombreCompletoCliente="Camilo Correa", Monto = 10000000, Plazo=10 },
     new Solicitud{ Id=3, NombreCompletoCliente="Pedro Perez", Monto = 24000000, Plazo=24 }
   };

    public static List<Solicitud> GetSolicitudes()
    {
        return _solicitudes;
    }

    public static Solicitud? GetSolicitud(int id)
    {
        return _solicitudes.SingleOrDefault(pizza => pizza.Id == id);
    }

    public static Solicitud CreateSolicitud(Solicitud solicitud)
    {
        _solicitudes.Add(solicitud);
        return solicitud;
    }

    public static Solicitud UpdateSolicitud(Solicitud update)
    {
        _solicitudes = _solicitudes.Select(solicitud =>
        {
            if (solicitud.Id == update.Id)
            {
                solicitud.NombreCompletoCliente = update.NombreCompletoCliente;
            }
            return solicitud;
        }).ToList();
        return update;
    }

    public static void RemovePizza(int id)
    {
        _solicitudes = _solicitudes.FindAll(solicitud => solicitud.Id == id).ToList();
    }
}