namespace ExerciciosInfnet.Exercicios;

public static class Exercicio11
{
    private const string CaminhoArquivo = "contatos.txt";

    public static void Executar()
    {
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\n=== Gerenciador de Contatos ===");
            Console.WriteLine("1 - Adicionar novo contato");
            Console.WriteLine("2 - Listar contatos cadastrados");
            Console.WriteLine("3 - Voltar ao menu principal");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": AdicionarContato(); break;
                case "2": ListarContatos(); break;
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

    private static void ListarContatos()
    {
        if (!File.Exists(CaminhoArquivo))
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        string[] linhas = File.ReadAllLines(CaminhoArquivo);

        if (linhas.Length == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
            return;
        }

        Console.WriteLine("\nContatos cadastrados:");
        foreach (string linha in linhas)
        {
            string[] partes = linha.Split(',');
            if (partes.Length == 3)
                Console.WriteLine($"Nome: {partes[0]} | Telefone: {partes[1]} | Email: {partes[2]}");
        }
    }
}
