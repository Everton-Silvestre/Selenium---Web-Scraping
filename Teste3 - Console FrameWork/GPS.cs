using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Teste3___Console_FrameWork
{
    public class GPS
    {
        //private object driver;

        public string Competencia { get; set; }
        public string CodGps { get; set; }
        public string ValorInss { get; set; }
        public string Cnpj { get; set; }
        public string ValorTerceiros { get; set; }
        public string Total { get; set; }
        private ChromeDriver driver { get; set; }
        private int contador { get; set; }


        public void PreencherCampoBrowser(string cnpj, string senha, DateTime comp)
        {

            IWebElement element = driver.FindElement(By.Name("formInicio:botaoConsultar"));
            IWebElement ele_cnpj = driver.FindElement(By.Name("formInicio:identificador"));
            IWebElement ele_senha = driver.FindElement(By.Name("formInicio:senha"));
            IWebElement ele_comp = driver.FindElement(By.Name("formInicio:competencia"));
            IWebElement cpt = driver.FindElement(By.Name("captcha_campo_resposta"));

            ele_cnpj.SendKeys(cnpj);
            ele_senha.SendKeys(senha);
            ele_comp.SendKeys(comp.Month.ToString("00") + comp.Year.ToString("0000"));
            cpt.SendKeys("");

            System.Threading.Thread.Sleep(10000);

            element.SendKeys(OpenQA.Selenium.Keys.Enter);

            ListarLinks(comp);

        }

        public void ListarLinks(DateTime comp)
        {
            contador = comp.Month;

            while (contador > 0)
            {
                IWebElement pesquisa = driver.FindElement(By.LinkText(contador.ToString("00") + "/" + comp.Year.ToString("0000")));
                pesquisa.SendKeys(OpenQA.Selenium.Keys.Enter);


                ICollection<IWebElement> links = driver.FindElements(By.TagName("a"));
                ICollection<IWebElement> valores = driver.FindElements(By.TagName("td"));
                for (int i = 0; i < links.Count() - 1; i++)
                {
                    links = driver.FindElements(By.TagName("a"));
                    var numDoc = links.ElementAt(i).Text;
                    links.ElementAt(i).Click();
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "aux.html";
                    string path2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\GPS";
                    Directory.CreateDirectory(path2);
                    File.WriteAllText(path, driver.PageSource, Encoding.UTF8);
                    string html = File.ReadAllText(path, Encoding.UTF8);
                    var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                    htmlToPdf.GeneratePdfFromFile(path, null, Path.GetFullPath(path2) + "\\" + contador.ToString("00") + comp.Year + "_" + numDoc + ".pdf");
                    driver.Navigate().Back();
                }

                driver.FindElements(By.TagName("a"));
                driver.FindElements(By.TagName("a")).LastOrDefault().Click();
                contador--;
            }

            driver.Close();
            Console.WriteLine("Finalizado");

        }

        public void AbrirBrowser(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://gps.receita.fazenda.gov.br/");

        }




    }

    
}
