/* Matrix.cs - Required set of matrix calculation operations
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
    /// Represents regular math matrixes, implemented in a column-major form.
    /// </summary>
    class Matrix
    {
        // current implementation, this could eventually be
        // replaced by memory mapped data
        private List<Vector> columns;

        /// <summary>
        /// Creates an empty matrix
        /// </summary>
        public Matrix()
        {
            columns = new List<Vector>();
        }

        /// <summary>
        /// Creates an empty matrix with pre-allocated size.
        /// </summary>
        /// <param name="cols">Amount of columns to pre-allocate</param>
        public Matrix(int cols):this(cols, 0)
        {
        }

        /// <summary>
        /// Creates an empty matrix with pre-allocated size.
        /// </summary>
        /// <param name="cols">Amount of columns to pre-allocate</param>
        /// <param name="rows">Amount of rows to pre-allocate</param>
        public Matrix(int cols, int rows)
        {
            columns = new List<Vector>(cols);
            for (int col = 0; col < cols; col++)
            {
                columns.Add(new Vector(rows));
            }
        }


        /// <summary>
        /// Initializes the matrix, taking ownership of the provided data.
        /// </summary>
        /// <param name="values">Set of columns in vector format to set the matrix to</param>
        public Matrix(List<Vector> values)
        {
            columns = values;
        }

        /// <summary>
        /// The current size of available matrix columns
        /// </summary>
        public int Colums => columns.Count;

        /// <summary>
        /// The current size of available matrix rows
       /// </summary>
        public int Rows { get; private set; }


        /// <summary>
        /// Allows single indexing into a specific matrix column.
        /// </summary>
        /// <returns>A specific matrix column</returns>
        public Vector this[int col]
        {
            get { return columns[col]; }
            set { columns[col] = value; }
        }

        /// <summary>
        /// Allows indexing into a specific matrix element in a column, row fashion.
        /// </summary>
        /// <returns>The matrix element data</returns>
        public double this[int col, int row]
        {
            get { return columns[col][row]; }
            set { columns[col][row] = value; }
        }

        /// <summary>
        /// Adds a row of data, appending a new row into the matrix.
        /// </summary>
        /// <param name="values">The set of values to append.</param>
        /// <exception cref="ArgumentException">If the values vector is not the same size as the current set of columns.</exception>
        public void Add(params double[] values)
        {
            if (columns.Count != values.Length)
            {
                throw new ArgumentException("values is not the same width as the matrix", nameof(values));
            }

            for (int index = 0; index < values.Length; index++)
            {
                columns[index].Add(values[index]);
            }

            Rows++;
        }

        /// <summary>
        /// Adds two matrixes.
        /// </summary>
        /// <returns>An equaly sized matrix with the sum of both matrix</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the matrix are not the same size (colums, rows)</exception>
        public static Matrix operator +(Matrix left, Matrix right)
        {
            if (left.Colums != right.Colums || right.Rows != right.Rows)
            {
                throw new ArgumentOutOfRangeException("both matrix must match its size");
            }


            Matrix elems = new Matrix(left.Colums, left.Rows);
            for (int column = 0; column < left.Colums; column++)
            {
                for (int row = 0; row < left.Rows; row++)
                {
                    elems[column, row] = left[column, row] + right[column, row];
                }
            }

            return elems;
        }

        /// <summary>
        /// Subtracts two matrixes.
        /// </summary>
        /// <returns>An equaly sized matrix with the sum of both matrix</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the matrix are not the same size (colums, rows)</exception>
        public static Matrix operator -(Matrix left, Matrix right)
        {
            if (left.Colums != right.Colums || right.Rows != right.Rows)
            {
                throw new ArgumentOutOfRangeException("both matrix must match its size");
            }


            Matrix elems = new Matrix(left.Colums, left.Rows);
            for (int column = 0; column < left.Colums; column++)
            {
                for (int row = 0; row < left.Rows; row++)
                {
                    elems[column, row] = left[column, row] + right[column, row];
                }
            }

            return elems;
        }
    }
}
