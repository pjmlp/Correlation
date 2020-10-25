/* FileLoaderTests.cs - Unit tests for data loading.
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
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CorrelationCalculator.Tests
{
    [TestClass]
    public class FileLoaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestInvalidFilename()
        {
            var fileLoader = new FileLoader();
            fileLoader.LoadFile("bad filename", new string[] { "dummy" });
        }

        [TestMethod] 
        [ExpectedException(typeof(ArgumentException))]
        public void TestMissingColumns()
        {
            var fileLoader = new FileLoader();
            fileLoader.LoadFile(@"Data\Data.csv", new string[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(CorruptFileException), "Expected 1 headers, only found 0")]
        public void TestInvalidColumnName()
        {
            var fileLoader = new FileLoader();
            fileLoader.LoadFile(@"Data\Data.csv", new string[] { "InvalidName" });
        }

        [TestMethod]
        public void TestReadFile()
        {
            var expected = new Matrix(2, 20);
            expected.Add(1.407141826,61);
            expected.Add(1.678699943,75);
            expected.Add(1.865219757,26);
            expected.Add(1.966657853,65);
            expected.Add(1.482162958,28);
            expected.Add(1.997403643,39);
            expected.Add(1.706233764,75);
            expected.Add(2.031750757,73);
            expected.Add(1.804367783,72);
            expected.Add(1.975533093,38);
            expected.Add(1.960452406,73);
            expected.Add(1.96944178, 61);
            expected.Add(1.814742934,42);
            expected.Add(1.547514583,26);
            expected.Add(1.712363232,21);
            expected.Add(2.007266849,48);
            expected.Add(1.972604446,47);
            expected.Add(1.511384678,55);
            expected.Add(1.473500875,36);
            expected.Add(2.017409051,37);


            var fileLoader = new FileLoader();
            Matrix values = fileLoader.LoadFile(@"Data\Data.csv", new string[] { "Height", "Age" });

            Assert.AreEqual(expected.Colums, values.Colums);
            Assert.AreEqual(expected.Rows, values.Rows);

            for (int col = 0; col < expected.Colums; col++)
            {
                for (int row = 0; row < expected.Rows; row++)
                {
                    Assert.AreEqual(expected[col, row], values[col, row]);
                }
            }
        }

    }
}
