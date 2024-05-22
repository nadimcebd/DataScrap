// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;
using System.Data;

Console.WriteLine("Hello, World!");

DataTable dtProxy = new DataTable();
//31.131.165.203:12323:14ad82bc6f042:a184409022
//// way 1
//Proxy proxy = new Proxy();
//proxy.SocksProxy= "http://176.118.200.188:12323";
//proxy.SocksUserName = "14ad82bc6f042";
//proxy.SocksPassword = "a184409022";
//proxy.SocksVersion = 1; 
//ChromeOptions options = new ChromeOptions();
//options.Proxy = proxy;



// way 2
//ChromeOptions options = new ChromeOptions();
//// Set up the ChromeDriver instance with proxy configuration using AddArgument
//options.AddArgument("--proxy-server=http://31.131.165.203:12323");
//using (IWebDriver driver = new ChromeDriver(options))

ChromeOptions options = new ChromeOptions();
ReadProxy();

InitiateWebDriver();
void InitiateWebDriver() {
    Proxy proxy = SetrandomProxy();
    options.Proxy = proxy;
    using (IWebDriver driver = new ChromeDriver(options))
    {


        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://accounts.binance.com/en/login");
        Console.WriteLine("Opened accounts.binance");



        //driver.FindElement(By.Id("email")).SendKeys("userName");
        //Console.WriteLine("username entered");
        // Add a wait for three seconds
        Thread.Sleep(5000);

        driver.FindElement(By.ClassName("bn-textField-input"))
           .SendKeys("ahlk.s@gmail.com");

        //driver.FindElement(By.ClassName("bn-button bn-button__primary data-size-large mt-6")).Click();


        NextClick(driver);
        driver.Quit();
        //driver.FindElement(By.XPath("//*[@id=\"wrap_app\"]/main/div/div[1]/form/button")).Click();
        //{
        //    var lbl = driver.FindElement(By.XPath("//*[@id=\"wrap_app\"]/main/div/div[1]/form/div/div[3]"));
        //    if (lbl != null) {
        //        var txt = driver.FindElement(By.XPath("//*[@id=\"wrap_app\"]/main/div/div[1]/form/div/div[3]")).Text;
        //    }

        //    //Result.Pass(60);
        //}

    }


}





void NextClick(IWebDriver driver)
{
    try
    {
        

       driver.FindElement(By.XPath("//*[@id=\"wrap_app\"]/main/div/div[1]/form/button")).Click();
        {
            Thread.Sleep(5000);
            try
            {
                var lbl = driver.FindElement(By.XPath("//*[@id=\"wrap_app\"]/main/div/div[1]/form/div/div[3]"));
                if (lbl != null)
                {
                    var txt = lbl.Text;
                }
                else
                {
                  RemoveWarnig(driver);
                  NextClick(driver);
                }
            }
            catch (Exception)
            {
                RemoveWarnig(driver);
                NextClick(driver);
            }


        }
    }
    catch (Exception)
    {
        try
        {
            RemoveWarnig(driver);
            NextClick(driver);
        }
        catch (Exception)
        {

            NextClick(driver);
        }
    }
}


void RemoveWarnig(IWebDriver driver)
{
    try
    {


        try
        {
            var warDiv = driver.FindElement(By.ClassName("bcap-icon-container"));
            if (warDiv != null)
            {
                warDiv.FindElement(By.TagName("svg")).Click();
                NextClick(driver);
            }
        }
        catch (Exception) { }


        try
        {
            var Cap = driver.FindElement(By.XPath("/html/body/div[6]/div/div[2]/div/div[1]/svg[1]/path"));
            if (Cap != null)
            {
                Cap.Click();
                NextClick(driver);
            }
        }
        catch (Exception) { }


        try
        {
            var war = driver.FindElement(By.XPath("//*[@id=\"__APP\"]/div[2]/div/div[2]/div/div[3]/button"));
            if (war != null)
            {
                war.Click();
                NextClick(driver);
            }
        }
        catch (Exception) { }

        try
        {
            var Cap6 = driver.FindElement(By.XPath("/html/body/div[6]/div/div[2]/div/div[1]/svg[1]"));
            if (Cap6 != null)
            {
                Cap6.Click();
                NextClick(driver);
            }
        }
        catch (Exception) { }


        try
        {
            var Cap7 = driver.FindElement(By.XPath("/html/body/div[7]/div/div[2]/div/div[1]/svg[1]"));
            if (Cap7 != null)
            {
                Cap7.Click();
                NextClick(driver);
            }
        }
        catch (Exception) { }

        try
        {
            var Cap8 = driver.FindElement(By.XPath("/html/body/div[8]/div/div[2]/div/div[1]/svg[1]"));
            if (Cap8 != null)
            {
                Cap8.Click();
                NextClick(driver);
            }
        }
        catch (Exception) { }


        try
        {
            var Cap5 = driver.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div/div[1]/svg[1]"));
            if (Cap5 != null)
            {
                Cap5.Click();
                NextClick(driver);
            }
        }
        catch (Exception) { }


    }
    catch (Exception)
    {
    }

}
void ReadProxy()
{
    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
    string ProxyPath = Path.Combine(baseDirectory + "wwww/proxy.txt");
    if (dtProxy.Columns.Count == 0)
    {
        dtProxy.Columns.Add("Proxy");
    }
    if (System.IO.File.Exists(ProxyPath))
    {
        using (StreamReader sr = new StreamReader(ProxyPath))
        {

            while (!sr.EndOfStream)
            {

                string[] rows = sr.ReadLine().Split('\n');

                DataRow dr = dtProxy.NewRow();
                for (int i = 0; i < 1; i++)
                {

                    dr[i] = rows[i];
                }
                dtProxy.Rows.Add(dr);
            }
        }
    }
}

