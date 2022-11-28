namespace SusuLabs.Lab3.Presentation.Menu.Impls;

/// <summary>
/// Главное меню программы
/// </summary>
public class MainMenu : BaseMenu
{
    private readonly List<Action> _actions = new();
    
    /// <summary>
    /// Добавляет элемент меню
    /// </summary>
    /// <param name="itemText">Подсказка для действия</param>
    /// <param name="itemAction">Действие меню</param>
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