int opciones = 0;
void Menu()
{
    Console.WriteLine("\n===Menú===");
    Console.WriteLine("1.Evaluar nuevo contenido");
    Console.WriteLine("2.Mostrar reglas del sistema");
    Console.WriteLine("3.Mostrar estadísticas de la sesión");
    Console.WriteLine("4.Reiniciar estadísticas");
    Console.WriteLine("5.Salir");
}
void EvaluarContenido()
{
    string clasificacion = "", tipocontenido = "",nivelproduccion = "";
    int horas = -1, minutos = 0;
    bool valihoras = false, valiminutos = false;

    while (tipocontenido != "pelicula" && tipocontenido != "serie" && tipocontenido != "documental"
        && tipocontenido != "evento en vivo")
    {
        Console.Write("Ingrese el tipo de contenido: ");
        tipocontenido = Console.ReadLine().ToLower();
        if (tipocontenido != "pelicula" && tipocontenido != "serie" && tipocontenido != "documental"
        && tipocontenido != "evento en vivo")
        {
            Console.WriteLine("Opción no válida, Opciones: pelicula, serie, documental o evento en vivo");
        }
    }
    while (!valiminutos || minutos <= 0)
    {
        Console.Write("ingrese los minutos de duración: ");
        valiminutos = int.TryParse(Console.ReadLine(), out minutos);
        if (!valiminutos || minutos <= 0)
        {
            Console.WriteLine("Ingrese la duracion del contenido en minutos. ejemplo: 30");
        }
    }

    while (clasificacion != "todo publico" && clasificacion != "+13" && clasificacion != "+18")
    {
        Console.Write("Ingrese la clasificación: ");
        clasificacion = Console.ReadLine().ToLower();

        if (clasificacion != "todo publico" && clasificacion != "+13" && clasificacion != "+18")
        {
            Console.WriteLine("Ingrese la clasificacíon permitida. ejemplo: todo publico, +13 o +18");
        }
    }
    
    while (!valihoras || horas < 0 || horas >23)
    {
        Console.Write("ingrese la hora programada: ");
        valihoras = int.TryParse(Console.ReadLine(), out horas);

        if (!valihoras || horas < 0 || horas > 23)
        {
            Console.WriteLine("Rango de horas no permitidas. Rango: (0-23)");
        }
    }
    
    while (nivelproduccion != "bajo" && nivelproduccion != "medio" && nivelproduccion != "alto")
    {
        Console.Write("Ingrese el nivel de producción: ");
        nivelproduccion = Console.ReadLine().ToLower();
        if (nivelproduccion != "bajo" && nivelproduccion != "medio" && nivelproduccion != "alto")
        {
            Console.WriteLine("Dato ingresado no válido. Opciones: Bajo, Medio o Alto");
        }
    }

}

bool ValidacionTec(string clasificacion, string tipocontenido, string nivelproduccion, int horas, int minutos)
{
    bool permitido = true;
    if (clasificacion == "todo publico" )
    {
        //todas las horas son pertmitidas!!
    }
    else if (clasificacion == "+13")
    {
        if (horas < 6 || horas >22)
        {
            permitido = false;
            Console.WriteLine("Las horas permitidas de +13 son: (6-22 horas)");
        }
    }
    else if (clasificacion == "+18")
    {
        if (horas < 22 && horas >5)
        {
            permitido = false;
            Console.WriteLine("Las horas permitidas de +18 son: (22-5 horas)");
        }
    }

    if (tipocontenido == "pelicula")
    {
        if (minutos < 60   || minutos > 180)
        {
            permitido = false;
            Console.WriteLine("Los minutos permitidos para películas son: (60-180 minutos)");
        }
    }
    else if (tipocontenido == "serie")
    {
        if (minutos <20 || minutos > 90)
        {
            permitido = false;
            Console.WriteLine("Los minutos permitidos para series son: (20-90 minutos)");
        }
    }
    else if (tipocontenido == "documental")
    {
        if (minutos < 30 || minutos > 120)
        {
            permitido = false;
            Console.WriteLine("Los minutos permitidos para documentales son: (30-120 minutos)");
        }
    }
    else if (tipocontenido == "evento en vivo")
    {
        if (minutos < 30 || minutos > 240)
        {
            permitido = false;
            Console.WriteLine("Los minutos permitidos para eventos en vivo son: (30-240 minutos)");
        }
    }
    
    if (nivelproduccion == "bajo")
    {
        if (clasificacion == "+18")
        {
            permitido = false;
            Console.WriteLine("Cuando la clasificacíon es baja permitido unicamente para: Todo publico y +13.");
        }
    }
    return permitido;
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