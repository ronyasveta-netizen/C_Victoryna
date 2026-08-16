using System;
using System.Collections.Generic;
using System.Text;

namespace С__Victoryna
{
    class Question
    {
        public string Text { get; set; }                       // Текст питання
        public List<string> Answers { get; set; } = new();     // Варіанти відповідей
        public List<int> CorrectIndexes { get; set; } = new(); // Індекси правильних відповідей
         public VictorynaCategory Category { get; set; }     // категорія питання 
        public Question(string text, List<string> answers, List<int> correctIndexes, VictorynaCategory category)
        {
            Text = text;
            Answers = answers;
            CorrectIndexes = correctIndexes;
            Category = category;
        }

        public override string ToString() => $"{Category}|{Text}|{string.Join(";", Answers)}|{string.Join(",", CorrectIndexes)}";
    }
}
