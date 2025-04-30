namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public string _numero { get; }
    public TipoCuenta _tipo { get; private set; }
    public decimal _saldo { get; private set; }
    public Estado _estado { get; private set; }
    public string[] _titulares { get; private set; }

    public CuentaBancaria(string numero, decimal saldo)
    {
        _numero = numero;
        _saldo = saldo;
        _estado = Estado.Activa;
    }

    public void InicializarCuenta(TipoCuenta tipo, string[] titulares)
    {
        _tipo = tipo;
        _titulares = titulares;

    }
    public void CambiarEstado(Estado nuevoEstado)
    {
        _estado = nuevoEstado;
    }

    public void AumentarSaldo(decimal monto)
    {
        _saldo += monto;
    }

    public void DisminuirSaldo(decimal monto)
    {
        _saldo -= monto;
    }

    public void Suspender()
    {
        _estado = Estado.Suspendida;
    }

    public bool EstaActiva()
    {
        return _estado == Estado.Activa;
    }
}