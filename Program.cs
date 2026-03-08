using System;

class Program
{
    static void Main()
    {
        // Array de libros disponibles en la biblioteca
        string[] librosDisponibles = new string[5];
        for (int i = 0; i < 5; i++)
            librosDisponibles[i] = "";

        // Array de libros prestados (máximo 3)
        string[] librosPrestados = new string[3];
        for (int i = 0; i < 3; i++)
            librosPrestados[i] = "";

        bool salir = false;

        Console.WriteLine("=== Sistema de Gestión de Biblioteca ===\n");

        while (!salir)
        {
            MostrarMenu();
            string accion = Console.ReadLine();

            // Normalización de entrada: convertir a minúsculas para insensibilidad a mayúsculas
            string accionNormalizada = NormalizarEntrada(accion);

            switch (accionNormalizada)
            {
                case "añadir":
                case "1":
                    AñadirLibro(librosDisponibles);
                    break;
                case "eliminar":
                case "2":
                    EliminarLibro(librosDisponibles);
                    break;
                case "mostrar":
                case "3":
                    MostrarLibros(librosDisponibles);
                    break;
                case "buscar":
                case "4":
                    BuscarLibro(librosDisponibles);
                    break;
                case "prestar":
                case "5":
                    PrestarLibro(librosDisponibles, librosPrestados);
                    break;
                case "devolver":
                case "6":
                    DevolverLibro(librosDisponibles, librosPrestados);
                    break;
                case "prestados":
                case "7":
                    MostrarLibrosPrestados(librosPrestados);
                    break;
                case "salir":
                case "8":
                    salir = true;
                    Console.WriteLine("\n¡Gracias por usar el sistema! Hasta luego.");
                    break;
                default:
                    Console.WriteLine("\n Opción no válida. Por favor, ingrese una opción válida.");
                    break;
            }
        }
    }

