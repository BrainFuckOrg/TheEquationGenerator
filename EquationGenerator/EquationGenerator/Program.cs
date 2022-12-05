using System;
using System.Diagnostics;
using Console = System.Console;

namespace EquationGenerator
{
    
    public static class Program
    {
        public static Boolean showProgress;
        public static void Main()
        {
            Int16 minSolution = 1;
            Int16 maxSolution = 10;
            Int16 n = 5000;
            //Console.WriteLine(EquationGenerator.GenerateEquationSecondDegree(-10,10));
            //Console.WriteLine(EquationGenerator.GenerateEquationFirstDegree(-10,10));
            //Console.WriteLine(EquationGenerator.GenerateEquationSecondDegree(-100,100));
            //Console.WriteLine(EquationWriter.GenerateEquationWithKoefs(new []{3,5,8,7,3,4,4,4,4,4,4,4,4,4,4,123124}));
            //Console.WriteLine(EquationGenerator.GenerateEquationWithSolution(new Int16[]{1,1,1}));
            //Console.WriteLine(EquationGenerator.GenerateEquationNDegree(1,10,5000));
            Console.WriteLine("show progress bar?");
            showProgress = Console.ReadLine() == "y";
            Console.WriteLine("Load to file? y/n");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("select file path for equation, if it doesn't exist it will be created");
                String path1 = Console.ReadLine();
                FileStream fs = new FileStream(path1, FileMode.OpenOrCreate);
                fs.Close();
                Console.WriteLine("select file path for answers, if it doesn't exist it will be created");
                String path2 = Console.ReadLine();
                fs = new FileStream(path2, FileMode.OpenOrCreate);
                fs.Close();
                StreamWriter sw = new StreamWriter(path1, false);
                sw.WriteLine(EquationGenerator.GenerateEquationNDegree(minSolution,maxSolution,n));
                sw.Close();
                sw = new StreamWriter(path2, false);
                for (int i = minSolution; i <= maxSolution; i++)
                {
                    sw.WriteLine("{0} ({1} times)",i,EquationGenerator.Answers[i-minSolution]);
                }
                sw.Close();
                Console.WriteLine("finished");
            }
            else
            {
                Console.WriteLine(EquationGenerator.GenerateEquationNDegree(minSolution,maxSolution,n));
                Console.WriteLine();
                for (int i = minSolution; i <= maxSolution; i++)
                {
                    Console.WriteLine("{0} ({1} times)",i,EquationGenerator.Answers[i-minSolution]);
                }
            }

            Console.WriteLine(stopwatch.ElapsedMilliseconds+" milliseconds");
        }
    }
}

