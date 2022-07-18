using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjects
{
    internal class CalculatorHelper
    {   
        /// <summary>
        /// This method takes in a single line expression string, removes all whitespace, and separates expressions inside of parentheses.
        /// </summary>
        /// <param name="Expression"></param> is the mathematical expression that the user input
        /// <returns>List/<String/> SubExpressions</returns> the list of sub-expressions within the expression.
        private List<String> InterpretParentheses(String Expression)
        {
            List<String> SubExpressions = new List<String>();
            String temp = String.Concat(Expression.Where(c => !char.IsWhiteSpace(c)));
            String[] tempArray1 = temp.Split("(");
            String[] tempArray2;
            for (int i = 0; i < tempArray1.Length; i++)
            {
                tempArray2 = tempArray1[i].Split(")");
                for(int j=0;j<tempArray2.Length; j++)
                {
                    SubExpressions.Add(tempArray2[j]);
                }

            }

            return SubExpressions;
        }
    }
}
