using System;
using System.Collections.Generic;

namespace DL;

public partial class RecetaMedica
{
    public int IdReceta { get; set; }

    public int IdPaciente { get; set; }

    public DateTime FechaDeConsulta { get; set; }

    public string Diagnostico { get; set; } = null!;

    public string NombreMedico { get; set; } = null!;

    public string NotasAdicionales { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
    public string NombrePaciente { get; set; }
    public string ApellidoPaternoPaciente { get; set; }
    public string ApellidoMaternoPaciente { get; set; }
}
