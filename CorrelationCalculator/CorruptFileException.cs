/* CorruptFileException.cs - Error for when the data files are corrupted.
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
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CorrelationCalculator
{
    /// <summary>
    /// Represents a corrupt measurements file.
    /// </summary>
    [Serializable]
    public class CorruptFileException: Exception
    {
        public CorruptFileException()
        {
        }

        public CorruptFileException(string message, Exception ex) : base(message, ex)
        {
        }

        public CorruptFileException(string message) : base(message)
        {
        }

        protected CorruptFileException(SerializationInfo info, StreamingContext ctx): base(info, ctx)
        {
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
