using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Timers;

namespace TextGenerator
{
    public class Generate
    {
        readonly static StringBuilder Render = new StringBuilder();
        public Action<StringBuilder> PutUrLogicHere { get; set; }
        Timer timer = new Timer();

        static int newFileIndex = 0;
        static int _TextSize; //alltext
        static int _curTextSizeAll; //currentAll
        static int _FileSize; //1 file size

        int oldFileIndex;
        //int fileCount;

        public static int GetCurrentTextSize
        {
            get
            {
                return Render.Length * sizeof(char);
            }
        }

        public static int AllTextSize
        {
            get { return _curTextSizeAll; }
            set { _curTextSizeAll = value; }
        }

        public static int FileSize
        {
            get { return _FileSize; }
            set { _FileSize = value; }
        }

        public Generate(int TextSize, int FileCount)
        {
            _TextSize = TextSize;
            //fileCount = FileCount;
            FileSize = TextSize / FileCount;
            Render.Capacity = FileSize / sizeof(char);
            timer.Elapsed += Timer_Elapsed;
            oldFileIndex = newFileIndex;
            timer.Interval = 100;
            timer.Start();
        }

        public static void Check()
        {
            if (GetCurrentTextSize > FileSize)
            {
                NewFile();
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var outNumber = 0d;
            if (oldFileIndex == newFileIndex)
            {
                outNumber = Math.Round((double)GetCurrentTextSize / FileSize * 100, 0, MidpointRounding.AwayFromZero);
            }
            else
            {
                oldFileIndex = newFileIndex;
                outNumber = 100;
            }
            Console.Write($"text{newFileIndex}.txt - {outNumber}/100 % ");
            
            Console.SetCursorPosition(0, newFileIndex);
            timer.Start();
        }

        public static void NewFile()
        {
            newFileIndex++;
            _curTextSizeAll += GetCurrentTextSize;

            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input")))
            {
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input"));
            }
             

            File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input", $"text{newFileIndex}.txt"), Render.ToString());
            Render.Clear();
        }

        public void WriteFile()
        {
            newFileIndex = 0;
            PutUrLogicHere?.Invoke(Render);
            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input");
            Process.Start(file);
        }
    }
}
