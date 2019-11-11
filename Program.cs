using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionconsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            Program program = new Program();
            Boolean encrypt = false;
            Boolean decrypt = false;
            String E = "Encrypt";
            String D = "Decrypt";
            int pKey = 0;


            //int mod = Mod(66, 26);
            //Console.WriteLine(mod);


            //Reads the user input to either Encrypt or Decrypt
            Console.WriteLine("Enter 'E' to Enrcypt or Enter 'D' to Decrypt.");
            string userInputEorD = Console.ReadLine(); 

            //Validates the the upper case and the lower case inputs
            if (userInputEorD == "E")
            {
                encrypt = true;
                userInputEorD = E;
                pKey = program.GetPrimeKey(1000000, 9000000, 10);
                Console.WriteLine("Initialization Vector: "+ pKey);
                Encrypt(pKey);
            }
            else if (userInputEorD == "e")
            {
                encrypt = true;
                userInputEorD = E;
                pKey = program.GetPrimeKey(1000000, 9000000, 10);
                Console.WriteLine("Initialization Vector: " + pKey);
                Encrypt(pKey);
            }
            else if (userInputEorD == "D"){
                decrypt = true;
                userInputEorD = D;
            }
            else if (userInputEorD == "d")
            {
                decrypt = true;
                userInputEorD = D;
            }
            Console.ReadLine();
        }
        private static string Encrypt(int pKey)
        {
            String userPass;
            String message;

            //Asks the user to input a password
            Console.WriteLine("\nYou've chossen to Encrypt");
            Console.WriteLine("\nInput a Passphare or a key, and press Enter!");

            //User password is stored in [userPass]
            userPass = Console.ReadLine();
            int pLength = userPass.Length;
            pKey = pLength * pKey;
            Console.WriteLine("Final key: " + pKey);

            //Asks the user to input a message of plain text to Encrypt
            Console.WriteLine("\nEnter the text that you want to Encrypt");
            //User message is stored in [message]
            message = Console.ReadLine();  
            return message;
            
        }
        Random Rand = new Random();

        private bool IsProbablyPrime(int p, int num_tests)
        {
            checked
            {
                // Perform the tests.
                for (int i = 0; i < num_tests; i++)
                {
                    // Pick a number n in the range (1, p).
                    long n = Rand.Next(2, p);

                    // Calculate n ^ (p - 1).
                    long result = n;
                    for (int power = 1; power < p - 1; power++)
                    {
                        result = (result * n) % p;
                    }

                    // If the final result is not 1, p is not prime.
                    if (result != 1) return false;
                }
            }

            // If we survived all the tests, p is probably prime.
            return true;
        }
        private int GetPrimeKey(int min, int max, int num_tests)
        {

            // Try random numbers until we find a prime.
            for (; ; )
            {
                // Pick a random odd p.
                int p = Rand.Next(min, max + 1);
                if (p % 2 == 0) continue;

                // See if it's prime.
                if (IsProbablyPrime(p, num_tests)) return p;
            }
        }
        private static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }
    }
}
