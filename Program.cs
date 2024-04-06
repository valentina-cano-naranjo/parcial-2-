using System;

bool Empezar = true;

while (Empezar)
{
    Console.WriteLine("Bienvenidos a Adivina el número");

//pedir numero de jugadores//
int numjugadores = 0;
Console.WriteLine("ingrese el numero de jugadores (entre 2 y 4): ");

while (!int.TryParse(Console.ReadLine(), out numjugadores) || numjugadores < 2 || numjugadores > 4) ;

int maximo = numjugadores switch
   {
    2 => 50,
    3 => 100,
    4 => 200,
    _ => 100
   };

Random rnd = new Random();
int numeroAleatorio = rnd.Next(0, maximo + 1);

int jugadorActual = 1;

while (true)
    {
    Console.WriteLine($"\nTurno del jugador {jugadorActual}");
    Console.Write("Ingrese un número: ");
    if (!int.TryParse(Console.ReadLine(), out int numeroIngresado))
      {
        Console.WriteLine("Por favor ingrese un número válido.");
        continue;
      }

    if (numeroIngresado < numeroAleatorio)
    {
        Console.WriteLine("MAYOR");
    }
    else if (numeroIngresado > numeroAleatorio)
    {
        Console.WriteLine("MENOR");
    }
    else
    {
        Console.WriteLine("¡HAS GANADO!");
        break;
    }

    jugadorActual = (jugadorActual % numjugadores) + 1;
    }

Console.Write("¿Desean jugar otra vez? (Sí/No): ");
Empezar = Console.ReadLine() == "sí";
Console.Clear();

while (Empezar) ;

Console.WriteLine("¡Gracias por jugar!");
}







