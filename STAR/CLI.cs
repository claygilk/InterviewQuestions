using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Timers;

namespace STAR
{
    public class CLI
    {
        private Quiz quiz { get; set; } = new Quiz();

        public void Menu()
        {
            Console.WriteLine("Welcome to STAR Gauntlet");
            Console.WriteLine("(T)echnical Questions");
            Console.WriteLine("(S)TAR Questions");
            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "t":
                    Console.WriteLine("Technical");
                    this.quiz.AllQuestions = quiz.GetQuestions(true);
                    break;
                case "s":
                    Console.WriteLine("Behavioral");
                    this.quiz.AllQuestions = quiz.GetQuestions(false);

                    break;
                default:
                    break;
            }

            StartQuiz();
        }


        public void StartTimer()
        {
            ConsoleKeyInfo cki;

            int i = 0;

            do
            {
                while (Console.KeyAvailable == false)
                {
                    Thread.Sleep(1000); // Loop until input is entered.
                    Console.WriteLine(i + " sec");
                    i++;
                }

                cki = Console.ReadKey(true);

            } while (cki.Key != ConsoleKey.Q);
        }

        public void StartQuiz()
        {
            // Initialize variables
            int questionCounter = 1;
            Random rand = new Random();

            do
            {
                Console.Clear();
                Console.WriteLine("Quiz in Progress...(Press 'Enter' To Get Another Question)");
                Console.WriteLine();

                // Get Random question
                int questionNumber = rand.Next(quiz.AllQuestions.Count);

                ConsoleKeyInfo cki;

                int seconds = 0;

                // Print question to console
                Console.WriteLine($"Question #{questionCounter}: {quiz.AllQuestions[questionNumber]}");
                quiz.AllQuestions.RemoveAt(questionNumber);
                Console.WriteLine("Questions: " + quiz.AllQuestions.Count);
                Console.WriteLine();

                do
                {
                    while (Console.KeyAvailable == false)
                    {
                        Thread.Sleep(1000); // Loop until input is entered.

                        Console.SetCursorPosition(0, Console.CursorTop);
                        //Console.Write(new string(' ', Console.BufferWidth));

                        int minutes = seconds / 60;
                        int currentSec = seconds % 60;
                        Console.Write(minutes + ":" + currentSec.ToString().PadLeft(2, '0'));

                        Console.SetCursorPosition(0, Console.CursorTop);
                        seconds++;
                    }

                    cki = Console.ReadKey(true);

                } while (cki.Key != ConsoleKey.Enter);

                questionCounter++;

            } while (true);
        }
    }
}
