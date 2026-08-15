using System;
using System.Collections.Generic;
using System.Text;

namespace С__Victoryna
{
    public enum VictorynaCategory
    {
        History = 1, Geography, Biology, Sport, Mathmatic, Programming
    }
    class Victoryna
    {
        public string Name { get; set; }                       // Назва вікторини
        public VictorynaCategory Category { get; set; }        // Категорія вікторини
        public List<Question> Questions { get; set; } = new(); // Список питань

        public Victoryna(string name, VictorynaCategory category, List<Question> questions)
        {
            Name = name;
            Category = category;
            Questions = questions;
        }

        public override string ToString() => $"{Name}|{Category}|{Questions.Count} questions";
    }
}
