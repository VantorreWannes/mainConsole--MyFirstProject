using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyProjects
{
    public static class CalculatorHelper
    {
        static CalculatorHelper()
        {

        }
        /// <summary>
        /// This method takes in a single line expression string, removes all whitespace, and separates expressions inside of parentheses.
        /// </summary>
        /// <param name="Expression"></param> is the mathematical expression that the user input
        /// <returns>List/<String/> SubExpressions</returns> the list of sub-expressions within the expression.
        public static List<string> InterpretParentheses(string Expression)
        {
            List<string> SubExpressions = new List<string>();
            string temp = string.Concat(Expression.Where(c => !char.IsWhiteSpace(c)));
            string[] tempArray1 = temp.Split("(");
            string[] tempArray2;
            for (int i = 0; i < tempArray1.Length; i++)
            {
                tempArray2 = tempArray1[i].Split(")");
                for (int j = 0; j < tempArray2.Length; j++)
                {
                    SubExpressions.Add(tempArray2[j]);
                }

            }

            return SubExpressions;
        }
        
        /// <summary>
        /// Evaluates a "simple expression" with the +,-,*,/,^ operations. If the calculation goes wrong, the function will return int.MinValue.
        /// Example: "2.317^4.2" will return a value of 34.09489.
        /// </summary>
        /// <param name="Expression"></param> A simple expression as a string in the form (number)(operator)(number)
        /// <returns></returns> Returns the solution of the simple expression as a float.
        public static float EvaluateSimpleExpression(string Expression)
        {
            float Value1 = 0, Value2 = 0;
            int OperatorLocation = 0;
            string[] Operators = { "+", "-", "*", "/", "^" };
            int index = 0;

            while((OperatorLocation == 0) && index<Operators.Length)
            {
                if (Expression.IndexOf(Operators[index]) == -1)
                index++;
                else
                    OperatorLocation = Expression.IndexOf(Operators[index]);
            }
            
            Value1 = float.Parse(Expression.Substring(0, OperatorLocation));
            Value2 = float.Parse(Expression.Substring(OperatorLocation+1));
            string Operator = Expression.Substring(OperatorLocation, 1);

            if (Operator.Equals("+"))
            {
                return Value1 + Value2;
            }
            else if (Operator.Equals("-"))
            {
                return Value1 - Value2;
            }
            else if (Operator.Equals("*"))
            {
                return Value1 * Value2;
            }
            else if (Operator.Equals("/"))
            {
                return Value1 / Value2;
            }
            else if (Operator.Equals("^"))
            {
                return (float)Math.Pow(Value1,Value2);
            }

            return float.MinValue;//If the function is used correctly, this statement should never occur.

        }

        public static bool TestForSimple(string Expression)
        {
            
            return false;
        }
    }
}
