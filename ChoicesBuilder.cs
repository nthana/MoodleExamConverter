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
            var cl = new ChoiceLine(line);
            Debug.Assert(cl.Count() > 0);
            for (int i = 0; i < cl.Count(); ++i)
                choices.Add(cl.Get(i));
        }

        private bool first;
        public string GetFullString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{:MULTICHOICE:");
            if (!choices[0].RightAnswer)
                sb.Append("\r\n");
            first = true;
            foreach (var choice in choices)
            {
                AppendExceptFirst(sb);
                sb.Append(CorrectCode(choice));
                sb.AppendLine(choice.Text);
            }
            sb.Append("}\r\n");
            return sb.ToString();
        }

        private void AppendExceptFirst(StringBuilder sb)
        {
            if (first)
                first = false;
            else
                sb.Append("~");
        }

        private string CorrectCode(Choice choice)
        {
            if (choice.RightAnswer)
                return "=";
            return "";
        }
    }
}
