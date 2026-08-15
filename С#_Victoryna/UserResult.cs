using System;
using System.Collections.Generic;
using System.Text;

namespace С__Victoryna
{
    class UserResult
    {
        public string VictorynaName { get; set; }      // Назва вікторини
        public int CorrectAnswers { get; set; }            // Кількість правильних відповідей
        public DateTime Date { get; set; }        // Дата проходження

        public UserResult(string victorynaName, int correctAnswers, DateTime date)
        {
            VictorynaName = victorynaName;
            CorrectAnswers = correctAnswers;
            Date = date;
        }

        public override string ToString() => $" {VictorynaName}|{CorrectAnswers}|{Date:yyyy-MM-dd}";
    }
}
