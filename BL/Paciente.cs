using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Paciente
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JalarconNetCoreContext context = new DL.JalarconNetCoreContext())
                {
                    var query = context.Pacientes.FromSqlRaw("GetAllPaciente").ToList();
                    result.Objects = new List<object>();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            ML.Paciente paciente = new ML.Paciente();
                            paciente.IdPaciente = obj.IdPaciente;
                            paciente.Nombre = obj.Nombre;
                            paciente.ApellidoPaterno = obj.ApellidoPaterno;
                            paciente.ApellidoMaterno = obj.ApellidoMaterno;
                            result.Objects.Add(paciente);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La tabla paciente esta vacia";

                    }
                }

            }
            catch (Exception ex) { 
            result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;

        }
    }
}
