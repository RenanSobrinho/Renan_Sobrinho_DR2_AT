namespace ExerciciosInfnet.Exercicios;

public static class Exercicio05
{
    public static void Executar()
    {
        Console.WriteLine("=== Exercício 5: Tempo até a Formatura ===\n");

        // Data de formatura definida manualmente no código
        DateTime dataFormatura = new DateTime(2026, 12, 15);

        DateTime dataAtual = LerData("Digite a data atual (dd/MM/yyyy): ");

        if (dataAtual > DateTime.Today)
        {
            Console.WriteLine("\nErro: A data informada não pode ser no futuro!");
            return;
        }

        if (dataAtual >= dataFormatura)
        {
            Console.WriteLine("\nParabéns! Você já deveria estar formado!");
            return;
        }

        // Calcula diferença em anos, meses e dias
        int anos = dataFormatura.Year - dataAtual.Year;
        int meses = dataFormatura.Month - dataAtual.Month;
        int dias = dataFormatura.Day - dataAtual.Day;

        if (dias < 0)
        {
            meses--;
            dias += DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month);
        }

        if (meses < 0)
        {
            anos--;
            meses += 12;
        }

        // Monta a mensagem de saída
        string mensagem = "Faltam ";
        if (anos > 0) mensagem += $"{anos} ano(s), ";
        mensagem += $"{meses} mes(es) e {dias} dia(s) para sua formatura!";

        Console.WriteLine($"\n{mensagem}");

        // Verifica se faltam menos de 6 meses (total em meses, ignorando anos)
        int totalMeses = anos * 12 + meses;
        if (totalMeses < 6)
            Console.WriteLine("A reta final chegou! Prepare-se para a formatura!");
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
