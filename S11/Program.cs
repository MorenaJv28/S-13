using Microsoft.Extensions.Options;
using S11.Modelo;
using S11.Data;
using S11.DAO;

using (var bd = new Contexto())
{
    bd.Database.EnsureCreated();

    int Option = -1;
    while (Option != 0)
    {
        Console.Write("\n\tMenu  \n1. Agregar estudiante \n2. Actualizar estudiante \n3. Ver lista de Estudiantes \n4. Elimnar  \n5. Salir \n>> ");
        Option = Convert.ToInt32(Console.ReadLine());
        #region Optioms
        switch (Option)
        {
            #region AgregarEstudiante
            case 1:
                bool agregarEstudiante = true;
                while (agregarEstudiante)
                {
                    Console.WriteLine("\n\tAgregar estudiante");
                    Console.WriteLine("Ingrese el nombre del estudiante: ");
                    var Nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese el apellido del estudiante: ");
                    var Apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese la edad del estudiante (Solo números enteros): ");
                    int Edad = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese el sexo del estudiante (Usar F= Femenino o Usar M= Masculino)");
                    var Sexo = Console.ReadLine();
                    var Estudiante = new estudiante()
                    {
                        Nombres = Nombre,
                        Apellidos = Apellido,
                        Edad = Edad,
                        Sexo = Sexo
                    };
                    bd.Add(Estudiante);
                    bd.SaveChanges();
                    Console.WriteLine("Registro completado");
                    Console.WriteLine("¿Desea agregar otro estudiante? (s/n): ");
                    string respuesta = Console.ReadLine().ToLower().Trim();

                    switch (respuesta)
                    {
                        case "s":
                            break;
                        case "n":
                            agregarEstudiante = false;
                            break;
                        default:
                            Console.WriteLine("Respuesta no válida. Por favor, ingrese 's' o 'n'.");
                            break;
                    }
                }
                break;
            #endregion
            #region ActualizarEstudiante
            case 2:
                Console.WriteLine("\n\tLista de Estudiantes:");
                var estudiantes = bd.Estudiante.ToList();

                foreach (var estudiante in estudiantes)
                {
                    Console.WriteLine($"ID: {estudiante.Id}, Nombres: {estudiante.Nombres}, Apellidos: {estudiante.Apellidos}, Edad: {estudiante.Edad}, Sexo: {estudiante.Sexo}");
                }

                bool ActualizarEstudiante = true;
                while (ActualizarEstudiante)
                {
                    Console.WriteLine("\n\tActualizar estudiante");
                    Console.WriteLine("Ingrese el ID del estudiante que desea actualizar (o si desea volver a menu principal ingrese 0): ");
                    int estudianteId = Convert.ToInt32(Console.ReadLine());

                    if (estudianteId == 0)
                    {
                        ActualizarEstudiante = false;
                        break;
                    }

                    var estudiante = bd.Estudiante.Find(estudianteId);
                    if (estudiante == null)
                    {
                        Console.WriteLine("Estudiante no encontrado.");
                    }
                    else
                    {
                        Console.Write($@" favor ingresa el campo a actualizar
1- Nombres {estudiante.Nombres}
2- Apellidos {estudiante.Apellidos}
3- Edad {estudiante.Edad}
4- Sexo {estudiante.Sexo}

>> ");
                        var LR = int.Parse(Console.ReadLine());
                        switch (LR)
                        {
                            case 1:
                                Console.WriteLine("Ingresa el  nombre del estudiante: ");
                                estudiante.Nombres = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("Ingresa el  apellido del estudiante: ");
                                estudiante.Apellidos = Console.ReadLine();
                                break;
                            case 3:
                                Console.WriteLine("Ingresa la  edad del estudiante: ");
                                estudiante.Edad = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 4:
                                Console.WriteLine("Ingresa el sexo del estudiante (Usar F= Femenino o M= Masculino): ");
                                estudiante.Sexo = Console.ReadLine();
                                break;
                            default:
                                Console.WriteLine("Opción no válida.");
                                break;
                        }

                        bd.Update(estudiante);
                        bd.SaveChanges();
                        Console.WriteLine("Estudiante actualizado correctamente.");
                    }
                }
                break;
            #endregion

            #region Ver Listado
            case 3:
                Console.WriteLine("\nListado de Estudiantes");
                bool Listado = true;
                while (Listado)
                {
                    var Estudiantes = bd.Estudiante.ToList();
                    const int idL = 5;
                    const int nombreL = 20;
                    const int apellidoL = 20;
                    const int edadL = 5;
                    const int sexoL = 5;

                    string format = $"{{0, -{idL}}}{{1, -{nombreL}}}{{2, -{apellidoL}}}{{3, -{edadL}}}{{4, -{sexoL}}}";

                    Console.WriteLine(string.Format(format, "ID", "Nombre", "Apellido", "Edad", "Sexo"));
                    Console.WriteLine(new string('-', idL + nombreL + apellidoL + edadL + sexoL));

                    foreach (var estudiante in Estudiantes)
                    {
                        Console.WriteLine(string.Format(format, estudiante.Id, estudiante.Nombres, estudiante.Apellidos, estudiante.Edad, estudiante.Sexo));
                    }
                    Console.WriteLine();
                    Console.WriteLine("¿Desea ir al menú principal? (s/n): ");
                    string respuesta2 = Console.ReadLine().ToLower().Trim();
                    
                    switch (respuesta2)
                    {
                        case "s":
                            Listado = false;
                            break;
                        case "n":
                            break;
                        default:
                            Console.WriteLine("Respuesta no válida. Por favor, ingrese 's' o 'n'.");
                            break;
                    }
                }

                break;
            #endregion
            #region Delete R
            case 4:
                Console.WriteLine("\nEliminar Registro");
                bool EliminarRe = true;
                while (EliminarRe)
                {
                    var Estudiantes = bd.Estudiante.ToList();
                    const int idL = 5;
                    const int nombreL = 20;
                    const int apellidoL = 20;
                    const int edadL = 5;
                    const int sexoL = 5;

                    string format = $"{{0, -{idL}}}{{1, -{nombreL}}}{{2, -{apellidoL}}}{{3, -{edadL}}}{{4, -{sexoL}}}";

                    Console.WriteLine(string.Format(format, "ID", "Nombre", "Apellido", "Edad", "Sexo"));
                    Console.WriteLine(new string('-', idL + nombreL + apellidoL + edadL + sexoL));

                    foreach (var estudiante in Estudiantes)
                    {
                        Console.WriteLine(string.Format(format, estudiante.Id, estudiante.Nombres, estudiante.Apellidos, estudiante.Edad, estudiante.Sexo));
                    }
                    Console.WriteLine();
                    Console.Write("Ingrese el ID del registro que desea eliminar o '0' para volver al menú : ");
                    if (int.TryParse(Console.ReadLine(), out int idEliminar) && idEliminar > 0)
                    {
                        var estudianteEliminar = bd.Estudiante.FirstOrDefault(e => e.Id == idEliminar);
                        if (estudianteEliminar != null)
                        {
                            bd.Estudiante.Remove(estudianteEliminar);
                            bd.SaveChanges();
                            Console.WriteLine();
                            Console.WriteLine("Estudiante eliminado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("No se encontro el registro. Por favor, ingrese un ID válido.");
                        }
                    }
                    else if (idEliminar == 0)
                    {
                        EliminarRe = false;
                    }
                    else
                    {
                        Console.WriteLine("no es válido. Por favor, ingrese un número entero positivo o '0' para volver al menú");
                    }
                }
                break;
            #endregion
            #region exit
            case 5:
                Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                Option = 0;
                break;
            default:
                Console.WriteLine("Opción no válida. Por favor, elige una opción válida.");
                break;
                #endregion
        }
    }
}
#endregion