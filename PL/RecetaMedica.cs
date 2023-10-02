using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class RecetaMedica
    {

        public static void GetAll()
        {
            ML.Result result = BL.RecetaMedica.GetAll();

            Console.WriteLine("Select * ");


            if (result.Correct)
            {

                foreach (ML.RecetaMedica recetaMedica in result.Objects)
                {


                    Console.WriteLine("El IdReceta es: " + recetaMedica.IdReceta);
                    Console.WriteLine("El IdPaciente: " + recetaMedica.Paciente.IdPaciente);
                    Console.WriteLine("La fecha de consulta es: " + recetaMedica.FechaDeConsulta);
                    Console.WriteLine("El diagnostico es: " + recetaMedica.Diagnostico);
                    Console.WriteLine("El nombre del medico es: " + recetaMedica.NombreMedico);
                    Console.WriteLine("Las notas adicionales son: " + recetaMedica.NotasAdicionales);
                    Console.WriteLine("El Nombre del paciente es: " + recetaMedica.Paciente.Nombre);
                    Console.WriteLine("El apellido paterno del paciente es: " + recetaMedica.Paciente.ApellidoPaterno);
                    Console.WriteLine("El apellido materno del paciente es: " + recetaMedica.Paciente.ApellidoMaterno);
                    Console.WriteLine("---------------------------------------------------------------------");

                }
            }
            else
            {
                Console.WriteLine("Error al mostrar" + result.ErrorMessage);
            }

        }
    


    public static void GetById()
    {

        Console.WriteLine("Ingresa el ID de la receta para buscarlo");
        int recetaMedica = int.Parse(Console.ReadLine());

        ML.Result result = BL.RecetaMedica.GetById(recetaMedica);



        if (result.Correct)
        {

            ML.RecetaMedica recetaMedica1 = (ML.RecetaMedica)result.Object;  //unboxing
            Console.WriteLine("El IdReceta es: " + recetaMedica1.IdReceta);
            Console.WriteLine("El IdPaciente: " + recetaMedica1.Paciente.IdPaciente);
            Console.WriteLine("La fecha de consulta es: " + recetaMedica1.FechaDeConsulta);
            Console.WriteLine("El diagnostico es: " + recetaMedica1.Diagnostico);
            Console.WriteLine("El nombre del medico es: " + recetaMedica1.NombreMedico);
            Console.WriteLine("Las notas adicionales son: " + recetaMedica1.NotasAdicionales);
            Console.WriteLine("El Nombre del paciente es: " + recetaMedica1.Paciente.Nombre);
            Console.WriteLine("El apellido paterno del paciente es: " + recetaMedica1.Paciente.ApellidoPaterno);
            Console.WriteLine("El apellido materno del paciente es: " + recetaMedica1.Paciente.ApellidoMaterno);
            Console.WriteLine("---------------------------------------------------------------------");


        }
        else
        {
            Console.WriteLine("Error al mostrar" + result.ErrorMessage);
        }

    }

        public static void Add()
        {
            ML.RecetaMedica recetaMedica = new ML.RecetaMedica();
            recetaMedica.Paciente = new ML.Paciente();

            Console.WriteLine("Ingresa el Id del paciente");
            recetaMedica.Paciente.IdPaciente = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la fecha de consulta dd-mm-yyyy");
            recetaMedica.FechaDeConsulta = Console.ReadLine();

            Console.WriteLine("Ingresa el diagnostico");
            recetaMedica.Diagnostico = Console.ReadLine();

            Console.WriteLine("Ingresa el nombre del medico");
            recetaMedica.NombreMedico = Console.ReadLine();

            Console.WriteLine("Ingresa las notas adicionales");
            recetaMedica.NotasAdicionales = Console.ReadLine();


            ML.Result result = BL.RecetaMedica.AddEF(recetaMedica);

            if (result.Correct)
            {
                Console.WriteLine("Usuario agregado exitosamente");
            }
            else
            {
                Console.WriteLine("Usuario no agregado" + result.ErrorMessage);
            }

        }

        public static void Delete()
        {
           
            Console.WriteLine("Borrar usuario");

            Console.WriteLine("Ingresa el ID del usuario que desea borrar");
            int IdReceta = int.Parse(Console.ReadLine());

            ML.Result result = BL.RecetaMedica.Delete(IdReceta);

            if (result.Correct)
            {
                Console.WriteLine("Usuario borrado correctamente");
            }
            else
            {
                Console.WriteLine("Error al borrar usuario" + result.ErrorMessage);
            }

        }

        public static void Update()
        {
            ML.RecetaMedica recetaMedica = new ML.RecetaMedica();
            recetaMedica.Paciente = new ML.Paciente();

            Console.WriteLine("Actualizar usuario");

            Console.WriteLine("Ingresa el Id de la receta");
            recetaMedica.IdReceta = int.Parse(Console.ReadLine());


            Console.WriteLine("Ingresa el Id del paciente");
            recetaMedica.Paciente.IdPaciente = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa la fecha de consulta dd-mm-yyyy");
            recetaMedica.FechaDeConsulta = Console.ReadLine();

            Console.WriteLine("Ingresa el diagnostico");
            recetaMedica.Diagnostico = Console.ReadLine();

            Console.WriteLine("Ingresa el nombre del medico");
            recetaMedica.NombreMedico = Console.ReadLine();

            Console.WriteLine("Ingresa las notas adicionales");
            recetaMedica.NotasAdicionales = Console.ReadLine();


            ML.Result result = BL.RecetaMedica.Update(recetaMedica);

            if (result.Correct)
            {
                Console.WriteLine("Usuario actualizado exitosamente");
            }
            else
            {
                Console.WriteLine("Usuario no actualizado" + result.ErrorMessage);
            }

        }

    }
}
