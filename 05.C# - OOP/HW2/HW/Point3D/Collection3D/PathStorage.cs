//Task04
//Create a class Path to hold a sequence of points in the 3D space. 
//Create a static class PathStorage with static methods to save and load paths from a text file. 
//Use a file format of your choice.

using System;
using System.IO;

namespace Collection3D
{
	//------
	//Task04
	//------
	public static class PathStorage
	{
		private static int[] ParsePointCoord (string [] inputCoord)
		{
			int[] resultPointCoord = new int[inputCoord.Length];

			for (int i = 0; i < inputCoord.Length; i++)
			{
				int intCoord = 0;
				if (int.TryParse(inputCoord[i], out intCoord))
				{
					resultPointCoord[i] = intCoord;
				}
				else
				{
					throw new ArgumentException("Invalide point coordinate: " + inputCoord[i]);
				}
			}

			return resultPointCoord;
		}


		public static Path LoadPath (string loadFilePath)
		{
			Path resultPath = new Path();

			StreamReader loadFile = new StreamReader(loadFilePath);

			using (loadFile)
			{
				string line = loadFile.ReadLine();

				while (line != null)
				{
					string[] pointCoord = line.Split(new string [] {", "}, StringSplitOptions.RemoveEmptyEntries);
					if (pointCoord.Length != 3)
					{
						throw new ArgumentException("Invalide point coordinates in input file " + loadFilePath);
					}
					else
					{
						int[] parsedPointCoord = ParsePointCoord(pointCoord);
						resultPath.AddPoint(parsedPointCoord[0], parsedPointCoord[1], parsedPointCoord[2]);
					}

                    line = loadFile.ReadLine();
				}
			}

			return resultPath;
		}

		public static void SavePath (string filePath, Path inputPath)
		{
			StreamWriter outputFile = new StreamWriter(filePath);

			using (outputFile)
			{
				Point3D[] outputPath = inputPath.GetPath();

				foreach (Point3D point in outputPath)
				{
					outputFile.WriteLine(point.ToString());
				}
			}
		}
	}
}
