using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodleExamConverter
{
    public class ChoiceLine
    {
        //private string line;
        List<Choice> choices = new List<Choice>();
        public ChoiceLine(string line) 
        { 
            //this.line = line;
            Split(line);
        }

        public int Count()
        {
            return choices.Count;
        }

        public Choice Get(int index)
        {
            return choices[index];
        }

        private void Split(string line)
        {
            int iLast = 0;
            for(int i=2; i < line.Length-1; i++)
            {
                if (!IsStartWithChoice(i, line))
                    continue;
                AddChoice(line, iLast, i);
                iLast = i;
                i++; // เพื่อข้ามกรณี *
            }
            AddChoice(line, iLast, line.Length);
        }

        private void AddChoice(string line, int start, int end)
        {
            bool correct = false;
            if (line[start] == CorrectMarker)
            {
                correct = true;
                start++;
            }
            var choice = line.Substring(start, end - start);
            choices.Add(new Choice(choice, correct));
        }

        private const char CorrectMarker = '*';
        // ค่าที่เป็นไปได้เช่น
        // *a. 
        // a.   
        public static bool IsStartWithChoice(int iStart, string input)
        {
            if (input.Length < 2 + iStart)
                return false;

            char first = input[iStart];
            if (first != CorrectMarker)
                return IsCharAndDot(iStart, input);
            else
                return IsCharAndDot(iStart + 1, input);
        }

        // เช่น a.
        private static bool IsCharAndDot(int iStart, string input)
        {
            if (input.Length < 2 + iStart)
                return false;

            return Char.IsLetter(input[iStart]) && input[iStart + 1] == '.';
        }

    }
}
