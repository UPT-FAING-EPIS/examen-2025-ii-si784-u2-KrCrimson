using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace UPT.BDD.Steps;

[Binding]
public class UPTRepositorySearchSteps : IDisposable
{
    private IWebDriver? _driver;
    private WebDriverWait? _wait;
    private const string BaseUrl = "https://repositorio.upt.edu.pe/";
    private string _searchTerm = string.Empty;

    [Given(@"que soy un estudiante de la UPT")]
    public void GivenQueSoyUnEstudianteDeLaUPT()
    {
        InitializeDriver();
    }

    [Given(@"que como estudiante tengo acceso al repositorio")]
    public void GivenQueComoEstudianteTengoAccesoAlRepositorio()
    {
        InitializeDriver();
        _driver!.Navigate().GoToUrl(BaseUrl);
        _wait!.Until(driver => driver.FindElements(By.CssSelector("input[type='text']")).Count > 0);
    }

    [Given(@"que como estudiante quiero investigar sobre desarrollo web")]
    [Given(@"que como estudiante quiero investigar sobre bases de datos")]
    [Given(@"que como estudiante quiero investigar sobre aplicaciones móviles")]
    [Given(@"que como estudiante quiero investigar sobre IA")]
    [Given(@"que como estudiante quiero investigar sobre BI")]
    public void GivenQueComoEstudianteQuieroInvestigar()
    {
        InitializeDriver();
        _driver!.Navigate().GoToUrl(BaseUrl);
        _wait!.Until(driver => driver.FindElements(By.CssSelector("input[type='text']")).Count > 0);
    }

    [When(@"accedo al sitio web del repositorio")]
    public void WhenAccedoAlSitioWebDelRepositorio()
    {
        _driver!.Navigate().GoToUrl(BaseUrl);
    }

    [When(@"realizo una búsqueda de ""(.*)""")]
    public void WhenRealizoUnaBusquedaDe(string tecnologia)
    {
        _searchTerm = tecnologia;
        PerformSearch(tecnologia);
    }

    [When(@"busco tesis relacionadas con ""(.*)""")]
    public void WhenBuscoTesisRelacionadasCon(string termino)
    {
        _searchTerm = termino;
        PerformSearch(termino);
    }

    [Then(@"debo ver la página principal del repositorio")]
    public void ThenDeboVerLaPaginaPrincipalDelRepositorio()
    {
        _wait!.Until(driver => driver.Title.Contains("DSpace") || driver.Title.Contains("Repositorio"));
        _driver!.Url.Should().Contain("repositorio.upt.edu.pe");
    }

    [Then(@"espero tener uno o muchos resultados")]
    public void ThenEsperoTenerUnoOMuchosResultados()
    {
        try
        {
            _wait!.Until(driver => 
                driver.FindElements(By.CssSelector(".ds-artifact-item, .artifact-description, .discovery-result-results, table.miscTable")).Count > 0 ||
                driver.PageSource.Contains("resultado") ||
                driver.PageSource.Contains("result")
            );

            var hasResults = _driver!.FindElements(By.CssSelector(".ds-artifact-item, .artifact-description, .discovery-result-results, table.miscTable")).Count > 0;
            var pageContainsResults = _driver.PageSource.Contains("resultado") || _driver.PageSource.Contains("result");
            
            (hasResults || pageContainsResults).Should().BeTrue($"No se encontraron resultados para la búsqueda: {_searchTerm}");
        }
        catch (WebDriverTimeoutException)
        {
            // Si hay timeout, verificamos si al menos apareció la página de resultados
            (_driver!.Url.Contains("discover") || _driver.Url.Contains("simple-search"))
                .Should().BeTrue($"La búsqueda de '{_searchTerm}' no llevó a la página de resultados");
        }
    }

    [Then(@"los resultados deben contener información sobre web")]
    public void ThenLosResultadosDebenContenerInformacionSobreWeb()
    {
        _wait!.Until(driver => 
            driver.PageSource.ToLower().Contains("web") ||
            driver.FindElements(By.CssSelector(".ds-artifact-item, .artifact-description")).Count > 0
        );

        var pageSource = _driver!.PageSource.ToLower();
        pageSource.Should().Contain("web");
    }

