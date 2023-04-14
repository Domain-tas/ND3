using ND3;

internal class Program
{
	private static void Main(string[] args)
	{
		Console.WriteLine("\t***** UŽDAVINIO SĄLYGOS *****\n");
		Console.Write("\tKanalų skaičius: ");
		var channels = Int32.Parse(Console.ReadLine());
		Console.Write("\tParaiškų skaičius: ");
		var lambda = Double.Parse(Console.ReadLine());
		Console.Write("\tParaiškos aptarnavimo trukmė: ");
		var mu = Double.Parse(Console.ReadLine());
		Console.Write("\tEilės ilgis: ");
		var queueLenght = Int32.Parse(Console.ReadLine());
		Console.Write("\tProcentalus aptaranvimo reikalavimas: ");
		var percentage = Double.Parse(Console.ReadLine())/100;
		Console.WriteLine("\n\n\t***** UŽDAVINIO SPRENDIMAS *****\n");
		var achievedPercentage = 0d;
		while(achievedPercentage < percentage)
		{
			Console.WriteLine($"\n\t***Iteracija su {channels} kanalais***\n");
			achievedPercentage = Mathing.Calculate(lambda, mu, channels, queueLenght);
			Console.WriteLine($"\n\tPasiektas aptarnavimo efektyvumas {(achievedPercentage * 100).ToString("F")}");
			channels += 1;
		}


	}

}