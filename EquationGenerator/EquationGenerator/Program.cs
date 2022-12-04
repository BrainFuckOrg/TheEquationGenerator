using System;
using Console = System.Console;

namespace EquationGenerator
{
    
    public static class Program{
        public static void Main()
        {
            //Console.WriteLine(EquationGenerator.GenerateEquationSecondDegree(-10,10));
            //Console.WriteLine(EquationGenerator.GenerateEquationFirstDegree(-10,10));
            //Console.WriteLine(EquationGenerator.GenerateEquationSecondDegree(-100,100));
            //Console.WriteLine(EquationWriter.GenerateEquationWithKoefs(new []{3,5,8,7,3,4,4,4,4,4,4,4,4,4,4,123124}));
            //Console.WriteLine(EquationGenerator.GenerateEquationWithSolution(new Int16[]{1,1,1}));
            //Console.WriteLine(EquationGenerator.GenerateEquationNDegree(1,10,5000));
            Console.WriteLine("Load to file? y/n");
            if (Console.ReadLine() == "y")
            {
                Console.WriteLine("select file");
                System.IO.StreamWriter writer = new StreamWriter(Console.ReadLine(), false);
                writer.Write(EquationGenerator.GenerateEquationNDegree(1,10,5000));
                writer.Close();
                Console.WriteLine("finished");
            }else Console.WriteLine(EquationGenerator.GenerateEquationNDegree(1,10,5000));
        }
    }
}

