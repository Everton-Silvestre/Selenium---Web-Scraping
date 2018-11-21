using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Teste3___Console_FrameWork
{
    class Program
    {
        static void Main(string[] args)
        {
            GPS gps = new GPS();

            Console.WriteLine("Digite o CNPJ");
            string cnpj = Console.ReadLine();

            Console.WriteLine("Digite a senha");
            string senha = Console.ReadLine();

            Console.WriteLine("Digite a competência");
            DateTime comp = DateTime.Parse(Console.ReadLine());

            gps.AbrirBrowser("http://gps.receita.fazenda.gov.br/");
            gps.PreencherCampoBrowser(cnpj,senha,comp);             

           
        }
    }
}
