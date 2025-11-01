using Xunit;
using MusicPlayerLib = MusicPlayer;

namespace MusicPlayer.Tests;

public class PlayCommandTests
{
    [Fact]
    public void Execute_ShouldCallPlayerPlay()
    {
        // Arrange
        var player = new MusicPlayerLib.MusicPlayer();
        var command = new MusicPlayerLib.PlayCommand(player);

        // Act
        var result = command.Execute();

        // Assert
        Assert.Equal("Playing the song.", result);
    }

    [Fact]
    public void Constructor_ShouldAcceptMusicPlayer()
    {
        // Arrange
        var player = new MusicPlayerLib.MusicPlayer();

        // Act
        var command = new MusicPlayerLib.PlayCommand(player);

        // Assert
        Assert.NotNull(command);
    }
}
