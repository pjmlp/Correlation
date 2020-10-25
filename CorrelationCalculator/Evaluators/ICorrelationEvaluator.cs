/* CorrelationEvaluator.cs - Generic interface for data analysis
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
    /// Represents the required set of operations for the
    /// evaluation of any kind of correlation.
    /// </summary>
    interface ICorrelationEvaluator
    {
        /// <summary>
        /// Provides a descriptive name for the correlation being calculated.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Given the specific dataset, calculate a correlation datapoint
        /// </summary>
        double Evaluate(Matrix dataset);
    }
}
