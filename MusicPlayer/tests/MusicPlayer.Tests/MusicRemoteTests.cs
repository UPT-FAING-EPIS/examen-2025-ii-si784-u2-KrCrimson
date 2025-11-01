using Xunit;
using MusicPlayerLib = MusicPlayer;

namespace MusicPlayer.Tests;

public class MusicRemoteTests
{
    [Fact]
    public void SetCommand_ShouldAcceptCommand()
    {
        // Arrange
        var remote = new MusicPlayerLib.MusicRemote();
        var player = new MusicPlayerLib.MusicPlayer();
        var command = new MusicPlayerLib.PlayCommand(player);

        // Act
        remote.SetCommand(command);

        // Assert
        Assert.NotNull(remote);
    }

    [Fact]
    public void PressButton_WithPlayCommand_ShouldReturnPlayingMessage()
    {
        // Arrange
        var remote = new MusicPlayerLib.MusicRemote();
        var player = new MusicPlayerLib.MusicPlayer();
        var command = new MusicPlayerLib.PlayCommand(player);
        remote.SetCommand(command);

        // Act
        var result = remote.PressButton();

        // Assert
        Assert.Equal("Playing the song.", result);
    }

    [Fact]
    public void PressButton_WithPauseCommand_ShouldReturnPausingMessage()
    {
        // Arrange
        var remote = new MusicPlayerLib.MusicRemote();
        var player = new MusicPlayerLib.MusicPlayer();
        var command = new MusicPlayerLib.PauseCommand(player);
        remote.SetCommand(command);

        // Act
        var result = remote.PressButton();

        // Assert
        Assert.Equal("Pausing the song.", result);
    }

    [Fact]
    public void PressButton_WithSkipCommand_ShouldReturnSkippingMessage()
    {
        // Arrange
        var remote = new MusicPlayerLib.MusicRemote();
        var player = new MusicPlayerLib.MusicPlayer();
        var command = new MusicPlayerLib.SkipCommand(player);
        remote.SetCommand(command);

        // Act
        var result = remote.PressButton();

        // Assert
        Assert.Equal("Skipping to the next song.", result);
    }

    [Fact]
    public void PressButton_WithoutCommand_ShouldReturnNoCommandMessage()
    {
        // Arrange
        var remote = new MusicPlayerLib.MusicRemote();

        // Act
        var result = remote.PressButton();

        // Assert
        Assert.Equal("No command set.", result);
    }

    [Fact]
    public void SetCommand_MultipleTimes_ShouldUpdateCommand()
    {
        // Arrange
        var remote = new MusicPlayerLib.MusicRemote();
        var player = new MusicPlayerLib.MusicPlayer();
        var playCommand = new MusicPlayerLib.PlayCommand(player);
        var pauseCommand = new MusicPlayerLib.PauseCommand(player);

        // Act
        remote.SetCommand(playCommand);
        var firstResult = remote.PressButton();
        remote.SetCommand(pauseCommand);
        var secondResult = remote.PressButton();

        // Assert
        Assert.Equal("Playing the song.", firstResult);
        Assert.Equal("Pausing the song.", secondResult);
    }
}
