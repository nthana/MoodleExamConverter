using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleExamConverter
{
    public class ChoicesBuilder
    {
        //private char ch = ' ';
        private List<Choice> choices = new List<Choice>();

        public bool hasData() { return choices.Count > 0; }

        public void Clear()
        {
            choices.Clear();
        }

        public void AddChoiceLine(string line)
        {
            Debug.Assert(ChoiceLine.IsStartWithChoice(0, line));
            var cl = new ChoiceLine(line);
            for (int i = 0; i < cl.Count(); ++i)
                choices.Add(cl.Get(i));
        }

        public string GetFullString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{:MULTICHOICE:\r\n");
            foreach (var choice in choices)
            {
                sb.Append("~");
                sb.Append(CorrectCode(choice));
                sb.AppendLine(choice.Text);
            }
            sb.Append("}\r\n");
            return sb.ToString();
        }

        private String CorrectCode(Choice choice)
        {
            if (choice.RightAnswer)
                return "=";
            return "";
        }
    }
}
