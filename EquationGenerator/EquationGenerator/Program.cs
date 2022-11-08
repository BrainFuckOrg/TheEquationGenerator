using System;

namespace EquationGenerator
{
    
    public static class Program{
        public static void Main()
        {
            //Console.WriteLine(EquationGenerator.GenerateEquationSecondDegree(-10,10));
            //Console.WriteLine(EquationGenerator.GenerateEquationFirstDegree(-10,10));
            //Console.WriteLine(EquationGenerator.GenerateEquationSecondDegree(-100,100));
            //Console.WriteLine(EquationWriter.GenerateEquationWithKoefs(new []{3,5,8,7,3,4,4,4,4,4,4,4,4,4,4,123124}));
            Console.WriteLine(EquationGenerator.GenerateEquationWithSolution(new Int16[]{1,1,1}));
        }
    }
}

