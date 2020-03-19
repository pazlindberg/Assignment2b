using System;
using System.Collections.Generic;
using System.Text;

namespace assignment2
{
    class MainMenu
    {
        public void Run()
        {
            while (this.Show()) ;
        }

        public bool Show()
        {
            bool running;

            Console.WriteLine("\n\n*****HUVUDMENY*****");
            Console.WriteLine("0 - avsluta");
            Console.WriteLine("1 -  Ungdom eller pensionär");
            Console.WriteLine("2 -  Upprepa tio gånger");
            Console.WriteLine("3 -  Det tredje ordet");
            Console.WriteLine("\n\n*******************");
            Console.Write("Val: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("mata in ett värde!");
                running = true;
            }
            else
            {
                running = true;
                switch (input)
                {
                    case "0":
                        Console.WriteLine("hejdåhejdå!");
                        running = false;
                        break;

                    case "1":
                        Option1();
                        break;

                    case "2":
                        Option2();
                        break;

                    case "3":
                        Option3();
                        break;

                    default:
                        Console.WriteLine("fekaktig inmatning!");
                        break;
                }
            }
            return (running);
        }

        private int totalkostnad;
        private int number_of_heads;

        public void Option1()
        {
            totalkostnad = 0;
            number_of_heads = 0;

            do
            {
                Console.Write("ålder: ");
                string input = Console.ReadLine();
                int input_nr;

                if (!int.TryParse(input, out input_nr))
                {
                    Console.WriteLine("mata in siffra!");
                }
                else
                {
                    if (input_nr > 0 && input_nr < 200)
                    {
                        number_of_heads++;
                        if (input_nr < 20)
                        {
                            Console.WriteLine("Ungdomspris 80kr");
                            totalkostnad += 80;
                        }
                        else if (input_nr > 64)
                        {
                            Console.WriteLine("Pensionärspris 90kr");
                            totalkostnad += 90;
                        }
                        else if ((input_nr > 100) || (input_nr < 5))
                        {
                            Console.WriteLine("freebie!");
                        }
                        else
                        {
                            Console.WriteLine("Standardpris 120kr");
                            totalkostnad += 120;
                        }
                    }
                    else
                    {
                        Console.WriteLine("en realistisk ålder, tack!");
                    }
                }

            } while (AskForMore());

            Console.WriteLine("Antal personer: {0}\tTotalkostnad: {1}", number_of_heads, totalkostnad);
        }

        public void Option2()
        {
            Console.Write("Text: ");
            string input = Console.ReadLine();
            for (int i = 0; i < 10; i++) Console.Write("\t" + (i + 1) + "\t" + input);
        }


        public void Option3()
        {
            while (Option3Run()) ;
        }

        public bool Option3Run()
        {
            bool running;
            Console.WriteLine("Skriv text: ");
            string input = Console.ReadLine();

            while (input.Contains("  ")) input = input.Replace("  ", " ");

            string[] splitted_input = input.Split(' ');

            if (splitted_input.Length > 2)
            {
                Console.WriteLine("Tredje ordet: {0}", splitted_input[2]);
                running = false;
            }
            else
            {
                Console.WriteLine("minst 3 ord!");
                running = true;
            }
            return (running);
        }


        private bool AskForMore()
        {
            bool more = false;
            Console.WriteLine("Lägga till fler [j/n]?");
            string c = Console.ReadLine();
            if (c[0] == 'j' || c[0] == 'J') { more = true; }
            else if (c[0] == 'n' || c[0] == 'N') { more = false; }
            return (more);
        }
    }
}

