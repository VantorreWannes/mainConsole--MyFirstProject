using System;
namespace ManyProjects
{
    public class SimpleCharacterCounter
    {
        public void ClassTwo()
        {
            Console.WriteLine("HOW MANY CHARACTERS\n");
            string[] readText = File.ReadAllLines("CharactersInWordList.txt");

            int counter = 0;
            for (int i = 0; i < readText.Length; i++)
            {
                int lengthOfWord = readText[counter].Length;
                Console.WriteLine(lengthOfWord);


                counter++;


            }


        }
    }
}


