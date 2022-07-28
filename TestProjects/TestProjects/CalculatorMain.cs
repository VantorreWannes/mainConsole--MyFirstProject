
namespace ManyProjects
{
    public static class CalculatorMain
    {
        public static string OrderOfOperations()
        {
            Console.WriteLine("\n Input your desired compound expression.");
            string InputExpression = Console.ReadLine();
            Console.WriteLine(CalculatorEvaluator.EvaluateCompoundExponential(InputExpression));
            return "Error";
        }
    }
}