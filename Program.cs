//Variables
bool volver = true;
const double BONO = 0.4; //Snake Case:Notación para constantes.

while (volver)
{
    decimal aporteMensual, rendimientoMensual, aporteTotal = 0, rendimientoTotal = 0, bonoMensual = 0, bonoTotal = 0, aporteTotalNeto, tasaMensual;
    string continuar;

    //Clase random
    Random random = new Random(); //Esta es la forma de instanciar una clase en objeto

    for (int mes = 1; mes <= 12; mes++)
    {
        Console.Write($"Ingrese la cantidad que desea ahorrar en el mes {mes}: ");
        aporteMensual = Convert.ToDecimal(Console.ReadLine());

        tasaMensual = (decimal)random.Next(1, 51) / 10;
        rendimientoMensual = aporteMensual * (tasaMensual / 100);

        if (tasaMensual < 3.5M)
        {
            bonoMensual = aporteMensual * (decimal)BONO;
            bonoTotal += bonoMensual;
            bonoMensual = 0;
        }

        aporteTotal += aporteMensual;
        rendimientoTotal += rendimientoMensual;

        Console.Write($"MES {mes}\n" +
                      $"Aportes: {aporteMensual:C}\n" +
                      $"Tasa: {tasaMensual}%\n" +
                      $"Rendimientos: {rendimientoMensual:C}\n" +
                      $"Bono: {bonoMensual:C}\n" +
                      $"---------------------------------------\n" +
                      $" \n");
    }

    aporteTotalNeto = rendimientoTotal + aporteTotal + bonoTotal;

    Console.Write($"Aportes totales: {aporteTotal:C}\n" +
                  $"Rendimientos totales: {rendimientoTotal:C}\n" +
                  $"Bonos totales: {bonoTotal:C}\n" +
                  "--------------------------------\n" +
                  $"TOTAL NETO: {aporteTotalNeto:C}\n" +
                  $" \n");


    Console.WriteLine("¿Desea ingresra a la natillera para el siguiente año? (s/n)");
    
    if (continuar == "n") volver = false;
}
    