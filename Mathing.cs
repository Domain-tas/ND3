using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ND3
{
	public static class Mathing
	{
		public static double Calculate(double lambda, double mu, int channels, int queueLenght)
		{
			var alpha = Alpha(lambda, mu);
			Console.WriteLine($"\tAlfa: {alpha}");
			var gamma = Gamma(alpha, channels);
			Console.WriteLine($"\tGama: {gamma}");
			var freedom = LaisvesTikimybe(gamma, alpha, channels, queueLenght);
			Console.WriteLine($"\tP0-1 galimybė: {freedom}");
			Console.WriteLine($"\tTikimybė, jog visi kanalai laisvi: {1 / freedom}");
			var atmetimoTikimybe = freedom.AtmetimoTikimybe(alpha, channels, queueLenght);
			Console.WriteLine($"\tAtmetimo tikimybė: {atmetimoTikimybe}");
			Console.WriteLine($"\tVidutiniškai nebus aptarnautas kas: {1 / atmetimoTikimybe} klientas");
			return 1 - atmetimoTikimybe;




		}
		public static void Test(int test)
		{
			var fak = test.Faktorialas();
			Console.WriteLine($"{test} faktorialas: {fak}");
		}
		private static double ProcessingIntensity(double duration)
		{
			return 1 / duration;
		}

		private static double Alpha(double lambda, double mu)
		{
			return lambda / mu;
		}

		private static double Gamma(double alpha, int channels)
		{
			return alpha / channels;
		}

		private static double AtmetimoTikimybe(this double freedom, double alpha, int channels, int queueLenght)
		{
			if(queueLenght==0)
				return AtmetimoTikimybe(freedom, alpha, channels);

			var first = Math.Pow(alpha, channels + queueLenght);
			var second = Math.Pow(channels, queueLenght) * channels.Faktorialas();
			var third = (1 / freedom);
			var result = first / second * third;
			return result;
		}
		private static double AtmetimoTikimybe(this double freedom, double alpha, int channels)
		{
			var first = Math.Pow(alpha, channels);
			var second = channels.Faktorialas();
			var third = (1 / freedom);
			var result = first / second * third;
			return result;
		}

		private static double LaisvesTikimybe(double gamma, double alpha, int channels, int queueLenght)
		{
			if (queueLenght == 0)
				return LaisvesTikimybe(gamma, alpha, channels);

			var firstSum = 0d;
			if (gamma == 1)
			{
				for (int i = 1; i <= channels; i++)
				{
					firstSum += Math.Pow(alpha, i - 1) / Faktorialas(i - 1);
				}
				return firstSum + queueLenght * Math.Pow(alpha, channels) / channels.Faktorialas();
			}

			for (int i = 1; i <= channels; i++)
			{
				firstSum += Math.Pow(alpha, i - 1) / Faktorialas(i - 1);
			}
			var secondSum = 0d;
			for (int i = 1; i <= channels + queueLenght; i++)
			{
				secondSum += Math.Pow(alpha, i + 1) / Math.Pow(channels, i + 1 - channels);
			}
			return firstSum + 1 / channels.Faktorialas() * secondSum;
		}
		private static double LaisvesTikimybe(double gamma, double alpha, int channels)
		{
			var result = 0d;
			for (int i = 1; i <= channels; i++)
			{
				result += Math.Pow(alpha, i) / Faktorialas(i);
			}
			return result;
		}

		private static double SantykineGeba(double atmetimo)
		{
			return 1 - atmetimo;
		}

		private static double AbsoliutiGeba(double lambda, double santykineGeba)
		{
			return lambda * santykineGeba;
		}

		private static double Faktorialas(this int input)
		{
			var result = 1d;
			for (int i = input; i > 0; i--)
			{
				result *= i;
			}
			return result;
		}
	}
}
