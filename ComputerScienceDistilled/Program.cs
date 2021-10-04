using System;
using System.Collections.Generic;
using System.Linq;
using static ComputerScienceDistilled.SortingAlgorithms;

namespace ComputerScienceDistilled
{
    class Program
    {
        #region Main
        static void Main()
        {
            Console.WriteLine("Please enter the function identifier");
            string input = Console.ReadLine();
            try
            {
                int identifier = int.Parse(input);
                Console.WriteLine("Correct input received");
                Console.ReadLine();
                CallFunction(identifier);

            }
            catch (Exception e)
            {
                ExceptionCase(e);
            }
        }

        static void CallFunction(int input)
        {
            string functionName = string.Empty;
            switch (input)
            {
                case 0: // Alphabetical Fish
                    functionName = "Alphabetical Fish";
                    Console.WriteLine("Function Selected: " + functionName);
                    List<string> saltwaterFish = new List<string>() { "Cod", "Herring", "Marlin" };
                    List<string> freshwaterFish = new List<string>() { "Asp", "Carp", "Ide", "Trout" };
                    List<string> combinedList = CombineFishLists_Alphabetical(saltwaterFish, freshwaterFish);
                    PrintList(combinedList);
                    Console.ReadLine();
                    break;
                case 1:
                    functionName = "Binary Search";
                    Console.WriteLine("Function Selected: " + functionName);
                    int[] args = new int[] { 0, 2, 3, 4, 7, 8, 9, 11, 23, 23, 34, 54, 55, 56, 78, 99, 100, 121, 124, 156, 179, 181};
                    Console.WriteLine("List is: [{0}]", string.Join(", ", args));
                    Console.WriteLine("Please type the number you'd like to find the index position of using a binary search.");
                    string answer = Console.ReadLine();
                    try
                    {
                        int target = int.Parse(answer);
                        BinarySearch(args, target);
                    }
                    catch (Exception e)
                    {
                        ExceptionCase(e);
                    }

                    break;
                case 2:
                    int[] sortArgs = new int[] { 2, 5, -4, 11, 0, 18, 22, 67, 51, 6 };
                    SortingAlgorithms.Quick_Sort_Main(sortArgs);
                    break;
                case 3:
                    break;
                default:
                    break;
            }

        }

        #endregion

        #region AlphabeticalFish
        static List<string> CombineFishLists_Alphabetical(List<string> saltwaterFish, List<string> freshwaterFish)
        {
            try
            {
                List<string> combinedList = new List<string>();
                while (!(saltwaterFish.Count() < 1 && freshwaterFish.Count() < 1))
                {
                    if (saltwaterFish.Any() && freshwaterFish.Any())
                    {
                        string fish = ReturnHighestInAlphabet(saltwaterFish[0], freshwaterFish[0]);
                        combinedList.Add(fish);
                        saltwaterFish.Remove(fish);
                        freshwaterFish.Remove(fish);
                    } 
                    else // handle stragglers
                    {
                        if (saltwaterFish.Count > 0)
                        {
                            combinedList.AddRange(saltwaterFish);
                            saltwaterFish.Clear();
                        }
                        else if (freshwaterFish.Count > 0)
                        {
                            combinedList.AddRange(freshwaterFish);
                            freshwaterFish.Clear();
                        }
                    }
                }

                return combinedList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred in CombineFishLists_Alphabetical: " + e.Message);
                Console.ReadLine();
                Console.Clear();
                Main();
                return null;
            }

        }


        static string ReturnHighestInAlphabet(string word1, string word2)
        {
            Byte[] word1_bytes = System.Text.Encoding.ASCII.GetBytes(word1);
            Byte[] word2_bytes = System.Text.Encoding.ASCII.GetBytes(word2);

            int shortestWordLength = Math.Min(word1_bytes.Length, word2_bytes.Length);            

            for (int i = 0; i < shortestWordLength; i ++)
            {                
                if (word1_bytes[i] < word2_bytes[i])
                {
                    return word1;
                }
                else if (word2_bytes[i] < word1_bytes[i])
                {
                    return word2;
                }
            }

            // words are identical, or one is longer than the other (and the letters checked are identical)
            if (word1.Length > word2.Length)
            {
                return word2;
            }
            else 
            {
                return word1;
            }    
        }

        #endregion

        #region BinarySearch

        static void BinarySearch(int[] args, int targetVal)
        {
            int left = 0, right = args.Length, middle = 0;

            while (left <= right)
            {
                middle = (left + right) / 2;
                if (targetVal == args[middle])
                {
                    Console.WriteLine("Target found: " + targetVal + " at index position: " + middle);
                    Console.ReadLine();
                    return;
                }
                else if (targetVal > args[middle])
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }

            }
            Console.WriteLine("Target not found in array");
            Console.ReadLine();
        }

        #endregion

        #region Generic
        static void PrintList(List<string> list)
        {
            Console.WriteLine("Combined List: ");
            foreach (string entry in list)
            {
                Console.WriteLine(entry);
            }           

        }

        static void ExceptionCase(Exception e)
        {
            Console.WriteLine("Incorrect input received. Please try again.");
            Console.WriteLine("Error: " + e.Message);
            Console.ReadLine();
            Console.Clear();
            Main();
        }

        #endregion
    }
}
