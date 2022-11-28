namespace SusuLabs.Lab3.Presentation.MenuAnnotationBuilder;

[AttributeUsage(AttributeTargets.Method)]
public class MenuItemAttribute : Attribute
{
    public string Text { get; }

    public MenuItemAttribute(string text)
    {
        Text = text;
    }
}