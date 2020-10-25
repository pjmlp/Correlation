/* KendallCorrelation.cs - Implementation of the Kendall correlation algorithm
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

namespace CorrelationCalculator.Evaluators
{
    /// <summary>
    /// Implements the Kendall correlation calculation.
    /// </summary>
    class KendallCorrelation : ICorrelationEvaluator
    {
        public string Name => "Kendall Correlation";

        public double Evaluate(Matrix dataset)
        {
            double[] rankA = dataset[0].RankExcel();
            double[] rankB = dataset[1].RankExcel();

            Array.Sort(rankA, rankB);

            double C = 0;
            double D = 0;

            // calculate the C values (concordants)
            for (int row = 0; row < rankB.Length; row++)
            {
                double val = rankB[row];
                double concordant = 0;

                for (int innerRow = row + 1; innerRow < rankB.Length; innerRow++)
                {
                    if (rankB[innerRow] > val)
                    {
                        concordant++;
                    }
                }

                C += concordant;
            }

            // calculate the C values (concordants)
            for (int row = 0; row < rankB.Length; row++)
            {
                double val = rankB[row];
                double discordant = 0;

                for (int innerRow = row + 1; innerRow < rankB.Length; innerRow++)
                {
                    if (rankB[innerRow] < val)
                    {
                        discordant++;
                    }
                }

                D += discordant;
            }



            double numerator = C - D;
            double denominator = (dataset.Rows * (dataset.Rows - 1)) / 2;
            double correlation = numerator / denominator;

            return correlation;

        }
    }
}
