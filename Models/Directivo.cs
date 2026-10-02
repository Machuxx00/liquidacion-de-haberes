namespace LiquidacionHaberes.Models;

// Herencia: Directivo también especializa el contrato común de Trabajador.
public sealed class Directivo : Trabajador
{
    public decimal Bono { get; private set; }
    public override decimal ImporteAdicional => Bono;

    public Directivo(string nombre, string dni, decimal sueldoBase, decimal bono)
        : base(nombre, dni, sueldoBase)
    {
        if (bono < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bono), "El bono no puede ser negativo.");
        }

        Bono = bono;
    }

    // Polimorfismo: este cálculo suma el bono al sueldo base.
    public override decimal CalcularPago() => SueldoBase + Bono;
}