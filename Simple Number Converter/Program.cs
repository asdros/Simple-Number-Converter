using System;

namespace SimpleNumberConverter
{
    public class Core
    {

        public static string ConvertTo(int value, int newBase)
        {
            string Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            int remainder = 0;

            if (value == 0)
                return "0";

            while (value > 0)
            {
                result = Chars[value % newBase] + result;
                Console.WriteLine("\t\t" + value + "\t/\t" + newBase + " | " + result[remainder]);
                value /= newBase;
            }
            return result;
        }

        public static int ConvertFrom(string number, int oldBase)
        {
            const int ASCII_LETTER_TO_VALUE = 55;
            const int ASCII_DIGIT_TO_VALUE = 48;
            int power = 0;
            int sum = 0;

            foreach (char digit in number)
            {
                if (!(char.IsUpper(digit) || char.IsDigit(digit)))
                    throw new Exception($"znak {digit} jest po za zakresem!.");

                int digitValue = char.IsDigit(digit) ? digit - ASCII_DIGIT_TO_VALUE : digit - ASCII_LETTER_TO_VALUE;

                if (digitValue > (oldBase - 1))
                    throw new Exception($"Wartość cyfrowa {digitValue} jest większa od cyfry podstawy!");

                sum = sum + ((int)Math.Pow(oldBase, power) * digitValue);

                Console.WriteLine($"\t\t | {oldBase} ^ {power} * {digit} = {Math.Pow(oldBase, power) * digitValue} \t||{sum}");

                power = power + 1;
            }
            Console.WriteLine("\t\n\nWynik pośredni, dziesiętnie: {0}\n\n", sum);

            return sum;
        }
        public static void Input(int firstBase, int secondBase)
        {
            Console.Clear();
            Console.WriteLine("\n\nPodaj liczbę w systemie " + firstBase + "-owym do przeliczenia: ");
            string temp = Console.ReadLine();
            int nvalue = Convert.ToInt32(temp);
            if (firstBase == 10)
            {
                string dwa = ConvertTo(nvalue, secondBase);
                Console.WriteLine("\n\n {0}\n\n", dwa);
            }
            else
            {

                int jeden = ConvertFrom(nvalue.ToString(), firstBase);
                string dwa = ConvertTo(jeden, secondBase);
                Console.WriteLine("\n\n {0}\n\n", dwa);
            }

        }
        public static void Main()
        {
            bool status = false;
            while (!status)
            {
                Console.WriteLine("\nPrzelicznik systemów liczbowych o górnym zakresie "); //add the maximum range
                Console.WriteLine("\n\t1 - Z \"dowolnego\" systemu na \"dowolnie\" inny\n\t2 - Koniec programu.");
                ConsoleKeyInfo button = Console.ReadKey();
                switch (button.Key)
                {                   
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("\nPodaj początkowy system, a następnie finalny");
                        int firstBase = Convert.ToInt32(Console.ReadLine());
                        int secondBase = Convert.ToInt32(Console.ReadLine());
                        Input(firstBase, secondBase);
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