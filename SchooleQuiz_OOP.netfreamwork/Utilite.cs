using SchooleQuiz_OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchooleQuiz_OOP
{
    public static class Utilite
    {
        public static Student AddStudent()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            //instansiate a student
            Student student = new Student();

            //get name
            Console.WriteLine("Enter Student FullName:");
            student.Fullname = Console.ReadLine();
            //get birthYear
            student.SetAge(GetInteger("Enter Student Birth (shamsi):", false));
            //get area
            Console.WriteLine("Enter Student Area:");
            student.Area = Console.ReadLine();
            Console.ResetColor();

            return student;
        }
        public static Quiz AddQuiz()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Quiz quiz = new Quiz();
            quiz.QuizDate = DateTime.Now;
            //quiz name
            Console.WriteLine("What Is Your Quiz Target:");
            quiz.QuizTitel = Console.ReadLine();

            int common = 1;
            quiz.Qustions = new List<Qustion>();
            while (common != 0)
            {
                Console.Clear();
                Qustion qustion = new Qustion();
                Console.WriteLine("Write Qustion Titel");
                qustion.Titel = Console.ReadLine();

                Console.WriteLine("Write 4 Qustion Option");
                qustion.Options = new List<string>();
                for (int i = 1; i <= 4; i++)
                {
                    Console.Write($"{i} - Option: ");

                    qustion.Options.Add(Console.ReadLine());
                }
                qustion.CurrctChoise = GetInteger("What Choise Is Currect?");
                Console.Clear();

                quiz.Qustions.Add(qustion);
                Console.WriteLine("Qustion Add.");
                common = GetInteger("For Exit 0 and contunue nother num...");
            }
            Console.ResetColor();
            return quiz;
        }
        public static void ShowQuizs()
        {
            if (!Schoole.Quizzes.Any())
            {
                Console.WriteLine("No Quiz Avilable\n" +
                    "for continue temp any key");
                Console.ReadKey();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Witch Quiz Do You Whant ?\n" +
                    "--------------------------------------");
                foreach (var item in Schoole.Quizzes)
                {
                    Console.WriteLine($"{item.Id} - {item.QuizTitel} ");
                    Console.WriteLine("---------------------------------------");
                }
                Guid quizId = GetGuid();
                while (!Schoole.Quizzes.Any(a => a.Id == quizId))
                {
                    quizId = GetGuid("Witch Quiz Do You Whant ?");
                }
                Quiz quiz = Schoole.Quizzes.Find(a => a.Id == quizId);
                Console.WriteLine("Showing Qustions...");
                Console.WriteLine("-------------------------------------------");
                foreach (var item in quiz.Qustions)
                {
                    Console.WriteLine($"{item.Titel}");
                    Console.WriteLine($"Options...");
                    foreach (var op in item.Options)
                    {
                        Console.WriteLine(op);
                    }
                    Console.WriteLine("----------------------------------------");
                }
                Console.ResetColor();
                Console.ReadKey();
            }
        }
        public static void TryToQuiz()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (CheckQuizAndStudent())
            {
                Console.WriteLine("Whitch Student Whant to Try Quiz?");
                foreach (var item in Schoole.Students)
                {
                    Console.WriteLine($"{item.Id} - {item.Fullname} - {item.GetAge()}");
                }
                Console.WriteLine("-----------Write one Id-----------");
                Guid studentId = GetGuid();
                while (!Schoole.Students.Any(a => a.Id == studentId))
                {
                    studentId = GetGuid("Wrang!!!\tWrite one Id");
                }
                Student student = Schoole.Students.Find(a => a.Id == studentId);
                Console.WriteLine("Chosing Random Quiz...");
                Random random = new Random();
                Task.Delay(2000).Wait();
                Console.Clear();
                int quizIndex = random.Next(0, Schoole.Quizzes.Count);
                Quiz quiz = Schoole.Quizzes[quizIndex];
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(quiz.QuizTitel);
                Console.WriteLine("--------------------------");
                QuizHistory quizHistory = new QuizHistory();
                quizHistory.Quiz = quiz;
                foreach (var item in quiz.Qustions)
                {
                    Console.WriteLine(item.Titel);
                    foreach (var op in item.Options)
                    {
                        Console.WriteLine(op);
                    }
                    Console.WriteLine("------------------------");
                    int choise = GetInteger("Choise Currect Index");
                    if (choise==item.CurrctChoise)
                    {
                        quizHistory.CurrcetChoises += 1;
                    }
                }
                student.QuizHistories.Add(quizHistory);
                Schoole.Students.First(a => a.Id == student.Id).QuizHistories.Add(quizHistory);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You Get {quizHistory.CurrcetChoises} from {quiz.Qustions.Count} Score.");
                Console.ResetColor();
                Console.WriteLine("Temp Any Key...");
                Console.ReadKey();
            }
            Console.ResetColor();

        }
        static bool CheckQuizAndStudent()
        {
            if (!Schoole.Quizzes.Any())
            {
                Console.WriteLine("No Quiz Avilble.");
                return false;
            }
            if (!Schoole.Students.Any())
            {
                Console.WriteLine("No Student Avilble.");
                return false;
            }
            if (Schoole.Students.Any() && Schoole.Quizzes.Any())
            {
                return true;
            }
            return false;
        }
        public static void Welecom()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            while (true)
            {
                int common = Utilite.GetInteger("What Do You Do?\n" +
                    "1)Add Student.\n" +
                    "2)Add Quiz.\n" +
                    "3)Get Quizs.\n" +
                    "4)Try To Quiz.");
                switch (common)
                {
                    case 1:
                        // add a student
                        Student student = AddStudent();
                        Schoole.Students.Add(student);
                        break;
                    case 2:
                        // add a quiz
                        Quiz quiz = AddQuiz();
                        Schoole.Quizzes.Add(quiz);
                        break;
                    case 3:
                        //get quzzes
                        ShowQuizs();
                        break;
                    case 4:
                        TryToQuiz();
                        // try to quiz
                        break;
                    default:
                        break;
                }
                Console.Clear();
                Console.ResetColor();
            }
        }
        public static Guid GetGuid(string alert = "")
        {
            Guid patientId;
            Console.WriteLine(alert);
            try
            {
                patientId = Guid.Parse(Console.ReadLine());
                return patientId;
            }
            catch (Exception)
            {
                Console.WriteLine("Wrang Its Not Currenct Format");
                patientId = GetGuid(alert);
            }
            return patientId;
        }
        public static int GetInteger(string alert, bool clear = true)
        {
            int val;
            Console.WriteLine(alert);
            try
            {
                val = int.Parse(Console.ReadLine());
                if (clear == true)
                    Console.Clear();
            }
            catch (FormatException)
            {
                Console.Clear();

                val = GetInteger(alert);
            }
            return val;
        }
        public static void AddMuck()
        {
            Student student = new Student()
            {
                Area = "Rasht",
                Fullname = "Alireza sejdei"
            };
            student.SetAge(1381);

            Student student1 = new Student()
            {
                Area = "Tehran",
                Fullname = "Ahamad Shokri"
            };
            student1.SetAge(1379);

            Quiz quiz = new Quiz()
            {
                QuizDate = DateTime.Now,
                QuizTitel = "English",
                Qustions = new List<Qustion>()
                {
                    new Qustion()
                    {
                        Titel="What is deffrent?",
                    CurrctChoise=4,
                        Options=new List<string>()
                        {
                            "They",
                            "He",
                            "She",
                            "Me"
                        }
                    },
                      new Qustion()
                    {
                        Titel="Witch About Place?",
                        CurrctChoise=2,
                        Options=new List<string>()
                        {
                            "When",
                            "Where",
                            "How",
                            "What"
                        }
                    },
                }
            };

            Schoole.Quizzes.Add(quiz);
            Schoole.Students.AddRange(new List<Student>() { student, student1 });

        }
    }
}
