using ExerciciosInfnet.Exercicios;

bool sair = false;

while (!sair)
{
    Console.Clear();
    Console.WriteLine("=== MENU DE EXERCÍCIOS - INFNET ===");
    Console.WriteLine("1  - Primeiro Programa");
    Console.WriteLine("2  - Cifrador de Nome");
    Console.WriteLine("3  - Calculadora");
    Console.WriteLine("4  - Dias até o Aniversário");
    Console.WriteLine("5  - Tempo até a Formatura");
    Console.WriteLine("6  - Cadastro de Alunos");
    Console.WriteLine("7  - Banco Digital");
    Console.WriteLine("8  - Cadastro de Funcionários");
    Console.WriteLine("9  - Controle de Estoque");
    Console.WriteLine("10 - Jogo de Adivinhação");
    Console.WriteLine("11 - Cadastro de Contatos");
    Console.WriteLine("12 - Formatters de Contatos");
    Console.WriteLine("0  - Sair");
    Console.Write("\nEscolha uma opção: ");

    string opcao = Console.ReadLine();

    try
    {
        switch (opcao)
        {
            case "1": Exercicio01.Executar(); break;
            case "2": Exercicio02.Executar(); break;
            case "3": Exercicio03.Executar(); break;
            case "4": Exercicio04.Executar(); break;
            case "5": Exercicio05.Executar(); break;
            case "6": Exercicio06.Executar(); break;
            case "7": Exercicio07.Executar(); break;
            case "8": Exercicio08.Executar(); break;
            case "9": Exercicio09.Executar(); break;
            case "10": Exercicio10.Executar(); break;
            case "11": Exercicio11.Executar(); break;
            case "12": Exercicio12.Executar(); break;
            case "0": sair = true; break;
            default:
                Console.WriteLine("Opção inválida!");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
    }

    if (!sair)
    {
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
}

Console.WriteLine("Encerrando programa...");
