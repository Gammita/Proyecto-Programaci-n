using System;
using System.Collections.Generic;

namespace AdmisionInstitucion
{
    class Program
    {
        // Lista para almacenar los correos electrónicos registrados
        static List<string> correosRegistrados = new List<string>();

        static void Main(string[] args)
        {
            while (true)
            {
                // Variables para almacenar los datos del formulario
                string nombre, apellido, email;
                DateTime fechaNacimiento;

                // Simulamos el llenado del formulario por parte del usuario
                Console.WriteLine("Por favor, complete el formulario de inscripción:");

                Console.Write("Nombre: ");
                nombre = Console.ReadLine();

                Console.Write("Apellido: ");
                apellido = Console.ReadLine();

                // Validar que el correo no esté registrado previamente
                while (true)
                {
                    Console.Write("Email: ");
                    email = Console.ReadLine();

                    if (!correosRegistrados.Contains(email))
                    {
                        correosRegistrados.Add(email); // Registrar el correo electrónico
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Este correo ya ha sido registrado. Por favor, utilice otro.");
                    }
                }

                Console.Write("Fecha de Nacimiento (YYYY-MM-DD): ");
                if (DateTime.TryParse(Console.ReadLine(), out fechaNacimiento))
                {
                    // Verificamos si el formulario es válido
                    if (!string.IsNullOrWhiteSpace(nombre) &&
                        !string.IsNullOrWhiteSpace(apellido) &&
                        fechaNacimiento != DateTime.MinValue)
                    {
                        string asunto = "Proceso de Admisión - Siguientes Pasos";
                        string mensaje = $"Hola {nombre},\n\n" +
                                         "Gracias por completar el formulario de inscripción. Por favor, siga las siguientes instrucciones para completar el proceso de admisión.\n\n" +
                                         "Saludos,\n" +
                                         "Institución Educativa";

                        // Simula el envío de un correo electrónico
                        Console.WriteLine($"Enviando correo a: {email}");
                        Console.WriteLine($"Asunto: {asunto}");
                        Console.WriteLine($"Mensaje: {mensaje}");
                        Console.WriteLine("Correo enviado con éxito.");

                        // Mensaje con los documentos requeridos
                        Console.WriteLine("\nPara seguir con el proceso de admisión, por favor traiga los siguientes documentos de forma física:");
                        Console.WriteLine("a) Fotocopia del documento de identificación del estudiante.");
                        Console.WriteLine("b) Fotocopia del documento de identificación de la persona encargada legal.");
                        Console.WriteLine("c) Informe de calificaciones de sétimo y octavo nivel.");
                        Console.WriteLine("d) Documento probatorio de residencia.");
                        Console.WriteLine("e) En caso de tener apoyo curricular, debe traer alguna constancia.");
                    }
                    else
                    {
                        Console.WriteLine("Formulario incompleto. No se tomará en cuenta para el proceso de admisión.");
                    }
                }
                else
                {
                    Console.WriteLine("Fecha de nacimiento no válida.");
                }

                // Pregunta al usuario si desea continuar
                Console.WriteLine("¿Desea continuar con otra solicitud? (S/N)");
                string respuesta = Console.ReadLine();

                if (respuesta.ToLower() != "s")
                {

                    // Mostrar los requisitos generales para seguir con el proceso
                    Console.WriteLine("\nRequisitos generales para seguir con el proceso de admisión:");
                    Console.WriteLine("1. Ubicación residencial (40%): De acuerdo con la ubicación de residencia del estudiante se toma en cuenta el porcentaje de 5% a 40%, entre más cerca resida de la institución el porcentaje será más alto.");
                    Console.WriteLine("2. Demostración de aptitudes vocacionales (15%): El estudiante realiza una prueba las cuales son dadas por la carrera la cual escogió en dicho proceso.");
                    Console.WriteLine("3. Entrevista (15%): Esta la realiza cada especialidad para los postulantes para demostrar sus aptitudes.");
                    Console.WriteLine("4. Promedio de notas (20%): Se tomará un promedio de nota del estudiante de las materias básicas de años pasados para realizar el porcentaje que corresponde.");
                    Console.WriteLine("5. Conducta (10%): Se toma en cuenta la nota de conducta obtenida del por el estudiante de los años anteriores.");

                    // Solicitar valores de cada requisito al usuario
                    Console.WriteLine("\nPor favor, ingrese los valores de los siguientes requisitos:");

                    Console.Write("Ubicación residencial (5-40%): ");
                    int ubicacionResidencial = int.Parse(Console.ReadLine());

                    Console.Write("Demostración de aptitudes vocacionales (0-15%): ");
                    int aptitudesVocacionales = int.Parse(Console.ReadLine());

                    Console.Write("Entrevista (0-15%): ");
                    int entrevista = int.Parse(Console.ReadLine());

                    Console.Write("Promedio de notas (0-20%): ");
                    int promedioNotas = int.Parse(Console.ReadLine());

                    Console.Write("Conducta (0-10%): ");
                    int conducta = int.Parse(Console.ReadLine());

                    // Calcular el puntaje total
                    int puntajeTotal = ubicacionResidencial + aptitudesVocacionales + entrevista + promedioNotas + conducta;

                    // Determinar si el estudiante fue admitido
                    if (puntajeTotal >= 70)
                    {
                        Console.WriteLine($"\nEl estudiante ha sido admitido con un puntaje total de: {puntajeTotal}%");
                        Console.WriteLine("¡Felicitaciones!");

                        // Pregunta al usuario admitido si está listo para el ingreso
                        Console.WriteLine("¿Está listo para el ingreso? (SI/No)");
                        string respuestaIngreso = Console.ReadLine();

                        if (respuestaIngreso.ToLower() == "si" || respuestaIngreso.ToLower() == "no")
                        {
                            break; // Salir del bucle si la respuesta es "SI" o "No"
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nEl estudiante no ha sido admitido. Puntaje total: {puntajeTotal}%");
                        Console.WriteLine("Lo sentimos.");
                        break; // Salir del bucle si el estudiante no fue admitido
                    }
                }
            }
        }
    }
}
