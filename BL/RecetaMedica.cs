using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class RecetaMedica
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JalarconNetCoreContext context = new DL.JalarconNetCoreContext())
                {

                    var query = context.RecetaMedicas.FromSqlRaw("RecetaMedicaGetAll").ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.RecetaMedica recetaMedica = new ML.RecetaMedica();
                            recetaMedica.Paciente = new ML.Paciente();
                            recetaMedica.IdReceta = obj.IdReceta;
                              recetaMedica.Paciente.IdPaciente = obj.IdPaciente;
                          recetaMedica.FechaDeConsulta = Convert.ToString(obj.FechaDeConsulta);
                            recetaMedica.Diagnostico = obj.Diagnostico;
                            recetaMedica.NombreMedico = obj.NombreMedico;
                            recetaMedica.NotasAdicionales = obj.NotasAdicionales;
                            recetaMedica.Paciente.Nombre = obj.NombrePaciente;
                            recetaMedica.Paciente.ApellidoPaterno = obj.ApellidoPaternoPaciente;
                            recetaMedica.Paciente.ApellidoMaterno = obj.ApellidoMaternoPaciente;

                            result.Objects.Add(recetaMedica);
                        }

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La tabla alumno no contiene registros";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;
        }


        public static ML.Result GetById(int IdReceta)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JalarconNetCoreContext context = new DL.JalarconNetCoreContext())
                {

                    var query = context.RecetaMedicas.FromSqlRaw($"RecetaMedicaGetById {IdReceta}").AsEnumerable().SingleOrDefault();
                    result.Objects = new List<object>();
                    if (query != null)
                    {

                        ML.RecetaMedica recetaMedica = new ML.RecetaMedica();
                        recetaMedica.Paciente = new ML.Paciente();
                        recetaMedica.IdReceta = query.IdReceta;
                        recetaMedica.Paciente.IdPaciente = query.IdPaciente;
                        recetaMedica.FechaDeConsulta = query.FechaDeConsulta.ToString("dd-MM-yyyy");
                        recetaMedica.Diagnostico = query.Diagnostico;
                        recetaMedica.NombreMedico = query.NombreMedico;
                        recetaMedica.NotasAdicionales = query.NotasAdicionales;
                        recetaMedica.Paciente.Nombre = query.NombrePaciente;
                        recetaMedica.Paciente.ApellidoPaterno = query.ApellidoPaternoPaciente;
                        recetaMedica.Paciente.ApellidoMaterno = query.ApellidoMaternoPaciente;

                        result.Object = recetaMedica;


                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "La tabla usuario no contiene registros";
                    }

                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;

        }

        public static ML.Result AddEF(ML.RecetaMedica recetaMedica)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JalarconNetCoreContext context = new DL.JalarconNetCoreContext())
                {


                    int rowAffected = context.Database.ExecuteSqlRaw($"RecetaMedicaAdd {recetaMedica.Paciente.IdPaciente},'{recetaMedica.FechaDeConsulta}', '{recetaMedica.Diagnostico}','{recetaMedica.NombreMedico}','{recetaMedica.NotasAdicionales}'");
                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;
        }


        public static ML.Result Delete(int IdReceta)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JalarconNetCoreContext context = new DL.JalarconNetCoreContext())
                {
                    int rowAffected = context.Database.ExecuteSqlRaw($"RecetaMedicaDelete {IdReceta}");
                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;

        }

        public static ML.Result Update(ML.RecetaMedica recetaMedica)
        {
            ML.Result result = new ML.Result();
            try
            {
                //Todo lo que se eje cute dnetro de using se libera al final, los recursos
                using (DL.JalarconNetCoreContext context = new DL.JalarconNetCoreContext())
                {


                    int rowAffected = context.Database.ExecuteSqlRaw($"RecetaMedicaUpdate {recetaMedica.IdReceta},{recetaMedica.Paciente.IdPaciente},'{recetaMedica.FechaDeConsulta}', '{recetaMedica.Diagnostico}','{recetaMedica.NombreMedico}','{recetaMedica.NotasAdicionales}'");
                    if (rowAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }


            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Exception = ex;
            }
            return result;

        }

    }
}
