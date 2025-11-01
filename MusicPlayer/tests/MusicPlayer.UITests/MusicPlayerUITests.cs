using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace MusicPlayer.UITests;

public class MusicPlayerUITests : IDisposable
{
    private IWebDriver _driver;
    private readonly string _baseUrl = "http://localhost:5000";
    private readonly string _browser;

    public MusicPlayerUITests()
    {
        _browser = Environment.GetEnvironmentVariable("BROWSER") ?? "chrome";
        InitializeDriver();
    }

    private void InitializeDriver()
    {
        if (_browser.ToLower() == "firefox")
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--headless");
            _driver = new FirefoxDriver(firefoxOptions);
        }
        else
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--disable-dev-shm-usage");
            _driver = new ChromeDriver(chromeOptions);
        }

        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        _driver.Manage().Window.Maximize();
    }

    [Fact]
    public void HomePage_ShouldLoad_Successfully()
    {
        // Act
        _driver.Navigate().GoToUrl(_baseUrl);

        // Assert
        Assert.Contains("Music Player Control", _driver.PageSource);
        Assert.NotNull(_driver.FindElement(By.Id("playButton")));
        Assert.NotNull(_driver.FindElement(By.Id("pauseButton")));
        Assert.NotNull(_driver.FindElement(By.Id("skipButton")));
    }

    [Fact]
    public void PlayButton_WhenClicked_ShouldShowPlayingMessage()
    {
        // Arrange
        _driver.Navigate().GoToUrl(_baseUrl);

        // Act
        var playButton = _driver.FindElement(By.Id("playButton"));
        playButton.Click();

        // Wait for page to reload
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.FindElement(By.Id("result")));

        // Assert
        var result = _driver.FindElement(By.Id("result"));
        Assert.Contains("Playing the song.", result.Text);
    }

    [Fact]
    public void PauseButton_WhenClicked_ShouldShowPausingMessage()
    {
        // Arrange
        _driver.Navigate().GoToUrl(_baseUrl);

        // Act
        var pauseButton = _driver.FindElement(By.Id("pauseButton"));
        pauseButton.Click();

        // Wait for page to reload
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.FindElement(By.Id("result")));

        // Assert
        var result = _driver.FindElement(By.Id("result"));
        Assert.Contains("Pausing the song.", result.Text);
    }

    [Fact]
    public void SkipButton_WhenClicked_ShouldShowSkippingMessage()
    {
        // Arrange
        _driver.Navigate().GoToUrl(_baseUrl);

        // Act
        var skipButton = _driver.FindElement(By.Id("skipButton"));
        skipButton.Click();

        // Wait for page to reload
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.FindElement(By.Id("result")));

        // Assert
        var result = _driver.FindElement(By.Id("result"));
        Assert.Contains("Skipping to the next song.", result.Text);
    }

    [Fact]
    public void AllButtons_ShouldBeVisible_AndClickable()
    {
        // Arrange
        _driver.Navigate().GoToUrl(_baseUrl);

        // Act & Assert
        var playButton = _driver.FindElement(By.Id("playButton"));
        var pauseButton = _driver.FindElement(By.Id("pauseButton"));
        var skipButton = _driver.FindElement(By.Id("skipButton"));

        Assert.True(playButton.Displayed);
        Assert.True(playButton.Enabled);

        Assert.True(pauseButton.Displayed);
        Assert.True(pauseButton.Enabled);

        Assert.True(skipButton.Displayed);
        Assert.True(skipButton.Enabled);
    }

    [Fact]
    public void MultipleCommands_ShouldExecute_Sequentially()
    {
        // Arrange
        _driver.Navigate().GoToUrl(_baseUrl);
        var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

        // Act & Assert - Play
        var playButton = _driver.FindElement(By.Id("playButton"));
        playButton.Click();
        wait.Until(d => d.FindElement(By.Id("result")));
        var result1 = _driver.FindElement(By.Id("result"));
        Assert.Contains("Playing the song.", result1.Text);

        // Act & Assert - Pause
        var pauseButton = _driver.FindElement(By.Id("pauseButton"));
        pauseButton.Click();
        wait.Until(d => d.FindElement(By.Id("result")));
        var result2 = _driver.FindElement(By.Id("result"));
        Assert.Contains("Pausing the song.", result2.Text);

        // Act & Assert - Skip
        var skipButton = _driver.FindElement(By.Id("skipButton"));
        skipButton.Click();
        wait.Until(d => d.FindElement(By.Id("result")));
        var result3 = _driver.FindElement(By.Id("result"));
        Assert.Contains("Skipping to the next song.", result3.Text);
    }

    public void Dispose()
    {
        _driver?.Quit();
        _driver?.Dispose();
    }
}
