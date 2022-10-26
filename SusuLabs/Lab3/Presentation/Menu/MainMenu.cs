using SusuLabs.Lab3.Presentation.Menu;

namespace SusuLabs.Lab3.Presentation;

public delegate void OnMenuItemSelected();

public class MainMenu : BaseMenu
{
    private readonly Dictionary<int, OnMenuItemSelected> _onMenuItemSelecteds;

    public MainMenu(string[] menuItems, Dictionary<int, OnMenuItemSelected> onMenuItemSelecteds): base(menuItems)
    {
        _onMenuItemSelecteds = onMenuItemSelecteds;
    }
    
    protected override void DrawInput()
    {
        if (_onMenuItemSelecteds.ContainsKey(MenuIndex))
        {
            _onMenuItemSelecteds[MenuIndex].Invoke();
        }
        
        Console.WriteLine("Для выхода нажмите e");
    }
}