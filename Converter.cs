using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MoodleExamConverter
{
    public class Converter
    {
        // ไม่สนใจ whitespace หน้าหลังบรรทัด
        // เลขข้อ เริ่มที่เลขอะไรก็ได้ แต่ถ้าเจอแล้ว ข้อถัดไปต้องไล่เลขกันไป เช่น 10.  แล้วก็ 11.
        // ข้อใหม่ ขึ้นด้วย  ตัวเลขตามด้วยจุด เช่น "1."
        // จากนั้นจะหา "a." จนกว่าจะเจอ หรือเจอ "2." ก่อน
        // ใช้กับ 4 choice ก่อน คือ a. b. c. d.
        // อาจมีแค่ 3 choice ก็ได้ ถ้าเจอ "2." ก่อน

        /* Source:
         * ---2---   this is a comment line. start with "---"
         * 1. question
         * additional line(s)
         * a. choiceA    *b. choiceB 
         * c. choiceC    d. choiceD
         * 
         * 2. question...
         * ...
         */

        /* Destination:
         * 1. question
         * {:MULTICHOICE:
         * a. choiceA
         * ~=b. choiceB
         * ~c. choiceC
         * ~d. choiceD }
         * 
         * in case of len of all choice <= 80 characters,
         * {:MULTICHOICE:a. choiceA ~=b. choiceB ~c. choiceC ~d. choiceD }
         * 
         */

        public Converter() { }

        // state:
        // 1- ยังไม่เจอเลขข้อเลย
        // 2- เจอเลขข้อแล้ว รอเจอ choice ไล่ไป อาจรอ a,b,c,d ได้หมด
        // choice จะไม่ยาวเกินบรรทัด
        // บรรทัดที่มี choice, จะเป็นข้อความแรกของบรรทัด เช่น "a."
        // ภายในอาจมี choice อื่นๆ เช่น "b."
        // // 2- เจอเลขข้อแล้ว ยังไม่เจอ a.
        // // 3- เจอchoice แล้ว   รอเจอ choice หรือ เลขข้อใหม่
        //
        // // แต่ละข้อต้องมีอย่างน้อย 1 choice จึงจะจบการทำงานได้ -> ไม่ต้องก็ได้

        // algorithm ง่ายๆ คือ
        // ถ้าเจอพวก a. ขึ้นต้น ถือเป้น choice  ถ้าขึ้นด้วยแบบอื่น แค่แสดงผลออกไปปกติ
        // บรรทัดที่มี choice ต้องอยู่ติดๆ กัน ห้ามมีบรรทัดปกติคั่น

        private string Replace(string source)
        {
            source = source.Replace("\t", " ");
            //source = source.Replace("{", "&#123;");
            source = source.Replace("}", "&#125;");
            return source;
        }

        private ChoicesBuilder choices;
        StringBuilder sb;
        public string Convert(string source, bool bRemoveChoiceLetter)
        {
            sb = new StringBuilder();
            source = source.Replace("\r", "");
            source = Replace(source);
            String[] lines = source.Split('\n');
            TrimAll(lines);

            choices = new ChoicesBuilder(bRemoveChoiceLetter);
            for (int i = 0; i < lines.Length; ++i)
            {
                string line = lines[i];
                if (line.StartsWith("---")) // comment line
                    continue;
                if (!IsStartWithChoice(line)) // normal text: เช่นพวกโจทย์
                {
                    InjectChoice();
                    sb.Append(line);
                    sb.Append("\r\n");
                }
                else
                {
                    choices.AddChoiceLine(line);
                }
            }
            InjectChoice();

            return sb.ToString();
        }

        private void InjectChoice()
        {
            if (choices.hasData())
            {
                sb.Append(choices.GetFullString());
                choices.Clear();
            }
        }

        private void TrimAll(string[] inputs)
        {
            for(int i=0;i<inputs.Length;i++)
            {
                inputs[i] = inputs[i].Trim();
            }
        }

        private bool IsStartWithChoice(string input)
        {
            return ChoiceLine.IsStartWithChoice(input);
        }
    }
}
