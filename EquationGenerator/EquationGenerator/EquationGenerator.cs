using System.Numerics;

namespace EquationGenerator;


public static class EquationGenerator
    /*Class for generation Equation*/
{

    private static String GenerateEquationWithSolution(Int16 []solution)
    {
        Int32[] coeff = new Int32[solution.Length+1];
        coeff[0] = 1;
        for (Int16 i = 0; i < solution.Length; i++)
        {
            coeff[i+1] = GenerateCoeff(i, solution)*(i%2==1?1:-1);
        }
        return EquationWriter.GenerateEquationWithKoefs(coeff);

    }

    private static Int32 GenerateCoeff(Int16 coefNumm, Int16[] solution, Int32 minNum=0)
    {
        Int32 sum = 0;
        for (Int32 i = minNum; i < solution.Length-coefNumm; i++)
        {
            if (coefNumm>0)
            {
                sum += solution[i] * GenerateCoeff((Int16)(coefNumm - 1),solution,i+1);
            }
            else
            {
                sum += solution[i];
            }
        }

        return sum;
    }
    public static String GenerateEquationWithSolutionSanya(Int16 []solution)
    {
        int[] coeffs = new int[solution.Length+1];
        for (int i = 0; i < coeffs.Length - 2; i++) coeffs[i] = 0;
        coeffs[^1] = -solution[0];
        coeffs[^2] = 1;
        for (int i = 1; i < solution.Length; i++)
        for (int j = 0; j < coeffs.Length; j++)
            coeffs[j] = (j!=coeffs.Length-1?coeffs[j + 1]:0) - coeffs[j] * solution[i];
        return EquationWriter.GenerateEquationWithKoefs(coeffs);
    }

    public static String GenerateEquationWithSolutionSanya2(Int16[] solution)
    {
        BigInteger[] coeffs = new BigInteger[solution.Length + 1];
        for (int i = 0; i < coeffs.Length - 2; i++) coeffs[i] = 0;
        coeffs[^1] = -solution[0];
        coeffs[^2] = 1;
        for (int i = 1; i < solution.Length; i++)
        {
            for (int j = 0; j < coeffs.Length; j++)
            {
                coeffs[j] = (j != coeffs.Length - 1 ? coeffs[j + 1] : 0) - coeffs[j] * solution[i];
            }

            if (Program.showProgress)
            {
                if(i>0)Console.SetCursorPosition(0,Console.GetCursorPosition().Top-1);
                Console.WriteLine((i*100)/solution.Length+ "%done  ");
                
            }
        }

        return EquationWriter.GenerateEquationWithKoefs(coeffs);
    }

    public static Int16[] Answers;
    public static String GenerateEquationNDegree(Int16 minSolution, Int16 maxSolution, Int16 n)
    {
        Answers = new Int16[maxSolution - minSolution+1];
        for (int i = 0; i < maxSolution; i++)
        {
            Answers[i] = 0;
        }
        Int16[] Solution = new Int16[n];
        Random random = new Random();
        for (int i = 0; i < Solution.Length; i++)
        {
            int index=Solution[i] = (Int16)random.Next(minSolution, maxSolution+1);
            Answers[index - minSolution]++;
        }
        
        //return GenerateEquationWithSolution(solution);
        return GenerateEquationWithSolutionSanya2(Solution);
    }
}