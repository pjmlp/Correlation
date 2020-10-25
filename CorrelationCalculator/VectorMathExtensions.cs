/* VectorExtensions.cs - Utility extension methods for Vector.
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
using System.Collections.Generic;

namespace CorrelationCalculator
{
    /// <summary>
    /// Set of math extensions, instead of having the Vector
    /// class full of methods for the different operations.
    /// </summary>
    public static class VectorMathExtensions
    {
        /// <summary>
        /// Calculates the average value for a given vector.
        /// </summary>
        public static double Average(this Vector vector)
        {
            if (vector.Size == 0)
            {
                return 0;
            }
            else
            {
                double sum = 0;
                for (int index = 0; index < vector.Size; index++)
                {
                    sum += vector[index];
                }

                return sum / vector.Size;
            }
        }

        /// <summary>
        /// Calculates the average value for a set of values, taking into consideration their
        /// relative positions inside of the rank.
        /// </summary>
        /// <param name="vector"></param>
        /// <param name="indexes"></param>
        /// <returns></returns>
        public static double AverageRank(this Vector vector, List<int> indexes)
        {
            if (vector.Size == 0)
            {
                return 0;
            }
            else
            {
                double sum = 0;
                for (int index = 0; index < indexes.Count; index++)
                {
                    sum += vector[indexes[index]] + index;
                }

                return sum / indexes.Count;
            }
        }

        /// <summary>
        /// Generates the rank of a vector, taking into consideration multiple occurrences
        /// of the same value.
        /// </summary>
        /// <param name="vector">Vector to rank</param>
        /// <returns>A set of rank values, of the same size of the input vector</returns>
        public static Vector Rank(this Vector vector)
        {
            var rankVec = new Vector(vector.Size);
            var rankColisions = new Dictionary<double, List<int>>();

            for (int i = 0; i < vector.Size; i++)
            {
                double val = vector[i];
                int counter = 0;
                for (int j = 0; j < vector.Size; j++)
                {
                    if (val < vector[j])
                    {
                        counter++;
                    } else if (i != j && val == vector[j])
                    {
                        counter++;
                        List<int> colisions;

                        if (!rankColisions.TryGetValue(val, out colisions))
                        {
                            colisions = new List<int>();
                            rankColisions.Add(val, colisions);
                        }
                        colisions.Add(i);
                    }

                }
                rankVec.Add(vector.Size - counter);
            }

            // now handle the rank colisions
            foreach (var colision in rankColisions)
            {
                double avgRank = rankVec.AverageRank(colision.Value);
                for (int index = 0; index < colision.Value.Count; index++)
                {
                    rankVec[colision.Value[index]] = avgRank;
                }
            }

            return rankVec;
        }

        /// <summary>
        /// Ranks the vector data following the same algorithm as Excel's RANK function.
        /// </summary>
        /// <param name="vector"></param>
        /// <returns>The ranked values</returns>
        public static double[] RankExcel(this Vector vector)
        {
            // we need to get vector data as a real array for Array.Sort.
            var copy = new double[vector.Size];
            for (int i = 0; i < vector.Size; i++)
            {
                copy[i] = vector[i];
            }


            // the indexes required to navigate on an ordered array
            var index = new int[vector.Size];
            for (int i = 0; i < index.Length; i++)
            {
                index[i] = i;
            }

            Array.Sort(copy, index);


            // now map the ranks, as Excel, keeping the rank for equal values.
            int rank = 1;
            int skipRank = 0;
            var rankVec = new double[vector.Size];
            for (int i = 0; i < rankVec.Length; i++)
            {
                if (i > 0)
                {
                    if(copy[i - 1] != copy[i])
                    {
                        if (skipRank > 0)
                        {
                            rank = rank + skipRank + 1;
                            skipRank = 0;
                        }
                        else
                        {
                            rank++;
                        }
                    }
                    else
                    {
                        skipRank++;
                    }
                }
                    

                rankVec[index[i]] = rank;
            }

            return rankVec;
        }
    }
}
