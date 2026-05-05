using System; // biblioteca padrão do sistema com classes genéricas
using System.Security.Cryptography; // biblioteca padrão do sistema relacionada a criptografia

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            string? dificuldade = ExibirMenuEscolhaDificuldade();

            ConfigurarPartida(dificuldade, out int numeroMaximo, out int tentativasMaximas);

            ExecutarPartida(numeroMaximo, tentativasMaximas);

            if (JogadorDesejaContinuar() == true)
                break;
        }
    }

    static string? ExibirMenuEscolhaDificuldade()
    {
        Console.Clear();

        Console.WriteLine("------------------------------------");
        Console.WriteLine("Jogo de Adivinhação");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Escolha o nível de dificuldade:");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("1 - Fácil (10 tentativas)");
        Console.WriteLine("2 - Médio (5 tentativas)");
        Console.WriteLine("3 - Difícil (3 tentativas)");
        Console.WriteLine("------------------------------------");

        Console.Write("Digite sua escolha: ");
        string? dificuldade = Console.ReadLine();

        return dificuldade;
    }

    static void ConfigurarPartida(string? dificuldade, out int numeroMaximo, out int tentativasMaximas)
    {
        numeroMaximo = 0;
        tentativasMaximas = 0;

        switch (dificuldade)
        {
            case "1":
                numeroMaximo = 20;
                tentativasMaximas = 10;
                break;

            case "2":
                numeroMaximo = 50;
                tentativasMaximas = 5;
                break;

            case "3":
                numeroMaximo = 100;
                tentativasMaximas = 3;
                break;

            default:
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Por favor, selecione uma dificuldade válida.");
                Console.Write("Digite ENTER para continuar...");
                Console.ReadLine();
                Environment.Exit(0);
                break;
        }
    }

    static void ExecutarPartida(int numeroMaximo, int tentativasMaximas)
    {
        int numeroAleatorio = RandomNumberGenerator.GetInt32(1, numeroMaximo + 1);

        int[] numerosDigitados = new int[100];
        int contadorNumerosDigitados = 0;
        int pontuacao = 1000;

        for (int tentativa = 1; tentativa <= tentativasMaximas; tentativa++)
        {
            Console.Clear();
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Tentativa {tentativa} de {tentativasMaximas}.");
            Console.WriteLine("------------------------------------");

            Console.Write($"Digite um número entre 1 e {numeroMaximo}: ");
            string? chute = Console.ReadLine();

            int numeroDigitado = Convert.ToInt32(chute);

            bool numeroEstaRepetido = false;

            for (int indiceChecado = 0; indiceChecado < numerosDigitados.Length; indiceChecado++)
            {
                if (numerosDigitados[indiceChecado] == numeroDigitado)
                {
                    numeroEstaRepetido = true;
                    break;
                }
            }

            if (numeroEstaRepetido == true)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Você já digitou esse número, tente novamente.");
                Console.WriteLine("------------------------------------");
                Console.Write("Digite ENTER para continuar...");
                Console.ReadLine();

                tentativa--;

                continue;
            }

            if (contadorNumerosDigitados < numerosDigitados.Length)
            {
                numerosDigitados[contadorNumerosDigitados] = numeroDigitado;

                contadorNumerosDigitados++;
            }

            if (numeroDigitado == numeroAleatorio)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Parabéns, você acertou!");
                Console.WriteLine("------------------------------------");

                break;
            }
            else if (numeroDigitado > numeroAleatorio)
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("O número digitado foi maior que o número secreto!");
                Console.WriteLine("------------------------------------");
            }
            else
            {
                Console.WriteLine("------------------------------------");
                Console.WriteLine("O número digitado foi menor que o número secreto!");
                Console.WriteLine("------------------------------------");
            }

            int diferencaNumerica = Math.Abs(numeroAleatorio - numeroDigitado); // 90 - 100 = 10;

            if (diferencaNumerica >= 10)
            {
                pontuacao -= 100;
            }
            else if (diferencaNumerica >= 5)
            {
                pontuacao -= 50;
            }
            else
            {
                pontuacao -= 20;
            }

            Console.WriteLine("Sua pontuação é: " + pontuacao);
            Console.WriteLine("------------------------------------");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();

            if (tentativa == tentativasMaximas)
            {
                Console.WriteLine($"Você usou todas as suas tentativas! O número era {numeroAleatorio}.");
                Console.WriteLine("------------------------------------");
                break;
            }
        }
    }

    static bool JogadorDesejaContinuar()
    {
        Console.Write("Deseja continuar? (s/N): ");
        string? opcaoContinuar = Console.ReadLine();

        if (opcaoContinuar?.ToUpper() != "S")
            return false;

        return true;
    }
}



