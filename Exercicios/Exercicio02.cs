namespace ExerciciosInfnet.Exercicios;

public static class Exercicio02
{
    public static void Executar()
    {
        Console.WriteLine("=== Exercício 2: Cifrador de Nome ===\n");

        Console.Write("Digite seu nome completo: ");
        string nome = Console.ReadLine() ?? "";

        string cifrado = CifrarTexto(nome);

        Console.WriteLine($"\nNome original: {nome}");
        Console.WriteLine($"Nome cifrado: {cifrado}");
    }

    // Desloca cada letra 2 posições no alfabeto, ignorando espaços e outros caracteres
    private static string CifrarTexto(string texto)
    {
        char[] caracteres = texto.ToCharArray();

        for (int i = 0; i < caracteres.Length; i++)
        {
            char c = caracteres[i];

            if (char.IsLetter(c) && c < 128) // ignora acentos e não-letras
            {
                bool maiuscula = char.IsUpper(c);
                char baseChar = maiuscula ? 'A' : 'a';

                // desloca 2 posições, voltando ao início do alfabeto se passar de 'Z'/'z'
                int posicao = (c - baseChar + 2) % 26;
                caracteres[i] = (char)(baseChar + posicao);
            }
            // espaços e outros caracteres permanecem inalterados
        }

        return new string(caracteres);
    }
}
