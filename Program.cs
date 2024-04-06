bool volver = true;

while (volver)
{
    Console.WriteLine("¡Bienvenido a la Natillera Navideña!");

    // Variables para el primer socio
    Socio socio1 = ProcesarSocio();

    // Variables para el segundo socio
    Socio socio2 = ProcesarSocio();

    // Liquidar la natillera al final del año para ambos socios
    LiquidarNatillera(socio1);
    LiquidarNatillera(socio2);

    Console.WriteLine("\n¿Desea ingresar a la natillera para el siguiente año? (s/n)");
    string continuar = Console.ReadLine();
    if (continuar.ToLower() != "s")
        volver = false;
}

Console.WriteLine("¡Gracias por utilizar la Natillera Navideña!");
  

        static Socio ProcesarSocio()
{
    Socio socio = new Socio();

    for (int mes = 1; mes <= 12; mes++)
    {
        Console.WriteLine($"\n--- Mes {mes} ---");
        Console.Write("Ingrese la cantidad que desea ahorrar este mes: ");
        decimal aporteMensual = Convert.ToDecimal(Console.ReadLine());

        socio.Aportar(aporteMensual);

        Console.WriteLine($"Aportes: {aporteMensual:C}");
        Console.WriteLine($"Saldo acumulado: {socio.Saldo:C}");

        if (aporteMensual == 0)
        {
            Console.WriteLine("Se aplicará una multa de $20,000 por no realizar aportes.");
            socio.AplicarMulta();
        }

        if (socio.Saldo > 0)
        {
            Console.Write("¿Desea solicitar un préstamo? (s/n): ");
            string respuesta = Console.ReadLine();
            if (respuesta.ToLower() == "s")
            {
                Console.Write("Ingrese la cantidad del préstamo: ");
                decimal cantidadPrestamo = Convert.ToDecimal(Console.ReadLine());
                if (socio.SolicitarPrestamo(cantidadPrestamo))
                {
                    Console.WriteLine($"Préstamo aprobado por {cantidadPrestamo:C}. Nuevo saldo: {socio.Saldo:C}");
                }
                else
                {
                    Console.WriteLine("El préstamo solicitado supera el saldo disponible. No se aprobó.");
                }
            }
        }
    }

    return socio;
}

static void LiquidarNatillera(Socio socio)
{
    Console.WriteLine($"\n--- Liquidación de la Natillera para {socio.Nombre} ---");
    Console.WriteLine($"Total multas pagadas: {socio.Multas * 20000:C}");
    Console.WriteLine($"Valor del préstamo (si lo solicitó): {socio.Prestamo?.Cantidad:C}");
    Console.WriteLine($"Intereses generados por el préstamo: {socio.Prestamo?.CalcularIntereses():C}");
    decimal totalLiquidado = socio.Saldo - (socio.Multas * 20000);
    if (socio.Prestamo != null)
    {
        totalLiquidado -= socio.Prestamo.CalcularIntereses() + socio.Prestamo.Cantidad;
    }
    Console.WriteLine($"Valor neto a liquidar: {totalLiquidado:C}");
}


    class Socio
{
    public string Nombre { get; set; }
    public decimal Saldo { get; private set; }
    public int Multas { get; private set; }
    public Prestamo Prestamo { get; private set; }

    public Socio()
    {
        Console.Write("Ingrese el nombre del socio: ");
        Nombre = Console.ReadLine();
    }

    public void Aportar(decimal cantidad)
    {
        Saldo += cantidad;
    }

    public void AplicarMulta()
    {
        if (Saldo == 0)
            Multas++;
        Saldo -= 20000;
    }

    public bool SolicitarPrestamo(decimal cantidad)
    {
        if (cantidad <= Saldo)
        {
            Prestamo = new Prestamo(cantidad);
            Saldo -= cantidad;
            return true;
        }
        return false;
    }
}

class Prestamo
{
    public decimal Cantidad { get; }
    public int MesSolicitud { get; }

    public Prestamo(decimal cantidad)
    {
        Cantidad = cantidad;
        MesSolicitud = DateTime.Now.Month;
    }

    public decimal CalcularIntereses()
    {
        int mesesDeIntereses = 12 - MesSolicitud;
        decimal intereses = Cantidad * mesesDeIntereses * 0.025M;
        return intereses;
    }
}

    