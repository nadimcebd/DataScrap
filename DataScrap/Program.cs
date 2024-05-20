// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

Console.WriteLine("Hello, World!");

using (IWebDriver driver = new ChromeDriver())
{
    driver.Manage().Window.Maximize();
    driver.Navigate().GoToUrl("https://accounts.binance.com/en/login");
    Console.WriteLine("Opened accounts.binance");

    //driver.FindElement(By.Id("email")).SendKeys("userName");
    //Console.WriteLine("username entered");


    driver.FindElement(By.ClassName("bn-textField-input"))
       .SendKeys("ahl.s@gmail.com");

    //driver.FindElement(By.ClassName("bn-button bn-button__primary data-size-large mt-6")).Click();


    NextClick(driver);

    //driver.FindElement(By.XPath("//*[@id=\"wrap_app\"]/main/div/div[1]/form/button")).Click();
    //{
    //    var lbl = driver.FindElement(By.XPath("//*[@id=\"wrap_app\"]/main/div/div[1]/form/div/div[3]"));
    //    if (lbl != null) {
    //        var txt = driver.FindElement(By.XPath("//*[@id=\"wrap_app\"]/main/div/div[1]/form/div/div[3]")).Text;
    //    }

    //    //Result.Pass(60);
    //}

}



void NextClick(IWebDriver driver)
{
    try
    {
      //  RemoveWarnig(driver);
        driver.FindElement(By.XPath("//*[@id=\"wrap_app\"]/main/div/div[1]/form/button")).Click();
        {

            try
            {
                var lbl = driver.FindElement(By.XPath("//*[@id=\"wrap_app\"]/main/div/div[1]/form/div/div[3]"));
                if (lbl != null)
                {
                    var txt = lbl.Text;
                }
                else
                {
                  //  RemoveWarnig(driver);
                    NextClick(driver);
                }
            }
            catch (Exception)
            {
              //  RemoveWarnig(driver);
                NextClick(driver);
            }


        }
    }
    catch (Exception)
    {
        try
        {
           // RemoveWarnig(driver);
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
        

        //try
        //{
        //    var warDiv = driver.FindElement(By.ClassName("bcap-icon-container"));
        //    if (warDiv != null)
        //    {
        //        warDiv.FindElement(By.TagName("svg")).Click();
        //    }
        //}
        //catch (Exception) { }


        try
        {
            var Cap = driver.FindElement(By.XPath("/html/body/div[6]/div/div[2]/div/div[1]/svg[1]/path"));
            if (Cap != null)
            {
                Cap.Click();
            }
        }
        catch (Exception) { }


        try
        {
            var war = driver.FindElement(By.XPath("//*[@id=\"__APP\"]/div[2]/div/div[2]/div/div[3]/button"));
            if (war != null)
            {
                war.Click();
            }
        }
        catch (Exception) { }

        try
        {
            var Cap6 = driver.FindElement(By.XPath("/html/body/div[6]/div/div[2]/div/div[1]/svg[1]"));
            if (Cap6 != null)
            {
                Cap6.Click();
            }
        }
        catch (Exception) { }


        try
        {
            var Cap7 = driver.FindElement(By.XPath("/html/body/div[7]/div/div[2]/div/div[1]/svg[1]"));
            if (Cap7 != null)
            {
                Cap7.Click();
            }
        }
        catch (Exception) { }

        try
        {
            var Cap8 = driver.FindElement(By.XPath("/html/body/div[8]/div/div[2]/div/div[1]/svg[1]"));
            if (Cap8 != null)
            {
                Cap8.Click();
            }
        }
        catch (Exception) { }


        try
        {
            var Cap5 = driver.FindElement(By.XPath("/html/body/div[5]/div/div[2]/div/div[1]/svg[1]"));
            if (Cap5 != null)
            {
                Cap5.Click();
            }
        }
        catch (Exception) { }


    }
    catch (Exception)
    {
    }

}

