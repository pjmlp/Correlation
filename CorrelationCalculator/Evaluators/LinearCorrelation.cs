/* LinearCorrelation.cs - Implementation of the linear correlation algorithm
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
    /// Implements the Linear correlation calculation, also known as Pearson
    /// correlation coefficient.
    /// </summary>
    class LinearCorrelation : ICorrelationEvaluator
    {
        public string Name => "Linear Correlation";

        public double Evaluate(Matrix dataset)
        {
            double meanA = dataset[0].Average();
            double meanB = dataset[1].Average();
            double a, b, ab = 0, aSquared = 0, bSquared = 0;

            for (int row = 0; row < dataset.Rows; row++)
            {
                a = dataset[0, row] - meanA;
                b = dataset[1, row] - meanB;

                ab += (a * b);
                aSquared += (a * a);
                bSquared += (b * b);
            }

            double correlation = ab / Math.Sqrt(aSquared * bSquared);

            return correlation;
        }
    }
}
