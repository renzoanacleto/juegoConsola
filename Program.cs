using Proyecto.Clases;

DragonFuego dragonFuego = new DragonFuego("Llamita", 1);
dragonFuego.MostrarDatos();

DragonAgua dragonAgua = new DragonAgua("El pez", 1);
dragonAgua.MostrarDatos();

Random dado = new();
int precision;
int esquive;
int danio;

Combatir(dragonFuego, dragonAgua);



void Combatir(IDragon dragon1, IDragon dragon2)
{
    Console.WriteLine("INICIANDO COMBATE...\n");
    int contador = 1;
    int seleccionAtaque = 0;
    bool seleccionValida = false;

    while(true)
    {
        Console.WriteLine($"=== TURNO {contador} ===");

        Console.WriteLine("Ingrese el numero del ataque a realizar: ");
        Console.WriteLine($"0 -> {dragon1.Ataques[0].Nombre}");
        Console.WriteLine($"1 -> {dragon1.Ataques[1].Nombre}");

        do
        {
            string? entrada = Console.ReadLine();

            if (int.TryParse(entrada, out seleccionAtaque))
            {
                if (seleccionAtaque == 0 || seleccionAtaque == 1)
                    seleccionValida = true;
                else
                    Console.WriteLine("Error: Debe ingresar un numero de ataque valido");
            }
            else
            {
                Console.WriteLine("Error: Entrada inválida. Ingrese un número válido.");
            }

        } while(!seleccionValida);
        
        RealizarAtaque(dragon1, dragon2, seleccionAtaque);
        Console.WriteLine();
        dragon1.MostrarEstatus();
        dragon2.MostrarEstatus();
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadLine();

        if (dragon1.Hp <= 0 || dragon2.Hp <= 0) break;

        RealizarAtaque(dragon2, dragon1, dado.Next(0, 2));
        Console.WriteLine();
        dragon1.MostrarEstatus();
        dragon2.MostrarEstatus();
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadLine();
        Console.WriteLine();
        contador++;

        if (dragon1.Hp <= 0 || dragon2.Hp <= 0) break;
    }

    if(dragon1.Hp > 0) 
        Console.WriteLine($"El ganador fue {dragon1.Nombre}");
    else 
        Console.WriteLine($"El ganador fue {dragon2.Nombre}");
}


void RealizarAtaque(IDragon p1, IDragon p2, int numAtaque)
{
    precision = dado.Next(1, 11);
    esquive = dado.Next(1, 11);
    Console.WriteLine($"{p1.Nombre} usa \"{p1.Ataques[numAtaque].Nombre}\" con precision de {precision}");
    Console.WriteLine($"{p2.Nombre} intenta esquivar con {esquive}");
    danio = p1.Atacar(precision, esquive, p2.Elemento, numAtaque);
    p2.Hp -= danio;
}


