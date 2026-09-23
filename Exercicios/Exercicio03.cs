namespace ExerciciosInfnet.Exercicios;

public static class Exercicio03
{
    public static void Executar()
    {
        Console.WriteLine("=== Exercício 3: Calculadora ===\n");

        double numero1 = LerNumero("Digite o primeiro número: ");
        double numero2 = LerNumero("Digite o segundo número: ");

        int operacao = LerOperacao();

        double resultado = 0;
        bool sucesso = true;
        string simbolo = "";

        switch (operacao)
        {
            case 1:
                resultado = numero1 + numero2;
                simbolo = "+";
                break;
            case 2:
                resultado = numero1 - numero2;
                simbolo = "-";
                break;
            case 3:
                resultado = numero1 * numero2;
                simbolo = "*";
                break;
            case 4:
                if (numero2 == 0)
                {
                    Console.WriteLine("\nErro: Divisão por zero não é permitida!");
                    sucesso = false;
                }
                else
                {
                    resultado = numero1 / numero2;
                    simbolo = "/";
                }
                break;
        }

        if (sucesso)
            Console.WriteLine($"\nResultado: {numero1} {simbolo} {numero2} = {resultado}");
    }

    private static double LerNumero(string mensagem)
    {
        double numero;
        while (true)
        {
            Console.Write(mensagem);
            if (double.TryParse(Console.ReadLine(), out numero))
                return numero;

            Console.WriteLine("Valor inválido! Digite um número.");
        }
    }

    private static int LerOperacao()
    {
        int opcao;
        while (true)
        {
            Console.WriteLine("\nEscolha a operação:");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.Write("Opção: ");

            if (int.TryParse(Console.ReadLine(), out opcao) && opcao >= 1 && opcao <= 4)
                return opcao;

            Console.WriteLine("Opção inválida! Digite 1, 2, 3 ou 4.");
        }
    }
}
