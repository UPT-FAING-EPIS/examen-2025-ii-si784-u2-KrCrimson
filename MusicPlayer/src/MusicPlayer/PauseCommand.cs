namespace MusicPlayer;

//Concrete Command
public class PauseCommand : IMusicCommand
{
    private MusicPlayer _player;

    public PauseCommand(MusicPlayer player)
    {
        _player = player;
    }

    public string Execute()
    {
        return _player.Pause();
    }
}
