/* Vector.cs - Set of vector operations for data manipulation
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
using System.Collections;
using System.Collections.Generic;

namespace CorrelationCalculator
{
    /// <summary>
    /// Represents regular math vectors
    /// </summary>
    public class Vector: IEnumerable<double>
    {
        // current implementation, this could eventually be
        // replaced by memory mapped data
        private List<double> data;

        /// <summary>
        /// Creates an empty vector
        /// </summary>
        public Vector()
        {
            data = new List<double>();
        }

        /// <summary>
        /// Creates an empty vector with pre-allocated size.
        /// </summary>
        /// <param name="capacity">Amount of data to pre-allocate</param>
        public Vector(int capacity)
        {
            data = new List<double>(capacity);
        }

        /// <summary>
        /// Initializes the vector, taking ownership of the provided data.
        /// </summary>
        /// <param name="values">Set of values to set the vector to</param>
        public Vector(List<double> values)
        {
            data = values;
        }

        /// <summary>
        /// Appends a new value to the end of the vector data.
        /// </summary>
        public void Add(double value)
        {
            data.Add(value);
        }

        /// <summary>
        /// Implementation of the IEnumerable.GetEnumerator() method
        /// </summary>
        public IEnumerator<double> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        /// <summary>
        /// Implementation of the IEnumerable.GetEnumerator() method
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }


        /// <summary>
        /// Current size of the vector
        /// </summary>
        public int Size => data.Count;

        /// <summary>
        /// Allows indexing into the current set of available data.
        /// </summary>
        public double this[int i]
        {
            get { return data[i]; }
            set { data[i] = value; }
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <returns>An equaly sized vector with the sum of both vectors</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the vectors are not the same size</exception>
        public static Vector operator +(Vector left, Vector right)
        {
            if (left.Size != right.Size)
            {
                throw new ArgumentOutOfRangeException("both vectors must match its size");
            }

            List<double> elems = new List<double>(left.Size);
            for (int index = 0; index < left.Size; index++)
            {
                elems.Add(left[index] + right[index]);
            }

            return new Vector(elems);
        }

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <returns>An equaly sized vector with the sum of both vectors</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the vectors are not the same size</exception>
        public static Vector Add(Vector left, Vector right)
        {
            return left + right;
        }

        /// <summary>
        /// Subtracts two vectors.
        /// </summary>
        /// <returns>An equaly sized vector with the subtraction of both vectors</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the vectors are not the same size</exception>
        public static Vector operator -(Vector left, Vector right)
        {
            if (left.Size != right.Size)
            {
                throw new ArgumentOutOfRangeException("both vectors must match its size");
            }

            List<double> elems = new List<double>(left.Size);
            for (int index = 0; index < left.Size; index++)
            {
                elems.Add(left[index] - right[index]);
            }

            return new Vector(elems);
        }

        /// <summary>
        /// Subtracts two vectors.
        /// </summary>
        /// <returns>An equaly sized vector with the subtraction of both vectors</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the vectors are not the same size</exception>
        public static Vector Subtract (Vector left, Vector right)
        {
            return left - right;
        }

        /// <summary>
        /// Multiples a scalar by all vector elements
        /// </summary>
        /// <returns>An equaly sized vector with the multiplication result</returns>
        public static Vector operator *(Vector vec, double value)
        {
            List<double> elems = new List<double>(vec.Size);
            for (int index = 0; index < vec.Size; index++)
            {
                elems.Add(vec[index] * value);
            }

            return new Vector(elems);
        }

        /// <summary>
        /// Multiples a scalar by all vector elements
        /// </summary>
        /// <returns>An equaly sized vector with the multiplication result</returns>
        public static Vector Multiply(Vector vec, double value)
        {
            return vec * value;
        }

        /// <summary>
        /// Dives all vector elements by a scalar.
        /// </summary>
        /// <returns>An equaly sized vector with the division result</returns>
        public static Vector operator /(Vector vec, double value)
        {
            List<double> elems = new List<double>(vec.Size);
            for (int index = 0; index < vec.Size; index++)
            {
                elems.Add(vec[index] / value);
            }

            return new Vector(elems);
        }

        /// <summary>
        /// Dives all vector elements by a scalar.
        /// </summary>
        /// <returns>An equaly sized vector with the division result</returns>
        public static Vector Divide(Vector vec, double value)
        {
            return vec / value;
        }

    }
}
