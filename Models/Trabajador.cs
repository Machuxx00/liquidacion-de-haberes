namespace LiquidacionHaberes.Models;

public abstract class Trabajador
{
    // Encapsulamiento: los datos se leen desde afuera, pero solo se asignan al construir el objeto.
    public string Nombre { get; private set; }
    public string Dni { get; private set; }
    public decimal SueldoBase { get; private set; }

    public abstract decimal ImporteAdicional { get; }

    protected Trabajador(string nombre, string dni, decimal sueldoBase)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre es obligatorio.", nameof(nombre));
        }

        if (string.IsNullOrWhiteSpace(dni))
        {
            throw new ArgumentException("El DNI es obligatorio.", nameof(dni));
        }

        if (sueldoBase <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(sueldoBase), "El sueldo base debe ser mayor que cero.");
        }

        Nombre = nombre.Trim();
        Dni = dni.Trim();
        SueldoBase = sueldoBase;
    }

    public abstract decimal CalcularPago();
}