using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleExamConverter
{
    public class Choice
    {
        public string Text { get; }
        public bool RightAnswer { get; }

        public Choice(string text, bool rightAnswer)
        {
            Text = text;
            RightAnswer = rightAnswer;
        }

    }
}
