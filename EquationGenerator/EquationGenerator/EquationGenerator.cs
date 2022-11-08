namespace EquationGenerator;

public static class EquationGenerator
    /*Class for generation Equation*/
{

    private static String GenerateEquationWithSolution(Int16 solution1)
    {
        return EquationWriter.GenerateEquationWithKoefs(new[] { 1, -solution1 });
    }

    private static String GenerateEquationWithSolution(Int16 solution1, Int16 solution2)
    {
        Int32 coeff1 = -(solution1 + solution2);
        Int32 coeff2 = solution1 * solution2;
        return EquationWriter.GenerateEquationWithKoefs(new[] { 1, coeff1, coeff2 });
    }
    
    public static String GenerateEquationWithSolution(Int16 []solution)
    {
        Int32[] coeffs = new Int32[solution.Length+1];
        coeffs[0] = 1;
        Int32 n = solution.Length;
        for (int p = 0; p < n; p++)
        {
            Int32 sum = 0;
            for (Int32 q = 1; q <= n-p; q++)
            {
                Int32 prod = 1;
                for (Int32 k = q; k <= q+p-1; k++)
                {
                    prod *= solution[k - 1];
                }

                Int32 sum1 = 0;
                prod = p == 0 && q > 1 ? 0 : prod;
                for (Int32 i = q+p; i <= n; i++)
                {
                    sum1 += solution[i - 1];
                }
                Console.WriteLine(p+") "+prod+" " + sum1);

                sum += prod * sum1;
            }
            Console.WriteLine("--- "+p+") "+sum);
            coeffs[p + 1] = sum * (p % 2 == 1 ? 1 : -1);
        }
        return EquationWriter.GenerateEquationWithKoefs(coeffs);
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
}