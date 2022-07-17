using System;
using System.Linq;
namespace ManyProjects
{

    public class longestWordInAListBetter
    {

        //class being called from mainHub
        public void ClassOneV2()
        {
            Console.WriteLine("What sentence do you want to select?");

            //converting the NumPad input to an int

            string lineSelectedString;
            lineSelectedString = Console.ReadLine();
            int lineSelected = System.Convert.ToInt16(lineSelectedString);
            //Console.WriteLine(lineSelected+"\n");
            /*keyInfoString = keyInfoString.Replace("NumPad", "");
            result = int.TryParse(keyInfoString, out number)
            Console.WriteLine("output boolean: " + result);
            Console.WriteLine("output number: " + number);*/
           
            string[] AllLines = File.ReadAllLines("longestWordList.txt");

            Console.WriteLine("\nYou have selected: " + AllLines[lineSelected] + "\n");
            
            string[] AllLinesLowerCase = AllLines.Select(s => s.ToLowerInvariant()).ToArray();

            //Console.WriteLine(lineSelected + "\n");
            //replace the . in a string
            string AllLinesLowerCaseString = string.Join(" ", AllLinesLowerCase);

            AllLinesLowerCaseString = AllLinesLowerCaseString.Replace(".", "\n");
            AllLinesLowerCaseString = AllLinesLowerCaseString.Replace("?", "\n");
            AllLinesLowerCaseString = AllLinesLowerCaseString.Replace("!", "\n");
            
            
            //Console.WriteLine("\n" + readAllLinesLowerCaseString + "\n")
            AllLinesLowerCase = AllLinesLowerCaseString.Split('\n');
           // Console.WriteLine(lineSelected + "\n");
            string[] activeWord = AllLinesLowerCase[lineSelected].Split(' ');

            Console.WriteLine(activeWord.ToString());
            /*foreach(var j in AllLinesLowerCaseString)
            
                Console.WriteLine(j);
            }*/
            
            Console.WriteLine("The longest word in this sentence is:\n");

            int counter = 0;
            string word = "";
            int lengthOfWord = 0;
            

            while (counter != activeWord.Length)
            {
                Console.WriteLine(activeWord[counter]);

                if (activeWord[counter].Length >= lengthOfWord)
                {
                    lengthOfWord = activeWord[counter].Length;
                    word = activeWord[counter];
                }
                counter++;
               
            }

            Console.WriteLine(word + "\n");
            
        }

    }
}

