using Logica;
using Obligatorio_P1;
using System;
using System.Threading;



class Program
{
    static Sistema miSistema = new Sistema();
    static void Main(string[] args)
    {
        
        try
        {
            miSistema.PrecargarDatos();
            // Mensaje inicial con colores y animación
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===================================");
            Console.WriteLine("   Bienvenido al Sistema de Gestión");
            Console.WriteLine("===================================");
            Console.ResetColor();

            Console.Write("Iniciando el sistema");

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(400);
                Console.Write(".");
            }

            Console.WriteLine();
            Thread.Sleep(1000);

            // Barra de carga simulada
            Console.Write("Cargando módulos: ");
            for (int i = 0; i <= 20; i++)
            {
                Console.Write("█");
                Thread.Sleep(100);
            }

            Thread.Sleep(1000);
            Console.Clear();

            // Mostrar escudo de seguridad antes del menú
            MostrarEscudo();
            Thread.Sleep(2000);
            Console.Clear();

            bool salir = false;

            while (!salir)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("===================================");
                Console.WriteLine("         MENÚ PRINCIPAL");
                Console.WriteLine("===================================");
                Console.ResetColor();

                Console.WriteLine("1. Listar Personas con activos");
                Console.WriteLine("2. Listar incidentes de una persona");
                Console.WriteLine("3. Ingresar nueva persona");
                Console.WriteLine("4. Listar activos sin backup");
                Console.WriteLine("0. Salir del sistema");
                Console.WriteLine("===================================");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Seleccione una opción: ");
                Console.ResetColor();

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        listarPersonasConActivos();
                        break;
                    case "2":
                        IncidentesDePersona();
                        break;
                    case "3":
                        altaPersona();
                        break;
                    case "4":
                        listarPersonasSinBackup();
                        break;
                    case "0":
                        salir = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Saliendo del sistema... ¡Hasta pronto!");
                        Console.ResetColor();
                        Thread.Sleep(1500);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción inválida. Presione una tecla para continuar...");
                        Console.ResetColor();
                        Console.ReadKey();
                        break;
                }

                Console.Clear();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error inesperado: {ex.Message}");
            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadKey();
        }
    }

    static void listarPersonasConActivos()
    {
        try
        {
            foreach (Persona persona in miSistema.personasConActivosAgrupadas())
            {
                Console.WriteLine("____________________");

                foreach (Activo act in miSistema.ObtenerActivosDe(persona))
                    Console.WriteLine($"Activo: {act}");

                Console.WriteLine("--------------------");
            }

            Console.WriteLine("\nPresione una tecla para volver al menú...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.ReadKey();
        }
    }

    static void IncidentesDePersona()
    {
        try
        {
            Console.WriteLine("Ingrese a la persona:");
            int cedula = int.Parse(Console.ReadLine());

            List<Incidente> incidentes = miSistema.incidentesPorActivo(cedula);

            Console.WriteLine($"Incidentes asociados:");
           
           
                foreach (Incidente inc in incidentes)
                {
                    Console.WriteLine($"ID: {inc.ToString()}");
                    Console.WriteLine("___________________________________________________");
                    
                }

            Console.WriteLine("\nPresione una tecla para volver al menú...");
            Console.ReadKey();
        }
        catch (Exception ex)
        { 
            Console.WriteLine($"Error al listar incidentes de la persona: {ex.Message}");
            Console.WriteLine("\nPresione una tecla para volver al menú...");
            Console.ReadKey();
        }
    }

    static void altaPersona()
    {
        try
        {

            Console.Clear();
            Console.WriteLine("Has elegido Dar un alta");
            Console.Write("Ingrese CI(sin puntos ni guiones): ");
            int dni = int.Parse(Console.ReadLine());
            Console.Write("Ingrese Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese Email: ");
            string email = Console.ReadLine();
            Console.Write("Ingrese Teléfono: ");
            int telefono = int.Parse(Console.ReadLine());

            // instanciamos la persona y la damos de alta

            Persona nuevaPersona = new Persona(dni, nombre, email, telefono);
            miSistema.altaPersona(nuevaPersona);

            Console.WriteLine("Persona agregada exitosamente.");
            Console.WriteLine("Presione una tecla para volver al menú...");
            Console.ReadKey();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al agregar persona: {ex.Message}");
            Console.WriteLine("\nPresione una tecla para volver al menú...");
            Console.ReadKey();
        }

    }

    static void listarPersonasSinBackup()
    {
        try
        {

            foreach (Activo act in miSistema.personasSinBackup())
            {
                Console.WriteLine($"Titular: {act.Cuenta.Titular}");
                Console.WriteLine($"Activo: {act}");
                Console.WriteLine("--------------------");
            }

            Console.WriteLine("\nPresione una tecla para volver al menú...");
            Console.ReadKey();

        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error al listar personas sin backup: {ex.Message}");
            Console.WriteLine("\nPresione una tecla para volver al menú...");
            Console.ReadKey();

        }
    }

    static void MostrarEscudo()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("        /\\");
        Console.WriteLine("       /  \\");
        Console.WriteLine("      / || \\");
        Console.WriteLine("     /  ||  \\");
        Console.WriteLine("    /   ||   \\");
        Console.WriteLine("   /    ||    \\");
        Console.WriteLine("   \\    ||    /");
        Console.WriteLine("    \\   ||   /");
        Console.WriteLine("     \\  ||  /");
        Console.WriteLine("      \\ || /");
        Console.WriteLine("       \\  /");
        Console.WriteLine("        \\/");
        Console.ResetColor();
        Console.WriteLine("   Protección y Seguridad Activa");
    }
}