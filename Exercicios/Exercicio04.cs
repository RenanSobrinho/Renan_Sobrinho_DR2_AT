namespace ExerciciosInfnet.Exercicios;

public static class Exercicio04
{
    public static void Executar()
    {
        Console.WriteLine("=== Exercício 4: Dias até o Próximo Aniversário ===\n");

        DateTime nascimento = LerData("Digite sua data de nascimento (dd/MM/yyyy): ");

        DateTime hoje = DateTime.Today;

        // Calcula o próximo aniversário
        DateTime proximoAniversario = new DateTime(hoje.Year, nascimento.Month, nascimento.Day);

        if (proximoAniversario < hoje)
            proximoAniversario = proximoAniversario.AddYears(1);

        int diasRestantes = (proximoAniversario - hoje).Days;

        Console.WriteLine($"\nFaltam {diasRestantes} dia(s) para seu próximo aniversário!");

        if (diasRestantes < 7)
            Console.WriteLine("Seu aniversário está chegando! Prepare a festa! 🎉");
    }

    private static DateTime LerData(string mensagem)
    {
        DateTime data;
        while (true)
        {
            Console.Write(mensagem);
            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out data))
                return data;

            Console.WriteLine("Data inválida! Use o formato dd/MM/yyyy.");
        }
    }
}