Proxy SetrandomProxy()
{
    Proxy proxy = new Proxy();
    Random random = new Random();
    int index = random.Next(dtProxy.Rows.Count);
    DataRow DtRow = dtProxy.Rows[index];
    if (DtRow != null)
    {
        string proxyURL = DtRow["Proxy"].ToString();

        string[] proxyInfo = proxyURL.Split(':');

        string proxyUsername = proxyInfo[2];
        string proxyPassword = proxyInfo[3];


        //Proxy proxy = new Proxy();
        proxy.SocksProxy = string.Format("http://{0}:{1}", proxyInfo[0], proxyInfo[1]); //"http://176.118.200.188:12323";
        proxy.SocksUserName = proxyUsername;
        proxy.SocksPassword = proxyPassword;
        proxy.SocksVersion = 1;
        ChromeOptions options = new ChromeOptions();
        options.Proxy = proxy;

    }
    return proxy;
}


//class Program
//{
//    static void Main()
//    {
//        var proxies = new List<string>
//        {
//            "http://211.193.1.11:80",
//            "http://138.68.60.8:8080",
//            "http://209.13.186.20:80"
//            // Add more proxy configurations as needed
//        };

//        // Select a random proxy configuration
//        var random = new Random();
//        int randomIndex = random.Next(proxies.Count);
//        string randomProxy = proxies[randomIndex];

//        // Create a new ChromeOptions instance
//        ChromeOptions options = new ChromeOptions();

//        // Assign proxy to chrome instance using AddArgument
//        options.AddArgument($"--proxy-server={randomProxy}");
//        options.AddArgument("headless");

//        // Set up the ChromeDriver instance
//        IWebDriver driver = new ChromeDriver(options);

//        // Navigate to target website
//        driver.Navigate().GoToUrl("http://ident.me");

//        // Add a wait for three seconds
//        Thread.Sleep(3000);

//        // Select the HTML body
//        IWebElement pageElement = driver.FindElement(By.TagName("body"));

//        // Get and print the text content of the page
//        string pageContent = pageElement.Text;
//        Console.WriteLine(pageContent);

//        // Close the browser
//        driver.Quit();

//    }
//}










//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System;

//class Program
//{
//    static void Main()
//    {
//        ChromeOptions options = new ChromeOptions();

//        // Set up the ChromeDriver instance with proxy configuration using AddArgument
//        options.AddArgument("--proxy-server=http://71.86.129.131:8080");

//        // Set up the ChromeDriver instance
//        IWebDriver driver = new ChromeDriver(options);

//        // Create the NetworkAuthenticationHandler with credentials
//        var networkAuthenticationHandler = new NetworkAuthenticationHandler
//        {
//            UriMatcher = uri => uri.Host.Contains("ident.me"), // Only apply for the specific host
//            Credentials = new PasswordCredentials("your_proxy_username", "your_proxy_password")
//        };

//        // Add the authentication credentials to the network request
//        var networkInterceptor = driver.Manage().Network;
//        networkInterceptor.AddAuthenticationHandler(networkAuthenticationHandler);

//        // Navigate to target website
//        driver.Navigate().GoToUrl("http://ident.me");

//        // Add a wait for three seconds
//        Thread.Sleep(3000);

//        // Select the HTML body
//        IWebElement pageElement = driver.FindElement(By.TagName("body"));

//        // Get and print the text content of the page
//        string pageContent = pageElement.Text;
//        Console.WriteLine(pageContent);

//        // Close the browser
//        driver.Quit();
//    }
//}