    [Then(@"los resultados deben contener información sobre bases de datos")]
    public void ThenLosResultadosDebenContenerInformacionSobreBasesDeDatos()
    {
        _wait!.Until(driver => 
            driver.PageSource.ToLower().Contains("base") ||
            driver.PageSource.ToLower().Contains("dato") ||
            driver.FindElements(By.CssSelector(".ds-artifact-item, .artifact-description")).Count > 0
        );

        var pageSource = _driver!.PageSource.ToLower();
        (pageSource.Contains("base") || pageSource.Contains("dato") || pageSource.Contains("database"))
            .Should().BeTrue("Los resultados deben contener información sobre bases de datos");
    }

    [Then(@"los resultados deben contener información sobre desarrollo móvil")]
    public void ThenLosResultadosDebenContenerInformacionSobreDesarrolloMovil()
    {
        _wait!.Until(driver => 
            driver.PageSource.ToLower().Contains("movil") ||
            driver.PageSource.ToLower().Contains("móvil") ||
            driver.PageSource.ToLower().Contains("mobile") ||
            driver.FindElements(By.CssSelector(".ds-artifact-item, .artifact-description")).Count > 0
        );

        var pageSource = _driver!.PageSource.ToLower();
        (pageSource.Contains("movil") || pageSource.Contains("móvil") || pageSource.Contains("mobile"))
            .Should().BeTrue("Los resultados deben contener información sobre desarrollo móvil");
    }

    [Then(@"los resultados deben contener información sobre inteligencia artificial")]
    public void ThenLosResultadosDebenContenerInformacionSobreInteligenciaArtificial()
    {
        _wait!.Until(driver => 
            driver.PageSource.ToLower().Contains("inteligencia") ||
            driver.PageSource.ToLower().Contains("artificial") ||
            driver.FindElements(By.CssSelector(".ds-artifact-item, .artifact-description")).Count > 0
        );

        var pageSource = _driver!.PageSource.ToLower();
        (pageSource.Contains("inteligencia") || pageSource.Contains("artificial") || pageSource.Contains("intelligence"))
            .Should().BeTrue("Los resultados deben contener información sobre inteligencia artificial");
    }

    [Then(@"los resultados deben contener información sobre business intelligence")]
    public void ThenLosResultadosDebenContenerInformacionSobreBusinessIntelligence()
    {
        _wait!.Until(driver => 
            driver.PageSource.ToLower().Contains("business") ||
            driver.PageSource.ToLower().Contains("intelligence") ||
            driver.PageSource.ToLower().Contains("inteligencia") ||
            driver.PageSource.ToLower().Contains("negocio") ||
            driver.FindElements(By.CssSelector(".ds-artifact-item, .artifact-description")).Count > 0
        );

        var pageSource = _driver!.PageSource.ToLower();
        (pageSource.Contains("business") || pageSource.Contains("intelligence") || 
         pageSource.Contains("inteligencia") || pageSource.Contains("negocio"))
            .Should().BeTrue("Los resultados deben contener información sobre business intelligence");
    }

    private void InitializeDriver()
    {
        if (_driver != null) return;

        var browser = Environment.GetEnvironmentVariable("BROWSER") ?? "chrome";

        if (browser.ToLower() == "firefox")
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--headless");
            firefoxOptions.AddArgument("--window-size=1920,1080");
            _driver = new FirefoxDriver(firefoxOptions);
        }
        else
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless=new");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--window-size=1920,1080");
            _driver = new ChromeDriver(chromeOptions);
        }

        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
    }

    private void PerformSearch(string searchTerm)
    {
        var searchBox = _driver!.FindElement(By.Name("query")) 
            ?? _driver.FindElement(By.CssSelector("input[type='text']"));
        searchBox.Clear();
        searchBox.SendKeys(searchTerm);
        searchBox.SendKeys(Keys.Enter);
    }

    public void Dispose()
    {
        _driver?.Quit();
        _driver?.Dispose();
        GC.SuppressFinalize(this);
    }
}
