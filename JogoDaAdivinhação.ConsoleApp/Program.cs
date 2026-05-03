//Objetivos/ Passo-a-Passo

//v1
//1.Nosso jogo deve aceitar o input do jogador e exibir o valor digitado
//2.Nosso jogo deve gerar um número secreto aleatório
//3.Nosso jogo deve validar a tentativa do jogador e exibir uma mensagem
//4.Nosso jogo deve permitir múltiplas tentativas

//v2
//1. Nosso implementar a funcionalidade de Dificuldade e Tentativas limitadas

using System;// biblioteca padrão do sistema com classes genéricas
using System.Security.Cryptography;//  biblioteca padrão do sistema relacionada a criptografia


while(true == true)
{
   //Console.Clear();

    Console.WriteLine("-----------------------------------");
    Console.WriteLine("jogo da Adivinhação");
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("Escolha o nível de Dificuldade:");
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("1 - Fácil (10 tentativas)");
    Console.WriteLine("2 - médio (5 tentativas)");
    Console.WriteLine("3 - Dificuldade (3 tentativas)");
    Console.WriteLine("-----------------------------------");

    Console.Write("Digite sua Escolha: ");
    string? Dificuldade = Console.ReadLine();

    int numeroMaximo = 0;
    int TentativasMaximas;

    switch(Dificuldade)
    {
        case"1":
            numeroMaximo = 20;
            TentativasMaximas = 10;
            break;

        case"2":
            numeroMaximo = 50;
            TentativasMaximas = 5;
             break;

        case"3":
            numeroMaximo = 100;
            TentativasMaximas = 3;
            break;

        default:
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("por favor, selecione uma Dificuldade válida.");
            Console.Write("Digite ENTER para continuar...");
            Console.ReadLine();
            continue;
    }

    int numeroAleatorio = RandomNumberGenerator.GetInt32(1, numeroMaximo + 1);

    for (int tentativa = 1; tentativa <= TentativasMaximas; tentativa++)
    {
        Console.Clear();
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("$Tentativas{tentativa} de {TentativasMaximas}.");
        Console.WriteLine("-----------------------------------"); 
        Console.Write($"Digite um número entre 1 e {numeroMaximo}: ");
    string? chute = Console.ReadLine();

    int numeroDigitado = Convert.ToInt32(chute);
   
    if(numeroDigitado == numeroAleatorio)
    {
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("parabéns, você acertou!");
    Console.WriteLine("-----------------------------------");

        break;
    }
    else if (numeroDigitado > numeroAleatorio)
    {
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("O número digitado foi maior que o número secreto!");
    Console.WriteLine("-----------------------------------");  
    }
    else
    {
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("O número digitado foi menor que o número secreto!");
    Console.WriteLine("-----------------------------------");
    } 
       if(tentativa == TentativasMaximas)
        {
           Console.WriteLine($"você usou todas as suas tentativas! O número era {numeroAleatorio}.");
           Console.WriteLine("-----------------------------------"); 
           break;
        }
          Console.ReadLine();
    }

    
    Console.Write("Deseja continuar ? (s/N): ");
    string? opcaoContinuar = Console.ReadLine(); 

    if(opcaoContinuar?.ToUpper() != "S")
    {
       break; 
    }

}

03;04


