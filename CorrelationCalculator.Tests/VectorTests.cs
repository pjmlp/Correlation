/* VectorTests.cs - Unit tests for vector based operations.
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

namespace CorrelationCalculator.Tests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void TestEmtpyInitialization()
        {
            var vector = new Vector();
            Assert.AreEqual(0, vector.Size);
        }

        [TestMethod]
        public void TestInitializationWithSize()
        {
            const int size = 10;

            var vector = new Vector(size);
            //Assert.AreEqual(size, vector.Size);
        }

        [TestMethod]
        public void TestAddingElementsSimple()
        {
            var vector = new Vector();
            vector.Add(2.5);
            vector.Add(3.8);

            Assert.AreEqual(2, vector.Size);
            Assert.AreEqual(2.5, vector[0]);
            Assert.AreEqual(3.8, vector[1]);
        }

        [TestMethod]
        public void TestAddingElementsInitialization()
        {
            var vector = new Vector { 2.5, 3.8 };

            Assert.AreEqual(2, vector.Size);
            Assert.AreEqual(2.5, vector[0]);
            Assert.AreEqual(3.8, vector[1]);
        }

        [TestMethod]
        public void TestAddingVectors()
        {
            const int size = 3;

            var firstVector = new Vector { 4, 3, 5 };
            var secondVector = new Vector { 9, 6, 10 };

            Vector result = firstVector + secondVector;

            Assert.AreEqual(size, firstVector.Size);
            Assert.AreEqual(size, secondVector.Size);
            Assert.AreEqual(size, result.Size);

            Assert.AreEqual(13, result[0]);
            Assert.AreEqual(9, result[1]);
            Assert.AreEqual(15, result[2]);
        }

        [TestMethod]
        public void TestSubtractingVectors()
        {
            const int size = 3;

            var firstVector = new Vector { 4, 3, 20 };
            var secondVector = new Vector { 9, 6, 10 };

            Vector result = firstVector - secondVector;

            Assert.AreEqual(size, firstVector.Size);
            Assert.AreEqual(size, secondVector.Size);
            Assert.AreEqual(size, result.Size);

            Assert.AreEqual(-5, result[0]);
            Assert.AreEqual(-3, result[1]);
            Assert.AreEqual(10, result[2]);
        }

        [TestMethod]
        public void TestMultiplyConstant()
        {
            const int size = 5;

            var vector = new Vector { 4, 3, 5, 8, 35 };

            Vector result = vector * 3;

            Assert.AreEqual(size, result.Size);

            var elems = new double[] { 12, 9, 15, 24, 105 };
            for (int index = 0; index < elems.Length; index++)
            {
                Assert.AreEqual(elems[index], result[index]);
            }
        }

        [TestMethod]
        public void TestDivideConstant()
        {
            const int size = 5;

            var vector = new Vector { 3, 9, 15, 24, 105 };

            Vector result = vector / 3;

            Assert.AreEqual(size, result.Size);

            var elems = new double[] { 1, 3, 5, 8, 35 };
            for (int index = 0; index < elems.Length; index++)
            {
                Assert.AreEqual(elems[index], result[index]);
            }
        }

    }
}
