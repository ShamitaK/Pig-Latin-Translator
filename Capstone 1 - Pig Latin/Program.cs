using System;

namespace Capstone_1___Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Lating Translator!");

            do
            {
                Console.WriteLine("Please pick a word, any word, but just one word: ");
                string userWord = Console.ReadLine().ToLower(); //.ToLower - lowercase letters
                string firstLetter = userWord.Substring(0, 1); // .Substring - new string that starts at a specified index

                //.Contains - in this case it checks if the userWord contains any vowels, adds way or move consonants to the end and adds ay.
                if ("aeiou".Contains(firstLetter)) 
                {
                    Console.WriteLine($"{userWord}way");
                }
                else
                {
                    TranslateToPigLatin(userWord);
                }
            }
            while (Continue()); //asks the user if they would like to continue with the translator. 
        }

        //word starts with a vowel, add way. Dont need to make another method because anything else will be considered consonants
        //consonants get moved to the end of the word + ay
        public static void TranslateToPigLatin(string message)
        {
            char[] vowels = "aeiou".ToCharArray(); //ToCharArray - method to extract the characters in a string to a character array
            int index = message.IndexOfAny(vowels); //
            string firstPart = message.Substring(index);
            string secondPart = message.Substring(0, index);
            Console.WriteLine(firstPart + secondPart + "ay");
        }

        //Created a seperate method to ask if the user would like to CONTINUE and choose another word.
        public static bool Continue()
        {
            Console.WriteLine("Would you like to contine, please enter y/n:");
            string userContinue = Console.ReadLine().ToLower();

            if (userContinue == "y" || userContinue == "yes")
            {
                return true; //returns back to the first method
            }
            else if (userContinue == "n" || userContinue == "no")
            {
                Console.WriteLine("Bummer! Hope you have a great day");
                return false; //terminates
            }
            else
            {
                //Recursion, if entry is invalid when asked to Continue, loops back to asking the "would you like to continue y/n
                Console.WriteLine("Uh oh, invalid entry. Please enter only y/n");
                return Continue(); //called in the first method.
            }
        }

    }
}
