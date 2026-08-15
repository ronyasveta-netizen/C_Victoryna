using System;
using System.Collections.Generic;
using System.Text;

namespace С__Victoryna
{
    public class User
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDate { get; private set; }
        
        public List<UserResult> Results { get; private set; } = new(); // Історія проходження вікторин

        public User(string login, string password, DateTime birthDate)
        {
            
            Login = login;
            Password = password;
            BirthDate = birthDate;
        }
        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
        public void ChangeBirthDate(DateTime newDate)
        {
            BirthDate = newDate;
        }        
        public void AddResult(UserResult result) // Додавання результату вікторини
        {
            Results.Add(result);
        }
        public override string ToString()
        {
            return $"{Login}|{Password}|{BirthDate:yyyy-MM-dd}";
        }
    }
}

