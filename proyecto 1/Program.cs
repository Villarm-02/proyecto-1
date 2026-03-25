int opciones = 0, totalEvaluados = 0, totalPublicados = 0, totalRechazados = 0, totalRevision = 0;
int totalimpactoalto = 0, totalimpactomedio = 0, totalimpactobajo = 0, porcentaje = 0 ;
string impactoPredominante = "";
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
    bool mostrarresultado = ValidacionTec(clasificacion, tipocontenido, nivelproduccion, horas, minutos);
    string decision = "";
    if (mostrarresultado == true )
    {
        string mostrarimpacto = ClasificacionImpacto(nivelproduccion, minutos, horas);
        if (mostrarimpacto == "Impacto Bajo")
        {
            decision = "Publicar";
            totalimpactobajo++;
        }
        else if (mostrarimpacto == "Impacto Medio")
        {
            decision = "Publicar con Ajustes";
            totalimpactomedio++;
        }
        else if (mostrarimpacto == "Impacto Alto")
        {
            decision = "Enviar a revisión";
            totalimpactoalto++;
        }
    }
    else
    {
        decision = "Rechazar";
    }

    Console.WriteLine("Decisión: " + decision);
    totalEvaluados++;

    if (decision == "Publicar" || decision == "Publicar con Ajustes")
        totalPublicados++;
    else if (decision == "Rechazar")
        totalRechazados++;
    else if (decision == "Enviar a revisión")
        totalRevision++;
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

string ClasificacionImpacto(string nivelproduccion, int minutos, int horas)
{
    string impacto = "";
    if (nivelproduccion == "alto" || minutos > 120 || (horas >= 20 && horas <= 23))
    {
        impacto = "Impacto Alto";
 
    }
    else if (nivelproduccion == "medio" || (minutos >= 60 && minutos <=120) )
    {
        impacto = "Impacto Medio";
    }
    else if(nivelproduccion == "bajo" && minutos < 60)
    {
        impacto = "Impacto Bajo";
    }
    return impacto;
}

void MostrarEstadisticas()
{
    
    for (int i = 0; i < 25; i++)
    {
        Console.Write("=");
    } 
    Console.WriteLine();

    if (totalEvaluados > 0)
    {
        porcentaje = (totalPublicados * 100) / totalEvaluados;
    }

    if (totalimpactoalto >= totalimpactomedio && totalimpactoalto >= totalimpactobajo)
    {
        impactoPredominante = "Alto";
    }
    else if (totalimpactomedio >= totalimpactobajo)
    {
        impactoPredominante = "Medio";
    }
    else
    {
        impactoPredominante = "Bajo";
    }

    Console.WriteLine();
    Console.WriteLine("Total de evaluados: " +totalEvaluados );
    Console.WriteLine("Total de publicados: " + totalPublicados);
    Console.WriteLine("Total de rechazados: " + totalRechazados);
    Console.WriteLine("Total en revisión: " + totalRevision);
    Console.WriteLine("Impacto predominante: " + impactoPredominante);
    Console.WriteLine("Porcentaje de aprobación: " + porcentaje + "%");

}

void ReiniciarEstadisticas()
{
    totalEvaluados = 0;
    totalPublicados = 0;
    totalRechazados = 0;
    totalRevision = 0;
    impactoPredominante = "";
    porcentaje = 0;
    totalimpactoalto = 0;
    totalimpactomedio = 0;
    totalimpactobajo = 0;
}

void ReglasdelSistema()
{
    for (int i = 0; i < 25; i++)
    {
        Console.Write("=");
    } 
    Console.WriteLine() ;

    Console.WriteLine("Reglas del Sistema.") ;
    Console.WriteLine("\nReglas de clasificación y horario.\n");
    Console.WriteLine("1. Todo público: cualquier hora");
    Console.WriteLine("2. +13: entre 6 y 22 horas");
    Console.WriteLine("3. +18: entre 22 y 5 horas");

    Console.WriteLine("\nReglas de duración por tipo.\n");
    Console.WriteLine("1. Película: 60–180 minutos");
    Console.WriteLine("2. Serie: 20–90 minutos");
    Console.WriteLine("3.Documental: 30–120 minutos");
    Console.WriteLine("4. Evento en vivo: 30–240 minutos");
    Console.WriteLine("Si la duración está fuera del rango permitido, el contenido no cumple la validación técnica. \n");

    Console.WriteLine("\nReglas de producción.\n");
    Console.WriteLine("1.Producción baja solo válida para Todo público o +13");
    Console.WriteLine("2. Producción media o alta válida para cualquier clasificación");

}

do
{
    Menu();
    Console.Write("\nIngrese una opción: ");
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
                EvaluarContenido();
                Console.ReadKey();
                break;
                    case 2:
                ReglasdelSistema();
                Console.ReadKey();
                break; 
                 case 3:
                MostrarEstadisticas();
                Console.ReadKey();
                break;
                case 4:
                ReiniciarEstadisticas();
                Console.ReadKey();
                break;
                    case 5:
                Console.Clear();
                Console.WriteLine("Saliendo del sistema...");
                Console.ReadKey();
                break;
            default:
                Console.WriteLine("Datos fuera del rango de opciones");
                Console.ReadKey();
                break;
        }
    }
} while (opciones !=5);

Console.WriteLine("\n===Resumen final===");
MostrarEstadisticas();
Console.ReadKey();