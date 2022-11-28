namespace SusuLabs.Lab3.Presentation.MenuAnnotationBuilder;

/// <summary>
/// Класс используется для пометки действия в меню
/// и добавления описания к этому действию.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class MenuItemAttribute : Attribute
{
    public string Text { get; }

    public MenuItemAttribute(string text)
    {
        Text = text;
    }
}