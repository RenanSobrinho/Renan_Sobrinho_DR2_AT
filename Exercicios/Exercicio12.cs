using System.Text;

namespace ExerciciosInfnet.Exercicios;

// Classe que representa um contato
public class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
}

// Interface que define o contrato de formatação
public interface IContatoFormatter
{
    void ExibirContatos(List<Contato> contatos);
}

// Classe base que implementa a interface
public class ContatoFormatter : IContatoFormatter
{
    public virtual void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("Formato não implementado.");
    }
}

// Formatação em Markdown
public class MarkdownFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("\n## Lista de Contatos");
        foreach (var c in contatos)
        {
            Console.WriteLine($"- **Nome:** {c.Nome}");
            Console.WriteLine($"  - Telefone: {c.Telefone}");
            Console.WriteLine($"  - Email: {c.Email}");
        }
    }
}

// Formatação em Tabela
public class TabelaFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("| Nome | Telefone | Email |");
        Console.WriteLine("----------------------------------------");
        foreach (var c in contatos)
        {
            Console.WriteLine($"| {c.Nome} | {c.Telefone} | {c.Email} |");
        }
        Console.WriteLine("----------------------------------------");
    }
}

// Formatação em Texto Puro
public class RawTextFormatter : ContatoFormatter
{
    public override void ExibirContatos(List<Contato> contatos)
    {
        Console.WriteLine();
        foreach (var c in contatos)
        {
            Console.WriteLine($"Nome: {c.Nome} | Telefone: {c.Telefone} | Email: {c.Email}");
        }
    }
}

public static class Exercicio12
{
    private const string CaminhoArquivo = "contatos.txt";

    public static void Executar()
    {
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\n=== Gerenciador de Contatos (com Formatação) ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Exibir contatos");
            Console.WriteLine("3 - Voltar ao menu principal");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": AdicionarContato(); break;
                case "2": ExibirContatosFormatados(); break;
                case "3": sair = true; break;
                default: Console.WriteLine("Opção inválida!"); break;
            }
        }
    }

    private static void AdicionarContato()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        try
        {
            using StreamWriter writer = File.AppendText(CaminhoArquivo);
            writer.WriteLine($"{nome},{telefone},{email}");
            Console.WriteLine("Contato cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar contato: {ex.Message}");
        }
    }

    private static List<Contato> LerContatos()
    {
        List<Contato> contatos = new List<Contato>();

        if (!File.Exists(CaminhoArquivo))
            return contatos;

        foreach (string linha in File.ReadAllLines(CaminhoArquivo))
        {
            string[] partes = linha.Split(',');
            if (partes.Length == 3)
            {
                contatos.Add(new Contato
                {
                    Nome = partes[0],
                    Telefone = partes[1],
                    Email = partes[2]
                });
            }
        }

        return contatos;
    }

    private static void ExibirContatosFormatados()
    {
        List<Contato> contatos = LerContatos();

        if (contatos.Count == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        Console.WriteLine("\nEscolha o formato de exibição:");
        Console.WriteLine("1 - Markdown");
        Console.WriteLine("2 - Tabela");
        Console.WriteLine("3 - Texto Puro");
        Console.Write("Opção: ");

        string opcao = Console.ReadLine();

        // Seleção dinâmica da classe de formatação (polimorfismo)
        IContatoFormatter formatter = opcao switch
        {
            "1" => new MarkdownFormatter(),
            "2" => new TabelaFormatter(),
            "3" => new RawTextFormatter(),
            _ => new ContatoFormatter()
        };

        formatter.ExibirContatos(contatos);
    }
}
