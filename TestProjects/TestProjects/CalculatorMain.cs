
namespace ManyProjects
{
    public static class CalculatorMain
    {
        public static string OrderOfOperations()
        {
            Console.WriteLine("\n Input your desired compound expression.");
            string InputExpression = "7+6-7+6/2*3";
            string LayeredExpression = "7+8+9+6+5+99+5";
            
            //Console.WriteLine(CalculatorHelper.IsLayered(LayeredExpression));
             Console.WriteLine(CalculatorHelper.IsCompound(InputExpression));
            //Console.WriteLine(CalculatorEvaluator.EvaluateCompoundExponential(InputExpression));
            //5CalculatorHelper.EvaluateCompoundExpression(InputExpression);
        
            return "Error";
        }
    }
}