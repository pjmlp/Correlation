/* SpearmanCorrelationTests.cs - Unit tests for the Spearman correlation calculations.
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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorrelationCalculator.Tests
{
    [TestClass]
    public class SpearmanCorrelationTests
    {
        [TestMethod]
        public void TestName()
        {
            var evaluator = new SpearmanCorrelation();
            Assert.AreEqual("Spearman Correlation", evaluator.Name);
        }

        [TestMethod]
        public void TestHeightAgeCorrelation()
        {
            const double epsilon = 0.0000000005;
            var fileLoader = new FileLoader();
            Matrix values = fileLoader.LoadFile(@"Data\Data.csv", new string[] { "Height", "Age" });

            var evaluator = new SpearmanCorrelation();
            double correlation = evaluator.Evaluate(values);
            Assert.IsTrue(correlation - 0.103759398496241 < epsilon);
        }
    }
}
