using System;
using System.Collections.Generic;

namespace PLIdentity;

public partial class Empleado
{
    public string NumeroEmpleado { get; set; } = null!;

    public string? Rfc { get; set; }

    public string? Nombre { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public string? Nss { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public byte[]? Foto { get; set; }

    public string? IdEmpresa { get; set; }
}
