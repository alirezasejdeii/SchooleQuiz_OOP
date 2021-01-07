using System;
using System.Collections.Generic;
using System.Text;

namespace SchooleQuiz_OOP.Models
{
    public static class Schoole
    {
        public static List<Student> Students { get; set; } = new List<Student>();
        public static List<Quiz> Quizzes { get; set; } = new List<Quiz>();
    }
}
