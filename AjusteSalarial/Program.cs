using System;
using AjusteSalarial.Entities;

namespace AjusteSalarial
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Insira seu salário bruto: R$");
                double salario = double.Parse(Console.ReadLine());
                Console.Write("Insira quantas horas você trabalha por mês: ");
                int horas = int.Parse(Console.ReadLine());
                Console.Write("Insira a quantidade de horas extras feitas em sábados: ");
                int hExtraSabado = int.Parse(Console.ReadLine());
                Console.Write("Insira a quantidade de horas extras feitas em dias de semana: ");
                int hExtraSemana = int.Parse(Console.ReadLine());
                Ajuste ajuste = new Ajuste(salario, hExtraSabado, hExtraSemana, horas); //Manda os dados para a classe Ajuste
                Console.WriteLine(ajuste.ToString()); //Exibe os dados formatados
            }
            catch (FormatException) //Erro de formato dos dados inseridos
            {
                Console.WriteLine("Valor inserido não reconhecido, insira apenas números.");
                Console.WriteLine();
                Main(args);
            }
            catch (Exception e) //Erro genérico
            {
                Console.WriteLine("Erro inesperado!");
                Console.WriteLine(e.Message);
                Main(args);
            }
        }
    }
}
