/* FileLoader.cs - Support code for file loading operations
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
using System;
using System.Globalization;
using System.IO;

namespace CorrelationCalculator
{
    /// <summary>
    /// Handles the file loading operations required to parse the measurements file.
    /// </summary>
    class FileLoader
    {
        /// <summary>
        /// Parses a measurement file stored in the CSV format.
        /// </summary>
        /// <param name="filename">The complete pathname to the file.</param>
        /// <param name="columns">Names of the columns whose data actually matters</param>
        /// <returns>An MxN matrix with the set of desired data</returns>
        /// <exception cref="CorruptFileException">If the file is not valid</exception>
        /// <exception cref="ArgumentException">If columns vector is not valid</exception>
        public Matrix LoadFile(string filename, string[] columns)
        {
            if (columns == null || columns.Length == 0)
            {
                throw new ArgumentException("Invalid column information", nameof(columns));
            }
            Matrix result = new Matrix(columns.Length);
            using (TextReader reader = new StreamReader(filename))
            {
                string[] headers = reader.ReadLine().Split(',');

                if (headers.Length < columns.Length)
                {
                    throw new CorruptFileException($"Expected {columns.Length} headers, found {headers.Length}");
                }

                // Try to retrieve the headers from the file
                int maxIndex;
                int[] indexes =  RetrieveHeaders(headers, columns, out maxIndex);
                

                double[] rowValues = new double[columns.Length];
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    if (data.Length < maxIndex)
                    {
                        throw new CorruptFileException($"Wrong number of columns, {line}");
                    }

                    for (int i = 0; i < columns.Length; i++)
                    {
                        if (!Double.TryParse(data[indexes[i]], NumberStyles.Any, CultureInfo.InvariantCulture, out rowValues[i]))
                        {
                            throw new CorruptFileException($"Could not parse value {data[indexes[i]]}");
                        }
                    }

                    result.Add(rowValues);
                }

            }

            return result;
        }

        /// <summary>
        /// Creates the mappings between the columns requested by the user and their actual
        /// position on the measurements file.
        /// </summary>
        /// <param name="headers">Set of headers read from the measurement file</param>
        /// <param name="columns">Set of columns desired by the application's user<</param>
        /// <param name="maxIndex">The index related to the column located on the rightest place</param>
        /// <returns>A mapping index of the column into the actual position on the filename</returns>
        /// <exception cref="CorruptFileException">If not all the columns were found as part of the arrays</exception>
        int[] RetrieveHeaders(string[] headers, string[] columns, out int maxIndex)
        {
            int foundHeaders = 0;
            maxIndex = 0;
            int[] indexes = new int[columns.Length];
            for (int i = 0; i < headers.Length; i++)
            {
                for (int j = 0; j < columns.Length; j++)
                {
                    if (headers[i] == columns[j])
                    {
                        indexes[j] = i;
                        maxIndex = Math.Max(maxIndex, i);
                        foundHeaders++;
                    }
                }
            }

            if (foundHeaders < columns.Length)
            {
                throw new CorruptFileException($"Expected {columns.Length} headers, only found {foundHeaders}");
            }

            return indexes;
        }
    }
}
