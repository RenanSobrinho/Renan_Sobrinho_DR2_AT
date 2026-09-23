namespace ExerciciosInfnet.Exercicios;

public static class Exercicio10
{
    public static void Executar()
    {
        Console.WriteLine("=== Exercício 10: Jogo de Adivinhação ===\n");

        Random random = new Random();
        int numeroSecreto = random.Next(1, 51); // 1 a 50

        int tentativasRestantes = 5;
        bool acertou = false;

        Console.WriteLine("Adivinhe o número entre 1 e 50! Você tem 5 tentativas.\n");

        while (tentativasRestantes > 0 && !acertou)
        {
            Console.Write($"Tentativas restantes: {tentativasRestantes} - Digite um número: ");
            string entrada = Console.ReadLine();

            if (!int.TryParse(entrada, out int palpite))
            {
                Console.WriteLine("Entrada inválida! Digite um número inteiro.\n");
                continue;
            }

            if (palpite < 1 || palpite > 50)
            {
                Console.WriteLine("Número fora do intervalo! Digite um valor entre 1 e 50.\n");
                continue;
            }

            tentativasRestantes--;

            if (palpite == numeroSecreto)
            {
                acertou = true;
                Console.WriteLine($"\nParabéns! Você acertou o número {numeroSecreto}!");
            }
            else if (palpite < numeroSecreto)
            {
                Console.WriteLine("O número secreto é maior!\n");
            }
            else
            {
                Console.WriteLine("O número secreto é menor!\n");
            }
        }

        if (!acertou)
            Console.WriteLine($"\nSuas tentativas acabaram! O número secreto era {numeroSecreto}.");
    }
}
