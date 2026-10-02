# Liquidación de haberes

Aplicación de consola en C# para calcular los depósitos de una nómina mixta de vendedores y directivos.

## Requisitos

- .NET 9 SDK

## Ejecutar

Desde la carpeta del proyecto:

```bash
dotnet run
```

Ingresá la cantidad de trabajadores y, para cada persona, su nombre, DNI, sueldo base y tipo. Los vendedores agregan una comisión y los directivos un bono. Al final se muestra el importe a depositar para cada trabajador y el total de la nómina.

## Diseño

- `Trabajador` es la clase abstracta con los datos comunes y el contrato de cálculo.
- `Vendedor` y `Directivo` heredan de `Trabajador` y calculan el pago sumando su comisión o bono.
- El programa procesa ambos tipos en una lista de `Trabajador`, usando polimorfismo para calcular cada depósito.
- Los datos se encapsulan con propiedades de solo lectura externa.