
namespace ManyProjects
{
    public static class CalculatorMain
    {
        public static string OrderOfOperations()
        {
            Console.WriteLine("\n Input your desired compound expression.");
            string InputExpression = "7+6+3/2*1";
            string LayeredExpression = "7+8+9+6+5+99+5";
            string IscompoundExpression = "2*1*1";
            string SimpleExpression = "1,5*1";

            Console.WriteLine(CalculatorHelper.EvaluateSimpleExpression(SimpleExpression));
            //Console.WriteLine(CalculatorHelper.IsSimple(SimpleExpression));
            //Console.WriteLine(CalculatorHelper.IsLayered(LayeredExpression));
            //Console.WriteLine(CalculatorHelper.IsCompound(IscompoundExpression));
            //Console.WriteLine(CalculatorEvaluator.EvaluateCompoundExponential(InputExpression));
            //CalculatorHelper.EvaluateCompoundExpressionLR(InputExpression);
        
            return "Error";
        }
    }
}