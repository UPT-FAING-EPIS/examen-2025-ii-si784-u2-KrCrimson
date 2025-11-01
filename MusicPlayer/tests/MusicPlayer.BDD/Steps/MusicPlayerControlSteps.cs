using FluentAssertions;
using TechTalk.SpecFlow;
using MusicPlayerLib = MusicPlayer;

namespace MusicPlayer.BDD.Steps;

[Binding]
public class MusicPlayerControlSteps
{
    private MusicPlayerLib.MusicPlayer? _player;
    private MusicPlayerLib.MusicRemote? _remote;
    private string? _result;
    private string? _firstResult;
    private string? _secondResult;

    [Given(@"I have a music player")]
    public void GivenIHaveAMusicPlayer()
    {
        _player = new MusicPlayerLib.MusicPlayer();
    }

    [Given(@"I have a remote control")]
    public void GivenIHaveARemoteControl()
    {
        _remote = new MusicPlayerLib.MusicRemote();
    }

    [When(@"I set the play command")]
    public void WhenISetThePlayCommand()
    {
        var command = new MusicPlayerLib.PlayCommand(_player!);
        _remote!.SetCommand(command);
    }

    [When(@"I set the pause command")]
    public void WhenISetThePauseCommand()
    {
        var command = new MusicPlayerLib.PauseCommand(_player!);
        _remote!.SetCommand(command);
    }

    [When(@"I set the skip command")]
    public void WhenISetTheSkipCommand()
    {
        var command = new MusicPlayerLib.SkipCommand(_player!);
        _remote!.SetCommand(command);
    }

    [When(@"I press the button")]
    public void WhenIPressTheButton()
    {
        _result = _remote!.PressButton();
        if (_firstResult == null)
        {
            _firstResult = _result;
        }
    }

    [When(@"I press the button again")]
    public void WhenIPressTheButtonAgain()
    {
        _secondResult = _remote!.PressButton();
    }

    [When(@"I press the button without setting a command")]
    public void WhenIPressTheButtonWithoutSettingACommand()
    {
        _result = _remote!.PressButton();
    }

    [Then(@"the result should be ""(.*)""")]
    public void ThenTheResultShouldBe(string expectedResult)
    {
        _result.Should().Be(expectedResult);
    }

    [Then(@"the first result should be ""(.*)""")]
    public void ThenTheFirstResultShouldBe(string expectedResult)
    {
        _firstResult.Should().Be(expectedResult);
    }

    [Then(@"the second result should be ""(.*)""")]
    public void ThenTheSecondResultShouldBe(string expectedResult)
    {
        _secondResult.Should().Be(expectedResult);
    }
}
