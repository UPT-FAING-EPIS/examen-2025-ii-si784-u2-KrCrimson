namespace MusicPlayer;

//Concrete Command
public class SkipCommand : IMusicCommand
{
    private MusicPlayer _player;

    public SkipCommand(MusicPlayer player)
    {
        _player = player;
    }

    public string Execute()
    {
        return _player.Skip();
    }
}
