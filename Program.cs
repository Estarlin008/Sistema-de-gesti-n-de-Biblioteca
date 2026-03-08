using System;

class Program
{
    static void Main()
    {
        // Variables para almacenar hasta 5 libros
        string libro1 = "";
        string libro2 = "";
        string libro3 = "";
        string libro4 = "";
        string libro5 = "";

        bool salir = false;

        Console.WriteLine("=== Sistema de Gestión de Biblioteca ===\n");

        while (!salir)
        {
            // Mostrar menú
            Console.WriteLine("\n¿Qué desea hacer?");
            Console.WriteLine("1. Añadir un libro");
            Console.WriteLine("2. Eliminar un libro");
            Console.WriteLine("3. Mostrar lista de libros");
            Console.WriteLine("4. Salir");
            Console.Write("\nIngrese su opción (1-4): ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AñadirLibro(ref libro1, ref libro2, ref libro3, ref libro4, ref libro5);
                    break;
                case "2":
                    EliminarLibro(ref libro1, ref libro2, ref libro3, ref libro4, ref libro5);
                    break;
                case "3":
                    MostrarLibros(libro1, libro2, libro3, libro4, libro5);
                    break;
                case "4":
                    salir = true;
                    Console.WriteLine("\n¡Gracias por usar el sistema! Hasta luego.");
                    break;
                default:
                    Console.WriteLine("\n❌ Opción no válida. Por favor, ingrese una opción entre 1 y 4.");
                    break;
            }
        }
    }

    // Función para añadir un libro
    static void AñadirLibro(ref string libro1, ref string libro2, ref string libro3, ref string libro4, ref string libro5)
    {
        // Verificar si hay espacio disponible
        if (!string.IsNullOrEmpty(libro1) && !string.IsNullOrEmpty(libro2) && 
            !string.IsNullOrEmpty(libro3) && !string.IsNullOrEmpty(libro4) && 
            !string.IsNullOrEmpty(libro5))
        {
            Console.WriteLine("\n❌ No hay más espacio. La biblioteca tiene el máximo de 5 libros.");
            return;
        }

        Console.Write("\nIngrese el título del libro a añadir: ");
        string nuevoLibro = Console.ReadLine();

        if (string.IsNullOrEmpty(nuevoLibro))
        {
            Console.WriteLine("❌ El título no puede estar vacío.");
            return;
        }

        // Guardar el libro en la primera variable vacía
        if (string.IsNullOrEmpty(libro1))
        {
            libro1 = nuevoLibro;
            Console.WriteLine($"✓ Libro '{nuevoLibro}' añadido exitosamente en la posición 1.");
        }
        else if (string.IsNullOrEmpty(libro2))
        {
            libro2 = nuevoLibro;
            Console.WriteLine($"✓ Libro '{nuevoLibro}' añadido exitosamente en la posición 2.");
        }
        else if (string.IsNullOrEmpty(libro3))
        {
            libro3 = nuevoLibro;
            Console.WriteLine($"✓ Libro '{nuevoLibro}' añadido exitosamente en la posición 3.");
        }
        else if (string.IsNullOrEmpty(libro4))
        {
            libro4 = nuevoLibro;
            Console.WriteLine($"✓ Libro '{nuevoLibro}' añadido exitosamente en la posición 4.");
        }
        else if (string.IsNullOrEmpty(libro5))
        {
            libro5 = nuevoLibro;
            Console.WriteLine($"✓ Libro '{nuevoLibro}' añadido exitosamente en la posición 5.");
        }
    }

    // Función para eliminar un libro
    static void EliminarLibro(ref string libro1, ref string libro2, ref string libro3, ref string libro4, ref string libro5)
    {
        // Verificar si hay libros para eliminar
        if (string.IsNullOrEmpty(libro1) && string.IsNullOrEmpty(libro2) && 
            string.IsNullOrEmpty(libro3) && string.IsNullOrEmpty(libro4) && 
            string.IsNullOrEmpty(libro5))
        {
            Console.WriteLine("\n❌ No hay libros en la biblioteca para eliminar.");
            return;
        }

        Console.Write("\nIngrese el título del libro a eliminar: ");
        string libroAEliminar = Console.ReadLine();

        if (string.IsNullOrEmpty(libroAEliminar))
        {
            Console.WriteLine("❌ El título no puede estar vacío.");
            return;
        }

        // Buscar y eliminar el libro
        if (libro1 == libroAEliminar)
        {
            libro1 = "";
            Console.WriteLine($"✓ Libro '{libroAEliminar}' eliminado exitosamente.");
        }
        else if (libro2 == libroAEliminar)
        {
            libro2 = "";
            Console.WriteLine($"✓ Libro '{libroAEliminar}' eliminado exitosamente.");
        }
        else if (libro3 == libroAEliminar)
        {
            libro3 = "";
            Console.WriteLine($"✓ Libro '{libroAEliminar}' eliminado exitosamente.");
        }
        else if (libro4 == libroAEliminar)
        {
            libro4 = "";
            Console.WriteLine($"✓ Libro '{libroAEliminar}' eliminado exitosamente.");
        }
        else if (libro5 == libroAEliminar)
        {
            libro5 = "";
            Console.WriteLine($"✓ Libro '{libroAEliminar}' eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine($"❌ El libro '{libroAEliminar}' no se encontró en la biblioteca.");
        }
    }

    // Función para mostrar la lista de libros
    static void MostrarLibros(string libro1, string libro2, string libro3, string libro4, string libro5)
    {
        // Verificar si hay libros para mostrar
        if (string.IsNullOrEmpty(libro1) && string.IsNullOrEmpty(libro2) && 
            string.IsNullOrEmpty(libro3) && string.IsNullOrEmpty(libro4) && 
            string.IsNullOrEmpty(libro5))
        {
            Console.WriteLine("\n📚 La biblioteca está vacía. No hay libros disponibles.");
            return;
        }

        Console.WriteLine("\n📚 === LIBROS DISPONIBLES EN LA BIBLIOTECA ===");
        int numeroLibro = 1;

        if (!string.IsNullOrEmpty(libro1))
            Console.WriteLine($"{numeroLibro++}. {libro1}");
        if (!string.IsNullOrEmpty(libro2))
            Console.WriteLine($"{numeroLibro++}. {libro2}");
        if (!string.IsNullOrEmpty(libro3))
            Console.WriteLine($"{numeroLibro++}. {libro3}");
        if (!string.IsNullOrEmpty(libro4))
            Console.WriteLine($"{numeroLibro++}. {libro4}");
        if (!string.IsNullOrEmpty(libro5))
            Console.WriteLine($"{numeroLibro++}. {libro5}");

        int librosDisponibles = 0;
        if (!string.IsNullOrEmpty(libro1)) librosDisponibles++;
        if (!string.IsNullOrEmpty(libro2)) librosDisponibles++;
        if (!string.IsNullOrEmpty(libro3)) librosDisponibles++;
        if (!string.IsNullOrEmpty(libro4)) librosDisponibles++;
        if (!string.IsNullOrEmpty(libro5)) librosDisponibles++;

        Console.WriteLine($"\nTotal de libros: {librosDisponibles}/5");
    }
}
