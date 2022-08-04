using System.Text.RegularExpressions;
namespace ManyProjects
{
    public static class CalculatorHelper
    {
        const string SIMPLE_EXPRESSION_REGEX = "^[0-9]{1,50}[\\.,]{0,1}[0-9]{0,50}[\\+]{0,1}[+\\-^*/]{1}[0-9]{1,50}[\\.,]{0,1}[0-9]{0,50}$";

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
            string Temp = string.Concat(Expression.Where(c => !char.IsWhiteSpace(c)));
            Temp = Temp.Replace(")", ")R").Replace("(", "R(");

            string[] tempArray1 = Temp.Split("R");

            string[] TempArray2;
            for (int i = 0; i < tempArray1.Length; i++)
            {
                TempArray2 = tempArray1[i].Split("R");
                for (int j = 0; j < TempArray2.Length; j++)
                {
                    SubExpressions.Add(TempArray2[j]);
                }

            }

            return SubExpressions;
        }


        /// <summary>
        /// Evaluates a "simple expression" with the +,-,*,/,^ operations. If the calculation goes wrong, the function will return int.MinValue.
        /// Example: "2.317^4.2" will return a value of 34.09489.
        /// </summary>
        /// <param name="Expression"></param> A simple expression as a string in the form (number)(operator)(number)
        /// <returns></returns> Returns the solution of the simple expression as a decimal.
        public static decimal EvaluateSimpleExpression(string Expression)
        {
            decimal Value1 = 0, Value2 = 0;
            int OperatorLocation = 0;
            string[] Operators = { "+", "-", "*", "/", "^" };
            int index = 0;

            while ((OperatorLocation == 0) && index < Operators.Length)
            {
               if (Expression.IndexOf(Operators[index]) == -1)
                    index++;
                else
                    OperatorLocation = Expression.IndexOf(Operators[index]);
            }

            Value1 = decimal.Parse(Expression.Substring(0, OperatorLocation));
            Value2 = decimal.Parse(Expression.Substring(OperatorLocation + 1));
            string Operator = Expression.Substring(OperatorLocation, 1);
            
            if (Operator.Equals("+"))
            {
                return Value1 + Value2;
            }
            else if (Operator.Equals("-"))
            {
                string  Value2Minus = "-" + Value2.ToString();
                return Value1 + decimal.Parse(Value2Minus);
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
                return (Decimal)Math.Pow((double)Value1, (double)Value2);
            }
            return decimal.MinValue;//If the function is used correctly, this statement should never occur.
        }

        /// <summary>
        /// Determines if a given string Expression is "Simple" or not.
        /// </summary>
        /// <param name="Expression".</param> Any string expression.
        /// <returns> true if the expression is simple. </returns>
        public static bool IsSimple(string Expression)
        {
            Regex Tester = new Regex(SIMPLE_EXPRESSION_REGEX);
            return Tester.IsMatch(Expression);
        }

/// <summary>
        /// Determines if a given string Expression is "layered" or not.
        /// </summary>
        /// <param name="Expression".</param> Any string expression.
        /// <returns> true if the expression is layered. </returns>
        public static bool IsCompound(string Expression)
        {
           var Operators = Regex.Matches(Expression, @"[\^+\-*/]").OfType<Match>().Select(m => m.Value).ToList();
            var Numbers = Regex.Matches(Expression, @"[0-9]{1,50}[\\.,]{0,1}[0-9]{0,50}").OfType<Match>().Select(m => m.Value).ToList();
            bool IsTrue = false;
            int NumbersCount = Numbers.Count();
            int OperatorCount = Operators.Count();
            int Counter = 0;
            while(Counter < (Numbers.Count()+Operators.Count())-3)
            { if ( OperatorCount == NumbersCount-1) { IsTrue = true;  }else{ IsTrue = false;}
             Numbers.RemoveAt(NumbersCount-1); Operators.RemoveAt(OperatorCount-1); 
             NumbersCount = Numbers.Count();
             OperatorCount = Operators.Count();
            }
           if ( IsTrue == true) { return true; }
            return false;
        }


        /// <summary>
        /// Determines if a given string Expression is "layered" or not.
        /// </summary>
        /// <param name="Expression".</param> Any string expression.
        /// <returns> true if the expression is layered. </returns>
        public static bool IsLayered(string Expression)
        {
            var Operators = Regex.Matches(Expression, @"[\^+\-*/]").OfType<Match>().Select(m => m.Value).ToList();
            bool isOperatorEqual = Operators.Distinct().Count() == 1;
            //Console.WriteLine("isOperatorEqual: "+isOperatorEqual);
            var Numbers = Regex.Matches(Expression, @"[0-9]{1,50}[\\.,]{0,1}[0-9]{0,50}").OfType<Match>().Select(m => m.Value).ToList();
            bool IsTrue = false;
            int NumbersCount = Numbers.Count();
            int OperatorCount = Operators.Count();
            int Counter = 0;
            while(Counter < (Numbers.Count()+Operators.Count())-3)
            { if ( OperatorCount == NumbersCount-1) { IsTrue = true;  }else{ IsTrue = false;}
             Numbers.RemoveAt(NumbersCount-1); Operators.RemoveAt(OperatorCount-1); 
             NumbersCount = Numbers.Count();
             OperatorCount = Operators.Count();
            }
           if ( IsTrue == true && isOperatorEqual == true) { return true; }
            return false;
        }

        /// <summary>
        /// Determines the operator from a given string.
        /// </summary>
        /// <param name="Expression".</param> Any string expression.
        /// <returns> returns the operator from the string if IsMultipleOperators is false .</returns>
        public static string WhatOperator(string Expression)
        {
            string OperatorS = "error no operator";
            var Arr = Regex.Matches(Expression, @"[\^+\-*/]").OfType<Match>().Select(m => m.Value).ToList();
             if(Arr.Count() > 0) { OperatorS = Arr[0]; }
           
            return OperatorS;


        }

        /// <summary>
        /// Evaluates a "layered expression". A "layered" expresssion consists of a string of mathematical operations with only 1 operation type such as 5*5*5*5.
        /// </summary>
        /// <param name="Expression"></param> A string expression with one operation type.
        /// <returns></returns> returns the value of the decimal
        public static decimal EvaluateLayeredExpression(string Expression, string OperatorS)
        {
            string temp = "";
            string simplePart = "";
            string expressionOperator = "";
            expressionOperator = OperatorS; //operator the layered expression uses
      
            while (!(IsSimple(Expression)))//loop until reduced to a simple expression.
            {
                temp = Expression.Substring(0, Expression.IndexOf(expressionOperator) + 1);
                Expression = Expression.Remove(0, temp.Length);
                simplePart = String.Concat(temp, Expression.Substring(0, Expression.IndexOf(expressionOperator)));
                Expression = Expression.Remove(0, Expression.IndexOf(expressionOperator));
                temp = EvaluateSimpleExpression(simplePart).ToString();
                Expression = String.Concat(temp, Expression);
               
            }
            return EvaluateSimpleExpression(Expression);
        }
       

    }
}