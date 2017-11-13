using System;
using System.Text;

namespace TextGenerator
{
    class Program
    {
        const int MaxLen = 50000000;
        static Random _rand = new Random();
        static void Main(string[] args)
        {
            //second param number of files
            Generate _gen = new Generate(MaxLen, 3);
            _gen.PutUrLogicHere = Logic;
            _gen.WriteFile();
        }


        //put ur logic here
        static void Logic(StringBuilder Render)
        {
            Func<int, String> RetString = (inpParam) => { return
                $"<301>, <Фамилия>, <Имя>, <Отчество>, <08.08.08>, <{inpParam}>, <180>, <200>, <4.7>";
            };
            while (Generate.AllTextSize<MaxLen)
            {                
                var number = (int)((_rand.NextDouble()+0.1) * 1000000 - 100000);
                for (int i = 0; i < 10; i++)
                {
                    Render.AppendLine(RetString(number));
                }
                Generate.Check();                                
            }

        }


    }
}
