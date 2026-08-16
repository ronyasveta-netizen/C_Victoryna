using System.Text;
using С__Victoryna;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;
        string s = "\U0001F531";
        Console.WriteLine("\t" + s);
        Console.WriteLine(" welcome to test\n");
        Console.ReadKey(true);
        
        // Створюємо менеджер користувачів
        UserManager userManager = new UserManager();

        // Завантажуємо користувачів з файлу (або створюємо адміна)
        userManager.LoadUsers();
        
        // Створюємо меню
        Menu menu = new Menu(userManager);

        // Показуємо меню логіну/реєстрації
        User user = menu.ShowLoginOrRegister();

        // Після входу — показуємо головне меню (або адмін-панель)
        menu.ShowMainMenu(user);
    }
}