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
                    throw new Exception($"znak {digit} jest po za zakresem!.");

                int digitValue = char.IsDigit(digit) ? digit - ASCII_DIGIT_TO_VALUE : digit - ASCII_LETTER_TO_VALUE;

                if (digitValue > (oldBase - 1))
                    throw new Exception($"Wartość cyfrowa {digitValue} jest większa od cyfry podstawy!");

                sum = sum + ((int)Math.Pow(oldBase, power) * digitValue);

                Console.WriteLine($"\t\t | {oldBase} ^ {power} * {digit} = {Math.Pow(oldBase, power) * digitValue} \t||{sum}");

                power = power + 1;
            }
            Console.WriteLine($"\t\n\nWynik pośredni, dziesiętnie: {sum}\n\n");

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
                Console.WriteLine($"\n\n {fromDecimal}\n\n");
            }
            else
            {
                toDecimal = ConvertFrom(numberToConvert, firstBase);
                fromDecimal= ConvertTo(toDecimal, secondBase);
                Console.WriteLine($"\n\n {fromDecimal}\n\n");
            }

        }
        public static void Main()
        {
            bool status = false;
            while (!status)
            {
                Console.WriteLine("\nPrzelicznik systemów liczbowych o górnym zakresie "); //add the maximum range
                Console.WriteLine("\n\t1 -  Przelicz liczbę\n\t2 - Koniec programu.");
                ConsoleKeyInfo button = Console.ReadKey();                                 // read the button to select the switch case        
                switch (button.Key)
                {                   
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("\nPodaj liczbę początkowego systemu liczbowego. ");
                        byte firstBase = Convert.ToByte(Console.ReadLine());

                        Console.WriteLine("\n\nPodaj liczbę w systemie " + firstBase + "-owym do przeliczenia. ");
                        string numberToConvert = Console.ReadLine();

                        Console.WriteLine("\nPodaj liczbę finalnego systemu liczbowego. ");
                        byte secondBase = Convert.ToByte(Console.ReadLine());

                        Input(firstBase, secondBase,numberToConvert);
                        break;
                    case ConsoleKey.D2:
                        status = true;
                        break;
                    default:
                        Console.WriteLine("\nNieprawidłowy wybór");
                        break;
                }
            }
        }
    }

}