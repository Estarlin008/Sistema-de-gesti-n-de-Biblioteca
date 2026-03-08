using System;

class Program
{
    static void Main()
    {
        // REFACTORIZACIÓN: Array de libros en lugar de 5 variables separadas
        string[] libros = new string[5];
        for (int i = 0; i < 5; i++)
            libros[i] = "";

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
                    AñadirLibro(libros);
                    break;
                case "eliminar":
                case "2":
                    EliminarLibro(libros);
                    break;
                case "mostrar":
                case "3":
                    MostrarLibros(libros);
                    break;
                case "salir":
                case "4":
                    salir = true;
                    Console.WriteLine("\n¡Gracias por usar el sistema! Hasta luego.");
                    break;
                default:
                    Console.WriteLine("\n❌ Opción no válida. Por favor, ingrese una opción válida.");
                    break;
            }
        }
    }

    // Método para mostrar el menú
    static void MostrarMenu()
    {
        Console.WriteLine("\n¿Qué desea hacer?");
        Console.WriteLine("1. Añadir un libro");
        Console.WriteLine("2. Eliminar un libro");
        Console.WriteLine("3. Mostrar lista de libros");
        Console.WriteLine("4. Salir");
        Console.Write("\nIngrese su opción (1-4): ");
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
            Console.WriteLine("\n❌ No hay más espacio. La biblioteca tiene el máximo de 5 libros.");
            return;
        }

        Console.Write("\nIngrese el título del libro a añadir: ");
        string nuevoLibro = Console.ReadLine();

        // Validar entrada vacía
        if (string.IsNullOrEmpty(nuevoLibro) || string.IsNullOrWhiteSpace(nuevoLibro))
        {
            Console.WriteLine("❌ El título no puede estar vacío.");
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
            Console.WriteLine("\n❌ No hay libros en la biblioteca para eliminar.");
            return;
        }

        Console.Write("\nIngrese el título del libro a eliminar: ");
        string libroAEliminar = Console.ReadLine();

        if (string.IsNullOrEmpty(libroAEliminar) || string.IsNullOrWhiteSpace(libroAEliminar))
        {
            Console.WriteLine("❌ El título no puede estar vacío.");
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

        Console.WriteLine($"❌ El libro '{libroAEliminar}' no se encontró en la biblioteca.");
    }

    // Función para mostrar la lista de libros (REFACTORIZACIÓN: Eliminada duplicación)
    static void MostrarLibros(string[] libros)
    {
        // Verificar si hay libros para mostrar
        if (BibliotecaEstaVacia(libros))
        {
            Console.WriteLine("\n📚 La biblioteca está vacía. No hay libros disponibles.");
            return;
        }

        Console.WriteLine("\n📚 === LIBROS DISPONIBLES EN LA BIBLIOTECA ===");
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
}
