using Microsoft.AspNetCore.Mvc;
using MusicPlayerLib = MusicPlayer;

namespace MusicPlayer.Web.Controllers;

public class HomeController : Controller
{
    private readonly MusicPlayerLib.MusicPlayer _player;
    private readonly MusicPlayerLib.MusicRemote _remote;

    public HomeController(MusicPlayerLib.MusicPlayer player, MusicPlayerLib.MusicRemote remote)
    {
        _player = player;
        _remote = remote;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult ExecuteCommand(string command)
    {
        MusicPlayerLib.IMusicCommand? musicCommand = command switch
        {
            "play" => new MusicPlayerLib.PlayCommand(_player),
            "pause" => new MusicPlayerLib.PauseCommand(_player),
            "skip" => new MusicPlayerLib.SkipCommand(_player),
            _ => null
        };

        if (musicCommand == null)
        {
            ViewBag.Result = "Invalid command";
        }
        else
        {
            _remote.SetCommand(musicCommand);
            ViewBag.Result = _remote.PressButton();
        }

        return View("Index");
    }
}
