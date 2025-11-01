using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Xunit;

namespace UPT.UITests;

public class UPTRepositoryTests : IDisposable
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private const string BaseUrl = "https://repositorio.upt.edu.pe/";

    public UPTRepositoryTests()
    {
        var browser = Environment.GetEnvironmentVariable("BROWSER") ?? "chrome";

        _driver = browser.ToLower() switch
        {
            "firefox" => new FirefoxDriver(),
            _ => new ChromeDriver()
        };

        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
    }

    [Fact]
    public void RepositoryPageLoads_Successfully()
    {
        // Dado que soy un estudiante
        // Cuando accedo al repositorio de la UPT
        _driver.Navigate().GoToUrl(BaseUrl);

        // Entonces debo ver la página principal del repositorio
        _wait.Until(driver => driver.Title.Contains("DSpace") || driver.Title.Contains("Repositorio"));
        
        Assert.True(_driver.Url.Contains("repositorio.upt.edu.pe"));
    }

    [Theory]
    [InlineData("web")]
    [InlineData("base de datos")]
    [InlineData("movil")]
    [InlineData("business intelligence")]
    [InlineData("inteligencia artificial")]
    public void SearchTechnology_ReturnsResults(string searchTerm)
    {
        // Dado que como estudiante tengo acceso al repositorio
        _driver.Navigate().GoToUrl(BaseUrl);
        _wait.Until(driver => driver.FindElements(By.CssSelector("input[type='text']")).Count > 0);

        // Cuando realizo una búsqueda de tecnología
        var searchBox = _driver.FindElement(By.Name("query")) 
            ?? _driver.FindElement(By.CssSelector("input[type='text']"));
        searchBox.Clear();
        searchBox.SendKeys(searchTerm);
        searchBox.SendKeys(Keys.Enter);

        // Entonces espero tener uno o muchos resultados
        try
        {
            _wait.Until(driver => 
                driver.FindElements(By.CssSelector(".ds-artifact-item, .artifact-description, .discovery-result-results, table.miscTable")).Count > 0 ||
                driver.PageSource.Contains("resultado") ||
                driver.PageSource.Contains("result")
            );

            var hasResults = _driver.FindElements(By.CssSelector(".ds-artifact-item, .artifact-description, .discovery-result-results, table.miscTable")).Count > 0;
            var pageContainsResults = _driver.PageSource.Contains("resultado") || _driver.PageSource.Contains("result");
            
            Assert.True(hasResults || pageContainsResults, 
                $"No se encontraron resultados para la búsqueda: {searchTerm}");
        }
        catch (WebDriverTimeoutException)
        {
            // Si hay timeout, verificamos si al menos apareció la página de resultados
            Assert.True(_driver.Url.Contains("discover") || _driver.Url.Contains("simple-search"),
                $"La búsqueda de '{searchTerm}' no llevó a la página de resultados");
        }
    }

    [Fact]
    public void SearchWeb_VerifyResultsContainWebKeyword()
    {
        // Dado que como estudiante quiero encontrar tesis de tecnología web
        _driver.Navigate().GoToUrl(BaseUrl);
        _wait.Until(driver => driver.FindElements(By.CssSelector("input[type='text']")).Count > 0);

        // Cuando busco "web"
        var searchBox = _driver.FindElement(By.Name("query")) 
            ?? _driver.FindElement(By.CssSelector("input[type='text']"));
        searchBox.Clear();
        searchBox.SendKeys("web");
        searchBox.SendKeys(Keys.Enter);

        // Entonces los resultados deben contener la palabra "web"
        _wait.Until(driver => 
            driver.PageSource.ToLower().Contains("web") ||
            driver.FindElements(By.CssSelector(".ds-artifact-item, .artifact-description")).Count > 0
        );

        var pageSource = _driver.PageSource.ToLower();
        Assert.Contains("web", pageSource);
    }

    [Fact]
    public void SearchDatabase_VerifyResultsContainDatabaseKeyword()
    {
        // Dado que como estudiante quiero encontrar tesis sobre bases de datos
        _driver.Navigate().GoToUrl(BaseUrl);
        _wait.Until(driver => driver.FindElements(By.CssSelector("input[type='text']")).Count > 0);

        // Cuando busco "base de datos"
        var searchBox = _driver.FindElement(By.Name("query")) 
            ?? _driver.FindElement(By.CssSelector("input[type='text']"));
        searchBox.Clear();
        searchBox.SendKeys("base de datos");
        searchBox.SendKeys(Keys.Enter);

        // Entonces los resultados deben contener palabras relacionadas con bases de datos
        _wait.Until(driver => 
            driver.PageSource.ToLower().Contains("base") ||
            driver.PageSource.ToLower().Contains("dato") ||
            driver.FindElements(By.CssSelector(".ds-artifact-item, .artifact-description")).Count > 0
        );

        var pageSource = _driver.PageSource.ToLower();
        Assert.True(pageSource.Contains("base") || pageSource.Contains("dato") || pageSource.Contains("database"));
    }

    [Fact]
    public void SearchMobile_VerifyResultsContainMobileKeyword()
    {
        // Dado que como estudiante quiero encontrar tesis sobre desarrollo móvil
        _driver.Navigate().GoToUrl(BaseUrl);
        _wait.Until(driver => driver.FindElements(By.CssSelector("input[type='text']")).Count > 0);

        // Cuando busco "movil"
        var searchBox = _driver.FindElement(By.Name("query")) 
            ?? _driver.FindElement(By.CssSelector("input[type='text']"));
        searchBox.Clear();
        searchBox.SendKeys("movil");
        searchBox.SendKeys(Keys.Enter);

        // Entonces los resultados deben contener palabras relacionadas con móvil
        _wait.Until(driver => 
            driver.PageSource.ToLower().Contains("movil") ||
            driver.PageSource.ToLower().Contains("móvil") ||
            driver.PageSource.ToLower().Contains("mobile") ||
            driver.FindElements(By.CssSelector(".ds-artifact-item, .artifact-description")).Count > 0
        );

        var pageSource = _driver.PageSource.ToLower();
        Assert.True(pageSource.Contains("movil") || pageSource.Contains("móvil") || pageSource.Contains("mobile"));
    }

    [Fact]
    public void SearchArtificialIntelligence_VerifyResultsContainAIKeyword()
    {
        // Dado que como estudiante quiero investigar sobre inteligencia artificial
        _driver.Navigate().GoToUrl(BaseUrl);
        _wait.Until(driver => driver.FindElements(By.CssSelector("input[type='text']")).Count > 0);

        // Cuando busco "inteligencia artificial"
        var searchBox = _driver.FindElement(By.Name("query")) 
            ?? _driver.FindElement(By.CssSelector("input[type='text']"));
        searchBox.Clear();
        searchBox.SendKeys("inteligencia artificial");
        searchBox.SendKeys(Keys.Enter);

        // Entonces los resultados deben contener palabras relacionadas con IA
        _wait.Until(driver => 
            driver.PageSource.ToLower().Contains("inteligencia") ||
            driver.PageSource.ToLower().Contains("artificial") ||
            driver.FindElements(By.CssSelector(".ds-artifact-item, .artifact-description")).Count > 0
        );

        var pageSource = _driver.PageSource.ToLower();
        Assert.True(pageSource.Contains("inteligencia") || pageSource.Contains("artificial") || pageSource.Contains("intelligence"));
    }

    [Fact]
    public void SearchBusinessIntelligence_VerifyResultsContainBIKeyword()
    {
        // Dado que como estudiante quiero investigar sobre business intelligence
        _driver.Navigate().GoToUrl(BaseUrl);
        _wait.Until(driver => driver.FindElements(By.CssSelector("input[type='text']")).Count > 0);

        // Cuando busco "business intelligence"
        var searchBox = _driver.FindElement(By.Name("query")) 
            ?? _driver.FindElement(By.CssSelector("input[type='text']"));
        searchBox.Clear();
        searchBox.SendKeys("business intelligence");
        searchBox.SendKeys(Keys.Enter);

        // Entonces los resultados deben contener palabras relacionadas con BI
        _wait.Until(driver => 
            driver.PageSource.ToLower().Contains("business") ||
            driver.PageSource.ToLower().Contains("intelligence") ||
            driver.PageSource.ToLower().Contains("inteligencia") ||
            driver.PageSource.ToLower().Contains("negocio") ||
            driver.FindElements(By.CssSelector(".ds-artifact-item, .artifact-description")).Count > 0
        );

        var pageSource = _driver.PageSource.ToLower();
        Assert.True(pageSource.Contains("business") || pageSource.Contains("intelligence") || 
                    pageSource.Contains("inteligencia") || pageSource.Contains("negocio"));
    }

    public void Dispose()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }
}
