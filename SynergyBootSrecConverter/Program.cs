
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace SynergyBootSrecConverter
{

	class Program
	{
		// *******************************************************
		static void Main(string[] args)
		{

			if (args.Length >= 2)
			{
				ConvertFile(args[0], args[1]);

			}
			else
			{
				System.Console.WriteLine("W parametrze musi być nazwa pliku srec");
			}

		}	// Main


		// *******************************************************
		static void ConvertFile(string srec_name, string out_name)
		{
			/*
			string out_name;
			int index = srec_name.LastIndexOf('.');
			if (index >= 0)
			{
				// out_name = srec_name.Remove(index) + ".bch";
				out_name = srec_name.Insert(index, "_out");
			}
			else
				out_name = srec_name + "_out";
			*/

			try
			{
				using (TextReader plik_we = new StreamReader(srec_name))
				using (TextWriter plik_wy = new StreamWriter(out_name))
				{
					while (true)
					{
						string line;

						line = plik_we.ReadLine();
						if (line == null)
							break;
						else if (line != "S31540120050771115FF860202FF020202FF160818FFE9")
							plik_wy.WriteLine(line);
					}

					plik_we.Close();
					plik_wy.Close();

					System.Console.WriteLine("Konwersja zakonczona sukcesem");
					System.Console.WriteLine("Stworzono plik: " + out_name);
				}
			}
			catch
			{
				System.Console.WriteLine("Plik srec nie istnieje");			// To moze zlapac tez inne wyjatki, ale nie wiem jak to zrobic
			}

		}	// ConvertFile

	}
}
