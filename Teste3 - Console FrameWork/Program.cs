using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PdfSharp;
using PdfSharp.Pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TheArtOfDev.HtmlRenderer.PdfSharp;



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

            //Hashtable hashtable = new Hashtable();

            //List<int> lista = new List<int>();

           
            //foreach (var tag in driver.FindElements(By.ClassName("coluna24")).Where(x => x.Text != "").Where(x=>!x.Text.Contains("/")).Where(x => !x.Text.Contains(",")))
            //{
            //    lista.Add(int.Parse(tag.Text));
            //    Console.Write(tag.Text);
                
            //}

            while (contador > 0)
            {

                System.Threading.Thread.Sleep(2000);

                IWebElement pesquisa = driver.FindElement(By.LinkText(contador.ToString("00") +"/"+ comp.Year.ToString("0000")));

                pesquisa.SendKeys(OpenQA.Selenium.Keys.Enter);


                ICollection<IWebElement> links = driver.FindElements(By.TagName("a"));

                ICollection<IWebElement> valores = driver.FindElements(By.TagName("td"));

                //links.ToList().;


                for (int i=0;i < links.Count() - 1;i++ )
                {
                    links = driver.FindElements(By.TagName("a"));
                    var numDoc = links.ElementAt(i).Text;
                    links.ElementAt(i).Click();





                    //var tag = driver.FindElements(By.TagName("td")).FirstOrDefault();

                    //String[] elements = Regex.Split(tag.Text.Trim().Replace("\r", ""), "\n");


                    //GPS gps = new GPS
                    //{

                    //    CodGps = elements[5],
                    //    Competencia = elements[6],                        
                    //    Cnpj = elements[7],
                    //    ValorInss = elements[8],
                    //    ValorTerceiros = elements[9]


                    //};


                    //Console.WriteLine(elements[5]);
                    //Console.WriteLine(elements[6]);
                    //Console.WriteLine(elements[7]);
                    //Console.WriteLine(elements[8]);
                    //Console.WriteLine(elements[9]);

                    //foreach (var tag in driver.FindElements(By.TagName("td")))
                    //{
                    //    //Console.WriteLine(tag.Text);

                    //    //foreach (var tag2 in tag.FindElements(By.TagName("font")))
                    //    //{
                    //    //    Console.WriteLine(tag2.Text.ElementAt(tag2.Text.inde));
                    //    //    //tag2.
                    //    //}
                    //    //continue;                                             
                    //}

                    //Screenshot image = driver.GetScreenshot();
                    //image.SaveAsFile("C:/Users/A36372/Desktop/Screenshot" +"-" + contador.ToString("00") + comp.Year.ToString("0000") +"-"+   numDoc + ".png", ScreenshotImageFormat.Png);


                    //System.IO.File.WriteAllText("C:/Users/A36372/Desktop/teste.htm", driver.PageSource);

                    //string html = driver.PageSource.Trim();

                    File.WriteAllText(@"C:\Users\A36372\Desktop\teste.html", driver.PageSource, UnicodeEncoding.UTF8);

                    //string html = File.ReadAllText(@"C:\Users\A36372\Desktop\teste.htm");

                    //PdfDocument pdf = PdfGenerator.GeneratePdf(html, PageSize.Letter);

                    //pdf.Save("C:/Users/A36372/Desktop/document.pdf");


                    String html = File.ReadAllText(@"C:\Users\A36372\Desktop\teste.html", UnicodeEncoding.UTF8);
                    var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                    
                    htmlToPdf.GeneratePdf(html, null, @"C:\Users\A36372\Desktop\"+ numDoc+".pdf");



                    driver.Navigate().Back();                     
                    //System.Threading.Thread.Sleep(1000);




                }


               


               

                //foreach (IWebElement link in links)
                //{

                    
                //    //link.Text.
                //    var numDoc = link.Text;
                //    link.Click();
                //    Screenshot image = driver.GetScreenshot();                    
                //    image.SaveAsFile("C:/Users/A36372/Desktop/Screenshot" + numDoc + ".png", ScreenshotImageFormat.Png);
                //    driver.Navigate().Back();

                //    //Console.WriteLine(link.Text.ToString());
                //}


                //foreach (var tag in driver.FindElements(By.ClassName("coluna19")).Where(x => x.Text != "").Where(x => !x.Text.Contains("/")).Where(x => !x.Text.Contains(",")))
                //{
                //    //lista.Add(int.Parse(tag.Text));
                //    //Console.Write(tag.Text);
                   

                //}

                //for (int i = 0; i < lista[i];i++)
                //{
                //    Screenshot image = driver.GetScreenshot();
                //    image.SaveAsFile("C:/Users/A36372/Desktop/Screenshot" + contador.ToString("00") + comp.Year.ToString("0000") + ".png", ScreenshotImageFormat.Png);
                    
                //}

                driver.Navigate().Back();
                                             
                //IWebElement pesquisa2 = driver.FindElement(By.LinkText());

                //pesquisa2.SendKeys(OpenQA.Selenium.Keys.Enter);

                //Console.ReadKey();

                contador--;

            }

            driver.Close();
            Console.WriteLine("Finalizado");
            


        }
    }
}
