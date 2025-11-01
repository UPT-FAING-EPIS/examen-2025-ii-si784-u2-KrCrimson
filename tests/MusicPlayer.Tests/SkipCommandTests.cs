using Xunit;
using MusicPlayerLib = MusicPlayer;

namespace MusicPlayer.Tests;

public class SkipCommandTests
{
    [Fact]
    public void Execute_ShouldCallPlayerSkip()
    {
        // Arrange
        var player = new MusicPlayerLib.MusicPlayer();
        var command = new MusicPlayerLib.SkipCommand(player);

        // Act
        var result = command.Execute();

        // Assert
        Assert.Equal("Skipping to the next song.", result);
    }

    [Fact]
    public void Constructor_ShouldAcceptMusicPlayer()
    {
        // Arrange
        var player = new MusicPlayerLib.MusicPlayer();

        // Act
        var command = new MusicPlayerLib.SkipCommand(player);

        // Assert
        Assert.NotNull(command);
    }
}
