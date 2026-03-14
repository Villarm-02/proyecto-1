int opciones = 0;
void Menu()
{
    Console.WriteLine("===Menú===");
    Console.WriteLine("1.Evaluar nuevo contenido");
    Console.WriteLine("2.Mostrar reglas del sistema");
    Console.WriteLine("3.Mostrar estadísticas de la sesión");
    Console.WriteLine("4.Reiniciar estadísticas");
    Console.WriteLine("5.Salir");
}
do
{
    Menu();
    Console.Write("Ingrese una opción: ");
    bool vali = int.TryParse(Console.ReadLine(), out opciones);
    if (!vali)
    {
        Console.WriteLine("Dato inválido, ingrese un número");
    }
    else
    {
        switch (opciones)
        {

            case 1:
                Console.WriteLine("En proceso");
                break;
                    case 2:
                Console.WriteLine("En proceso");
                break; 
                 case 3:
                Console.WriteLine("En proceso");
                break;
                case 4:
                Console.WriteLine("En proceso");
                break;
                    case 5:
                Console.Clear();
                Console.WriteLine("Saliendo del sistema...");
                break;
            default:
                Console.WriteLine("Datos fuera del rango de opciones");
                break;
        }
    }
} while (opciones !=5);