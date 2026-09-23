namespace ExerciciosInfnet.Exercicios;

public class Produto
{
    public string Nome { get; set; }
    public int Quantidade { get; set; }
    public decimal Preco { get; set; }
}

public static class Exercicio09
{
    private const string CaminhoArquivo = "estoque.txt";

    public static void Executar()
    {
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("\n=== Controle de Estoque ===");
            Console.WriteLine("1 - Inserir Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Voltar ao menu principal");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": InserirProduto(); break;
                case "2": ListarProdutos(); break;
                case "3": sair = true; break;
                default: Console.WriteLine("Opção inválida!"); break;
            }
        }
    }

    private static void InserirProduto()
    {
        // Verifica quantos produtos já existem no arquivo
        int quantidadeAtual = 0;
        if (File.Exists(CaminhoArquivo))
            quantidadeAtual = File.ReadAllLines(CaminhoArquivo).Length;

        if (quantidadeAtual >= 5)
        {
            Console.WriteLine("Limite de produtos atingido!");
            return;
        }

        Console.Write("Nome do produto: ");
        string nome = Console.ReadLine();

        Console.Write("Quantidade em estoque: ");
        if (!int.TryParse(Console.ReadLine(), out int quantidade))
        {
            Console.WriteLine("Quantidade inválida!");
            return;
        }

        Console.Write("Preço unitário: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal preco))
        {
            Console.WriteLine("Preço inválido!");
            return;
        }

        try
        {
            // AppendText evita sobrescrever o arquivo
            using StreamWriter writer = File.AppendText(CaminhoArquivo);
            writer.WriteLine($"{nome},{quantidade},{preco.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            Console.WriteLine("Produto cadastrado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao salvar produto: {ex.Message}");
        }
    }

    private static void ListarProdutos()
    {
        if (!File.Exists(CaminhoArquivo))
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        string[] linhas = File.ReadAllLines(CaminhoArquivo);

        if (linhas.Length == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        Console.WriteLine("\nProdutos cadastrados:");
        foreach (string linha in linhas)
        {
            try
            {
                string[] partes = linha.Split(',');
                string nome = partes[0];
                int quantidade = int.Parse(partes[1]);
                decimal preco = decimal.Parse(partes[2], System.Globalization.CultureInfo.InvariantCulture);

                Console.WriteLine($"Produto: {nome} | Quantidade: {quantidade} | Preço: {preco:C}");
            }
            catch
            {
                Console.WriteLine("Linha corrompida ou em formato incorreto, ignorada.");
            }
        }
    }
}