    // Método para mostrar el menú
    static void MostrarMenu()
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════╗");
        Console.WriteLine("║       ¿Qué desea hacer?                  ║");
        Console.WriteLine("╠═══════════════════════════════════════════╣");
        Console.WriteLine("║ 1. Añadir un libro                        ║");
        Console.WriteLine("║ 2. Eliminar un libro                      ║");
        Console.WriteLine("║ 3. Mostrar lista de libros                ║");
        Console.WriteLine("║ 4. Buscar un libro                        ║");
        Console.WriteLine("║ 5. Prestar un libro (máx. 3)              ║");
        Console.WriteLine("║ 6. Devolver un libro                      ║");
        Console.WriteLine("║ 7. Ver libros prestados                   ║");
        Console.WriteLine("║ 8. Salir                                  ║");
        Console.WriteLine("╚═══════════════════════════════════════════╝");
        Console.Write("\nIngrese su opción: ");
    }

    // Método para normalizar entrada (convertir a minúsculas y eliminar espacios)
    static string NormalizarEntrada(string entrada)
    {
        if (string.IsNullOrEmpty(entrada))
            return "";
        return entrada.Trim().ToLower();
    }

    // Método para cambiar nombre de variable
    static int ContarLibrosVacios(string[] libros)
    {
        int contador = 0;
        foreach (string libro in libros)
        {
            if (string.IsNullOrEmpty(libro))
                contador++;
        }
        return contador;
    }

    // Método para contar libros disponibles
    static int ContarLibrosDisponibles(string[] libros)
    {
        return libros.Length - ContarLibrosVacios(libros);
    }

    // Método para verificar si la biblioteca está vacía
    static bool BibliotecaEstaVacia(string[] libros)
    {
        return ContarLibrosDisponibles(libros) == 0;
    }

    // Método para verificar si la biblioteca está llena
    static bool BibliotecaEstaLlena(string[] libros)
    {
        return ContarLibrosVacios(libros) == 0;
    }

    // Función para añadir un libro (REFACTORIZACIÓN: Eliminada duplicación)
    static void AñadirLibro(string[] libros)
    {
        // Verificar si hay espacio disponible ANTES de pedir datos
        if (BibliotecaEstaLlena(libros))
        {
            Console.WriteLine("\n No hay más espacio. La biblioteca tiene el máximo de 5 libros.");
            return;
        }

        Console.Write("\nIngrese el título del libro a añadir: ");
        string nuevoLibro = Console.ReadLine();

        // Validar entrada vacía
        if (string.IsNullOrEmpty(nuevoLibro) || string.IsNullOrWhiteSpace(nuevoLibro))
        {
            Console.WriteLine(" El título no puede estar vacío.");
            return;
        }

        nuevoLibro = nuevoLibro.Trim();

        // Guardar el libro en la primera posición vacía (REFACTORIZACIÓN: bucle en lugar de múltiples if)
        for (int i = 0; i < libros.Length; i++)
        {
            if (string.IsNullOrEmpty(libros[i]))
            {
                libros[i] = nuevoLibro;
                Console.WriteLine($"✓ Libro '{nuevoLibro}' añadido exitosamente en la posición {i + 1}.");
                return;
            }
        }
    }

    // Función para eliminar un libro (REFACTORIZACIÓN: Eliminada duplicación)
    static void EliminarLibro(string[] libros)
    {
        // Verificar si hay libros para eliminar
        if (BibliotecaEstaVacia(libros))
        {
            Console.WriteLine("\n No hay libros en la biblioteca para eliminar.");
            return;
        }

        Console.Write("\nIngrese el título del libro a eliminar: ");
        string libroAEliminar = Console.ReadLine();

        if (string.IsNullOrEmpty(libroAEliminar) || string.IsNullOrWhiteSpace(libroAEliminar))
        {
            Console.WriteLine(" El título no puede estar vacío.");
            return;
        }

        libroAEliminar = libroAEliminar.Trim();

        // Buscar y eliminar el libro (REFACTORIZACIÓN: bucle en lugar de múltiples else if)
        for (int i = 0; i < libros.Length; i++)
        {
            if (libros[i] == libroAEliminar)
            {
                libros[i] = "";
                Console.WriteLine($"✓ Libro '{libroAEliminar}' eliminado exitosamente.");
                return;
            }
        }

        Console.WriteLine($" El libro '{libroAEliminar}' no se encontró en la biblioteca.");
    }

    // Función para mostrar la lista de libros (REFACTORIZACIÓN: Eliminada duplicación)
    static void MostrarLibros(string[] libros)
    {
        // Verificar si hay libros para mostrar
        if (BibliotecaEstaVacia(libros))
        {
            Console.WriteLine("\n La biblioteca está vacía. No hay libros disponibles.");
            return;
        }

        Console.WriteLine("\n === LIBROS DISPONIBLES EN LA BIBLIOTECA ===");
        int numeroLibro = 1;

        // Solo mostrar libros que NO están vacíos (REFACTORIZACIÓN: bucle en lugar de múltiples if)
        foreach (string libro in libros)
        {
            if (!string.IsNullOrEmpty(libro))
            {
                Console.WriteLine($"{numeroLibro++}. {libro}");
            }
        }

        int librosDisponibles = ContarLibrosDisponibles(libros);
        Console.WriteLine($"\nTotal de libros: {librosDisponibles}/5");
    }

    // NUEVA FUNCIÓN: Buscar un libro por título
    static void BuscarLibro(string[] libros)
    {
        if (BibliotecaEstaVacia(libros))
        {
            Console.WriteLine("\n La biblioteca está vacía. No hay libros para buscar.");
            return;
        }

        Console.Write("\nIngrese el título del libro a buscar: ");
        string libroBuscado = Console.ReadLine();

        if (string.IsNullOrEmpty(libroBuscado) || string.IsNullOrWhiteSpace(libroBuscado))
        {
            Console.WriteLine(" El título no puede estar vacío.");
            return;
        }

        libroBuscado = libroBuscado.Trim();

        // Buscar el libro en la colección
        for (int i = 0; i < libros.Length; i++)
        {
            if (!string.IsNullOrEmpty(libros[i]) && libros[i] == libroBuscado)
            {
                Console.WriteLine($"\n '{libroBuscado}' se encontró en la biblioteca. Está disponible.");
                return;
            }
        }

        Console.WriteLine($"\n '{libroBuscado}' no se encontró en la colección.");
    }

    // NUEVA FUNCIÓN: Prestar un libro (máximo 3)
    static void PrestarLibro(string[] librosDisponibles, string[] librosPrestados)
    {
        if (BibliotecaEstaVacia(librosDisponibles))
        {
            Console.WriteLine("\n No hay libros disponibles para prestar.");
            return;
        }

        // Verificar si ya tiene 3 libros prestados
        if (ContarLibrosDisponibles(librosPrestados) >= 3)
        {
            Console.WriteLine("\n Ya tiene el máximo de 3 libros prestados. Debe devolver uno para prestar otro.");
            return;
        }

        Console.Write("\nIngrese el título del libro que desea prestar: ");
        string libroAPrestar = Console.ReadLine();

        if (string.IsNullOrEmpty(libroAPrestar) || string.IsNullOrWhiteSpace(libroAPrestar))
        {
            Console.WriteLine(" El título no puede estar vacío.");
            return;
        }

        libroAPrestar = libroAPrestar.Trim();

        // Verificar que el libro esté disponible
        int indiceLibro = -1;
        for (int i = 0; i < librosDisponibles.Length; i++)
        {
            if (librosDisponibles[i] == libroAPrestar)
            {
                indiceLibro = i;
                break;
            }
        }

        if (indiceLibro == -1)
        {
            Console.WriteLine($" El libro '{libroAPrestar}' no está disponible en la biblioteca.");
            return;
        }

        // Agregar el libro a la lista de prestados
        for (int i = 0; i < librosPrestados.Length; i++)
        {
            if (string.IsNullOrEmpty(librosPrestados[i]))
            {
                librosPrestados[i] = libroAPrestar;
                librosDisponibles[indiceLibro] = "";
                Console.WriteLine($"✓ Libro '{libroAPrestar}' prestado exitosamente.");
                Console.WriteLine($"Libros prestados: {ContarLibrosDisponibles(librosPrestados)}/3");
                return;
            }
        }
    }

    // NUEVA FUNCIÓN: Devolver un libro prestado
    static void DevolverLibro(string[] librosDisponibles, string[] librosPrestados)
    {
        if (BibliotecaEstaVacia(librosPrestados))
        {
            Console.WriteLine("\n No hay libros prestados para devolver.");
            return;
        }

        Console.Write("\nIngrese el título del libro a devolver: ");
        string libroADevolver = Console.ReadLine();

        if (string.IsNullOrEmpty(libroADevolver) || string.IsNullOrWhiteSpace(libroADevolver))
        {
            Console.WriteLine(" El título no puede estar vacío.");
            return;
        }

        libroADevolver = libroADevolver.Trim();

        // Buscar el libro en la lista de prestados
        for (int i = 0; i < librosPrestados.Length; i++)
        {
            if (librosPrestados[i] == libroADevolver)
            {
                librosPrestados[i] = "";

                // Agregar el libro de vuelta a la biblioteca
                for (int j = 0; j < librosDisponibles.Length; j++)
                {
                    if (string.IsNullOrEmpty(librosDisponibles[j]))
                    {
                        librosDisponibles[j] = libroADevolver;
                        break;
                    }
                }

                Console.WriteLine($"✓ Libro '{libroADevolver}' devuelto exitosamente.");
                Console.WriteLine($"Libros prestados: {ContarLibrosDisponibles(librosPrestados)}/3");
                return;
            }
        }

        Console.WriteLine($" El libro '{libroADevolver}' no está en la lista de libros prestados.");
    }

    // NUEVA FUNCIÓN: Mostrar libros prestados
    static void MostrarLibrosPrestados(string[] librosPrestados)
    {
        if (BibliotecaEstaVacia(librosPrestados))
        {
            Console.WriteLine("\n No tiene libros prestados actualmente.");
            return;
        }

        Console.WriteLine("\n === LIBROS PRESTADOS ===");
        int numeroLibro = 1;

        foreach (string libro in librosPrestados)
        {
            if (!string.IsNullOrEmpty(libro))
            {
                Console.WriteLine($"{numeroLibro++}. {libro}");
            }
        }

        int librosPrestadosCount = ContarLibrosDisponibles(librosPrestados);
        Console.WriteLine($"\nTotal de libros prestados: {librosPrestadosCount}/3");
    }

}
