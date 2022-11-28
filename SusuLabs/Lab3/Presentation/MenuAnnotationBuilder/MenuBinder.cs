using System.Reflection;
using SusuLabs.Lab3.Presentation.Menu;
using SusuLabs.Lab3.Presentation.Menu.Impls;
using SusuLabs.Lab3.Utils;

namespace SusuLabs.Lab3.Presentation.MenuAnnotationBuilder;

/// <summary>
/// Класс 
/// </summary>
public static class MenuBinder
{
    /// <summary>
    /// Создаёт и привязывает меню к определенным действиям объекта
    /// </summary>
    /// <param name="obj">Объект с действиями</param>
    /// <returns>Меню</returns>
    /// <seealso cref="BaseMenu"/>
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