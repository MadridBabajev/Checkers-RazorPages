using Games;
using MenuSystem.ConsoleHelpers;

namespace MenuSystem;

public class NewGameMenu: IMenu
{

    private readonly string[] _newGameMenuItems = { "PVP (VS Player local) - template", "PVE (VS PC) - not implemented", "EVE (PC VS PC) - not implemented", "PVP Online - not implemented", "Back" };
    private static readonly Dictionary<int, IGame> NewGameMenuItemsDictionary = new()
    {
        { 0, new GamePlayerVsPlayer() },
        { 1, new GamePlayerVsPc() },
        { 2, new GamePcVsPc() },
        { 3, new GamePlayerVsPlayerOnline() }
    };
    public void InitialiseMenu()
    {
        Console.WriteLine("\n== Game modes ==");
        bool userWantsToExist = false;
        while (!userWantsToExist)
        {
            int userChoice = ConsoleHelper.MultipleChoice(true, _newGameMenuItems);
            switch (userChoice)
            {
                case -1:
                case 4 :   
                    userWantsToExist = true;
                    break;
                case 0:
                case 1:
                case 2:
                case 3:
                    NewGameMenuItemsDictionary[userChoice].StartGame();
                    break;
            }
        }
    }
}