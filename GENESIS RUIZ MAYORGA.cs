using System;

class Program
{
    static void Main()
    {
        int N = 16; // Carné termina en 6 => 6 + 10 = 16

        string[] nombres = new string[N];
        int[] gravedad = new int[N];

        int cantidad = 0;
        int opcion = 0;

        do
        {
            Console.Clear();

            Console.WriteLine("===== HOSPITAL SAN RAFAEL =====");
            Console.WriteLine("1. Registrar paciente");
            Console.WriteLine("2. Mostrar pacientes");
            Console.WriteLine("3. Modificar gravedad");
            Console.WriteLine("4. Eliminar paciente");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Debe ingresar un número.");
                Console.ReadKey();
                continue;
            }

            switch (opcion)
            {
                case 1:
                    if (cantidad < N)
                    {
                        Console.Write("Nombre del paciente: ");
                        nombres[cantidad] = Console.ReadLine();

                        int nivel;

                        do
                        {
                            Console.Write("Nivel de gravedad (1-5): ");

                        } while (!int.TryParse(Console.ReadLine(), out nivel)
                                 || nivel < 1
                                 || nivel > 5);

                        gravedad[cantidad] = nivel;
                        cantidad++;

                        Console.WriteLine("Paciente registrado correctamente.");
                    }
                    else
                    {
                        Console.WriteLine("No hay espacio disponible.");
                    }
                    break;

                case 2:
                    if (cantidad == 0)
                    {
                        Console.WriteLine("No hay pacientes registrados.");
                    }
                    else
                    {
                        Console.WriteLine("\nLISTA DE PACIENTES");

                        for (int i = 0; i < cantidad; i++)
                        {
                            Console.WriteLine(
                                (i + 1) + ". " +
                                nombres[i] +
                                " - Gravedad: " +
                                gravedad[i]);
                        }
                    }
                    break;

                case 3:
                    Console.Write("Nombre del paciente: ");
                    string buscar = Console.ReadLine();

                    bool encontrado = false;

                    for (int i = 0; i < cantidad; i++)
                    {
                        if (nombres[i].ToLower() == buscar.ToLower())
                        {
                            int nuevaGravedad;

                            do
                            {
                                Console.Write("Nueva gravedad (1-5): ");

                            } while (!int.TryParse(Console.ReadLine(), out nuevaGravedad)
                                     || nuevaGravedad < 1
                                     || nuevaGravedad > 5);

                            gravedad[i] = nuevaGravedad;

                            Console.WriteLine("Gravedad actualizada.");
                            encontrado = true;
                            break;
                        }
                    }

                    if (!encontrado)
                    {
                        Console.WriteLine("Paciente no encontrado.");
                    }
                    break;

                case 4:
                    Console.Write("Nombre del paciente a eliminar: ");
                    string eliminar = Console.ReadLine();

                    int posicion = -1;

                    for (int i = 0; i < cantidad; i++)
                    {
                        if (nombres[i].ToLower() == eliminar.ToLower())
                        {
                            posicion = i;
                            break;
                        }
                    }

                    if (posicion == -1)
                    {
                        Console.WriteLine("Paciente no encontrado.");
                    }
                    else
                    {
                        for (int i = posicion; i < cantidad - 1; i++)
                        {
                            nombres[i] = nombres[i + 1];
                            gravedad[i] = gravedad[i + 1];
                        }

                        cantidad--;

                        Console.WriteLine("Paciente eliminado correctamente.");
                    }
                    break;

                case 5:
                    Console.WriteLine("Saliendo del programa...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }

            if (opcion != 5)
            {
                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 5);
    }
}