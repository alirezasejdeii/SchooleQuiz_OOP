using System;
using System.Collections.Generic;
using System.Text;

namespace SchooleQuiz_OOP.Models
{
    public class Qustion
    {
        public Qustion()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Titel { get; set; }
        public int CurrctChoise { get; set; }
        public List<string> Options { get; set; }
    }
}
