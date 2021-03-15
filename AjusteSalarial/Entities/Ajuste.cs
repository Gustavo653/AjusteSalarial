﻿using System;
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

        public double SalarioHora(double salario, int horas)
        {
            double salarioHora;
            salarioHora = (salario * 12) / (52 * horas);
            return salarioHora;
        }
        public double AjusteINSS(double salario)
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
        public double AjusteIR(double salario)
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
        public double AjusteFGTS(double salario)
        {
            double FGTS = salario * 0.03;
            return FGTS;
        }
        public double AjusteHoraExtraSabado(int hExtraSabado)
        {
            double salarioHora = SalarioHora(Salario, Horas);
            salarioHora = salarioHora * 1.1;
            return salarioHora;
        }
        public double AjusteHoraExtraSemana(int hExtraSemana)
        {
            double salarioHora = SalarioHora(Salario, Horas);
            salarioHora = salarioHora * 0.5;
            return salarioHora;
        }
        public double ValeTransporte(double salario)
        {
            double valeTransporte;
            valeTransporte = salario * 0.06;
            return valeTransporte;
        }

        public override string ToString()
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
            return $"\n Seu salário bruto é de: {Salario} \n Seu salário hora é de: {salarioHora} " +
                $"\n O valor do INSS é de: {INSS} \n O valor do IR é de: {IR} \n O valor do seu FGTS é de: {FGTS}" +
                $"\n Suas horas extras em sábados foram de: {HESab} e de dias de semana foram de: {HESem}" +
                $"\n O valor do seu vale transporte foi de: {ValTrans} \n Seu salário líquido foi de: {SalarioLiquido}";
        }
    }
}
