/* Program.cs - Application entry point
* Copyright (C) 2018 Paulo Pinto
*
* This library is free software; you can redistribute it and/or
* modify it under the terms of the GNU Lesser General Public
* License as published by the Free Software Foundation; either
* version 2 of the License, or (at your option) any later version.
*
* This library is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
* Lesser General Public License for more details.
*
* You should have received a copy of the GNU Lesser General Public
* License along with this library; if not, write to the
* Free Software Foundation, Inc., 59 Temple Place - Suite 330,
* Boston, MA 02111-1307, USA.
*/
using CorrelationCalculator.Evaluators;
using System;
using System.Collections.Generic;
using System.IO;

namespace CorrelationCalculator
{
    /// <summary>
    /// Class containing the main entry point into the program.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry point into the program.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                // (1) Prompt user for file / options.
                string filename = GetFilename();
                if (filename != null)
                {
                    string[] columnNames = new string[2];

                    columnNames[0] = GetColumnName("first");
                    columnNames[1] = GetColumnName("second");

                    // (2) Read file from disk.
                    FileLoader loader = new FileLoader();
                    Matrix data = loader.LoadFile(filename, columnNames);

                    // (3) Calculate.
                    var evaluators = new List<ICorrelationEvaluator> { new LinearCorrelation(), new SpearmanCorrelation(), new KendallCorrelation() };

                    foreach (var evaluator in evaluators)
                    {
                        double correlation = evaluator.Evaluate(data);
                        Console.WriteLine($"The {evaluator.Name} value is {correlation}");
                    }
                }
            }
            catch(ApplicationException ex)
            {
                Console.WriteLine("Could not generate the desired set of correlations, due to an application error.");
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// Asks the user for the filename
        /// </summary>
        /// <returns>The actual filename, or null if the user has decided to exit</returns>
        static string GetFilename()
        {
            bool exits = false;
            string filename = null;

            do
            {
                Console.Write("Please provide the measurement's filename: ");
                filename = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(filename))
                {
                    exits = File.Exists(filename);
                    if (!exits)
                    {
                        Console.WriteLine($"The file {filename} does not exist!");
                    }
                }

            } while (!exits && !String.IsNullOrWhiteSpace(filename));

            return filename;

        }

        /// <summary>
        /// Asks the user for a specific column
        /// </summary>
        /// <returns>The name of the column</returns>
        static string GetColumnName(string name)
        {
            Console.Write($"Please provide the {name} column name: ");
            return Console.ReadLine();
        }
    }
}
