using System;

namespace MasterMind
{
    class Program
    {
        static void Main(string[] args)
        {
            int randNum;
            string comRandNumber = "";
            Random r = new Random();

            comRandNumber = r.Next(1, 6).ToString();
            comRandNumber = comRandNumber + r.Next(1, 6).ToString();
            comRandNumber = comRandNumber + r.Next(1, 6).ToString();
            comRandNumber = comRandNumber + r.Next(1, 6).ToString();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Simple MasterMind");
            Console.WriteLine("----------------------------------------");
            int userNum=0;
            string userNumstr = "";
            ReadInput();

            void ReadInput()
            {
                Console.WriteLine("Enter 4 digits between 1 and 4");
                userNumstr=Console.ReadLine();

                try
                {
                    if(userNumstr.Length>4)
                    {
                        Console.WriteLine("Input number should be 4 digit number");
                        Console.ReadLine();
                        return;
                    }
                    userNum = int.Parse(userNumstr);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Input is not a valid number");
                    Console.ReadLine();
                    return;
                }

                foreach (var ch in userNumstr.ToCharArray())
                {
                    if (Convert.ToInt32(ch.ToString()) > 6 || Convert.ToInt32(ch.ToString()) < 1)
                    {
                        Console.WriteLine("All the digits should be between 1 to 6");
                        Console.ReadLine();
                        return;

                    }
                }
            }

            //10 tries

            for (int i = 0; i <= 10; i++)
            {
                string output = PositionMatch(comRandNumber, userNumstr);
                if(i==10)
                {
                    Console.WriteLine("Sorry you have exceeded max no. of attempts.");
                    Console.ReadLine();

                    return;
                }    

                if(output=="++++")
                {
                    Console.WriteLine("Winner!!!");
                    Console.ReadLine();
                    break;
                    
                }
                else
                {
                    Console.WriteLine(output);
                    Console.WriteLine("Not matching.Please give another try.");
                    ReadInput();
                }
            }



             string PositionMatch(string compNum, string userNum)
            {
                var result = "";
                int c = 0;
                foreach (var ch in compNum.ToCharArray())
                {
                    if (ch == userNum[c])
                        result = result + "+";
                    else
                        result = result + "-";

                    c++;
                }
                return result;
            }
        }
    }
}
