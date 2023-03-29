using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Edge;

class Program
{
    static void Main(string[] args)
    {
        // Inicializa o driver do Chrome
        IWebDriver driver = new EdgeDriver();

        // Navega até a página do Google
        driver.Navigate().GoToUrl("https://www.google.com/");
        Thread.Sleep(10000);

        // Pede para o usuário inserir a localização
        Console.WriteLine("Insira a localização desejada:");
        string localizacao = Console.ReadLine();

        // Busca por restaurantes na zona desejada
        IWebElement caixaDeBusca = driver.FindElement(By.Name("q"));
        caixaDeBusca.SendKeys("restaurantes em " + localizacao);
        caixaDeBusca.SendKeys(Keys.Enter);

        // Espera que os resultados sejam carregados, e que o user escolha um restaurante
        System.Threading.Thread.Sleep(5000); // espera 5 segundo

        // waiting
        System.Threading.Thread.Sleep(2000); // espera 2 segundo

        //Vai buscar o nome do restaurante
        IWebElement restaurantName = driver.FindElement(By.ClassName("SPZz6b"));
        Console.WriteLine("Nome do restaurante: {0}", restaurantName.Text);

        // Vai buscar o endereço do restaurante
        IWebElement restaurantAddress = driver.FindElement(By.ClassName("LrzXr"));
        Console.WriteLine("Endereço do restaurante: {0}", restaurantAddress.Text);

        // Vai buscar o telefone do restaurante (exception not handled, no compound classes allowed, trying to find another way)
        //string classNameTelephone = "LrzXr zdqRlf kno-fv";
        //IWebElement restaurantTelephone = driver.FindElement(By.ClassName($"{classNameTelephone}"));
        //Console.WriteLine("Telefone do restaurante: {0}", restaurantTelephone.Text);


        //// Espera até que os resultados sejam carregados
        //IList<IWebElement> resultados = null;
        //while (resultados == null || resultados.Count == 0)
        //{
        //    resultados = driver.FindElements(By.CssSelector("#search .g"));
        //    System.Threading.Thread.Sleep(10000); // Aguarda 1 segundo
        //}

        //// Extrai os links das páginas de restaurantes
        //IList<IWebElement> links = driver.FindElements(By.CssSelector("div.g div.r a"));
        //List<string> urls = new List<string>();
        //foreach (IWebElement link in links)
        //{
        //    urls.Add(link.GetAttribute("href"));
        //}

        //// Extrai os números de telefone e e-mails de cada página de restaurante
        //foreach (string url in urls)
        //{
        //    driver.Navigate().GoToUrl(url);

        //    // Espera até que a página do restaurante seja carregada
        //    IList<IWebElement> restaurantes = driver.FindElements(By.CssSelector("body"));
        //    if (restaurantes.Count > 0)
        //    {
        //        IWebElement restaurante = restaurantes[0];

        //        // Extrai o número de telefone
        //        string telefone = "";
        //        try
        //        {
        //            telefone = restaurante.FindElement(By.CssSelector("[href^='tel:']")).GetAttribute("href").Replace("tel:", "");
        //        }
        //        catch (NoSuchElementException) { }

        //        Console.WriteLine("Telefone: " + telefone);
        //        Console.WriteLine("");
        //    }
        //}

        // Fecha o driver do Chrome
        driver.Quit();
    }
}

