using Xunit;
using MusicPlayerLib = MusicPlayer;

namespace MusicPlayer.Tests;

public class MusicPlayerTests
{
    [Fact]
    public void Play_ShouldReturnPlayingMessage()
    {
        // Arrange
        var player = new MusicPlayerLib.MusicPlayer();

        // Act
        var result = player.Play();

        // Assert
        Assert.Equal("Playing the song.", result);
    }

    [Fact]
    public void Pause_ShouldReturnPausingMessage()
    {
        // Arrange
        var player = new MusicPlayerLib.MusicPlayer();

        // Act
        var result = player.Pause();

        // Assert
        Assert.Equal("Pausing the song.", result);
    }

    [Fact]
    public void Skip_ShouldReturnSkippingMessage()
    {
        // Arrange
        var player = new MusicPlayerLib.MusicPlayer();

        // Act
        var result = player.Skip();

        // Assert
        Assert.Equal("Skipping to the next song.", result);
    }
}
