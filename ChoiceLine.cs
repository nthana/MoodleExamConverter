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
            if (!IsStartWithChoice(0, line))
                return; // no choice

            int iLast = 0;            
            // เหตุที่เริ่มที่ 3 เพราะตำแหน่ง 0 เชื่อว่าเป็น choice แรกเสมอ
            //    จึงพยายามหาจุดสิ้นสุดของข้อความแรก
            for(int i=3; i < line.Length-1; i++)
            {
                if (Char.IsLetter(line[i - 1])) // ตัวที่แล้วห้ามเป็น letter; ไม่งั้นห้ามเป็นการขึ้น choice ใหม่
                    continue;   // เช่น spec.   ตรง "c." ไม่ถึงเป็น choice; แต่ spe c. แบบนี้ได้
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
            var choice = line.Substring(start, end - start).Trim();
            choices.Add(new Choice(choice, correct));
        }

        private const char CorrectMarker = '*';
        // ค่าที่เป็นไปได้เช่น
        // *a. 
        // a.   
        public static bool IsStartWithChoice(string input)
        {
            return IsStartWithChoice(0, input);
        }
        private static bool IsStartWithChoice(int iStart, string input)
        {
            if (input.Length < 2 + iStart)
                return false;

            char first = input[iStart];
            if (first != CorrectMarker)
                return IsCharDotSpace(iStart, input);
            else
                return IsCharDotSpace(iStart + 1, input);
        }

        // เช่น a.
        private static bool IsCharDotSpace(int iStart, string input)
        {
            if (input.Length < 3 + iStart)
                return false;

            return  Char.IsLetter(input[iStart]) && // Char.IsLower(input[iStart]) && 
                    input[iStart + 1] == '.' && 
                    input[iStart + 2] == ' ';
        }

    }
}
