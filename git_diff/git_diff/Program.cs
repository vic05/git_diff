using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace git_diff
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gitRepositories = new string[] { "GitRepositories_1a.txt", "GitRepositories_2a.txt", "GitRepositories_3a.txt", "GitRepositories_1b.txt", "GitRepositories_2b.txt", "GitRepositories_3b.txt" };
            Console.WriteLine("Please choose which files to compare.\n1) 1a & 1b\n2) 2a & 2b\n3) 3a & 3b\n");

            int choice = 0;
            bool validChoice = false;
            while (validChoice == false)
            {
                choice = Int32.Parse(Console.ReadLine());
                if (choice == 1 || choice == 2 || choice == 3)
                {
                    validChoice = true;
                }
                else
                {
                    Console.WriteLine("Invalid entry. Try again.");
                }
            }

            string path1 = Path.Combine(Directory.GetCurrentDirectory(), gitRepositories[choice - 1]);
            string path2 = Path.Combine(Directory.GetCurrentDirectory(), gitRepositories[choice + 2]);
            List<string> contents1 = File.ReadAllLines(path1).ToList();
            List<string> contents2 = File.ReadAllLines(path2).ToList();

            bool different = false;
            for (int i = 0; i < contents1.Count(); i++)
            {
                if (contents1[i] != contents2[i])
                {
                    Console.WriteLine("\na.txt and b.txt are different");
                    different = true;
                    break;
                }
            }
            if (different != true)
            {
                Console.WriteLine("\na.txt and b.txt are not different");
            }
        }
    }
}