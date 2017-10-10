using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextGenerator
{
    class Program
    {
        const int MaxLen = 50000000;
        static Random _rand = new Random();
        static void Main(string[] args)
        {
            Generate _gen = new Generate();
            _gen.PutUrLogicHere = Logic;
            _gen.WriteFile();
        }

        static void Logic(StringBuilder Render)
        {
            Func<int, String> RetString = (inpParam) => { return
                $"<301>, <Фамилия>, <Имя>, <Отчество>, <08.08.08>, <{inpParam}>, <180>, <200>, <4.7>";
            };
            var AllFileSize = Generate.GetCurrentTextSize;
            var FileSize = MaxLen / 100;

            while (AllFileSize<MaxLen)
            {
                var number = (int)((_rand.NextDouble()+0.1) * 1000000 - 100000);
                for (int i = 0; i < 10; i++)
                {
                    Render.AppendLine(RetString(number));
                }
                
                if (Generate.GetCurrentTextSize>FileSize)
                {
                    AllFileSize += Generate.GetCurrentTextSize;
                    Generate.NewFile();
                }

            }

        }


    }
}
