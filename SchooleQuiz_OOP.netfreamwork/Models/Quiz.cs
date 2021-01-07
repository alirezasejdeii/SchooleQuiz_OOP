using System;
using System.Collections.Generic;
using System.Text;

namespace SchooleQuiz_OOP.Models
{
  public  class Quiz
    {

        public Quiz()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        public string QuizTitel { get; set; }
        public List<Qustion> Qustions { get; set; } //Qustion
        public DateTime QuizDate { get; set; }

    }
}
