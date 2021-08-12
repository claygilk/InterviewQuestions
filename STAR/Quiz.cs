using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace STAR
{
    public class Quiz
    {
        public List<string> AllQuestions { get; set; }

        private readonly string starFilePath = @"C:\Users\Student\source\repos\STAR\questions.txt";

        private readonly string techFilePath = @"C:\Users\Student\source\repos\STAR\techquestions.txt";

        public List<string> GetQuestions(bool isTechQuiz)
        {
            List<string> allQuestions = new List<string>();

            string file;

            if (isTechQuiz)
            {
                file = this.techFilePath;
            }
            else
            {
                file = this.starFilePath;
            }

            using (StreamReader reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    string question = reader.ReadLine();

                    allQuestions.Add(question);
                }
            }

            return allQuestions;
        }
    }
}
