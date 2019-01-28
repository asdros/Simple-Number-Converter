using System;

namespace SimpleNumberConverter
{
    public class Core
    {

        public static string ConvertTo(int value, byte newBase) // this function returns a number coverted from the decimal number system
        {
            string Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            int remainder = 0;

            if (value == 0)
                return "0";

            while (value > 0)
            {
                result = Chars[value % newBase] + result;
                
                Console.WriteLine($"\t\t {value} \t/\t {newBase} | {result[remainder]}");
                value /= newBase;
            }
            return result;
        }

        public static int ConvertFrom(string number, int oldBase) //this function returns a number converted into the decimal number system
        {
            const byte ASCII_LETTER_TO_VALUE = 55;
            const byte ASCII_DIGIT_TO_VALUE = 48;
            int power = 0;
            int sum = 0;


            for (int i = number.Length - 1; i >= 0; i--)           // read the number from the back
            {
                char digit = number[i];                         // keep the one digit of number
                
                if (!(char.IsUpper(digit) || char.IsDigit(digit)))
                    throw new Exception($"The char {digit} is out of range!.");

                int digitValue = char.IsDigit(digit) ? digit - ASCII_DIGIT_TO_VALUE : digit - ASCII_LETTER_TO_VALUE;

                if (digitValue > (oldBase - 1))
                    throw new Exception($"The digital value {digitValue} is greatest than the base number!");

                sum = sum + ((int)Math.Pow(oldBase, power) * digitValue);

                Console.WriteLine($"\t\t | {oldBase} ^ {power} * {digit} = {Math.Pow(oldBase, power) * digitValue} \t||{sum}");

                power = power + 1;
            }

            return sum;
        }
        public static void Input(byte firstBase, byte secondBase, string numberToConvert)
        {
            int toDecimal;
            string fromDecimal;
            Console.Clear();          
            
            if (firstBase == 10)                                                                
            {
                int temp = Convert.ToInt32(numberToConvert);
                fromDecimal = ConvertTo(temp, secondBase);
            }
            else
            {
                toDecimal = ConvertFrom(numberToConvert, firstBase);
                Console.WriteLine("\n\n");
                fromDecimal= ConvertTo(toDecimal, secondBase);
            }
            Console.WriteLine($"\n\n{numberToConvert}({firstBase}) = {fromDecimal}({secondBase})\n\n");
        }
        public static void Main()
        {
            bool status = false;
            while (!status)
            {
                Console.WriteLine("\nThe converter of numerical systems "); 
                Console.WriteLine("\n\t1 - Convert a number\n\t2 - End of program.");
                ConsoleKeyInfo button = Console.ReadKey();                                 // read the button to select the switch case        
                switch (button.Key)
                {                   
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("\nEnter the number of the initial number system. ");
                        byte firstBase = Convert.ToByte(Console.ReadLine());

                        Console.WriteLine("\n\nEnter the number in the system " + firstBase + " to be converted. ");
                        string numberToConvert = Console.ReadLine();

                        Console.WriteLine("\nEnter the number of the final number system. ");
                        byte secondBase = Convert.ToByte(Console.ReadLine());

                        Input(firstBase, secondBase,numberToConvert);
                        break;
                    case ConsoleKey.D2:
                        status = true;
                        break;
                    default:
                        Console.WriteLine("\nIncorrect choice.");
                        break;
                }
            }
            Console.WriteLine();
        }
    }

}