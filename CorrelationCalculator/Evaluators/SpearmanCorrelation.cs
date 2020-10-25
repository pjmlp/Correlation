/* SpearmanCorrelation.cs - Implementation of the Spearman correlation algorithm
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

namespace CorrelationCalculator.Evaluators
{
    /// <summary>
    /// Implements the Spearman correlation calculation, also known as Pearson
    /// correlation coefficient.
    /// Makes use of direct calculation instead of the Pearson approximation over the ranks.
    /// </summary>
    class SpearmanCorrelation : ICorrelationEvaluator
    {
        public string Name => "Spearman Correlation";

        public double Evaluate(Matrix dataset)
        {
            Vector rankA = dataset[0].Rank();
            Vector rankB = dataset[1].Rank();

            double d, dSquared = 0;

            for (int row = 0; row < dataset.Rows; row++)
            {
                d = rankA[row] - rankB[row];
                dSquared += (d * d);
            }

            double numerator = 6 * dSquared;
            double denominator = dataset.Rows * ((dataset.Rows * dataset.Rows) - 1);
            double correlation = 1 - (numerator / denominator);

            return correlation;
        }
    }
}
