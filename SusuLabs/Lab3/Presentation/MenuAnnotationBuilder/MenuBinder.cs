using System.Reflection;
using SusuLabs.Lab3.Presentation.Menu;
using SusuLabs.Lab3.Presentation.Menu.Impls;
using SusuLabs.Lab3.Utils;

namespace SusuLabs.Lab3.Presentation.MenuAnnotationBuilder;

public static class MenuBinder
{
    public static BaseMenu BindMenu(object obj)
    {
        var res = new MainMenu();
        var type = obj.GetType();
        
        var methods = type.GetMethods( BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        foreach (var method in methods)
        {
            method.GetCustomAttributes()
                .FirstOrDefault(attr => attr is MenuItemAttribute)
                ?.Also(itemAttribute => res.AddItem(
                    ((MenuItemAttribute)itemAttribute).Text,
                    () => { method.Invoke(obj, null); }
                    )
                );
        }

        return res;
    }
}