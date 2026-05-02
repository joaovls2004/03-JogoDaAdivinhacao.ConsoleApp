//Objetivos/ Passo-a-Passo
//1.Nosso jogo deve aceitar o input do jogador e exibir o valor digitado
//2.Nosso jogo deve gerar um número secreto aleatório
//3.Nosso jogo deve validar a tentativa do jogador e exibir uma mensagem

using System;

 // eu quero usar a biblioteca padrão do sistema relacionada a criptografia
using System.Security.Cryptography;

bool deveContinuar = true;

while(true == true)
{
   //Console.Clear();

    Console.WriteLine("-----------------------------------");
    Console.WriteLine("jogo da Adivinhação");
    Console.WriteLine("-----------------------------------");

    int numeroAleatorio = RandomNumberGenerator.GetInt32(1, 21);

    Console.Write("Digite um número entre 1 e 20: ");
    string? chute = Console.ReadLine();

    int numeroDigitado = Convert.ToInt32(chute);

    if(numeroDigitado == numeroAleatorio)
    {
    Console.WriteLine("-----------------------------------");
    Console.WriteLine("parabéns, você acertou!");
    Console.WriteLine("-----------------------------------");
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

    Console.WriteLine("Deseja continuar ? (s/N): ");
    string? opcaoContinuar = Console.ReadLine();

    if(opcaoContinuar.ToUpper() != "S")
    {
       break; 
    }

    Console.ReadLine();

}




