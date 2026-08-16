using System;
using System.Collections.Generic;
using System.Text;

namespace С__Victoryna
{
    class AdminMenu
    {
        public void Show(User admin)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===============================================");
                Console.WriteLine($"Адмін-панель — {admin.Login}");
                Console.WriteLine("===============================================");
                Console.WriteLine("[1] Переглянути всіх користувачів");
                Console.WriteLine("[2] Видалити користувача");
                Console.WriteLine("[3] Переглянути всі вікторини");
                Console.WriteLine("[4] Переглянути всі питання");
                Console.WriteLine("[5] Переглянути всі результати");
                Console.WriteLine("[0] Вийти");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        return; 

                    default:
                        Console.WriteLine("Невірний вибір!");
                        Pause();
                        break;
                }

            }
        }

        private void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
            Console.ReadKey(true);
        }
    }
}
