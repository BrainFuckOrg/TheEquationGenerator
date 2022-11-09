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

    }
    public static String GenerateEquationWithSolutionSanya(Int16 []solution)
    {
        int[] coeffs = new int[solution.Length+1];
        for (int i = 0; i < coeffs.Length - 2; i++) coeffs[i] = 0;
        coeffs[coeffs.Length - 1] = -solution[0];
        coeffs[coeffs.Length - 2] = 1;
        for (int i = 1; i < solution.Length; i++)
        for (int j = 0; j < coeffs.Length; j++)
            coeffs[j] = (j!=coeffs.Length-1?coeffs[j + 1]:0) - coeffs[j] * solution[i];
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