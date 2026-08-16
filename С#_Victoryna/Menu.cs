using System;
using System.Collections.Generic;
using System.Text;

namespace С__Victoryna
{
    class Menu
    {
        private UserManager _userManager;

        public Menu(UserManager userManager)
        {
            _userManager = userManager;
        }

        private void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
            Console.ReadKey(true);
        }

        public User ShowLoginOrRegister()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===============================================");
                Console.WriteLine("                 ВІКТОРИНА");
                Console.WriteLine("===============================================");
                Console.WriteLine("[1] Увійти");
                Console.WriteLine("[2] Зареєструватися");
                Console.WriteLine("[0] Вийти");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var user = ShowLoginMenu();
                        if (user != null)
                            return user;
                        break;

                    case "2":
                        var newUser = ShowRegisterMenu();
                        if (newUser != null)
                            return newUser;
                        break;

                    case "0":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        Pause();
                        break;
                }
            }
        }

        private User ShowLoginMenu()
        {
            Console.Clear();
            Console.WriteLine("============== Вхід ==============");

            Console.Write("Логін: ");
            string login = Console.ReadLine();

            Console.Write("Пароль: ");
            string password = Console.ReadLine();

            var user = _userManager.Login(login, password);

            if (user == null)
            {
                Console.WriteLine("Невірний логін або пароль!");
                Pause();
                return null;
            }

            Console.WriteLine("Вхід успішний!");
            Pause();
            return user;
        }

        private User ShowRegisterMenu()
        {
            Console.Clear();
            Console.WriteLine("=========== Реєстрація ===========");

            Console.Write("Введіть логін: ");
            string login = Console.ReadLine();

            if (_userManager.IsLoginTaken(login))
            {
                Console.WriteLine("Такий логін вже існує!");
                Pause();
                return null;
            }

            Console.Write("Введіть пароль: ");
            string password = Console.ReadLine();

            Console.Write("Введіть дату народження (YYYY-MM-DD): ");
            DateTime birthDate;

            while (!DateTime.TryParse(Console.ReadLine(), out birthDate))
            {
                Console.WriteLine("Невірний формат дати. Спробуйте ще раз.");
            }

            bool success = _userManager.Register(login, password, birthDate);

            if (!success)
            {
                Console.WriteLine("Реєстрація не вдалася.");
                Pause();
                return null;
            }
            return _userManager.Login(login, password);
        }

        public void ShowMainMenu(User user)
        {
            if (user.Role == "admin")
            {
                AdminMenu adminMenu = new AdminMenu();
                adminMenu.Show(user);
                return;
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===============================================");
                Console.WriteLine($"Вітаємо, {user.Login}!");
                Console.WriteLine("===============================================");
                Console.WriteLine("[1] Почати вікторину (поки не реалізовано)");
                Console.WriteLine("[2] Переглянути результати (поки не реалізовано)");
                Console.WriteLine("[0] Вийти");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Вікторина ще не реалізована.");
                        Pause();
                        break;

                    case "2":
                        Console.WriteLine("Результати ще не реалізовані.");
                        Pause();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Невірний вибір!");
                        Pause();
                        break;
                }
            }
        }
    }
}
