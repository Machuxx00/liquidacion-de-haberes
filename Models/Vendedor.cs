namespace LiquidacionHaberes.Models;

// Herencia: Vendedor reutiliza los datos y el contrato definidos por Trabajador.
public sealed class Vendedor : Trabajador
{
    public decimal Comision { get; private set; }
    public override decimal ImporteAdicional => Comision;

    public Vendedor(string nombre, string dni, decimal sueldoBase, decimal comision)
        : base(nombre, dni, sueldoBase)
    {
        if (comision < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(comision), "La comisión no puede ser negativa.");
        }

        Comision = comision;
    }

    // Polimorfismo: este cálculo suma la comisión al sueldo base.
    public override decimal CalcularPago() => SueldoBase + Comision;
}