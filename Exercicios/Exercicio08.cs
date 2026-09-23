namespace ExerciciosInfnet.Exercicios;

// Classe base
public class Funcionario
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public decimal SalarioBase { get; set; }

    public virtual decimal CalcularSalario()
    {
        return SalarioBase;
    }

    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {Nome} | Cargo: {Cargo} | Salário: {CalcularSalario():C}");
    }
}

// Subclasse que herda de Funcionario e adiciona bônus
public class Gerente : Funcionario
{
    private const decimal PercentualBonus = 0.20m;

    public override decimal CalcularSalario()
    {
        return SalarioBase + (SalarioBase * PercentualBonus);
    }
}

public static class Exercicio08
{
    public static void Executar()
    {
        Console.WriteLine("=== Exercício 8: Cadastro de Funcionários (Herança) ===\n");

        Funcionario funcionario = new Funcionario
        {
            Nome = "Ana Souza",
            Cargo = "Analista",
            SalarioBase = 4000
        };

        Gerente gerente = new Gerente
        {
            Nome = "Carlos Lima",
            Cargo = "Gerente de Vendas",
            SalarioBase = 6000
        };

        funcionario.ExibirDados();
        gerente.ExibirDados();
    }
}
