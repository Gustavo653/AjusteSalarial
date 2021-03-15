using System;
using System.Collections.Generic;
using System.Text;

namespace AjusteSalarial.Entities
{
    class Ajuste
    {
        public double Salario { get; set; }
        public int HExtraSabado { get; set; }
        public int HExtraSemana { get; set; }
        public int Horas { get; set; }

        public Ajuste(double salario, int hExtraSabado, int hExtraSemana, int horas)
        {
            Salario = salario;
            HExtraSabado = hExtraSabado;
            HExtraSemana = hExtraSemana;
            Horas = horas;
        }

        public double SalarioHora(double salario, int horas) //Calcula o salário hora
        {
            double salarioHora;
            salarioHora = (salario * 12) / (52 * horas);
            return salarioHora; 
        }
        public double AjusteINSS(double salario) //Calcula o valor do INSS
        {
            //INSS
            double INSS;
            if (salario <= 1045)
            {
                INSS = salario * 0.075;
                return INSS;
            }
            else if (salario <= 1830.29)
            {
                INSS = salario * 0.08;
                return INSS;
            }
            else if (salario <= 3050.52)
            {
                INSS = salario * 0.09;
                return INSS;
            }
            else
            {
                INSS = salario * 0.11;
                return INSS;
            }
        }
        public double AjusteIR(double salario) //Calcula o valor do IR
        {
            double IR;
            if (salario <= 1903.99)
            {
                return 0;
            }
            else if (salario <= 2826.66)
            {
                IR = salario * 0.075;
                return IR;
            }
            else if (salario <= 3751.05)
            {
                IR = salario * 0.15;
                return IR;
            }
            else if (salario <= 4664.68)
            {
                IR = salario * 0.225;
                return IR;
            }
            else
            {
                IR = salario * 0.275;
                return IR;
            }
        }
        public double AjusteFGTS(double salario) //Calcula o valor do FGTS
        {
            double FGTS = salario * 0.03;
            return FGTS;
        }
        public double AjusteHoraExtraSabado(int hExtraSabado) //Calcula o valor das horas extras
        {
            double salarioHora = SalarioHora(Salario, Horas);
            salarioHora = salarioHora * 1.1;
            return salarioHora;
        }
        public double AjusteHoraExtraSemana(int hExtraSemana) //Calcula o valor das horas extras
        {
            double salarioHora = SalarioHora(Salario, Horas);
            salarioHora = salarioHora * 0.5;
            return salarioHora;
        }
        public double ValeTransporte(double salario) //Calcula o valor do vale transporte
        {
            double valeTransporte;
            valeTransporte = salario * 0.06;
            return valeTransporte;
        }

        public override string ToString() //Faz o cálculo do salário líquido e mostra o resultado formatado
        {
            double salarioHora = SalarioHora(Salario, Horas);
            double INSS = AjusteINSS(Salario);
            double FGTS = AjusteFGTS(Salario);
            double HESab = AjusteHoraExtraSabado(HExtraSabado);
            double HESem = AjusteHoraExtraSemana(HExtraSemana);
            double ValTrans = ValeTransporte(Salario);
            double SalarioLiquido = Salario - (INSS + ValTrans);
            SalarioLiquido = SalarioLiquido + (HESab + HESem);
            double IR = AjusteIR(SalarioLiquido);
            SalarioLiquido = SalarioLiquido - IR;
            return $"\n Seu salário bruto é de: R${Salario} \n Seu salário hora é de: R${salarioHora.ToString("F2")} " +
                $"\n O valor do INSS é de: R${INSS.ToString("F2")} \n O valor do IR é de: R${IR.ToString("F2")} \n O valor do seu FGTS é de: R${FGTS.ToString("F2")}" +
                $"\n Suas horas extras em sábados foram de: R${HESab.ToString("F2")} e de dias de semana foram de: R${HESem.ToString("F2")}" +
                $"\n O valor do seu vale transporte foi de: R${ValTrans.ToString("F2")} \n Seu salário líquido é de: R${SalarioLiquido.ToString("F2")}";
        }
    }
}
