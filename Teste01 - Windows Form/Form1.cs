using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Teste01___Windows_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://gps.receita.fazenda.gov.br/");

            IWebElement element = driver.FindElement(By.Name("formInicio:botaoConsultar"));

            IWebElement cnpj = driver.FindElement(By.Name("formInicio:identificador"));

            IWebElement senha = driver.FindElement(By.Name("formInicio:senha"));

            IWebElement comp = driver.FindElement(By.Name("formInicio:competencia"));


            cnpj.SendKeys("76101989000191");
            senha.SendKeys("76101989");
            comp.SendKeys("122015");



            System.Threading.Thread.Sleep(10000);

            element.SendKeys(OpenQA.Selenium.Keys.Enter);

            element.SendKeys(OpenQA.Selenium.Keys.Control + "l");

            element.SendKeys(OpenQA.Selenium.Keys.Tab);

            Console.Read();


        }
    }
}
