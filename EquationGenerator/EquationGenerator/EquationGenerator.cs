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