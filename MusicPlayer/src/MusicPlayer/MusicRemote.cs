namespace MusicPlayer;

//Invoker - MusicRemote
public class MusicRemote
{
    private IMusicCommand? _command;

    public void SetCommand(IMusicCommand command)
    {
        _command = command;
    }

    public string PressButton()
    {
        if (_command == null)
        {
            return "No command set.";
        }
        return _command.Execute();
    }
}
