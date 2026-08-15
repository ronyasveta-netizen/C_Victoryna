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

        public Question(string text, List<string> answers, List<int> correctIndexes)
        {
            Text = text;
            Answers = answers;
            CorrectIndexes = correctIndexes;
        }

        public override string ToString()
        {
            // Формат для збереження у файл (можемо змінити пізніше)
            return $"{Text}|{string.Join(";", Answers)}|{string.Join(",", CorrectIndexes)}";
        }
    }
}
