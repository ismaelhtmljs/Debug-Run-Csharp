using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            // fondo de color para el programa
            Console.ForegroundColor = ConsoleColor.Green;
            // ASCII ART
            Console.WriteLine(@"
                ____    ____ ____  __ __   ___     ____  __ __ __  __      ___  __  __  __  ___  ____  ____ 
                || \\  ||    || )) || ||  // \\    || \\ || || ||\ ||     //   (( \ ||  || // \\ || \\ || \\  
                ||  )) ||==  ||=)  || || (( ___    ||_// || || ||\\||    ((     \\  ||==|| ||=|| ||_// ||_//  
                ||_//  ||___ ||_)) \\_//  \\_||    || \\ \\_// || \||     \\__ \_)) ||  || || || || \\ ||    

                                Version : Beta 2.5  By : Ismaelxd74    Github : ismaelhtmljs 
                                    [-]puedes entrar a ver el repositorio en mi github
                                             [*]https://github.com/ismaelhtmljs
            ");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Para salir del programa escriba 'exit'");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[1]Depurar");
            Console.WriteLine("[2]Ver Archivos dentro del proyecto");
            Console.WriteLine("[3]Moverse de escritorio");
            Console.WriteLine("[4]Crear Proyecto");

            string respuesta = Console.ReadLine();

            if (respuesta == "1")
            {
                string depurar_string = "dotnet run";
                EjecutarComando(depurar_string);
                LimpiarConsola();
            }
            
            else if (respuesta == "2")
            {
                Ver_archivos();
                LimpiarConsola();
            }

            else if(respuesta == "3")
            {
                Moverse_directorio();
            }

            else if(respuesta == "4")
            {
                // iniciar bucle para segunda lista
                while(true)
                {
                    Console.Clear();
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Advertencia : Debe tener instalado .NET SDK (Software Development Kit), puede instalarlo por este enlace : https://dotnet.microsoft.com/es-es/download/dotnet");
                    Console.ForegroundColor= ConsoleColor.Cyan;
                    Console.WriteLine("¿Que tipo de proyecto desea crear?");
                    
                    // lista
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[1]Aplicacion de Consola");
                    Console.WriteLine("[2]WindosForm");
                    Console.WriteLine("[3]Web");
                    Console.WriteLine("[4]WebApi");
                    Console.WriteLine("[5]Aplicacion de Escritorio");
                    Console.WriteLine("[6]Regresar al principio");
                    string respuesta_2 = Console.ReadLine();

                    // condicion que verifica la respuesta
                    if (respuesta_2 == "1")
                    {
                        string console_command = "dotnet new console -n MiAplicacionConsola";
                        EjecutarComando(console_command);
                        LimpiarConsola();
                    }

                    else if (respuesta_2 == "2")
                    {
                        string windowsform_command = "dotnet new winforms -n MiAppWinForms";
                        EjecutarComando(windowsform_command);
                        LimpiarConsola();
                    }

                    else if(respuesta_2 == "3")
                    {
                        string web_command = "dotnet new web -n MiAplicacionWeb";
                        EjecutarComando(web_command);
                        LimpiarConsola();
                    }

                    else if (respuesta_2 == "4")
                    {
                        string web_api_command = "dotnet new webapi -n MiApi";
                        EjecutarComando(web_api_command);
                        LimpiarConsola();
                    }

                    else if (respuesta_2 == "5")
                    {
                        string wpf_command = "dotnet new wpf -n MiAppWPF";
                        EjecutarComando(wpf_command);
                        LimpiarConsola();
                    }

                    else if (respuesta_2 == "6")
                    {
                        LimpiarConsola();
                        break;
                    }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No existe la opcion que se coloco");
                        Console.ForegroundColor = ConsoleColor.Green;
                        LimpiarConsola();
                    }
                }
            }

            else if (respuesta == "exit")
            {
                Finish_Program finish_Program = new Finish_Program();
                finish_Program.Finish_Program_view();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No existe la opcion que se coloco");
                Console.ForegroundColor = ConsoleColor.Green;
                LimpiarConsola();
            }
        }
    }

    // Ejecutor de Comandos
    static void EjecutarComando(string comando)
    {
        ProcessStartInfo processStartInfo = new ProcessStartInfo()
        {
            FileName = "cmd.exe",
            Arguments = $"/C {comando}",
            UseShellExecute = true,
            CreateNoWindow = false,
        };

        // depuracion
        Process.Start(processStartInfo);
    }

    // Ver Archivos
    static void Ver_archivos()
    {
        string directorio = Directory.GetCurrentDirectory();
        string[] archivos = Directory.GetFileSystemEntries(directorio);

        Console.WriteLine("\nArchivos en el directorio:");
        foreach (string archivo in archivos)
        {
            Console.WriteLine(archivo);
        }
    }

    static void Moverse_directorio()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("EJEMPLO : C:/Ruta/de/su/archivo");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Coloque la ruta en la que desea moverse");
        string ruta = Console.ReadLine();
        ruta = ruta.Replace('/', '\\');

        // verificar si la ruta existe
        if (Directory.Exists(ruta))
        {
            Directory.SetCurrentDirectory(ruta);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"¡Ahora estás en: {Directory.GetCurrentDirectory()}!");
            Console.ForegroundColor = ConsoleColor.Green;
            LimpiarConsola();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("El directorio no existe. Asegúrate de que la ruta sea correcta.");
            Console.ForegroundColor = ConsoleColor.Green;
            LimpiarConsola();
        }
    }

    // limpiar consola
    static void LimpiarConsola()
    {
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }
}

class Finish_Program
{
    public void Finish_Program_view()
    {
        // Mensaje que se muestra para terminar el programa
        Console.WriteLine("Presione cualquir tecla para finalizar el programa");
        Console.ReadLine();
        Environment.Exit(0);
    }
}