namespace SusuLabs.Lab3.Presentation.Menu.Impls;

public class MainMenu : BaseMenu
{
    private readonly List<Action> _actions = new();
    
    public void AddItem(string itemText, Action itemAction)
    {
        _menuItems.Add(itemText);
        _actions.Add(itemAction);
    }

    protected override void DrawInput()
    {
        _actions[MenuIndex].Invoke();
        Console.WriteLine("Для выхода нажмите e");
    }
}