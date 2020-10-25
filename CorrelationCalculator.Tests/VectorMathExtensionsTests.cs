/* VectorMathExtensionsTests.cs - Unit tests for vector based operations.
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CorrelationCalculator.Tests
{
    [TestClass]
    public class VectorMathExtensionsTests
    {
        [TestMethod]
        public void TestAverage()
        {
            var vector = new Vector { 4, 3, 5, 8, 35 };

            double average = vector.Average();

            Assert.AreEqual(11, average);
        }

        [TestMethod]
        public void TestRank()
        {
            var vector = new Vector { 3, 24, 105, 9, 15 };

            Vector rank = vector.Rank();

            Assert.AreEqual(vector.Size, rank.Size);
            CollectionAssert.AreEqual(new double[] { 1, 4, 5, 2, 3 }, rank.ToList());
        }

        [TestMethod]
        public void TestMultipleRanks()
        {
            var vector = new Vector { 3, 9, 105, 9, 15 };

            Vector rank = vector.Rank();

            Assert.AreEqual(vector.Size, rank.Size);
            CollectionAssert.AreEqual(new double[] { 1, 2.5, 5, 2.5, 4 }, rank.ToList());
        }
    }
}
