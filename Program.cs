using System.Globalization;
using LiquidacionHaberes.Models;

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-AR");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-AR");

Console.WriteLine("=== Liquidación de haberes ===");
int cantidad = LeerEnteroPositivo("Cantidad de trabajadores: ");
var personal = new List<Trabajador>();

for (int indice = 1; indice <= cantidad; indice++)
{
	Console.WriteLine($"\nTrabajador {indice} de {cantidad}");
	string nombre = LeerTexto("Nombre: ");
	string dni = LeerTexto("DNI: ");
	decimal sueldoBase = LeerMonto("Sueldo base: ", permitirCero: false);

	Console.Write("Tipo (V = vendedor, D = directivo): ");
	string tipo = (Console.ReadLine() ?? string.Empty).Trim().ToUpperInvariant();

	while (tipo is not "V" and not "D")
	{
		Console.Write("Ingrese V para vendedor o D para directivo: ");
		tipo = (Console.ReadLine() ?? string.Empty).Trim().ToUpperInvariant();
	}

	if (tipo == "V")
	{
		decimal comision = LeerMonto("Comisión: ");
		personal.Add(new Vendedor(nombre, dni, sueldoBase, comision));
	}
	else
	{
		decimal bono = LeerMonto("Bono: ");
		personal.Add(new Directivo(nombre, dni, sueldoBase, bono));
	}
}

Console.WriteLine("\n=== Montos a depositar ===");
decimal totalNomina = 0;

// Polimorfismo: la misma lista invoca el cálculo particular de cada tipo de trabajador.
foreach (Trabajador trabajador in personal)
{
	decimal pago = trabajador.CalcularPago();
	totalNomina += pago;
	Console.WriteLine(
		$"{trabajador.Nombre} | DNI: {trabajador.Dni} | " +
		$"Base: {trabajador.SueldoBase:C} | Adicional: {trabajador.ImporteAdicional:C} | " +
		$"A depositar: {pago:C}");
}

Console.WriteLine($"\nTotal de nómina: {totalNomina:C}");

static string LeerTexto(string mensaje)
{
	Console.Write(mensaje);
	string valor = (Console.ReadLine() ?? string.Empty).Trim();
	while (string.IsNullOrWhiteSpace(valor))
	{
		Console.Write("El valor no puede estar vacío. " + mensaje);
		valor = (Console.ReadLine() ?? string.Empty).Trim();
	}

	return valor;
}

static int LeerEnteroPositivo(string mensaje)
{
	Console.Write(mensaje);
	while (true)
	{
		if (int.TryParse(Console.ReadLine(), out int valor) && valor > 0)
		{
			return valor;
		}

		Console.Write("Ingrese un número entero mayor que cero: ");
	}
}

static decimal LeerMonto(string mensaje, bool permitirCero = true)
{
	Console.Write(mensaje);
	while (true)
	{
		if (decimal.TryParse(Console.ReadLine(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal valor)
			&& (permitirCero ? valor >= 0 : valor > 0))
		{
			return valor;
		}

		Console.Write(permitirCero ? "Ingrese un monto igual o mayor que cero: " : "Ingrese un monto mayor que cero: ");
	}
}
