namespace ExerciciosInfnet.Exercicios;

// Classe que representa uma Conta Bancária, com encapsulamento do saldo
public class ContaBancaria
{
    public string Titular { get; set; }
    private decimal saldo; // privado - não acessível diretamente de fora

    public ContaBancaria(string titular, decimal saldoInicial = 0)
    {
        Titular = titular;
        saldo = saldoInicial;
    }

    public void Depositar(decimal valor)
    {
        if (valor <= 0)
        {
            Console.WriteLine("O valor do depósito deve ser positivo!");
            return;
        }

        saldo += valor;
        Console.WriteLine($"Depósito de {valor:C} realizado com sucesso!");
        ExibirSaldo();
    }

    public void Sacar(decimal valor)
    {
        Console.WriteLine($"Tentativa de saque: {valor:C}");

        if (valor > saldo)
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque!");
            return;
        }

        saldo -= valor;
        Console.WriteLine($"Saque de {valor:C} realizado com sucesso!");
        ExibirSaldo();
    }

    public void ExibirSaldo()
    {
        Console.WriteLine($"Saldo atual: {saldo:C}");
    }
}

public static class Exercicio07
{
    public static void Executar()
    {
        Console.WriteLine("=== Exercício 7: Banco Digital (Encapsulamento) ===\n");

        ContaBancaria conta = new ContaBancaria("João Silva");

        Console.WriteLine($"Titular: {conta.Titular}\n");

        conta.Depositar(500);
        Console.WriteLine();
        conta.Sacar(700);
        Console.WriteLine();
        conta.Sacar(200);
    }
}
