using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste3___Console_FrameWork
{
    class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Digite a competência");
            DateTime comp = DateTime.Parse(Console.ReadLine());


            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://gps.receita.fazenda.gov.br/");


            System.Threading.Thread.Sleep(2000);

            IWebElement element = driver.FindElement(By.Name("formInicio:botaoConsultar"));

            IWebElement ele_cnpj = driver.FindElement(By.Name("formInicio:identificador"));

            IWebElement ele_senha = driver.FindElement(By.Name("formInicio:senha"));

            IWebElement ele_comp = driver.FindElement(By.Name("formInicio:competencia"));

            ele_cnpj.SendKeys("76101989000191");
            ele_senha.SendKeys("76101989");
            ele_comp.SendKeys(comp.Month.ToString("00") + comp.Year.ToString("0000"));

            System.Threading.Thread.Sleep(10000);

            element.SendKeys(OpenQA.Selenium.Keys.Enter);


            //ReadOnlyCollection<IWebElement> elem = driver.FindElementsByClassName("coluna24");

            //int i = 0;
            //IList<string> all = new List<string>();

            //foreach (IWebElement iwebelement in elem)
            //{
            //    all.Add(elem.tex);
            //    Console.WriteLine(elem.ToList().);

            //}

            var contador = comp.Month;

            Hashtable hashtable = new Hashtable();

            //List<string> lista = new List<string>();

            foreach (var tag in driver.FindElements(By.ClassName("coluna24")).Where(x => x.Text != "" ))
            {
                
                Console.Write(tag.Text);
                //lista.Add(tag.Text);
            }

            while (contador > 0)
            {

                System.Threading.Thread.Sleep(2000);

                IWebElement pesquisa = driver.FindElement(By.LinkText(contador.ToString("00") +"/"+ comp.Year.ToString("0000")));

                pesquisa.SendKeys(OpenQA.Selenium.Keys.Enter);

                Screenshot image = driver.GetScreenshot();

                image.SaveAsFile("C:/Users/A36372/Desktop/Screenshot" + contador.ToString("00") + comp.Year.ToString("0000") + ".png", ScreenshotImageFormat.Png);

                driver.Navigate().Back();

                //IWebElement pesquisa2 = driver.FindElement(By.LinkText());

                //pesquisa2.SendKeys(OpenQA.Selenium.Keys.Enter);

                //Console.ReadKey();

                contador--;

            }


        }
    }
}
