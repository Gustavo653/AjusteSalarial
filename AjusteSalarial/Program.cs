using System;
using AjusteSalarial.Entities;

namespace AjusteSalarial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Insira seu salário bruto: ");
            double salario = double.Parse(Console.ReadLine());
            Console.Write("Insira quantas horas você trabalha por mês: ");
            int horas = int.Parse(Console.ReadLine());
            Console.Write("Insira a quantidade de horas extras feitas em sábados: ");
            int hExtraSabado = int.Parse(Console.ReadLine());
            Console.Write("Insira a quantidade de horas extras feitas em dias de semana: ");
            int hExtraSemana = int.Parse(Console.ReadLine());
            Ajuste ajuste = new Ajuste(salario, hExtraSabado, hExtraSemana, horas);
            Console.WriteLine(ajuste.ToString());
        }
    }
}
