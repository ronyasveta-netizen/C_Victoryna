using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace С__Victoryna
{
    class UserManager
    {
        private List<User> _users = new();

        // Завантаження користувачів з файлу
        public void LoadUsers()
        {
            if (!File.Exists("users.txt"))
            {
                // Створюємо адміна за замовчуванням
                _users.Add(new User("admin", "Admin123!", new DateTime(1973, 8, 13), "admin"));
                SaveUsers();
                return;
            }

            var lines = File.ReadAllLines("users.txt");

            foreach (var line in lines)
            {
                var parts = line.Split('|');
                if (parts.Length != 4) continue;

                string login = parts[0];
                string password = parts[1];
                DateTime birthDate = DateTime.Parse(parts[2]);
                string role = parts[3];

                _users.Add(new User(login, password, birthDate, role));
            }


            bool adminExists = _users.Any(u => u.Role == "admin");
            if (!adminExists)
            {
                _users.Add(new User("admin", "Admin123!", new DateTime(1973, 8, 13), "admin"));
                SaveUsers();
            }
        }

        // Збереження користувачів у файл
        public void SaveUsers()
        {
            List<string> lines = new();

            foreach (var u in _users)
                lines.Add(u.ToString());

            File.WriteAllLines("users.txt", lines);
        }

        // Перевірка чи логін зайнятий
        public bool IsLoginTaken(string login)
        {
            if (login == "admin")
                return true;
            return _users.Any(u => u.Login == login);
        }

        // Валідація пароля
        private bool IsPasswordValid(string password)
        {
            if (password.Length < 6)
            {
                Console.WriteLine("Пароль має містити мінімум 6 символів.");
                return false;
            }

            if (!password.Any(char.IsDigit))
            {
                Console.WriteLine("Пароль має містити хоча б одну цифру.");
                return false;
            }

            if (!password.Any(char.IsUpper))
            {
                Console.WriteLine("Пароль має містити хоча б одну велику літеру.");
                return false;
            }

            if (!Regex.IsMatch(password, @"[\W_]"))
            {
                Console.WriteLine("Пароль має містити хоча б один спеціальний символ (*, !, ?, @, #, %).");
                return false;
            }

            return true;
        }

        // Реєстрація
        public bool Register(string login, string password, DateTime birthDate)
        {
            if (IsLoginTaken(login))
            {
                Console.WriteLine("Такий логін вже існує.");
                return false;
            }

            if (!IsPasswordValid(password))
            {
                Console.WriteLine("Пароль не відповідає вимогам.");
                return false;
            }

            var user = new User(login, password, birthDate);
            _users.Add(user);
            SaveUsers();

            Console.WriteLine("Реєстрація успішна!");
            return true;
        }

        // Логін
        public User Login(string login, string password)
        {
            foreach (var u in _users)
                if (u.Login == login && u.Password == password)
                    return u;

            return null;
        }

        // Зміна пароля
        public bool ChangePassword(User user, string newPassword)
        {
            if (!IsPasswordValid(newPassword))
                return false;

            user.ChangePassword(newPassword);
            SaveUsers();
            return true;
        }

        // Зміна дати народження
        public bool ChangeBirthDate(User user, DateTime newDate)
        {
            user.ChangeBirthDate(newDate);
            SaveUsers();
            return true;
        }
    }
}
