using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SchooleQuiz_OOP.Models
{
    public class Student
    {
        public Student()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        /// <summary>
        /// for calcuting age
        /// </summary>
        /// <param name="year"></param>
        public string Fullname { get; set; }

        private int age;

        public int GetAge()
        {
            return age;
        }
        /// <summary>
        /// Write Shamsi Birth Year
        /// </summary>
        /// <param name="value"></param>
        public void SetAge(int value)
        {
            age = 1399-value;
        }

        public string Area { get; set; }

        public List<QuizHistory> QuizHistories { get; set; } = new List<QuizHistory>();

    }
}
