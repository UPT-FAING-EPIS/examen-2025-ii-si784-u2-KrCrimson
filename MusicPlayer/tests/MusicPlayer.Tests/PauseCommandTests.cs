using Xunit;
using MusicPlayerLib = MusicPlayer;

namespace MusicPlayer.Tests;

public class PauseCommandTests
{
    [Fact]
    public void Execute_ShouldCallPlayerPause()
    {
        // Arrange
        var player = new MusicPlayerLib.MusicPlayer();
        var command = new MusicPlayerLib.PauseCommand(player);

        // Act
        var result = command.Execute();

        // Assert
        Assert.Equal("Pausing the song.", result);
    }

    [Fact]
    public void Constructor_ShouldAcceptMusicPlayer()
    {
        // Arrange
        var player = new MusicPlayerLib.MusicPlayer();

        // Act
        var command = new MusicPlayerLib.PauseCommand(player);

        // Assert
        Assert.NotNull(command);
    }
}
