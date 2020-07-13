using System;

namespace Capstone_1___Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine(String.Format("{0, 60}", "Welcome to The Pig Latin Translator!"));

                GetUserInput("\nPlease pick a word, any word, but just one word: ");
                string userWord = Console.ReadLine().ToLower(); //Note to self: .ToLower - lowercase letters

                ConfirmationToTranslate(userWord);

            } while (TryAgain());
        }

        static string GetUserInput(string userResponse)
        {
            //created a seperate method to get any input. 
            Console.WriteLine(userResponse);
            return userResponse;
        }

        //word starts with a vowel, add way. Dont need to make another method because anything else will be considered consonants
        //consonants get moved to the end of the word + ay
        public static void TranslateToPigLatin(string message)
        {
            //Try using StringBuilder next time or maybe use Split();

            //Created a seperate method for this because I didn't want all words to be translated like this, I used this in ConfirmationToPigLatin
            //only if the word started with a consonant.
            char[] vowels = "aeiou".ToCharArray(); //ToCharArray - method extracts characters in a string and divides it into individual character array. 
            int index = message.IndexOfAny(vowels); 
            string firstPart = message.Substring(index);
            string secondPart = message.Substring(0, index);
            Console.WriteLine(firstPart + secondPart + "ay");
        }

        //Created this ConfirmationToTranslate method because I only wanted to proceed if the user wanted to translate their word choice, if they mistyped the word they
        //could renter the word instead of going through the whole process and TryAgain.
        public static void ConfirmationToTranslate(string word)
        {
            string firstLetter = word.Substring(0); //.Substring - new string that starts at a specified index
            var vowels = "aeiou";

            GetUserInput($"\nWould you like to translate {word} into Pig Latin? Please enter y/n: ");
            string continueToTranslate = Console.ReadLine();

            if(continueToTranslate == "yes".ToLower() || continueToTranslate == "y".ToLower())
            {
                //.Contains - in this case it checks if the userWord contains any vowels, adds way or move consonants to the end and adds ay.
                if (vowels.Contains(firstLetter))
                {
                    Console.WriteLine($"\n{word}way");
                }
                else
                {
                    TranslateToPigLatin(word);
                }
            } else if(continueToTranslate == "no".ToLower() || continueToTranslate == "n".ToLower())
            {
                TryAgain();
            } else
            {
                Console.WriteLine("Uh oh, invalid entry!");
            }
        }


        //Created this method because I could reuse this TryAgain method multiple times. 
        public static bool TryAgain()
        {
            Console.WriteLine("\nWould you like to translate another word to Pig Latin? Please enter y/n:");
            string userContinue = Console.ReadLine().ToLower();

            if (userContinue == "y".ToLower() || userContinue == "yes".ToLower())
            {
                Console.Clear();
                return true; //returns back to the first method
            }
            else if (userContinue == "n".ToLower() || userContinue == "no".ToLower())
            {
                Console.WriteLine("Bummer! Thanks for playing, hope you have a wonderful day!");
                return false; //terminates
            }
            else
            {
                //Recursion, if entry is invalid when asked to Continue, loops back to asking the "would you like to continue y/n
                Console.WriteLine("Uh oh, invalid entry. Please enter only y/n");
                return TryAgain(); //called in the first method.
            }
        }
    }
}
