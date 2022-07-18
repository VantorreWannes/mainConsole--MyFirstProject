using System;
namespace ManyProjects
{

    public class longestWordInAList
    {


        public void ClassOne()
        {
            Console.WriteLine("The longest word in this list is:\n");
            string[] readText = File.ReadAllLines("longestWordList.txt");

            //String wordRn = "";
            int counter = 0;
            string word = "";
            int lengthOfWord = 0;

            //foreach (String wordRn in readText)
            while (counter != readText.Length)
            {
                //wordRn = readText[counter];
                //Console.WriteLine(wordRn);

                if (readText[counter].Length >= lengthOfWord)
                {


                    //wordRn = word;
                    lengthOfWord = readText[counter].Length;
                    word = readText[counter];
                }
                else
                {

                }
                counter++;

            }

            Console.WriteLine(word);

        }

    }
}

