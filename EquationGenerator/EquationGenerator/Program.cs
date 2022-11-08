using System;

namespace EquationGenerator
{
    static class EquationWriter
    {
        public static String GenerateEquationWithKoefs(Int32[] coeffs)
        {
            if (coeffs.Length < 2)
            {
                throw new Exception("Too few koefs");
            }

            String equation = "";
            UInt16 extant = (UInt16)(coeffs.Length - 1);
            Int16 coeffNum = 0;
            Boolean withSpaces = false;

            do
            {
                equation += XWithCoeff(coeffs[coeffNum++], extant, ref withSpaces);
            } while (extant-- > 0);
            {
                
            }
            equation += " = 0";
            
            return equation;
        }

        private static String XWithCoeff(Int32 coeff, UInt16 extant, ref Boolean withSpaces)
        {
            String equation = "";
            if (coeff == 0)
            {
                return "";
            }

            equation += RightStringNumber(coeff, ref withSpaces);
            
            if (extant == 0)
            {
                equation += Math.Abs(coeff);
                return equation;
            }
            
            equation += Math.Abs(coeff) == 1 ? "" : Math.Abs(coeff);
            equation +=  "x";
            equation += extant == 1 ? "" : SupNumber(extant);
            return equation;
        }

        private static String RightStringNumber(Int32 coeff, ref Boolean withSpaces)
        {
            String equation = "";

            if (withSpaces)
            {
                equation += coeff > 0 ? " + " : " - ";
            }
            else
            {
                withSpaces = true;
                equation += coeff > 0 ? "": "-";
            }
            return equation;
            
        }
        private static String SupNumber(UInt16 number)
        {
            Char[] supNumbers = new[] { '\x2070', '\xB9', '\xB2', '\xB3', '\x2074','\x2075','\x2076', '\x2077', '\x2078', '\x2079'};
            
            String degree = "";
            foreach (var numberPart in number.ToString())
            {
                //Console.WriteLine((Int16)numberPart);
                degree += supNumbers[numberPart - '0'];
            }

            return degree;
        }
    }
    
    public static class EquationGenerator
    /*Class for generation Equation*/
    {
        
        private static String GenerateEquationWithSolution(Int16 solution1)
        {
            return EquationWriter.GenerateEquationWithKoefs(new []{1, -solution1});
        }
        
        private static String GenerateEquationWithSolution(Int16 solution1, Int16 solution2)
        {
            Int32 coeff1 = -(solution1 + solution2);
            Int32 coeff2 = solution1 * solution2;
            return EquationWriter.GenerateEquationWithKoefs(new[] { 1, coeff1, coeff2 });
        }

        public static String GenerateEquationFirstDegree(Int16 minSopution, Int16 maxSolution)
        {
            Random random = new Random();
            Int16 solution1 = (Int16)random.Next(minSopution, maxSolution);
            return GenerateEquationWithSolution(solution1);
        }
        
        public static String GenerateEquationSecondDegree(Int16 minSopution, Int16 maxSolution)
        {
            Random random = new Random();
            Int16 solution1 = (Int16)random.Next(minSopution, maxSolution);
            Int16 solution2 = (Int16)random.Next(minSopution, maxSolution);
            return GenerateEquationWithSolution(solution1, solution2);
        }
        
        public 
        static void Main()
        {
            //Console.WriteLine(EquationGenerator.GenerateEquationSecondDegree(-10,10));
            //Console.WriteLine(EquationGenerator.GenerateEquationFirstDegree(-10,10));
            //Console.WriteLine(EquationGenerator.GenerateEquationSecondDegree(-100,100));
            Console.WriteLine(EquationWriter.GenerateEquationWithKoefs(new []{3,5,8,7,3,4,4,4,4,4,4,4,4,4,4,123124}));
        }
    }
}

