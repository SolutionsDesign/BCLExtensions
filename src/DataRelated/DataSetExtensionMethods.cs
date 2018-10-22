//////////////////////////////////////////////////////////////////////
// BCLExtensions is (c) 2010 Solutions Design. All rights reserved.
// http://www.sd.nl
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c) 2010 Solutions Design. All rights reserved.
// 
// The BCLExtensions library sourcecode and its accompanying tools, tests and support code
// are released under the following license: (BSD2)
// ----------------------------------------------------------------------
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met: 
//
// 1) Redistributions of source code must retain the above copyright notice, this list of 
//    conditions and the following disclaimer. 
// 2) Redistributions in binary form must reproduce the above copyright notice, this list of 
//    conditions and the following disclaimer in the documentation and/or other materials 
//    provided with the distribution. 
// 
// THIS SOFTWARE IS PROVIDED BY SOLUTIONS DESIGN ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, 
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL SOLUTIONS DESIGN OR CONTRIBUTORS BE LIABLE FOR 
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR 
// BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
//
// The views and conclusions contained in the software and documentation are those of the authors 
// and should not be interpreted as representing official policies, either expressed or implied, 
// of Solutions Design. 
//
//////////////////////////////////////////////////////////////////////
// Contributers to the code:
//		- Frans Bouma [FB]
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using SD.Tools.BCLExtensions.SystemRelated;

namespace SD.Tools.BCLExtensions.DataRelated
{
	/// <summary>
	/// Class for DataSet related extension methods.
	/// </summary>
	public static class DataSetExtensionMethods
	{
		/// <summary>
		/// Gets the value of the column with the column name specified from the DataRow in the type specified. If the value is DBNull.Value, null / Nothing
		/// will be returned, if TValue is a nullable value type or a reference type, the default value for TValue will be returned otherwise. 
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <param name="row">The row.</param>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>the value of the column specified, or the default value for the type specified if not found.</returns>
		/// <remarks>Use this method instead of Field(Of TValue) if you don't want to receive cast exceptions</remarks>
		public static TValue Value<TValue>(this DataRow row, string columnName)
		{
			TValue toReturn = default(TValue);
			if(!((row == null) || string.IsNullOrEmpty(columnName) || (row.Table == null) || !row.Table.Columns.Contains(columnName)))
			{
				object columnValue = row[columnName];
				if(columnValue != DBNull.Value)
				{
					Type destinationType = typeof(TValue);
					if(typeof(TValue).IsNullableValueType())
					{
						destinationType = destinationType.GetGenericArguments()[0];
					}
					if(columnValue is TValue)
					{
						toReturn = (TValue)columnValue;
					}
					else
					{
						try
						{
							toReturn = (TValue)Convert.ChangeType(columnValue, destinationType);
						}
						catch
						{
							// conversion failed for some reason, not compatible. return null
							toReturn = default(TValue);
						}
					}
				}
			}
			return toReturn;
		}
	}
}
