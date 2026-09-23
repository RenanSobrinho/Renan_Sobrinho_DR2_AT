namespace ExerciciosInfnet.Exercicios;

// Classe que representa um Aluno
public class Aluno
{
    public string Nome { get; set; }
    public string Matricula { get; set; }
    public string Curso { get; set; }
    public double Media { get; set; }

    public void ExibirDados()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Matrícula: {Matricula}");
        Console.WriteLine($"Curso: {Curso}");
        Console.WriteLine($"Média: {Media}");
        Console.WriteLine($"Situação: {VerificarAprovacao()}");
    }

    public string VerificarAprovacao()
    {
        return Media >= 7 ? "Aprovado" : "Reprovado";
    }
}

public static class Exercicio06
{
    public static void Executar()
    {
        Console.WriteLine("=== Exercício 6: Cadastro de Alunos ===\n");

        Aluno aluno = new Aluno
        {
            Nome = "Renan",
            Matricula = "2026001",
            Curso = "Engenharia de Software",
            Media = 8.5
        };

        aluno.ExibirDados();
    }
}
