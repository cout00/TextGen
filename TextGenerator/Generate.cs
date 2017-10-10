using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGenerator
{
    public class Generate
    {
        readonly static StringBuilder Render = new StringBuilder();
        public Action<StringBuilder> PutUrLogicHere { get; set; }

        static int newFileIndex = 0;


        public static int GetCurrentTextSize
        {
            get { return Render.ToString().Count()*sizeof(char); }
            
        }
        

        public static void NewFile()
        {
            newFileIndex++;
            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"input", $"text{newFileIndex}.txt"), Render.ToString());
            Render.Clear();
        }

        public void WriteFile()
        {
            newFileIndex = 0;         
            PutUrLogicHere?.Invoke(Render);          
        }
        

    }
}
