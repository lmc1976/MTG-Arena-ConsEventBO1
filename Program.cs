using System;

public class Program
{
	static void Main()
	{
        short gold = 0;
        byte victories = 0, defeats = 0, uncommons = 0, rares = 0;
        int totalGold = 0;
        ushort totalUncommons = 0, totalRares = 0, qTornaments;
        float pWin;

        do
        {
            Console.WriteLine("Type deck winning rate (0-100)");
            pWin = float.Parse(Console.ReadLine());
            Console.WriteLine("Type how many tournament events you want to test (20,000 Max)");
            qTornaments = ushort.Parse(Console.ReadLine());
        } while (pWin < 0 | pWin > 100 | qTornaments > 20000);

        /*
        With 20k tornament amout the maximum will be:
        Type:       VariableName:   V. Type     Max Value:            Max Value on Program
        Uncommons   totalUncommons  ushort      65,535                60.000
        Raras       totalRaras      ushort      65,535                40.000
        Gold        totalGold       int         +-2.147.483.647       +10.000.000/-8.000.000
        */

        Random nRand = new Random();

        for (int y = 0; y < qTornaments; y++)
        {

            while ((victories < 7) & (defeats < 3))
            {
                float roll = nRand.Next(0, 10001);
                roll /= 100;
                Console.WriteLine("The roll value from 0 to 100 is: {0,5} the deck winning rate is: {1} this was a " + (roll < pWin ? "VICTORY" : "DEFEAT"), roll, pWin);
                if (pWin > roll)
                {
                    victories++;
                }
                else
                {
                    defeats++;
                }
            }

            Console.WriteLine("Victories Amount: {0}\nDefeats Amount: {1}", victories, defeats);
            switch (victories)
            {
                case 0:
                    gold -= 400;
                    uncommons += 3;
                    break;
                case 1:
                    gold -= 300;
                    uncommons += 3;
                    break;
                case 2:
                    gold -= 200;
                    uncommons += 3;
                    break;
                case 3:
                    gold -= 100;
                    uncommons += 3;
                    break;
                case 4:
                    uncommons += 3;
                    break;
                case 5:
                    gold += 100;
                    uncommons += 2;
                    rares++;
                    break;
                case 6:
                    gold += 300;
                    uncommons++;
                    rares += 2;
                    break;
                case 7:
                    gold += 500;
                    uncommons++;
                    rares += 2;
                    break;
            }

            Console.WriteLine("Gold Amount: {0} Unconmuns Amount: {1} Rares Amount: {2}", gold, uncommons, rares);
            totalGold += gold;
            totalUncommons += uncommons;
            totalRares += rares;
            rares = uncommons = victories = defeats = Convert.ToByte(gold = 0);

        }

        Console.WriteLine("\n\n****************  TOTAL  ***************");
        Console.WriteLine("*  Gold Spent on Fees...:{0,12:n0}  *", qTornaments * 500);
        Console.WriteLine("*  Gold Earned..........:{0,12:n0}  *", totalGold);
        Console.WriteLine("*  Uncommons Amount.....:{0,12:n0}  *", totalUncommons);
        Console.WriteLine("*  Rares Amount.........:{0,12:n0}  *", totalRares);
        Console.WriteLine("****************************************");
    }
}

